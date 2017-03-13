<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/19/spinlock-parte-iii/'>Spinlock (Parte III)</a>
<p>Após comentar sobre os spinlock nos posts Spinlock <a href="http://blogs.msdn.com/b/fcatae/archive/2010/07/12/spinlock-parte-1.aspx" target="_blank">Parte I</a> e <a href="http://blogs.msdn.com/b/fcatae/archive/2010/07/15/spinlock-parte-ii.aspx" target="_blank">Parte II</a>, agora vamos para o lado prático.</p>  <p>&#160;</p>  <p><strong>Monitorando os Spinlocks</strong></p>  <p>O comando DBCC SQLPERF(SPINLOCKSTATS) não é documentado, mas auxilia na monitoração dos spinlocks. Enquanto escrevia esse post, descobri que existe uma DMV também.</p>  <blockquote>   <div align="left">     <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_os_spinlock_stats</span></pre>
  </div>
</blockquote>
<a href="http://11011.net/software/vspaste"></a>

<p>O resultado será apresentado:</p>

<p><a href="images\1447.image_2.png"><img style="border-right-width: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px" title="image" border="0" alt="image" src="images\4503.image_thumb.png" width="458" height="210" /></a> </p>

<p>&#160;</p>

<p><strong>Impacto no Servidor</strong></p>

<p>O que esperar do spinlock e qual será seu risco para o servidor? Em situações de contenção por spinlock, observa-se uma série de threads bloqueadas por um único ponto de contenção – são vários “loops infinitos” tentando obter o spinlock. Cada contenção é contabilizada como <strong>collision</strong>, sendo possível determinar o número de “rodadas” (spins) efetuada por cada thread através de <strong>spins_per_collision</strong>. O ideal é que esses números sejam ZERO – mas é tolerável (e normal) encontrar valores entre 0 e 1000.</p>

<p>Conforme o número de <strong>spins/collision</strong> aumenta, o servidor começa a perder mais tempo dentro do bloqueio do que executando tarefas. Nesse momento, a CPU dispara para 100% e entra em um loop infinito. Esse é um comportamento transitório de milissegundos porque, por outro lado, existe um limite máximo de spins. Quando a thread ultrapassa esse valor, ela entra entra em um estado de dormência (sleep) – denominado backoff:</p>

<blockquote>
  <p><strong>Backoff</strong> – Após um alto número de spins para obter o spinlock e sem sucesso, o SQL Server coloca a thread no estado inativo durante alguns milissegundos. Durante o período de backoff, a thread deixa de executar suas tarefas e fica esperando pelo lock.</p>
</blockquote>

<p>A partir do número de <strong>backoff </strong>e o tempo em dormência (<strong>sleep time</strong>), fica mais fácil compreender o impacto no desempenho do servidor. Esses contadores devem ser zero, pois qualquer outro valor indica uma contenção.</p>

<p>&#160;</p>

<p><strong>Analisando o Resultado</strong></p>

<p>Se você encontrar um servidor que apresente as colunas <strong>spins</strong>, <strong>sleep time </strong>e <strong>backoff </strong>diferente de zero, não há motivos para desespero. Contenção sempre existe e para isso que servem os spinlocks. </p>

<p>Tenho utilizado uma estratégia de comparação entre os locks. Há estruturas em memória que apresentam mais contenção que outras, como por exemplo os Locks e Buffers. </p>

<p>A regra proposta é observar o número de spins/collision e backoff dos spinlocks chamados LOCK_HASH e BUF_HASH. Esses servem como baseline. Depois, procuramos por qualquer outro spinlock que apresente um maior número de spins/backoff. Esses serão os “possíveis spinlocks” com problemas.</p>

<p>Não há uma resolução simples para esse tipo de contenção. Normalmente, a causa está relacionada com uma limitação na arquitetura do SQL Server ou uma situação de Bug. Por isso, acredito que o DBA não tem controle sobre a situação. Seu papel é monitorar o servidor e identificar os problemas antes que se tornem críticos. Além disso, aplicar Service Pack e patches de correção podem resolver a situação.</p>

<p>&#160;</p>

<p><strong>Exemplos</strong></p>

<p>Aqui seguem dois exemplos que ilustram contenção por spinlock. Nos dois casos, veja ambos ultrapassam 10000 spins/collision – chegando a quase 180000. Consequentemente, há backoff nas threads e sleep time.</p>

<p>1. Contenção no Spinlock MUTEX. </p>

<blockquote>
  <p><a href="http://blogs.msdn.com/b/psssql/archive/2008/06/16/query-performance-issues-associated-with-a-large-sized-security-cache.aspx" target="_blank">Contention on Large Sized Security Cache</a></p>
</blockquote>

<p>2. Contenção no Procedure Cache (SQL Manager)</p>

<blockquote>
  <p><a href="http://blogs.msdn.com/b/fcatae/archive/2009/12/17/spinlock-contention.aspx" target="_blank">Spinlock Contention</a></p>
</blockquote>

<p>&#160;</p>

<p>Se alguém quiser compartilhar algum exemplo, envie o resultado do DBCC SQLPERF(SPINLOCKSTATS) e deixarei disponível a análise no blog. </p>
