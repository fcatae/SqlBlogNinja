<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/12/coleta-de-dados-no-sql-2008script-1/'>Coleta de dados no SQL 2008–Script 1</a>
<p>A primeira parte do script de coleta de dados para diagn&oacute;stico de performance est&aacute; apresentado nesse artigo. </p>
<p style="padding-left: 30px"><strong>Links Relacionados</strong></p>
<ul>
<li>Blocker Script original: <a href="http://support.microsoft.com/kb/271509/en-us">sp_blocker_pss80</a></li>
<li>Vers&atilde;o SQL2000: <a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/07/lab-sql-blocker-script-2000-performance-lock-e-bloqueios.aspx">Blocker&nbsp;Modificado</a></li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-1.aspx">Coleta de dados no SQL 2008&ndash;Script 1</a>&nbsp;</li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-2.aspx">Coleta de dados no SQL 2008&ndash;Script 2</a></li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-3.aspx">Coleta de dados no SQL 2008&ndash;Script 3</a></li>
<li>Vers&atilde;o final: <a href="http://blogs.msdn.com/b/fcatae/p/monitorsql.aspx">Monitor SQL (Vers&atilde;o atualizada do Blocker Script)</a></li>
</ul>
<p>&nbsp;</p>
<h2>Introdu&ccedil;&atilde;o</h2>
<p>O <a target="_blank" href="http://blogs.msdn.com/b/fcatae/archive/2010/10/07/lab-sql-blocker-script-2000-performance-lock-e-bloqueios.aspx">blocker script (vers&atilde;o modificada)</a> &eacute; utilizado para coletar informa&ccedil;&otilde;es que auxiliam no diagn&oacute;stico de performance SQL Server 2000. Apesar desse script ser compat&iacute;vel com o SQL Server 2005 e 2008, ele ainda depende de tabelas e views obsoletas como a <a target="_blank" href="http://msdn.microsoft.com/en-us/library/ms179881.aspx">sysprocesses</a>. Por isso, &eacute; importante atualizar o blocker script de forma a adotar as novas DMV e DMF de sistema.</p>
<p>&nbsp;</p>
<h2>Script &ndash; Parte I</h2>
<p>O objetivo do script (PARTE 1) &eacute; coletar informa&ccedil;&otilde;es de car&aacute;ter praticamente est&aacute;tico, que inclui informa&ccedil;&otilde;es relacionadas a:</p>
<ul>
<li>M&aacute;quina (Nome virtual, nome f&iacute;sico, ProcessID do SQL Server) </li>
<li>Inst&acirc;ncia SQL Server (Vers&atilde;o do produto, Service Pack aplicado, Collation) </li>
<li>Configura&ccedil;&otilde;es (sys.configuration ou sp_configure) </li>
<li>Bancos de dados (sys.databases e master_files) </li>
</ul>
<p>Infelizmente, o c&oacute;digo do script ainda <strong>n&atilde;o foi finalizado</strong>, mas decidi postar no blog para a curiosidade do pessoal.</p>
<div id="codeSnippetWrapper" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 20px 0px 10px;width: 97.5%;font-family: 'Courier New', courier, monospace;direction: ltr;font-size: 8pt;overflow: auto;cursor: text;border: silver 1px solid;padding: 4px">
<pre id="codeSnippet" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 0em;width: 100%;font-family: 'Courier New', courier, monospace;direction: ltr;color: black;font-size: 8pt;overflow: visible;border-style: none;padding: 0px">CREATE PROCEDURE #spBlockerPfe_0
AS

SET NOCOUNT ON

DECLARE @time DATETIME

SET @time = GETDATE()
PRINT ''
PRINT 'MACHINE INFORMATION'

PRINT ''
PRINT 'ServerName: ' + @@SERVERNAME
PRINT 'PhysicalName: ' + CAST(SERVERPROPERTY('ComputerNamePhysicalNetBIOS') AS VARCHAR)
PRINT 'ProductVersion: ' + CAST(SERVERPROPERTY('ProductVersion') AS VARCHAR)
PRINT 'ProductLevel: ' + CAST(SERVERPROPERTY('ProductLevel') AS VARCHAR)
PRINT 'ResourceVersion: ' + CAST(SERVERPROPERTY('ResourceVersion') AS VARCHAR)
PRINT 'ResourceLastUpdateDateTime: ' + CAST(SERVERPROPERTY('ResourceLastUpdateDateTime') AS VARCHAR)
PRINT 'Edition: ' + CAST(SERVERPROPERTY('Edition') AS VARCHAR)
PRINT 'ProcessId: ' + CAST(SERVERPROPERTY('ProcessId') AS VARCHAR)
PRINT 'SessionId: ' + CAST(@@SPID AS VARCHAR)
PRINT 'Collation: ' + CAST(SERVERPROPERTY('Collation') AS VARCHAR(32))

PRINT @@version
PRINT ''
PRINT 'EXEC xp_msver'
PRINT ''
EXEC xp_msver

PRINT 'SELECT sys.configurations'
PRINT ''
SELECT name, value, value_in_use FROM sys.configurations

PRINT 'INFO ' + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
	
SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.databases'
-- VIEW ANY DATABASE
SELECT 
d.name, d.database_id, d.source_database_id, d.owner_sid, d.create_date, d.compatibility_level, d.collation_name, d.user_access, d.user_access_desc, d.is_read_only, d.is_auto_close_on, d.is_auto_shrink_on, d.state, d.state_desc, d.is_in_standby, d.is_cleanly_shutdown, d.is_supplemental_logging_enabled, d.snapshot_isolation_state, d.snapshot_isolation_state_desc, d.is_read_committed_snapshot_on, d.recovery_model, d.recovery_model_desc, d.page_verify_option, d.page_verify_option_desc, d.is_auto_create_stats_on, d.is_auto_update_stats_on, d.is_auto_update_stats_async_on, d.is_ansi_null_default_on, d.is_ansi_nulls_on, d.is_ansi_padding_on, d.is_ansi_warnings_on, d.is_arithabort_on, d.is_concat_null_yields_null_on, d.is_numeric_roundabort_on, d.is_quoted_identifier_on, d.is_recursive_triggers_on, d.is_cursor_close_on_commit_on, d.is_local_cursor_default, d.is_fulltext_enabled, d.is_trustworthy_on, d.is_db_chaining_on, d.is_parameterization_forced, d.is_master_key_encrypted_by_server, d.is_published, d.is_subscribed, d.is_merge_published, d.is_distributor, d.is_sync_with_backup, d.service_broker_guid, d.is_broker_enabled, d.log_reuse_wait, d.log_reuse_wait_desc, d.is_date_correlation_on, d.is_cdc_enabled, d.is_encrypted, d.is_honor_broker_priority_on
FROM sys.databases d

PRINT 'BLOCKER_PFE_END sys.databases '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.master_files'
-- VIEW ANY DEFINITION
SELECT * FROM sys.master_files
PRINT 'BLOCKER_PFE_END sys.master_files '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN CleanStats'
-- ALTER SERVER STATE
DBCC SQLPERF('sys.dm_os_wait_stats', CLEAR)
DBCC SQLPERF('sys.dm_os_latch_stats', CLEAR)
PRINT 'BLOCKER_PFE_END CleanStats '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
GO


SELECT * from sys.dm_os_sys_info</pre>
<br /></div>
<p>&nbsp;</p>
<p>Fiquem &agrave; vontade para usar os coment&aacute;rios para dar sugest&otilde;es ou comentar modifica&ccedil;&otilde;es, assim como para fazer as perguntas relacionadas ao funcionamento dele.</p>
