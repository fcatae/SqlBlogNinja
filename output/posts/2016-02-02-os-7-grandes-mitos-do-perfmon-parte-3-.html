<a link='https://blogs.msdn.microsoft.com/fcatae/2016/02/02/os-7-grandes-mitos-do-perfmon-parte-3/'>Os 7 Grandes Mitos do Perfmon (Parte 3)</a>
<p>No <a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/19/os-7-grandes-mitos-do-perfmon-parte-1.aspx">primeiro post da s&eacute;rie Os 7 Grandes Mitos do Perfmon (Parte 1)</a>, comentei sobre os contadores:</p>
<ul>
<li>Buffer Manager:Buffer Cache Hit Ratio</li>
<li>LogicalDisk: Average Disk Queue Length e LogicalDisk: %Disk Busy</li>
</ul>
<p>Depois <a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/26/os-7-grandes-mitos-do-perfmon-parte-2.aspx">abordei os contadores relacionados ao Paging File (Parte 2)</a>:</p>
<ul>
<li>Paging File:%Usage</li>
<li>Memory: Page Faults/sec e Memory: Pages/sec</li>
</ul>
<p>Agora vamos terminar com os 3 &uacute;ltimos contadores.</p>
<p>&nbsp;</p>
<h4>5. SQL Access Methods: Page Splits/sec</h4>
<p>O contador Page Splits/sec indica o n&uacute;mero de ocorr&ecirc;ncias de page splits no servidor.</p>
<p>Os registros s&atilde;o armazenados em p&aacute;ginas de 8Kb no servidor. Quando o processo de inser&ccedil;&atilde;o de registro tenta inserir novos dados, mas n&atilde;o encontra espa&ccedil;o livre na p&aacute;gina, ent&atilde;o inicia-se o processo de page split. Nesse processo, metade dos registros s&atilde;o movidos para uma nova p&aacute;gina, liberando espa&ccedil;o da p&aacute;gina original. Ap&oacute;s o processo de page split, as p&aacute;ginas envolvidas ficam com 50% de espa&ccedil;o livre e podem continuar o processo de inser&ccedil;&atilde;o.</p>
<p>Normalmente esse &eacute; o contador favorito para iniciar uma conversa sobre &ldquo;Fill factor&rdquo;, pois altos n&uacute;meros do contador Page splits/sec indicam que as p&aacute;ginas est&atilde;o frequentemente cheias. Entretanto, o processo de Page Split ocorre naturalmente durante a inser&ccedil;&atilde;o de dados e n&atilde;o corresponde necessariamente a um problema. Processos de inser&ccedil;&atilde;o em massa causam sempre um alto n&uacute;mero de page splits/sec.</p>
<p>Se realmente for necess&aacute;rio investigar a ocorr&ecirc;ncia de Page Splits, recomendo que utilize a DMV sys.dm_db_index_operational_stats.</p>
<p>Entretanto, a principal an&aacute;lise &eacute; validar os resultados de fragmenta&ccedil;&atilde;o usando a DMF sys.dm_db_index_physical_stats (vers&atilde;o moderna do DBCC SHOWCONTIG).</p>
<p>&nbsp;</p>
<h4>6. SQL Locks: Lock Waits/sec</h4>
<p>O contador de Lock Waits/sec indica quantas sess&otilde;es entram em bloqueios por segundo. Usar o Perfmon para monitorar os locks &eacute; algo que acho interessante na teoria.</p>
<blockquote>
<p>Exemplo: Estou no tr&acirc;nsito de S&atilde;o Paulo e de repente come&ccedil;ou a chover. Quero monitorar quantas vezes fico bloqueado por algum sem&aacute;foro usando um contador semelhante ao Lock Waits/sec.</p>
</blockquote>
<p>Na pr&aacute;tica, isso tem resultados curiosos:</p>
<blockquote>
<p>A chuva piorou bastante e n&atilde;o estou andando e ainda n&atilde;o consegui atravessar a avenida. Por isso, o contador Lock Waits/sec indica 0, porque n&atilde;o estou passando por mais nenhum outro sem&aacute;foro.</p>
</blockquote>
<p>O contador de Lock Waits/sec n&atilde;o fornece muita pistas sobre o desempenho do servidor. No geral, esse contador apresenta um valor flutuante e com pouco significado. Em condi&ccedil;&otilde;es de problemas ou de tranquilidade (situa&ccedil;&otilde;es completamente opostas), ele indica zero.</p>
<p>Os demais contadores da fam&iacute;lia de Lock s&atilde;o confusos. &Eacute; praticamente imposs&iacute;vel conseguir enxergar Number of Deadlock/sec maior do que 1. Lock timeouts possui um nome atrativo, mas geralmente a query sofre timeout (note que lock timeout est&aacute; associado a <a href="https://msdn.microsoft.com/en-us/library/ms182729.aspx">@@LOCK_TIMEOUT</a>).</p>
<p>Recomendo que use as DMV sys.dm_os_waiting_tasks e sys.dm_exec_requests para acompanhar os bloqueios. Entretanto, se realmente for importante monitorar os locks usando o Perfmon, ent&atilde;o considere o uso do &ldquo;Lock Wait Time (ms)&rdquo; e &ldquo;Average Wait Time (ms)&rdquo;. </p>
<p>&nbsp;</p>
<h4>7. SQL General Statistics: User Connections</h4>
<p>O contador de &ldquo;User connection&rdquo; diz quantas sess&otilde;es est&atilde;o conectadas ao servidor. Na realidade, n&atilde;o h&aacute; nenhum problema em monitorar esse contador, visto que o servidor possui um limite m&aacute;ximo de 30 mil conex&otilde;es. O problema ocorre quando as pessoas usam esse contador para medir a carga no servidor.</p>
<p>Por exemplo, qual dos servidores est&aacute; mais sobrecarregado? (a diferen&ccedil;a &eacute; de 50 vezes!)</p>
<ul>
<li>Servidor A com 100 conex&otilde;es</li>
<li>Servidor B com 5000 conex&otilde;es</li>
</ul>
<p>Entretanto, a carga depende de quais comandos que est&atilde;o sendo executados no servidor. Consigo imaginar um usu&aacute;rio chamado DBA, que &eacute; capaz de executar um &uacute;nico comando DBCC CHECKDB, e &eacute; capaz de causar muito mais carga do que v&aacute;rias aplica&ccedil;&otilde;es rodando ao mesmo tempo.</p>
<p>Muito semelhante ao User Connections, s&atilde;o os contadores chamados &ldquo;SQL Statistics: Batch Requests/sec&rdquo; e &ldquo;SQLStatistics: SQL Compilations/sec&rdquo;. O processo de compila&ccedil;&atilde;o e execu&ccedil;&atilde;o depende muito do tipo de comando submetido. Existem comandos ad-hoc que podem ser facilmente compilados e executados. Por outro lado, existem comandos que acabam com o desempenho da m&aacute;quina.</p>
<p>Como disse no artigo <a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/12/perfmon-falso-sentido-de-monitoracao.aspx">Perfmon: Falso sentido de monitora&ccedil;&atilde;o</a>, use o Performance Monitor para criar baselines de compara&ccedil;&atilde;o do servidor. Houve aumento do n&uacute;mero de conex&otilde;es, batches/seg, n&uacute;meros de compila&ccedil;&otilde;es? Se voc&ecirc; quiser saber a verdadeira causa, ent&atilde;o abandone (temporariamente) o Perfmon e use a estrat&eacute;gia correta (DMV ou XE).</p>
<p>&nbsp;</p>
<p>Finalmente terminamos com a lista dos 7 Grandes Mitos do Performance Monitor.</p>
<p>&nbsp;</p>
<p>No pr&oacute;ximo artigo, farei a sele&ccedil;&atilde;o dos contadores do Perfmon que voc&ecirc; DEVE usar.</p>
