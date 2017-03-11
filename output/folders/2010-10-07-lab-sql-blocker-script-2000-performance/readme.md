<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/07/lab-sql-blocker-script-2000-performance/'>LAB: SQL Blocker Script 2000 (Performance)</a>
<p><strong>Blocker Script</strong> &eacute; uma stored procedure escrita por um engenheiro de suporte (MikeZ), sendo muito utilizado para coletar dados relacionados a bloqueios. Esse script est&aacute; dispon&iacute;vel atrav&eacute;s do artigo KB 271509.</p>
<blockquote>
<p>How to monitor blocking in SQL Server 2005 and in SQL Server 2000 <br /><a href="http://support.microsoft.com/kb/271509/en-us" title="http://support.microsoft.com/kb/271509/en-us">http://support.microsoft.com/kb/271509/en-us</a></p>
</blockquote>
<p>Esse script tem anos de exist&ecirc;ncia e seu c&oacute;digo continua praticamente o mesmo. Um dos (poucos) problemas &eacute; a impossibilidade de identificar queries causando alto consumo de CPU, sendo necess&aacute;rio adotar uma ferramenta adicional como o SQL Profiler. Pensando nisso, fiz algumas altera&ccedil;&otilde;es que auxiliam no diagn&oacute;stico de performance coletando menos informa&ccedil;&atilde;o. J&aacute; faz 5 anos que tenho usado essa vers&atilde;o modificada do Blocker script para avaliar a performance de servidores SQL Server.</p>
<p>&nbsp;</p>
<h2>Como coletar informa&ccedil;&otilde;es de performance?</h2>
<p>1) Crie a stored procedure <strong>sp_blocker_pfe_auto </strong>usando o script abaixo. </p>
<div id="codeSnippetWrapper" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 20px 0px 10px;width: 97.5%;font-family: 'Courier New', courier, monospace;direction: ltr;max-height: 200px;font-size: 8pt;overflow: auto;cursor: text;border: silver 1px solid;padding: 4px">
<pre id="codeSnippet" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 0em;width: 100%;font-family: 'Courier New', courier, monospace;direction: ltr;color: black;font-size: 8pt;overflow: visible;border-style: none;padding: 0px">USE MASTER
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID('dbo.fn_blocker_pfe_sql_text'))
   DROP FUNCTION dbo.fn_blocker_pfe_sql_text

GO
---------------------------------------------------------------------------------------
-- Procedure: dbo.fn_blocker_pfe_sql_text 
---------------------------------------------------------------------------------------
CREATE FUNCTION dbo.fn_blocker_pfe_sql_text(@sql_handle BINARY(20), @stmt_start INT, @stmt_end INT, @length INT)
RETURNS VARCHAR(8000)
AS
BEGIN

    DECLARE @text VARCHAR(8000)
    DECLARE @len INT

    IF @stmt_end &gt; 0 
    BEGIN
       SET @len = (@stmt_end - @stmt_start)/2
       IF @len &lt; @length 
          SET @length = @len       
    END
 
    SELECT @text = SUBSTRING(text, @stmt_start/2, @length) FROM ::fn_get_sql(@sql_handle)

    RETURN @text

end

GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID('dbo.sp_blocker_pfe80') )
   DROP PROCEDURE dbo.sp_blocker_pfe80
GO
---------------------------------------------------------------------------------------
-- Procedure: dbo.sp_blocker_pfe 
---------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_blocker_pfe80 (
    @info bit = 0, 
    @process bit = 0, 
    @process2 bit = 0, 
    @lock bit = 0, 
    @waitstat bit = 0, 
    @inputbuffer bit = 0,
    @sqlhandle bit = 0,
    @sqlhandle_collect bit = 0,
    @sqlhandle_flush bit = 0,
    @opentran bit = 0,
    @logspace bit = 0,
    @memstatus bit = 0,
    @perfinfo bit = 0,
    @trace bit = 0,
    @textsize int = 256
    )
AS 

SET NOCOUNT ON
SET LANGUAGE 'us_english'

DECLARE @spid VARCHAR(6)
DECLARE @blocked VARCHAR(6)
DECLARE @time DATETIME
DECLARE @time2 DATETIME
DECLARE @dbname nVARCHAR(128)
DECLARE @status SQL_VARIANT
DECLARE @useraccess SQL_VARIANT
DECLARE @perfobjname NVARCHAR(256)

IF is_member('sysadmin')=0 
BEGIN
  PRINT 'Must be a member of the sysadmin group in order to run this procedure'
  return
END

SET @time = getdate()

DECLARE @probclients 
    TABLE (
        spid        SMALLINT, 
        ecid        SMALLINT, 
        blocked        SMALLINT, 
        waittype    BINARY(2), 
        dbid        SMALLINT, 
        sql_handle    BINARY(20), 
        stmt_start    INT, 
        stmt_end    INT, 
        PRIMARY KEY (spid, ecid))

INSERT @probclients 
    SELECT spid, ecid, blocked, waittype, dbid, sql_handle, stmt_start, stmt_end
    FROM master.dbo.sysprocesses 
    WHERE 
            (
            kpid&lt;&gt;0 OR 
            waittype&lt;&gt;0x0000 OR 
            open_tran&lt;&gt;0 OR 
            spid IN (SELECT blocked FROM master.dbo.sysprocesses)
            ) AND spid&gt;50

---------------------------------------------------------------------------------------
-- 8.2 Start time: 
---------------------------------------------------------------------------------------
SET @time2 = GETDATE()
PRINT ''
PRINT '8.3 Start time: ' + CONVERT(VARCHAR(26), @time, 121) + ' ' + CONVERT(VARCHAR(12), datediff(ms,@time,@time2))

---------------------------------------------------------------------------------------
-- Static Configuration
---------------------------------------------------------------------------------------
IF @info = 1 
BEGIN
    SET @time2 = GETDATE()
    PRINT ''
    PRINT 'MACHINE INFORMATION'

    PRINT ''
    PRINT 'ServerName: ' + @@SERVERNAME
    PRINT 'PhysicalName: ' + CAST(SERVERPROPERTY('ComputerNamePhysicalNetBIOS') AS VARCHAR)
    PRINT 'ProductVersion: ' + CAST(SERVERPROPERTY('ProductVersion') AS VARCHAR)
    PRINT 'ProductLevel: ' + CAST(SERVERPROPERTY('ProductLevel') AS VARCHAR)
    PRINT 'Edition: ' + CAST(SERVERPROPERTY('Edition') AS VARCHAR)
    PRINT 'ProcessId: ' + CAST(SERVERPROPERTY('ProcessId') AS VARCHAR)
    PRINT 'SessionId: ' + CAST(@@SPID AS VARCHAR)
    PRINT ''
    PRINT @@version
    PRINT ''
    PRINT 'EXEC xp_msver'
    PRINT ''
    EXEC xp_msver

    PRINT 'SELECT sysconfigures'
    PRINT ''
    SELECT value, comment FROM sysconfigures

    PRINT 'INFO ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- Connections 
---------------------------------------------------------------------------------------
IF @process = 1 
BEGIN
    SET @time2 = GETDATE()
    PRINT ''
    PRINT 'SYSPROCESSES' 

    SELECT spid, status, blocked, open_tran, 
        waitresource, waittype, waittime, cmd, lastwaittype, 
        cpu, physical_io,memusage, 
        last_batch=convert(VARCHAR(26), last_batch,121),
        login_time=convert(VARCHAR(26), login_time,121),
        net_address,net_library, 
        dbid, ecid, kpid, hostname, hostprocess, loginame, program_name, 
        nt_domain, nt_username, uid, sid,
        sql_handle, stmt_start, stmt_end
    FROM master.dbo.sysprocesses
    WHERE 
        spid IN (SELECT spid FROM @probclients)

    PRINT 'ESP ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- Connections2 
---------------------------------------------------------------------------------------
IF @process2 = 1 
BEGIN
    SET @time2 = GETDATE()
    PRINT ''
    PRINT 'SYSPROCESSES2' 

    SELECT spid, status, blocked, open_tran, 
        waitresource, waittype, waittime, cmd, lastwaittype, 
        cpu, physical_io,memusage, 
        last_batch=convert(VARCHAR(26), last_batch,121),
        login_time=convert(VARCHAR(26), login_time,121),
        net_address,net_library, 
        dbid, ecid, kpid, hostname, hostprocess, loginame, program_name, 
        nt_domain, nt_username, uid, sid,
        sql_handle, stmt_start, stmt_end
    FROM master.dbo.sysprocesses
    WHERE 
        (kpid&lt;&gt;0 OR waittype&lt;&gt;0x0000 OR open_tran&lt;&gt;0) AND (spid&gt;50)

    PRINT 'ESP2 ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END
---------------------------------------------------------------------------------------
-- SYSLOCKINFO 
---------------------------------------------------------------------------------------
IF @lock = 1 
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'SYSLOCKINFO'

	SELECT CONVERT (smallint, req_spid) AS spid,
		rsc_dbid AS dbid,
		rsc_objid AS ObjId,
		rsc_indid AS IndId,
		SUBSTRING (v.name, 1, 4) AS Type,
		SUBSTRING (rsc_text, 1, 32) as Resource,
		SUBSTRING (u.name, 1, 8) AS Mode,
		SUBSTRING (x.name, 1, 5) AS Status
	FROM 	
		master.dbo.syslockinfo l inner join master.dbo.spt_values v on (l.rsc_type = v.number and v.type = 'LR')
								 inner join master.dbo.spt_values x on (l.req_status = x.number and x.type = 'LS')
								 inner join master.dbo.spt_values u on (l.req_mode + 1 = u.number and u.type = 'L')
	WHERE l.rsc_type = 5 


    PRINT 'ESL ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- DBCC SQLPERF(WAITSTATS)
---------------------------------------------------------------------------------------
IF @waitstat = 1 
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'DBCC SQLPERF(WAITSTATS)'

    DBCC SQLPERF(WAITSTATS)

    PRINT 'DBCCWAIT ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- DBCC INPUTBUFFER
---------------------------------------------------------------------------------------
IF @inputbuffer = 1
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'DBCC INPUTBUFFER(*)'

    DECLARE ibuffer CURSOR FAST_FORWARD FOR
        SELECT DISTINCT CAST (spid AS VARCHAR(6)) AS spid
        FROM @probclients
        WHERE (spid &lt;&gt; @@spid) 

    OPEN ibuffer
    FETCH NEXT FROM ibuffer INTO @spid
        
    WHILE (@@FETCH_STATUS &lt;&gt; -1)
    BEGIN
        PRINT ''
        PRINT 'DBCC INPUTBUFFER FOR SPID ' + @spid
        EXEC ('DBCC INPUTBUFFER (' + @spid + ')')

        FETCH NEXT FROM ibuffer INTO @spid
    END
    DEALLOCATE IBUFFER

    PRINT 'DBCCINPUTBUFFER(*) END ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- SQLHANDLE
---------------------------------------------------------------------------------------
IF @sqlhandle = 1
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'SQLHANDLE'

    SELECT 
        sql_handle, stmt_start, stmt_end,
        total = count(*), 
        text = cast(dbo.fn_blocker_pfe_sql_text(sql_handle, stmt_start, stmt_end, @textsize) as VARCHAR(1024))
    FROM @probclients WHERE ecid = 0 and spid&lt;&gt;@@spid
    GROUP BY sql_handle, stmt_start, stmt_end
    ORDER BY count(*) DESC

    PRINT 'ESH HANDLE 0x0000000000000000000000000000000000000000 ' + convert(VARCHAR(12), datediff(ms,@time2,getdate())) 
END

---------------------------------------------------------------------------------------
-- DBCC OPENTRAN
---------------------------------------------------------------------------------------
IF @opentran = 1 
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'DBCC OPENTRAN(*)'
    DECLARE ibuffer CURSOR FAST_FORWARD FOR
        SELECT DISTINCT CAST (dbid AS VARCHAR(6)) FROM @probclients
        WHERE dbid &lt;&gt; 0
        UNION SELECT '2'

    OPEN ibuffer
    FETCH NEXT FROM ibuffer INTO @spid

    WHILE (@@FETCH_STATUS &lt;&gt; -1)
    BEGIN
        PRINT ''
        SET @dbname = DB_NAME(@spid)
        SET @status = DATABASEPROPERTYEX(@dbname,'Status')
        SET @useraccess = DATABASEPROPERTYEX(@dbname,'UserAccess')

        PRINT 'DBCC OPENTRAN FOR DBID ' + @spid + ' ['+ @dbname + ']'

        IF @status = N'ONLINE' and @useraccess = N'SINGLE_USER'
            PRINT 'Skipped: Status=ONLINE UserAccess=SINGLE_USER'
        ELSE
            DBCC OPENTRAN(@dbname)
        
        FETCH NEXT FROM ibuffer INTO @spid

    END

    DEALLOCATE ibuffer

    PRINT 'DBCCOPENTRAN(*) END ' + convert(VARCHAR(12), datediff(ms,@time2,getdate()))
END

---------------------------------------------------------------------------------------
-- DBCC MEMORYSTATUS
---------------------------------------------------------------------------------------
IF @memstatus = 1
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'DBCC MEMORYSTATUS'

    DBCC MEMORYSTATUS

    PRINT 'MEMSTATUS ' + convert(VARCHAR(12), datediff(ms,@time2,getdate()))
END

---------------------------------------------------------------------------------------
-- DBCC SQLPERF(LOGSPACE)
---------------------------------------------------------------------------------------
IF @logspace = 1
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'DBCC SQLPERF(LOGSPACE)'

    DBCC SQLPERF(LOGSPACE)

    PRINT 'DBCCLOG ' + convert(VARCHAR(12), datediff(ms,@time2,getdate()))
END

---------------------------------------------------------------------------------------
-- Sysperfinfo
---------------------------------------------------------------------------------------
IF @perfinfo = 1
BEGIN

    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'SYSPERFINFO'
    
    SELECT TOP 1 @perfobjname=LEFT(object_name, CHARINDEX(N':',object_name)) FROM sysperfinfo
    SELECT object_name, counter_name, cntr_value FROM sysperfinfo
    WHERE 
        object_name IN (@perfobjname + N'Buffer Manager',
                        @perfobjname + N'Databases',
                        @perfobjname + N'General Statistics',
                        @perfobjname + N'Memory Manager',
                        @perfobjname + N'SQL Statistics') 

    PRINT 'PERFINFO ' + convert(VARCHAR(12), datediff(ms,@time2,getdate()))

END

---------------------------------------------------------------------------------------
-- ::fn_trace_getinfo
---------------------------------------------------------------------------------------
IF @trace = 1
BEGIN
    SELECT @time2 = GETDATE()
    PRINT ''
    PRINT 'TRACE_GETINFO'

    SELECT * FROM ::fn_trace_getinfo(0)

    PRINT 'TRCINF ' + convert(VARCHAR(12), datediff(ms,@time2,getdate()))
END

---------------------------------------------------------------------------------------
-- End time
---------------------------------------------------------------------------------------
PRINT ''
PRINT 'End time: ' + convert(varchar(26), getdate(), 121)
   
GO    

IF EXISTS (SELECT * FROM sysobjects WHERE id = OBJECT_ID('dbo.sp_blocker_pfe_auto') )
   DROP PROCEDURE dbo.sp_blocker_pfe_auto
GO
---------------------------------------------------------------------------------------
-- Procedure: dbo.sp_blocker_pfe_auto
---------------------------------------------------------------------------------------
CREATE PROCEDURE dbo.sp_blocker_pfe_auto
AS

SET NOCOUNT ON

EXEC dbo.sp_blocker_pfe80 @info = 1, @trace = 1

WHILE 1=1
BEGIN

    EXEC dbo.sp_blocker_pfe80 @process2 = 1, @inputbuffer = 1, @sqlhandle = 1
    RAISERROR('',0,1) WITH NOWAIT
    WAITFOR DELAY '0:0:15'

    EXEC dbo.sp_blocker_pfe80 @process2 = 1, @inputbuffer = 1, @sqlhandle = 1
    RAISERROR('',0,1) WITH NOWAIT
    WAITFOR DELAY '0:0:15'

    EXEC dbo.sp_blocker_pfe80 @process2 = 1, @inputbuffer = 1, @sqlhandle = 1
    RAISERROR('',0,1) WITH NOWAIT
    WAITFOR DELAY '0:0:15'

    EXEC dbo.sp_blocker_pfe80 
            @process2 = 1, @inputbuffer = 1, @sqlhandle = 1,
            @waitstat = 1, @lock = 1, @opentran = 1
    RAISERROR('',0,1) WITH NOWAIT
    WAITFOR DELAY '0:0:15'
    
END
</pre>
<br /></div>
<p>Esse script cria os seguintes scripts no banco de dados MASTER: <strong><em>fn_blocker_pfe_sql_text</em></strong>, <strong><em>sp_blocker_pfe80</em></strong>, <strong><em>sp_blocker_pfe_auto</em></strong>. Ap&oacute;s criado esses objetos, n&atilde;o &eacute; necess&aacute;rio rodar o script novamente.</p>
<p>&nbsp;</p>
<p>2) Execute a stored procedure <strong>sp_blocker_pfe_auto </strong>usando um usu&aacute;rio com privil&eacute;gios de <strong>SysAdmin</strong> para coletar informa&ccedil;&otilde;es do servidor SQL. Esse script fica executando infinitamente e pode ser cancelado ap&oacute;s obter as informa&ccedil;&otilde;es necess&aacute;rias.</p>
<blockquote>
<p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/3823.image_50D9BA18.png"><img height="354" width="436" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/4812.image_thumb_73019FD1.png" alt="SQL sp_blocker_pfe_auto" border="0" title="sp_blocker_pfe_auto" style="border-right-width: 0px;padding-left: 0px;padding-right: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px;padding-top: 0px" /></a></p>
</blockquote>
<p>&nbsp;</p>
<p>3) &Eacute; poss&iacute;vel coletar as informa&ccedil;&otilde;es do Blocker Script usando a linha de comando</p>
<blockquote>
<p><span style="font-family: Courier New;font-size: x-small">osql -S <span style="color: #ff0000">SERVIDOR\INSTANCIA</span> -o <span style="color: #ff0000">arquivo_saida.out</span> -E -Q "sp_blocker_pfe_auto" -w2000</span></p>
</blockquote>
<blockquote>
<p><strong>Aten&ccedil;&atilde;o: N&atilde;o esque&ccedil;a de alterar o nome do servidor&nbsp; inst&acirc;ncia SQL Server (SERVIDOR\INSTANCIA) e do arquivo de sa&iacute;da. </strong></p>
</blockquote>
<p>No meu caso, a linha de comando ficou assim: </p>
<blockquote>
<p><span style="font-family: Courier New;font-size: x-small">osql -S fcatae-11\katmai &ndash;o blocker2010-10-07.out -E -Q "sp_blocker_pfe_auto" -w2000</span></p>
</blockquote>
<p>Ap&oacute;s 30 minutos de coleta de dados, apertei Control-C para finalizar o script. Na minha m&aacute;quina, foi gerado o arquivo <strong>blocker2010-10-07.out</strong>&nbsp; com 5MB. O tamanho do arquivo varia conforme a carga no servidor, mas &eacute; razo&aacute;vel estimar arquivos de 300MB para uma monitora&ccedil;&atilde;o de 8 horas.</p>
<p>&nbsp;</p>
<h2>Exemplo</h2>
<p>Em uma situa&ccedil;&atilde;o de bloqueio, identificamos que o SPID 56 est&aacute; bloqueando a sess&atilde;o 57. O recurso envolvido &eacute; a tabela identificada por 5:2105058535 (dbid:objid).</p>
<blockquote>
<p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/2352.image_538F493E.png"><img height="307" width="501" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/7120.image_thumb_7FCBD022.png" alt="sql blocker result" border="0" title="SQL Blocker Result" style="border-right-width: 0px;padding-left: 0px;padding-right: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px;padding-top: 0px" /></a></p>
</blockquote>
<p>&nbsp;</p>
<h2>Pr&oacute;ximos Passos</h2>
<ol>
<li>Esse script funciona desde o SQL Server 2000. J&aacute; est&aacute; na hora de atualizar para SQL 2008, usando as novas Views de sistema. </li>
<li>As t&eacute;cnicas para analisar o resultado precisam ser documentadas. Quase todos os problemas (alta CPU, conten&ccedil;&atilde;o de disco, TempDb, bloqueios) podem ser identificados com o aux&iacute;lio desse script. </li>
</ol>
<p>&nbsp;</p>
<p>Essa semana estou reescrevendo a stored procedure para usar as novas funcionalidades do SQL 2008 e, em breve, disponibilizarei um tutorial sobre como analisar o arquivo de sa&iacute;da (falta tempo para fazer tudo isso). Essa &eacute; uma das principais ferramentas para diagn&oacute;stico de performance. </p>
<p style="padding-left: 30px"><strong>Links Relacionados</strong></p>
<ul>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-1.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 1</span></a>&nbsp;</li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-2.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 2</span></a></li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-3.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 3</span></a></li>
<li>Vers&atilde;o final: <a href="http://blogs.msdn.com/b/fcatae/p/monitorsql.aspx"><span style="color: #0066dd">Monitor SQL (Vers&atilde;o atualizada do Blocker Script)</span></a></li>
</ul>
<p>Gostaria de convidar a todos que deixem seus coment&aacute;rios sobre o assunto &ndash; sugest&otilde;es, id&eacute;ias, dicas, etc. </p>
