<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/12/coleta-de-dados-no-sql-2008script-3/'>Coleta de dados no SQL 2008–Script 3</a>
<p>A terceira parte do script de coleta de dados para diagn&oacute;stico de performance est&aacute; apresentado nesse artigo. A <a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/coleta-de-dados-no-sql-2008-script-2.aspx" target="_blank">segunda parte</a> era o cora&ccedil;&atilde;o do script e roda em intervalos peri&oacute;dicos de 5 a 15 segundos. Por outro lado, a terceira parte corresponde a parte massiva e que coleta a maior parte das informa&ccedil;&otilde;es. O objetivo aqui &eacute; coletar dados relevantes em uma frequencia menor &ndash; em torno de 1 a 5 minutos.</p>
<p style="padding-left: 30px"><strong>Links Relacionados</strong></p>
<ul>
<li>Blocker Script original: <a href="http://support.microsoft.com/kb/271509/en-us">sp_blocker_pss80</a></li>
<li>Vers&atilde;o SQL2000: <a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/07/lab-sql-blocker-script-2000-performance-lock-e-bloqueios.aspx">Blocker&nbsp;Modificado</a></li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-1.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 1</span></a>&nbsp;</li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-2.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 2</span></a></li>
<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/12/coleta-de-dados-no-sql-2008-script-3.aspx"><span style="color: #0066dd">Coleta de dados no SQL 2008&ndash;Script 3</span></a></li>
<li>Vers&atilde;o final: <a href="http://blogs.msdn.com/b/fcatae/archive/2012/07/05/monitor-sql.aspx"><span style="color: #0066dd">Monitor SQL (Vers&atilde;o atualizada do Blocker Script)</span></a></li>
</ul>
<p>&nbsp;</p>
<h2>Introdu&ccedil;&atilde;o</h2>
<p>O <a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/07/lab-sql-blocker-script-2000-performance-lock-e-bloqueios.aspx" target="_blank">blocker script (vers&atilde;o modificada)</a> &eacute; utilizado para coletar informa&ccedil;&otilde;es que auxiliam no diagn&oacute;stico de performance SQL Server 2000. Apesar desse script ser compat&iacute;vel com o SQL Server 2005 e 2008, ele ainda depende de tabelas e views obsoletas como a <a href="http://msdn.microsoft.com/en-us/library/ms179881.aspx" target="_blank">sysprocesses</a>. Por isso, &eacute; importante atualizar o blocker script de forma a adotar as novas DMV e DMF de sistema.</p>
<p>&nbsp;</p>
<h2>Script &ndash; Parte III</h2>
<p>O objetivo do script (PARTE 3) &eacute; coletar informa&ccedil;&otilde;es relacionadas a:</p>
<ul>
<li>Transa&ccedil;&atilde;o</li>
<li>Mem&oacute;ria</li>
<li>I/O</li>
<li>Etc</li>
</ul>
<p>Esse script enquadra todos os comandos que n&atilde;o s&atilde;o est&aacute;ticos (<a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/coleta-de-dados-no-sql-2008-script-1.aspx" target="_blank">Script 1</a>) ou din&acirc;micos (<a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/coleta-de-dados-no-sql-2008-script-2.aspx" target="_blank">Script 2</a>). &Eacute; um meio termo. Infelizmente, o c&oacute;digo do script ainda <strong>n&atilde;o foi finalizado. </strong>Se houver altera&ccedil;&otilde;es, ser&aacute; a inclus&atilde;o de novas DMV que ficaram faltando.</p>
<p>&nbsp;</p>
<div style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 20px 0px 10px;width: 97.5%;font-family: 'Courier New', courier, monospace;direction: ltr;font-size: 8pt;overflow: auto;cursor: text;border: silver 1px solid;padding: 4px" id="codeSnippetWrapper">
<pre style="text-align: left;line-height: 12pt;background-color: #f4f4f4;margin: 0em;width: 100%;font-family: 'Courier New', courier, monospace;direction: ltr;color: black;font-size: 8pt;overflow: visible;border-style: none;padding: 0px" id="codeSnippet">CREATE PROCEDURE #spBlockerPfe_2(@prevDate DATETIME)
AS

SET NOCOUNT ON

DECLARE @time DATETIME

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN SYSINFO'
-- SQL 2008
SELECT 
s.total_physical_memory_kb, s.available_physical_memory_kb, 
s.total_page_file_kb, s.available_page_file_kb, 
s.system_cache_kb, s.kernel_paged_pool_kb, s.kernel_nonpaged_pool_kb, 
s.system_high_memory_signal_state, s.system_low_memory_signal_state
FROM sys.dm_os_sys_memory s

-- SQL 2008
select 
p.physical_memory_in_use_kb, p.large_page_allocations_kb, p.locked_page_allocations_kb, 
p.total_virtual_address_space_kb, p.virtual_address_space_reserved_kb, p.virtual_address_space_committed_kb, p.virtual_address_space_available_kb, 
p.memory_utilization_percentage, p.available_commit_limit_kb, 
p.process_physical_memory_low, p.process_virtual_memory_low
from sys.dm_os_process_memory p


PRINT 'BLOCKER_PFE_END SYSINFO '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_tran_active_transactions'

SELECT
t.transaction_id, t.name, t.transaction_begin_time, t.transaction_type, t.transaction_state
FROM sys.dm_tran_active_transactions t

PRINT 'BLOCKER_PFE_END sys.dm_tran_active_transactions '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_tran_database_transactions'

SELECT 
dt.transaction_id, dt.database_id, dt.database_transaction_begin_time, 
dt.database_transaction_type, dt.database_transaction_state, 
dt.database_transaction_log_record_count, dt.database_transaction_log_bytes_used, 
dt.database_transaction_log_bytes_reserved, 
dt.database_transaction_begin_lsn, dt.database_transaction_last_lsn
FROM sys.dm_tran_database_transactions dt
WHERE database_transaction_begin_time is NOT NULL

PRINT 'BLOCKER_PFE_END sys.dm_tran_database_transactions '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_tran_locks'

SELECT
l.resource_type, l.resource_database_id, l.resource_associated_entity_id, 
l.request_mode, l.request_status, 
l.request_session_id, l.request_owner_type, l.request_owner_id, 
l.resource_subtype, l.resource_description
FROM sys.dm_tran_locks l
WHERE l.resource_type = 'OBJECT'
	
PRINT 'BLOCKER_PFE_END sys.dm_tran_locks '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_tran_locks[OBJECTS]'

SELECT
l.resource_database_id, l.resource_associated_entity_id, 
request_mode = CAST(l.request_mode AS VARCHAR(8)), request_status = CAST(l.request_status AS VARCHAR(8)),
l.request_session_id, l.request_owner_id, 
resource_subtype = CAST(l.resource_subtype AS VARCHAR(16)), resource_description = CAST(l.resource_description AS VARCHAR(16))
FROM sys.dm_tran_locks l
WHERE l.resource_type = 'OBJECT'
	
PRINT 'BLOCKER_PFE_END sys.dm_tran_locks[OBJECTS] '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_connections'

SELECT 
	c.connect_time, 
	s.login_time, 
	s.group_id, s.original_login_name, 
	c.auth_scheme, c.net_transport, c.client_net_address, c.client_tcp_port, 
	s.host_name, s.program_name, 
	c.session_id, c.connection_id, c.parent_connection_id,
	c.endpoint_id, c.node_affinity,
	c.net_packet_size, c.local_net_address, c.local_tcp_port, 	
	c.encrypt_option, 
	s.host_process_id, s.client_interface_name, s.client_version, 
	s.is_user_process, s.transaction_isolation_level 
FROM sys.dm_exec_connections c left join sys.dm_exec_sessions s on c.session_id = s.session_id
WHERE c.connect_time &gt;= @prevDate

PRINT 'BLOCKER_PFE_END sys.dm_exec_connections ' + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


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
	s.prev_error,
	s.original_login_name, s.host_name, s.program_name, c.most_recent_sql_handle
FROM 
	(SELECT DISTINCT session_id FROM sys.dm_tran_session_transactions) t
	INNER JOIN sys.dm_exec_connections c on c.session_id = t.session_id
	INNER JOIN sys.dm_exec_sessions s on c.session_id = s.session_id

PRINT 'BLOCKER_PFE_END sys.dm_exec_sessions ' + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN FlushSqlHandle'

SELECT
'COUNT=',			Count=COUNT(*),
'SQLHANDLE=',		req.sql_handle, 
'QUERY_HASH=',		req.query_hash,
'STMT_START=',		req.stmt_start, 
'STMT_END=',		req.stmt_end,
'QUERY_PLAN_HASH=',	req.query_plan_hash
FROM #sqlquery_requested req 
GROUP BY sql_handle, query_hash, stmt_start, req.stmt_end, req.query_plan_hash
ORDER BY COUNT(*)

DELETE #sqlquery_requested
	FROM #sqlquery_requested req
	WHERE exists (select 1 from #sqlquery_completed sq where sq.sql_handle=req.sql_handle and sq.stmt_start = req.stmt_start)

SELECT
'SQLHANDLE=',		req.sql_handle, 
'STMT_START=',		req.stmt_start, 
'STMT_END=',		req.stmt_end,
'SQLTEXT=',			sqltext=(SELECT SUBSTRING(	text, stmt_start/2 + 1, 
												((CASE	WHEN stmt_end = -1 THEN DATALENGTH(text) 
														WHEN stmt_end = 0 THEN 1024
														ELSE stmt_end END) - stmt_start)/2 )
						FROM sys.dm_exec_sql_text(sql_handle))
FROM #sqlquery_requested req 
GROUP BY sql_handle, query_hash, stmt_start, req.stmt_end

INSERT #sqlquery_completed
	SELECT DISTINCT sql_handle, stmt_start 
	FROM #sqlquery_requested CROSS APPLY sys.dm_exec_sql_text(sql_handle) st
	WHERE st.text IS NOT NULL
	
TRUNCATE TABLE #sqlquery_requested

PRINT 'BLOCKER_PFE_END FlushSqlHandle' + convert(VARCHAR(12), datediff(ms,@time,getdate())) 


/*
SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_procedure_stats'

SELECT
	objname=OBJECT_NAME([ps].[object_id], [ps].[database_id]), ps.type,
	ps.database_id, ps.object_id, 
	ps.sql_handle, ps.plan_handle, 
	ps.cached_time, ps.last_execution_time, 
	ps.execution_count, 
	ps.total_worker_time, ps.last_worker_time, ps.min_worker_time, ps.max_worker_time, 
	ps.total_physical_reads, ps.last_physical_reads, ps.min_physical_reads, ps.max_physical_reads, 
	ps.total_logical_writes, ps.last_logical_writes, ps.min_logical_writes, ps.max_logical_writes, 
	ps.total_logical_reads, ps.last_logical_reads, ps.min_logical_reads, ps.max_logical_reads, 
	ps.total_elapsed_time, ps.last_elapsed_time, ps.min_elapsed_time, ps.max_elapsed_time
FROM sys.dm_exec_procedure_stats ps

PRINT 'BLOCKER_PFE_END sys.dm_exec_procedure_stats '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 */


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_io_virtual_file_stats'

SELECT 
	fs.database_id, fs.file_id, 
	fs.num_of_reads, fs.num_of_bytes_read, fs.io_stall_read_ms, fs.num_of_writes, fs.num_of_bytes_written, fs.io_stall_write_ms, fs.io_stall, 
	fs.size_on_disk_bytes, virtual_file_handle = fs.file_handle
FROM sys.dm_io_virtual_file_stats (-1,-1) fs

PRINT 'BLOCKER_PFE_END sys.dm_io_virtual_file_stats '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_os_schedulers'

SELECT
	sos.scheduler_id, sos.is_online, sos.is_idle, 
	sos.current_tasks_count, sos.runnable_tasks_count, sos.active_workers_count, sos.current_workers_count, sos.work_queue_count, 
	sos.pending_disk_io_count
FROM sys.dm_os_schedulers sos

PRINT 'BLOCKER_PFE_END sys.dm_os_schedulers '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_os_memory_clerks'

SELECT
mc.type, total_kb = mc.single_pages_kb+mc.multi_pages_kb+mc.virtual_memory_committed_kb,
mc.memory_node_id, mc.single_pages_kb, mc.multi_pages_kb, mc.virtual_memory_reserved_kb, mc.virtual_memory_committed_kb, mc.awe_allocated_kb, mc.shared_memory_reserved_kb, mc.shared_memory_committed_kb, mc.name
FROM sys.dm_os_memory_clerks mc
WHERE single_pages_kb+multi_pages_kb+virtual_memory_committed_kb &gt; 102400

PRINT 'BLOCKER_PFE_END sys.dm_os_memory_clerks '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_os_wait_stats'

select * from sys.dm_os_wait_stats where waiting_tasks_count &gt; 0

PRINT 'BLOCKER_PFE_END sys.dm_os_wait_stats '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_os_latch_stats'

select * from sys.dm_os_latch_stats where waiting_requests_count &gt; 0

PRINT 'BLOCKER_PFE_END sys.dm_os_latch_stats '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 

SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_exec_query_resource_semaphores'

SELECT 
	qrsem.resource_semaphore_id, qrsem.target_memory_kb, qrsem.max_target_memory_kb, qrsem.total_memory_kb, qrsem.available_memory_kb, qrsem.granted_memory_kb, qrsem.used_memory_kb, qrsem.grantee_count, qrsem.waiter_count, qrsem.timeout_error_count, qrsem.forced_grant_count, qrsem.pool_id
FROM sys.dm_exec_query_resource_semaphores qrsem

PRINT 'BLOCKER_PFE_END sys.dm_exec_query_resource_semaphores '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) 
 
GO


SET @time = GETDATE()
PRINT ''
PRINT 'BLOCKER_PFE_BEGIN sys.dm_io_pending_io_requests'

SELECT 
	io_type = CAST(io.io_type AS VARCHAR(7)), io.io_pending_ms_ticks, io.io_pending, io.scheduler_address, io_pending_handle=io.io_handle, io.io_offset
FROM sys.dm_io_pending_io_requests io

PRINT 'BLOCKER_PFE_END sys.dm_io_pending_io_requests '  + convert(VARCHAR(12), datediff(ms,@time,getdate())) </pre>
</div>
<p>&nbsp;</p>
<p>Fiquem &agrave; vontade para usar os coment&aacute;rios para dar sugest&otilde;es ou comentar modifica&ccedil;&otilde;es, assim como para fazer as perguntas relacionadas ao funcionamento dele.</p>
