<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/12/coleta-de-dados-no-sql-2008script-2/'>Coleta de dados no SQL 2008–Script 2</a>
<p>A segunda parte do script de coleta de dados para diagn&oacute;stico de performance est&aacute; apresentado nesse artigo. Aqui, os dados ser&atilde;o coletados em intervalos de 5 a 15 segundos. Esse &eacute; o cora&ccedil;&atilde;o do blocker script e corresponde a um ponto muito delicado, porque a coleta &eacute; realizada frequentemente sem impacto de performance. </p>
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
<h2>Script &ndash; Parte II</h2>
<p>O objetivo do script (PARTE 2) &eacute; coletar informa&ccedil;&otilde;es relacionados a execu&ccedil;&atilde;o de queries no SQL Server. Similar a an&aacute;lise de WaitStats, o script coleta informa&ccedil;&otilde;es sobre as threads em execu&ccedil;&atilde;o.</p>
<ul>
<li>sys.dm_exec_requests</li>
<li>sys.dm_exec_sessions</li>
<li>sys.dm_exec_broker_activated_tasks</li>
<li>sys.dm_exec_cursors</li>
<li>sys.dm_exec_memory_grants</li>
</ul>
<p>Infelizmente, o c&oacute;digo do script ainda <strong>n&atilde;o foi finalizado</strong>. Segue o trecho do c&oacute;digo com (grande) possibilidade de altera&ccedil;&atilde;o. Uma delas &eacute; a inclus&atilde;o da <strong>sys.dm_os_tasks </strong>e reescrever a <strong>sys.dm_exec_requests </strong>com join com a <strong>sys.dm_exec_session </strong>e <strong>sys.dm_exec_</strong><strong>connections</strong>. Admito que ainda est&aacute; muito cru e precisa de melhorias.</p>
<p>A dificuldade aqui &eacute; balancear a quantidade de informa&ccedil;&atilde;o obtida com a qualidade. Esse trecho ser&aacute; executado periodicamente e poder&aacute; causar um aumento significativo no tamanho final do arquivo gerado.</p>
<div id="codeSnippetWrapper" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 20px 0px 10px;width: 97.5%;font-family: 'Courier New', courier, monospace;direction: ltr;font-size: 8pt;overflow: auto;cursor: text;border: silver 1px solid;padding: 4px">
<pre id="codeSnippet" style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 0em;width: 100%;font-family: 'Courier New', courier, monospace;direction: ltr;color: black;font-size: 8pt;overflow: visible;border-style: none;padding: 0px">/*
CREATE TABLE #sqlquery_completed
(
	sql_handle			varbinary(64),
	stmt_start			int,
	PRIMARY KEY (sql_handle,stmt_start)
	-- TODO: adicionar stmt_end
)

CREATE TABLE #sqlquery_requested
(
	sql_handle			varbinary(64),
	stmt_start			int,
	stmt_end			int,
	query_hash			binary(8),
	query_plan_hash		binary(8)
)
*/

CREATE PROCEDURE #spBlockerPfe_1(@prevDate DATETIME)
AS

SET NOCOUNT ON

DECLARE @time DATETIME

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_requests'

SELECT 
	req.session_id, req.request_id, req.start_time, req.status, req.command, 
	req.sql_handle, req.statement_start_offset, req.statement_end_offset, req.plan_handle, 
	req.database_id, req.user_id, req.connection_id, req.blocking_session_id, req.wait_type, req.wait_time,  
	req.open_transaction_count, req.open_resultset_count, req.transaction_id, req.percent_complete, req.estimated_completion_time, 
	req.cpu_time, req.total_elapsed_time, req.scheduler_id, req.reads, req.writes, req.logical_reads, 
	req.row_count, req.prev_error, req.nest_level, req.granted_query_memory, req.group_id, 
	req.query_hash, req.query_plan_hash
FROM sys.dm_exec_requests req
WHERE sql_handle IS NOT NULL AND 

select * from sys.dm_exec_sessions

PRINT 'BLOCKER_PFE_END sys.dm_exec_requests '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_requests (brokers)'
-- BAD PLAN
SELECT 
	req.session_id, req.request_id, req.start_time, req.status, req.command, 
	req.sql_handle, req.statement_start_offset, req.statement_end_offset, req.plan_handle, 
	req.database_id, req.user_id, req.connection_id, req.blocking_session_id, req.wait_type, req.wait_time,  
	req.open_transaction_count, req.open_resultset_count, req.transaction_id, req.percent_complete, req.estimated_completion_time, 
	req.cpu_time, req.total_elapsed_time, req.scheduler_id, req.reads, req.writes, req.logical_reads, 
	req.row_count, req.prev_error, req.nest_level, req.granted_query_memory, req.group_id, 
	req.query_hash, req.query_plan_hash
FROM sys.dm_exec_requests req
WHERE req.session_id IN (SELECT spid FROM sys.dm_broker_activated_tasks)

PRINT 'BLOCKER_PFE_END sys.dm_exec_requests (brokers) '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_sessions'

SELECT 
	s.session_id, 
	s.login_time,
	s.status, 
	s.cpu_time, s.memory_usage, s.total_scheduled_time, s.total_elapsed_time, 
	s.last_request_start_time, s.last_request_end_time, 
	s.reads, s.writes, s.logical_reads, 
	s.row_count, 
	s.prev_error
FROM sys.dm_exec_sessions s
WHERE last_request_start_time &gt; @prevDate OR last_request_end_time &gt; @prevDate

PRINT 'BLOCKER_PFE_END sys.dm_exec_sessions '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_cursors'

SELECT
	c.session_id, c.creation_time, c.cursor_id, 
	c.worker_time, c.reads, c.writes, c.dormant_duration, c.fetch_buffer_start, 
	c.ansi_position, c.is_open, c.fetch_status, c.sql_handle, c.statement_start_offset, c.statement_end_offset, 
	c.plan_generation_num, c.is_async_population, c.is_close_on_commit, c.fetch_buffer_size
FROM sys.dm_exec_cursors(0) c
 
PRINT 'BLOCKER_PFE_END sys.dm_exec_cursors '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN CollectSqlHandle'

-- COLLECT ADHOC REQUEST
INSERT #sqlquery_requested
SELECT
	sql_handle,
	statement_start_offset,
	statement_end_offset,
	query_hash,
	query_plan_hash
FROM sys.dm_exec_requests
WHERE sql_handle is not null

-- COLLECT CURSOR
INSERT #sqlquery_requested
SELECT
	sql_handle,
	statement_start_offset,
	statement_end_offset,
	NULL,
	NULL
FROM sys.dm_exec_cursors(0)

-- OPENTRAN
INSERT #sqlquery_requested
SELECT 
	c.most_recent_sql_handle,
	0,
	0,
	NULL,
	NULL
FROM sys.dm_exec_connections c
WHERE session_id IN (SELECT session_id FROM sys.dm_tran_session_transactions) 

PRINT 'BLOCKER_PFE_END CollectSqlHandle' + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_query_memory_grants'

SELECT
	mg.session_id, mg.request_id, 
	mg.resource_semaphore_id, mg.query_cost, mg.dop, 
	mg.used_memory_kb, mg.required_memory_kb, mg.requested_memory_kb, mg.granted_memory_kb, mg.max_used_memory_kb, mg.ideal_memory_kb, 
	mg.request_time, mg.grant_time, mg.wait_time_ms, mg.timeout_sec, 
	mg.queue_id, mg.wait_order, mg.plan_handle, mg.sql_handle, mg.group_id, mg.pool_id
FROM sys.dm_exec_query_memory_grants mg

PRINT 'BLOCKER_PFE_END sys.dm_exec_query_memory_grants '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 
GO</pre>
<br /></div>
<p>&nbsp;</p>
<p>Fiquem &agrave; vontade para usar os coment&aacute;rios para dar sugest&otilde;es ou comentar modifica&ccedil;&otilde;es, assim como para fazer as perguntas relacionadas ao funcionamento dele.</p>
