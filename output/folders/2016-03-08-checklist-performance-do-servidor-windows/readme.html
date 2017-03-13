<a link='https://blogs.msdn.microsoft.com/fcatae/2016/03/08/checklist-performance-do-servidor-windows/'>Checklist: Performance do Servidor (Windows)</a>
Podemos criar um breve checklist sobre como validar a infraestrutura de um servidor SQL usando o Performance Monitor.
<blockquote><strong>Artigo complementar: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/15/checklist-performance-do-servidor-sql.aspx">Checklist: Performance do Servidor (SQL)</a>

<strong>Desafio: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/16/desafio-analisando-servidor-com-perfmon.aspx">Analisando Servidor com Perfmon</a></strong></blockquote>
A análise da infraestrutura sob a ótica do Windows é dividida nos seus principais recursos: CPU, memória, storage e rede.
<h3><strong>CPU</strong></h3>
Monitoração do consumo de CPU no servidor.
<ul>
	<li><strong>Processor: %Processor Time</strong>: verificar se o consumo de CPU está abaixo de 80%. É importante manter uma margem de 10-20% para permitir um eventual pico de utilização.</li>
	<li><strong>Processor: </strong><strong>%Privileged Time</strong>: verificar se o consumo em Kernel Time está abaixo de 30%. Não faz sentido um servidor de banco de dados gastar mais tempo em Kernel executando tarefa de sistemas ao invés de executar as queries SQL.</li>
	<li><strong>System: Processor Queue Length: </strong>monitorar esse valor ao longo do tempo e comparar com o consumo de CPU. Alto consumo de CPU associado a filas de processador indicam que existem processos externos afetando o desempenho do SQL Server.</li>
</ul>
&nbsp;
<h3><strong>Memória</strong></h3>
Monitoração da memória disponível no SO e consumo interno da Kernel.
<ul>
	<li><strong>Memory: Available MB: </strong>monitorar esse contador ao longo do tempo e garantir que ele está sempre acima de 100MB. Caso haja momentos em que esse indicador fique muito baixo, recomenda-se configurar ou diminuir o “Max Server Memory” do servidor SQL Server e garantir que sempre haja memória disponível.</li>
	<li><strong>Memory: Pool Nonpaged Bytes: </strong>analisar se a quantidade de Nonpaged Pool se mantém constante ao longo dos dias ou se há indícios de memory leak. Isso pode indicar um problema em drivers de Kernel e afeta a estabilidade do SO.</li>
	<li><strong>Memory: Pool Paged Bytes:</strong> analisar se a quantidade de Paged Pool se mantém constante ao longo dos dias ou se há indícios de memory leak. Isso pode indicar um problema em drivers de Kernel e afeta a estabilidade do SO.</li>
</ul>
&nbsp;
<h3>Storage</h3>
A análise do storage foi detalhada no <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/01/perfmon-monitorando-o-storage.aspx">artigo Monitorando o Storage</a>. O ideal é conduzir uma análise individualizada por volume do disco ao invés de consolidar em uma única análise.

A carga pode ser medida em IOPS. Altos valores de IOPS causam gargalos em discos mecânicos FC, SCSI, SAS, SATA.
<ul>
	<li><strong>Disk Reads/sec:</strong> calcular o número de leituras em um disco de dados. Na teoria, essas leituras possuem característica aleatória e em blocos de 8Kb. No entanto, é comum encontrar servidores realizando table scan e causando leituras sequenciais e blocos maiores que 8Kb. Portanto, é possível determinar a natureza da leitura (aleatória ou sequencial) através do tamanho dos blocos de escrita (contador <strong>Disk Bytes/Read</strong>). Valores de referência:
<ul>
	<li>100 IOPS = Disco 7200 RPM</li>
	<li>150 IOPS = Disco 10k RPM</li>
	<li>175 IOPS = Disco 15k RPM</li>
	<li>10.000 IOPS = Disco SSD</li>
</ul>
</li>
	<li><strong>Disk Writes/sec:</strong> ignorar o número de escritas no disco de dados. Ignorar esse contador nos discos do tempdb: log e dados. Calcular o IOPS nos discos de log. Idealmente esse valor deve ficar abaixo de 200, embora seja aceitável atingir até 1000 IOPS. Normalmente as escritas são aceleradas através de um write-cache no storage.</li>
	<li><strong>Disk Transfers/sec: </strong>soma dos IOPS de escrita e leitura. Utilizar esse contador quando precisar de uma análise simplificada sobre a carga.</li>
</ul>
A carga pode ser medida em MB/s. Altos valores na taxa de transferência causam gargalos nas interfaces de disco e cabos de interconexão
<ul>
	<li><strong>Disk Read Bytes/sec:</strong> calcular a taxa de transferência de leitura. Não existe um limite para esse valor. Sugestão de
<ul>
	<li>20 MB/s: baixo</li>
	<li>100 MB/s: normal</li>
	<li>200 MB/s: alto (equivalente a Fiber Channel 2Gbit)</li>
</ul>
</li>
	<li><strong>Disk Write Bytes/sec:</strong> calcular a taxa de transferência de escrita. Entretanto, existem algumas considerações:
<ul>
	<li>Disco de dados: fluxo de escrita é causado pelo processo de checkpoint, que pode aumentar a concorrência de escrita e afetar indiretamente a latência do storage</li>
	<li>Disco de log: quase sempre a taxa de escrita é baixa (abaixo de 20MB/s) porque os pacotes são pequenos</li>
</ul>
</li>
	<li><strong>Disk Bytes/sec:</strong> soma da taxa de transferência de leitura e escrita. Utilizar esse contador quando precisar de uma análise simplificada sobre a carga.</li>
</ul>
A latência do disco é a principal medida em relação ao storage:
<ul>
	<li><strong>Avg Disk Sec/Read</strong>: Validar se a latência do disco está dentro da expectativa. Em geral, adotam-se valores máximos de 50 a 100ms como tempo de respostas para o disco de dados. Uma sugestão de tempos:
<ul>
	<li>&lt;1ms : inacreditável</li>
	<li>&lt;3ms : excelente</li>
	<li>&lt;5ms : muito bom</li>
	<li>&lt;10ms : dentro do esperado</li>
	<li>&lt;20ms : razoável</li>
	<li>&lt;50ms : limite</li>
	<li>&gt;100ms : ruim</li>
	<li>&gt; 1 seg : contenção severa de disco</li>
	<li>&gt; 15 seg : problemas graves com o storage</li>
</ul>
</li>
	<li><strong>Avg Disk Sec/Write</strong>: Validar se a latência do disco está dentro da expectativa. Ignore esse valor para os discos de dados. Utilize esse contador para os discos de log com latências reduzidas:
<ul>
	<li>&lt;1ms : excelente</li>
	<li>&lt;3ms : bom</li>
	<li>&lt;5ms : razoável</li>
	<li>&lt;10ms : limite</li>
	<li>&gt;20ms : ruim</li>
	<li>&gt; 1 seg : contenção severa de disco</li>
	<li>&gt; 15 seg : problemas graves com o storage
<ul><!--EndFragment--></ul>
</li>
</ul>
</li>
	<li><strong>Avg Disk Sec/Transfer: </strong>Média ponderada entre os tempos de leitura e escrita. Utilizar esse contador quando precisar de uma análise simplificada sem a necessidade de olhar dois contadores (Read e Write) ao mesmo tempo. <!--EndFragment--></li>
</ul>
Adicionalmente, pode ser incluído o contador de “outstanding I/O”.
<ul>
	<li><strong>Current Disk Queue Length: </strong>corresponde ao número de requisições de I/O que estão ativas esperando por uma resposta do storage ou enfileiradas na HBA. Infelizmente esse contador é confundido com o “Avg Disk Queue Length”, que não possui o mesmo significado. Se o tempo de latência estiver adequado, é possível fazer o ajuste do parâmetro de “Queue Depth” da placa HBA. Dessa forma, o host pode aumentar o número de I/O enviados ao storage e diminuir a fila da HBA. Esse é um parâmetro específco por placa (ex: Emulex, QLogic, etc).</li>
</ul>
&nbsp;
<h3>Rede</h3>
Monitoração do tráfego de rede.
<ul>
	<li><strong>Bytes Received/sec:</strong> calcular a taxa de dados recebidos pela rede. Esse valor é sempre baixo, pois corresponde aos pacotes com comandos. A exceção é durante a recepção de cargas BCP. Valores de referência:
<ul>
	<li>5MB/s : normal</li>
	<li>10MB/s: alto</li>
	<li>100MB/s: muito alto (equivalente a uma placa Ethernet 1Gbit)</li>
</ul>
</li>
	<li><strong>Bytes Sent/sec: </strong>calcular a taxa de dados enviados pela rede. Esse valor é superior à quantidade de dados recebidos, pois corresponde ao conjunto de dados a ser retornado ao cliente.
<ul>
	<li>10MB/s : normal</li>
	<li>20MB/s : alto</li>
	<li>100MB/s: muito alto (equivalente a uma placa Ethernet 1Gbit)</li>
</ul>
</li>
	<li><strong>Bytes Total/sec: </strong>soma de dados recebidos e enviados pela rede. Utilizar esse contador quando precisar de uma análise simplificada do tráfego de rede.</li>
</ul>
&nbsp;
<h1>Referência</h1>
Os demais artigos dessa série estão listados abaixo.
<blockquote><strong>Artigo: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/12/perfmon-falso-sentido-de-monitoracao.aspx">Perfmon- Falso Sentido de Monitoração</a>

<strong>Artigo: Os 7 Grandes Mitos do Perfmon:</strong>
<ul>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/19/os-7-grandes-mitos-do-perfmon-parte-1.aspx">Parte 1: Buffer Cache Hit Ratio, Average Disk Queue Length e %Disk Busy</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/26/os-7-grandes-mitos-do-perfmon-parte-2.aspx">Parte 2: Paging File:%Usage, Memory: Page Faults/sec e Memory: Pages/sec</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/02/os-7-grandes-mitos-do-perfmon-parte-3.aspx">Parte 3: SQL Access Methods: Page Splits/sec, SQL Locks: Lock Waits/sec e SQL General Statistics: User Connections</a></li>
</ul>
</blockquote>
<blockquote><strong>Artigo: </strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/09/contadores-do-perfmon.aspx">Contadores do Perfmon</a>

<strong>Desafio: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/16/desafio-analisando-servidor-com-perfmon.aspx">Analisando Servidor com Perfmon</a></strong>

<strong>Artigo: Monitorando com o Perfmon</strong>
<ul>
	<li><strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/02/23/perfmon-monitorando-o-buffer-manager.aspx">Perfmon: Monitorando o Buffer Manager</a></strong></li>
	<li><strong><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/01/perfmon-monitorando-o-storage.aspx">Perfmon: Monitorando o Storage</a></strong></li>
</ul>
<strong>Checklist</strong>
<ul>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/08/checklist-performance-do-servidor-windows.aspx">Checklist: Performance do Servidor (Windows)</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/15/checklist-performance-do-servidor-sql.aspx">Checklist: Performance do Servidor (SQL)</a></li>
</ul>
</blockquote>
