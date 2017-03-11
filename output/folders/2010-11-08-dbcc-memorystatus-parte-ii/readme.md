<a link='https://blogs.msdn.microsoft.com/fcatae/2010/11/08/dbcc-memorystatus-parte-ii/'>DBCC MEMORYSTATUS (Parte II)</a>
<p>Continuando o artigo sobre o <a href="http://blogs.msdn.com/b/fcatae/archive/2010/07/26/dbcc-memorystatus-parte-1.aspx" target="_blank">DBCC MEMORYSTATUS</a>, comentaremos sobre o trecho que fala sobre os contadores globais de memória da máquina e do processo do SQL Server.</p>  <p><strong>Process/System Counts:</strong></p>  <blockquote>   <pre class="code">Process/System Counts                    Value                
---------------------------------------- -------------------- 
Available Physical Memory                          3808894976 
Available Virtual Memory                        8726174752768 
Available Paging File                             72376823808 
Working Set                                         569122816 
Percent of Committed Memory in WS                         100 
Page Faults                                           2837379 
System physical memory high                                 1 
System physical memory low                                  0 
Process physical memory low                                 0 
Process virtual memory low                                  0 
<br /></pre>
</blockquote>

<p>Identificamos a quantidade de memória disponível através dos contadores “AVAILABLE …”:</p>

<ul>
  <li><strong>Available Physical Memory</strong> – Quantidade de memória RAM livre na máquina. Esse contador é extremamente importante e deve se manter constante. </li>

  <li><strong>Available Virtual Memory</strong> – Memória que pode ser reservada dentro do processo do SQL Server. Na plataforma 32-bits, a reserva de memória virtual era limitada a 2GB ou 3GB. Na plataforma 64-bits, esse valor sobe para 7 ou 8TB. Usualmente encontram-se valores entre 100-300kb nas máquinas 32-bits, e ignora-se esse valor nas máquinas 64-bits.</li>

  <li><strong>Available Paging File</strong> – Espaço disponível para alocação de “Committed Memory”, que inclui o arquivo de Page file disponível somada a memória RAM. Normalmente esse valor não é uma limitação para o SQL Server, mas pode impactar os processos do Sistema Operacional. Esse valor jamais deve chegar em zero, caso contrário, qualquer componente do Windows (inclusive o Cluster e a Kernel) pode falhar por falta de memória.</li>
</ul>

<p>Um fator muito importante para se avaliar é a quantidade de memória alocada x memória RAM, que devem ser valores muito próximos. Esse fator está indicado por “Percent of Committed Memory in Working Set (WS)” e sempre que possível deve ser 100%. Se forem encontrados valores em torno de 50, isso indica que 50% da memória alocada para o SQL Server está em RAM e o demais em Page File, que é uma situação ruim.</p>

<p>SQL Server monitora continuamente o ambiente interno e externo através dos “sinais” chamados:</p>

<ul>
  <li><strong>System physical memory high</strong> – Sistema Operacional apresenta muita memória disponível que pode ser utilizada pelo SQL Server </li>

  <li><strong>System physical memory low</strong> – Sistema necessita memória RAM e solicita que o SQL Server diminua o consumo do recurso </li>

  <li><strong>Process physical memory low</strong> – Os componentes internos do SQL Server necessitam rebalanceamento de memória </li>

  <li><strong>Process virtual memory low</strong> – O processo do SQL Server apresenta pouca memória virtual e futuras reservas podem falhar </li>
</ul>

<p>A partir do SQL Server 2008, essas informações estão disponíveis em DMV.</p>

<ul>
  <li><a href="http://msdn.microsoft.com/en-us/library/bb510493.aspx" target="_blank">sys.dm_os_sys_memory</a> </li>

  <li><a href="http://msdn.microsoft.com/en-us/library/bb510747.aspx" target="_blank">sys.dm_os_process_memory</a> </li>
</ul>

<p><strong>[Nov/9] </strong>Agradeço aos comentários do Rodrigo por corrigir um erro do artigo: resultado de “Available Paging File” corresponde ao Committed Memory, e não exatamente ao arquivo do Page File. O conceito de Committed memory engloba tanto a memória RAM como o Page File, sendo igual a soma de ambos.</p>
