<a link='https://blogs.msdn.microsoft.com/fcatae/2016/03/15/checklist-performance-do-servidor-sql/'>Checklist: Performance do Servidor (SQL)</a>
<p>Podemos criar um breve checklist sobre como validar a infraestrutura de um servidor SQL usando o Performance Monitor.<blockquote>   <p><strong>Artigo complementar: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/08/checklist-performance-do-servidor-windows.aspx">Checklist: Performance do Servidor (Windows)</a></p>    <p><strong>Desafio: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/16/desafio-analisando-servidor-com-perfmon.aspx">Analisando Servidor com Perfmon</a></strong></p> </blockquote><p>O primeiro passo na an&aacute;lise do SQL Server no Performance Monitor &eacute; criar um baseline inicial para caracterizar a carga. Depois, complementamos com informa&ccedil;&otilde;es sobre a utiliza&ccedil;&atilde;o de mem&oacute;ria pelos componentes internos do SQL.</p><p>&nbsp;</p><h3>Baseline do SQL Server</h3><p>Esses contadores devem ser usados para ajudar a caracterizar a carga no banco de dados:</p><p><strong>General Statistics </strong></p><ul>   <li><strong>Connection Reset/sec</strong>: taxa de sess&otilde;es reiniciando a sess&atilde;o atrav&eacute;s do connection pooling</li>    <li><strong>Logins/sec</strong>: taxa de autentica&ccedil;&otilde;es no servidor</li>    <li><strong>Logouts/sec</strong>: taxa de usu&aacute;rios desconectando do servidor </li>    <li><strong>User Connections</strong>: quantidade de sess&otilde;es de usu&aacute;rios</li> </ul><p><strong>SQL Statistics </strong></p><ul>   <li><strong>Batch Requests/sec</strong>: taxa de requisi&ccedil;&otilde;es recebidas por segundo</li>    <li><strong>Safe Auto-Params/sec</strong>: taxa de autoparametriza&ccedil;&atilde;o (auto-param) realizadas </li>    <li><strong>Forced Parametrizations/sec</strong>: taxa de parametriza&ccedil;&atilde;o for&ccedil;ada (forced-param) realizadas </li>    <li><strong>SQL Compilations/sec</strong>: taxa de compila&ccedil;&atilde;o pelo otimizador </li>    <li><strong>SQL Re-Compilations/sec</strong>: taxa de recompila&ccedil;&atilde;o pelo otimizador</li> </ul><p>Existem valores e sugest&otilde;es para esses contadores. No entanto, o mais importante &eacute; ter um baseline para compara&ccedil;&atilde;o futura.</p><p>&nbsp;</p><h3>Buffer Manager: Consumo de Mem&oacute;ria</h3><p>A mem&oacute;ria do servidor SQL Server pode ser observada melhor com o aux&iacute;lio dos contadores:</p><ul>   <li><strong>Buffer Manager: Page life expectancy: </strong>verificar se esse valor se mant&eacute;m constante ou subindo ao longo do tempo. O c&aacute;lculo do Page Life Expectancy &eacute; mais complexo em m&aacute;quinas NUMA e corresponde a uma m&eacute;dia harm&ocirc;nica entre os n&oacute;s. As quedas desse contador indicam o momento de aumento de carga. Valores de refer&ecirc;ncia:</li>    <ul>     <li>&lt;10 : excessivamente baixo, podendo gerar erros, asserts e dumps </li>      <li>&lt;300 : baixo </li>      <li>1000: razo&aacute;vel </li>      <li>5000 : bom</li>   </ul>    <li><strong>Buffer Manager: Free list stalls/sec</strong>: garantir que &eacute; sempre zero. A ocorr&ecirc;ncia de stall significa que as threads foram congeladas e est&atilde;o todas trabalhando em conjunto com o Lazy Writer para a libera&ccedil;&atilde;o de mem&oacute;ria. Em geral, esse comportamento ocorre quando o Page Life Expectancy fica pr&oacute;ximo de zero. </li>    <li><strong>Buffer Manager: Lazy writes/sec</strong>: usar esse n&uacute;mero como baseline. O processo de Lazy Writer (LW) ocorre lentamente em background. Quando esse contador aumenta, isso pode significar que a mem&oacute;ria livre est&aacute; baixa e, por isso, o servidor acelerou o processo do LW. </li>    <li><strong>Buffer Manager: Page lookups/sec</strong>: usar esse n&uacute;mero como baseline.&nbsp; </li>    <li><strong>Buffer Manager: Page reads/sec</strong>: usar esse n&uacute;mero como baseline de compara&ccedil;&atilde;o com as opera&ccedil;&otilde;es de leitura em disco (Read IOPS). Podemos estimar que cada Page Read corresponde a um I/O de leitura no disco. </li>    <li><strong>Buffer Manager: Readahead pages/sec:</strong> usar esse n&uacute;mero como baseline de compara&ccedil;&atilde;o com as taxas de leitura no disco (MB/s). Podemos dizer que cada Readahead page corresponde a 8Kb de leitura sequencial no disco.</li> </ul><p>&nbsp;</p><h3>Distribui&ccedil;&atilde;o de Mem&oacute;ria do SQL Server</h3><p>A distribui&ccedil;&atilde;o de mem&oacute;ria do Database Cache pode ser observada com os contadores:   <br></p><ul>   <li><strong>Database pages: </strong>n&uacute;mero de p&aacute;ginas correspondente ao Database Cache.&nbsp;&nbsp; </li>    <li><strong>Free pages: </strong>n&uacute;mero de p&aacute;ginas livres no Buffer Pool. Se a quantidade de p&aacute;ginas livres ficar constante (acima de 1000), ent&atilde;o est&aacute; sobrando mem&oacute;ria. </li>    <li><strong>Stolen pages</strong>: quantidade de p&aacute;ginas dedicadas para tarefas internas do banco de dados (compila&ccedil;&atilde;o, execu&ccedil;&atilde;o, object cache). Quanto maior for o n&uacute;mero de stolen pages, menos p&aacute;ginas ficar&atilde;o dispon&iacute;veis para o Database Cache. Sugest&atilde;o de valores:</li>    <ul>     <li>25% : normal </li>      <li>50% : relativamente alto, pode causar press&atilde;o de mem&oacute;ria interna &ndash; exceto se houver muitas Free Pages dispon&iacute;veis </li>      <li>75% : excessivamente alto, investigar qual o Memory Clerk respons&aacute;vel pelo consumo &ndash; exceto se houver muitas Free Pages dispon&iacute;veis</li>   </ul>    <li><strong>Target pages</strong>: total de p&aacute;ginas a ser alcan&ccedil;ado pelo SQL Server em um futuro. Monitorar se existem quedas bruscas nesse valor, que indicaria uma press&atilde;o de mem&oacute;ria externa. </li>    <li><strong>Total pages</strong>: total de p&aacute;ginas alocadas pelo SQL Server.</li>    <ul>     <li>Target pages = Total pages : normal</li>      <li>Target pages &gt; Total pages : warmup do servidor ou a mem&oacute;ria est&aacute; sobrando</li>      <li>Target pages &lt; Total pages : enquanto essa condi&ccedil;&atilde;o for verdadeira, o Lazy Writer estar&aacute; trabalhando agressivamente para reduzir o n&uacute;mero de p&aacute;ginas at&eacute; igualar ao Target Page.</li>   </ul> </ul><p>&nbsp;</p><h1>Refer&ecirc;ncia</h1><p>Os demais artigos dessa s&eacute;rie est&atilde;o listados abaixo.</p><blockquote>   <p><strong>Artigo: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/12/perfmon-falso-sentido-de-monitoracao.aspx">Perfmon- Falso Sentido de Monitora&ccedil;&atilde;o</a> </p>    <p><strong>Artigo: Os 7 Grandes Mitos do Perfmon:</strong> </p>    <ul>     <li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/19/os-7-grandes-mitos-do-perfmon-parte-1.aspx">Parte 1: Buffer Cache Hit Ratio, Average Disk Queue Length e %Disk Busy</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/26/os-7-grandes-mitos-do-perfmon-parte-2.aspx">Parte 2: Paging File:%Usage, Memory: Page Faults/sec e Memory: Pages/sec</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/02/os-7-grandes-mitos-do-perfmon-parte-3.aspx">Parte 3: SQL Access Methods: Page Splits/sec, SQL Locks: Lock Waits/sec e SQL General Statistics: User Connections</a></li>   </ul> </blockquote><blockquote>   <p><strong>Artigo: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/09/contadores-do-perfmon.aspx">Contadores do Perfmon</a> </p>    <p><strong>Desafio: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/16/desafio-analisando-servidor-com-perfmon.aspx">Analisando Servidor com Perfmon</a></strong></p>    <p><strong>Artigo: Monitorando com o Perfmon</strong> </p>    <ul>     <li><strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/23/perfmon-monitorando-o-buffer-manager.aspx">Perfmon: Monitorando o Buffer Manager</a></strong></li>      <li><strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/01/perfmon-monitorando-o-storage.aspx">Perfmon: Monitorando o Storage</a></strong></li>   </ul>    <p><strong> Checklist</strong></p>    <ul>     <li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/08/checklist-performance-do-servidor-windows.aspx">Checklist: Performance do Servidor (Windows)</a></li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/15/checklist-performance-do-servidor-sql.aspx">Checklist: Performance do Servidor (SQL)</a>        <br></li>   </ul></blockquote></p>
