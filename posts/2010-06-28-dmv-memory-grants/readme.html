<a link='https://blogs.msdn.microsoft.com/fcatae/2010/06/28/dmv-memory-grants/'>DMV: Memory Grants</a>
<p>Como monitorar queries que realizam alto consumo de memória?</p>  <p>(Comentário: existem várias formas de interpretar “consumo de memória”. Nesse artigo, falamos sobre o espaço de trabalho usado por uma query)</p>  <p>Use a view: <strong>sys.dm_exec_query_memory_grants</strong></p>  <p><em>Exemplo:</em></p>  <blockquote>   <pre class="code"><span style="color: green">-- MEMORY GRANTS
</span><span style="color: blue">SELECT 
</span>mg<span style="color: gray">.</span>session_id<span style="color: gray">, </span>mg<span style="color: gray">.</span>request_id<span style="color: gray">, </span>mg<span style="color: gray">.</span>resource_semaphore_id<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>query_cost<span style="color: gray">, </span>mg<span style="color: gray">.</span>dop<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>used_memory_kb<span style="color: gray">, </span>mg<span style="color: gray">.</span>required_memory_kb<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>requested_memory_kb<span style="color: gray">, </span>mg<span style="color: gray">.</span>granted_memory_kb<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>max_used_memory_kb<span style="color: gray">, </span>mg<span style="color: gray">.</span>ideal_memory_kb<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>request_time<span style="color: gray">, </span>mg<span style="color: gray">.</span>grant_time<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>wait_time_ms<span style="color: gray">, </span>mg<span style="color: gray">.</span>timeout_sec<span style="color: gray">, </span>mg<span style="color: gray">.</span>queue_id<span style="color: gray">, </span>mg<span style="color: gray">.</span>wait_order<span style="color: gray">, 
</span>mg<span style="color: gray">.</span>plan_handle<span style="color: gray">, </span>mg<span style="color: gray">.</span><span style="color: blue">sql_handle</span><span style="color: gray">, 
</span>mg<span style="color: gray">.</span>group_id<span style="color: gray">, </span>mg<span style="color: gray">.</span>pool_id
<span style="color: blue">FROM </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_exec_query_memory_grants </span>mg</pre>
</blockquote>

<p>&#160;</p>

<p><u><strong>Descrição:</strong></u></p>

<ul>
  <li><strong>session_id:</strong> Indica a sessão do usuário que está consumindo memória</li>

  <li><strong>query_cost: </strong>Custo estimado da query. Normalmente queries pesadas utilizam paralelismo de thread.</li>

  <li><strong>dop: </strong>Degree of Parallelism – número de threads que estão rodando para resolver a query</li>

  <li><strong>granted_memory_kb: </strong>Quantidade de memória usada no momento pela query</li>

  <li><strong>wait_time, queue_id: </strong>Tempo de espera na fila por mais “espaço de trabalho”, ou seja, memória</li>

  <li><strong>plan_handle, sql_handle: </strong>Identificadores da query e do plano de execução</li>
</ul>

<p>&#160;</p>

<p><strong>Quando usar? </strong></p>

<p>Esperas por RESOURCE_SEMAPHORE significam que as queries estão enfileirando por falta de memória disponível para o “espaço de trabalho”. Esse espaço de trabalho é usado como área temporária para comandos de SORT e HASH.</p>
