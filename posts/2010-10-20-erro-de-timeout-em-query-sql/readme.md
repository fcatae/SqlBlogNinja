<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/20/erro-de-timeout-em-query-sql/'>Erro de Timeout em Query SQL</a>
<p>Hoje o pessoal estava reclamando sobre erros de timeout no SQL Server. Qual seria uma forma eficiente de gerar um trace da aplicação/SQL e identificar quem está causando problemas? Uma forma é gerar um Trace com essas informações e abrir usando a query abaixo.</p>  <blockquote>   <pre class="code"><span style="color: blue">SELECT 
    </span>DatabaseName<span style="color: gray">, </span>TextData<span style="color: gray">, 
    </span>StartTime<span style="color: gray">, </span>EndTime<span style="color: gray">, </span>Duration<span style="color: gray">/</span>1000 <span style="color: blue">as </span><span style="color: red">'Duration (ms)'</span><span style="color: gray">, 
    </span>Reads<span style="color: gray">, </span>Writes<span style="color: gray">, </span>CPU<span style="color: gray">, </span>Hostname<span style="color: gray">, </span>LoginName<span style="color: gray">, </span>ApplicationName<span style="color: gray">, 
    </span>SPID
<span style="color: blue">FROM </span><span style="color: gray">::</span><span style="color: green">fn_trace_gettable</span><span style="color: gray">(</span><span style="color: red">'C:\QueryTimeout.trc'</span><span style="color: gray">,</span>1<span style="color: gray">)
    </span><span style="color: blue">WHERE </span>EventClass <span style="color: gray">in (</span>10<span style="color: gray">,</span>12<span style="color: gray">)
</span></pre>
</blockquote>

<p>Uma lista dos comandos cancelados fica registrado em um arquivo de Trace chamado “QueryTimeout.TRC”. </p>

<p><a href="images\6327.image_5A1C0DF3.png"><img style="border-right-width: 0px;padding-left: 0px;padding-right: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px;padding-top: 0px" title="image" border="0" alt="image" src="images\8233.image_thumb_701253B8.png" width="635" height="156" /></a></p>

<p>Observe que a coluna de <strong>Duration</strong> apresenta valores próximos aos 30 segundos de timeout (30000 milissegundos). Para gerar esse Trace, utilize os scripts de START e STOP que seguem abaixo. </p>

<p>&#160;</p>

<p><strong>Instruções:</strong></p>

<ul>
  <li>Copie o script de START para capturar os comandos que foram cancelados por TIMEOUT, substituindo os parâmetros de MAXFILESIZE e FILENAME por valores adequados ao seu ambiente. Rode o script no servidor. </li>

  <li>Para finalizar a captura de dados, rode o script de STOP, substituindo o parâmetro FILENAME pelo nome do arquivo de Trace correspondente. </li>
</ul>

<p>&#160;</p>

<p><strong>START: Script para capturar o QueryTimeout</strong></p>

<table border="0" cellspacing="0" cellpadding="2" width="100%"><tbody>
    <tr>
      <td valign="top" width="100%"><font size="2">
          <pre>------------------------------------------------------
-- SQL Server 2005/2008                             --
------------------------------------------------------
declare @rc int
declare @TraceID int
declare @maxfilesize bigint
declare @filename nvarchar(512)
declare @intfilter int
declare @bigintfilter bigint

------------------------------------------------------
-- PARAMETROS
--   @maxfilesize = Tamanho do arquivo (MB)
--   @filename = Nome do arquivo (omitir extensão .TRC)
------------------------------------------------------
set @maxfilesize = 100 
set @filename = N'C:\QueryTimeout'
------------------------------------------------------

-- Criacao do trace
exec @rc = sp_trace_create @TraceID output, 0, @filename, @maxfilesize, NULL 
if (@rc != 0) goto error

-- Define os eventos/colunas a serem coletados
--  Evento: 10 = RPC:Completed
--  Evento: 12 = SQL:BatchCompleted
declare @on bit
set @on = 1
exec sp_trace_setevent @TraceID, 10, 7, @on
exec sp_trace_setevent @TraceID, 10, 15, @on
exec sp_trace_setevent @TraceID, 10, 31, @on
exec sp_trace_setevent @TraceID, 10, 8, @on
exec sp_trace_setevent @TraceID, 10, 16, @on
exec sp_trace_setevent @TraceID, 10, 48, @on
exec sp_trace_setevent @TraceID, 10, 64, @on
exec sp_trace_setevent @TraceID, 10, 1, @on
exec sp_trace_setevent @TraceID, 10, 9, @on
exec sp_trace_setevent @TraceID, 10, 17, @on
exec sp_trace_setevent @TraceID, 10, 25, @on
exec sp_trace_setevent @TraceID, 10, 41, @on
exec sp_trace_setevent @TraceID, 10, 49, @on
exec sp_trace_setevent @TraceID, 10, 2, @on
exec sp_trace_setevent @TraceID, 10, 10, @on
exec sp_trace_setevent @TraceID, 10, 18, @on
exec sp_trace_setevent @TraceID, 10, 26, @on
exec sp_trace_setevent @TraceID, 10, 34, @on
exec sp_trace_setevent @TraceID, 10, 50, @on
exec sp_trace_setevent @TraceID, 10, 66, @on
exec sp_trace_setevent @TraceID, 10, 3, @on
exec sp_trace_setevent @TraceID, 10, 11, @on
exec sp_trace_setevent @TraceID, 10, 35, @on
exec sp_trace_setevent @TraceID, 10, 51, @on
exec sp_trace_setevent @TraceID, 10, 4, @on
exec sp_trace_setevent @TraceID, 10, 12, @on
exec sp_trace_setevent @TraceID, 10, 60, @on
exec sp_trace_setevent @TraceID, 10, 13, @on
exec sp_trace_setevent @TraceID, 10, 6, @on
exec sp_trace_setevent @TraceID, 10, 14, @on
exec sp_trace_setevent @TraceID, 12, 7, @on
exec sp_trace_setevent @TraceID, 12, 15, @on
exec sp_trace_setevent @TraceID, 12, 31, @on
exec sp_trace_setevent @TraceID, 12, 8, @on
exec sp_trace_setevent @TraceID, 12, 16, @on
exec sp_trace_setevent @TraceID, 12, 48, @on
exec sp_trace_setevent @TraceID, 12, 64, @on
exec sp_trace_setevent @TraceID, 12, 1, @on
exec sp_trace_setevent @TraceID, 12, 9, @on
exec sp_trace_setevent @TraceID, 12, 17, @on
exec sp_trace_setevent @TraceID, 12, 41, @on
exec sp_trace_setevent @TraceID, 12, 49, @on
exec sp_trace_setevent @TraceID, 12, 6, @on
exec sp_trace_setevent @TraceID, 12, 10, @on
exec sp_trace_setevent @TraceID, 12, 14, @on
exec sp_trace_setevent @TraceID, 12, 18, @on
exec sp_trace_setevent @TraceID, 12, 26, @on
exec sp_trace_setevent @TraceID, 12, 50, @on
exec sp_trace_setevent @TraceID, 12, 66, @on
exec sp_trace_setevent @TraceID, 12, 3, @on
exec sp_trace_setevent @TraceID, 12, 11, @on
exec sp_trace_setevent @TraceID, 12, 35, @on
exec sp_trace_setevent @TraceID, 12, 51, @on
exec sp_trace_setevent @TraceID, 12, 4, @on
exec sp_trace_setevent @TraceID, 12, 12, @on
exec sp_trace_setevent @TraceID, 12, 60, @on
exec sp_trace_setevent @TraceID, 12, 13, @on

-- Configura o filtro
--   Filter: Column Duration &gt; 500 (ms) 
--   Filter: Column ERROR = 2 (ABORT)
set @bigintfilter = 500000
exec sp_trace_setfilter @TraceID, 13, 0, 4, @bigintfilter

set @intfilter = 2
exec sp_trace_setfilter @TraceID, 31, 0, 0, @intfilter

------------------------------------------------------
-- START: Inicia a coleta de eventos
------------------------------------------------------
exec sp_trace_setstatus @TraceID, 1

------------------------------------------------------
-- FIM
------------------------------------------------------
error: 
-- select ErrorCode=@rc
finish: 
select * from sys.traces where id = @TraceID
------------------------------------------------------&#160; </pre>
        </font></td>
    </tr>
  </tbody></table>

<p>&#160;</p>

<p><strong>STOP: Script para finalizar o trace</strong></p>

<table border="0" cellspacing="0" cellpadding="2"><tbody>
    <tr>
      <td valign="top"><font size="2">
          <pre>------------------------------------------------------
-- STOP: Trace
------------------------------------------------------
declare @TraceID int
declare @filename nvarchar(512)

------------------------------------------------------
-- PARAMETROS
--  @filename = Nome do arquivo do Trace (.TRC)
------------------------------------------------------
set @filename = N'C:\QueryTimeout.trc'

select @TraceID = id from sys.traces where path = @filename 

if @TraceID is NULL
BEGIN
	PRINT 'Trace nao encontrado. Path=' + @filename
	goto finish
END

exec sp_trace_setstatus @TraceID, 0
exec sp_trace_setstatus @TraceID, 2

select * from sys.traces where path is not null

finish:&#160; </pre>
        </font></td>
    </tr>
  </tbody></table>
