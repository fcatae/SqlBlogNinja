<a link='https://blogs.msdn.microsoft.com/fcatae/2009/09/02/resource-monitor-notifications/'>Resource Monitor: Notifications</a>
<p>Durante o <strong>TechEd 2009</strong>, ouvi um coment&aacute;rio do <strong>Fernando Garcia </strong>(gente fina!) sobre o diagn&oacute;stico de problemas de falta de mem&oacute;ria usando a DMV: <strong>dm_os_ring_buffer </strong>e filtrando por registros do tipo <strong>RING_BUFFER_RESOURCE_MONITOR</strong>. Afinal, que tipo de informa&ccedil;&atilde;o fica armazenada?</p>
<p class="MsoNormal"><span style="font-size: xx-small"><span><span></span></span></span>&nbsp;</p>
<pre class="code"><span>SELECT </span><span>* </span><span>FROM </span><span>sys</span><span>.</span><span>dm_os_ring_buffers
</span><span>WHERE ring_buffer_type </span><span>= </span><span>'RING_BUFFER_RESOURCE_MONITOR'
</span><span>ORDER BY timestamp DESC
</span><p class="MsoNormal"><span style="font-size: xx-small"><span><span></span></span></span>&nbsp;</p><p>A primeira parte do resultado descreve qual o tipo de notifica&ccedil;&atilde;o.</p><pre><pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px"><span>&lt;</span><span>Record</span> <span>id</span>=<span>"0"</span> <span>type</span>=<span>"RING_BUFFER_RESOURCE_MONITOR"</span> <span>time</span>=<span>"146278552"</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;</span><span>ResourceMonitor</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>Notification</span><span>&gt;</span>RESOURCE_MEMPHYSICAL_HIGH<span>&lt;/</span><span>Notification</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>IndicatorsProcess</span><span>&gt;</span>0<span>&lt;/</span><span>IndicatorsProcess</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>IndicatorsSystem</span><span>&gt;</span>1<span>&lt;/</span><span>IndicatorsSystem</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>NodeId</span><span>&gt;</span>0<span>&lt;/</span><span>NodeId</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>Effect</span> <span>type</span>=<span>"APPLY_LOWPM"</span> <span>state</span>=<span>"EFFECT_OFF"</span> <span>reversed</span>=<span>"0"</span><span>&gt;</span>0<span>&lt;/</span><span>Effect</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>Effect</span> <span>type</span>=<span>"APPLY_HIGHPM"</span> <span>state</span>=<span>"EFFECT_ON"</span> <span>reversed</span>=<span>"0"</span><span>&gt;</span>0<span>&lt;/</span><span>Effect</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>Effect</span> <span>type</span>=<span>"REVERT_HIGHPM"</span> <span>state</span>=<span>"EFFECT_OFF"</span> <span>reversed</span>=<span>"0"</span><span>&gt;</span>0<span>&lt;/</span><span>Effect</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;/</span><span>ResourceMonitor</span><span>&gt;</span>
</pre>
</pre>
<p>Os eventos poss&iacute;veis s&atilde;o:</p>
<ul>
<li>RESOURCE_MEMPHYSICAL_HIGH </li>
<li>RESOURCE_MEMPHYSICAL_LOW </li>
<li>RESOURCE_MEM_STEADY </li>
<li>RESOURCE_MEMVIRTUAL_LOW</li>
</ul>
<p>Esses eventos podem ser internos/externos &agrave; inst&acirc;ncia do SQL Server, conforme a indica&ccedil;&atilde;o dos campos:</p>
<ul>
<li>IndicatorsProcess </li>
<li>IndicatorsSystem</li>
</ul>
<p>Resource Monitor far&aacute; o broadcast dessa notifica&ccedil;&atilde;o para todos os componentes de mem&oacute;ria.</p>
<p><br />A segunda parte detalha cada um dos Memory Nodes, apresentando a distribui&ccedil;&atilde;o de mem&oacute;ria entre os &ldquo;Allocators&rdquo;.</p>
<pre><pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;</span><span>MemoryNode</span> <span>id</span>=<span>"0"</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>ReservedMemory</span><span>&gt;</span>6282232<span>&lt;/</span><span>ReservedMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>CommittedMemory</span><span>&gt;</span>38712<span>&lt;/</span><span>CommittedMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>SharedMemory</span><span>&gt;</span>0<span>&lt;/</span><span>SharedMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>AWEMemory</span><span>&gt;</span>8192<span>&lt;/</span><span>AWEMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>SinglePagesMemory</span><span>&gt;</span>3208<span>&lt;/</span><span>SinglePagesMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>MultiplePagesMemory</span><span>&gt;</span>21896<span>&lt;/</span><span>MultiplePagesMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;/</span><span>MemoryNode</span><span>&gt;</span></pre>
</pre>
<p>&nbsp;</p>
<p>A terceira parte apresenta informa&ccedil;&otilde;es importantes sobre o status do Sistema Operacional e do processo do SQL Server.</p>
<pre><pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;</span><span>MemoryRecord</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>MemoryUtilization</span><span>&gt;</span>100<span>&lt;/</span><span>MemoryUtilization</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>TotalPhysicalMemory</span><span>&gt;</span>6222536<span>&lt;/</span><span>TotalPhysicalMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>AvailablePhysicalMemory</span><span>&gt;</span>3044516<span>&lt;/</span><span>AvailablePhysicalMemory</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>TotalPageFile</span><span>&gt;</span>12665292<span>&lt;/</span><span>TotalPageFile</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>AvailablePageFile</span><span>&gt;</span>9388376<span>&lt;/</span><span>AvailablePageFile</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>TotalVirtualAddressSpace</span><span>&gt;</span>8589934464<span>&lt;/</span><span>TotalVirtualAddressSpace</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>AvailableVirtualAddressSpace</span><span>&gt;</span>8583481552<span>&lt;/</span><span>AvailableVirtualAddressSpace</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">    <span>&lt;</span><span>AvailableExtendedVirtualAddressSpace</span><span>&gt;</span>0<span>&lt;/</span><span>AvailableExtendedVirtualAddressSpace</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px">  <span>&lt;/</span><span>MemoryRecord</span><span>&gt;</span>
</pre>
<pre style="background-color: #ffffff;margin: 0em;width: 100%;font-family: consolas,'Courier New',courier,monospace;font-size: 10px"><span>&lt;/</span><span>Record</span><span>&gt;</span></pre>
</pre>
<p>Descri&ccedil;&atilde;o dos campos: </p>
<ul>
<li><strong>MemoryUtilization</strong>: Utiliza&ccedil;&atilde;o de mem&oacute;ria RAM pelo SQL Server </li>
<li><strong>TotalPhysicalMemory</strong>: Quantidade total de mem&oacute;ria RAM </li>
<li><strong>AvailablePhysicalMemory</strong>: Mem&oacute;ria RAM dispon&iacute;vel </li>
<li><strong>TotalPageFile</strong>: Quantidade total de committed memory </li>
<li><strong>AvailablePageFile</strong>: Quantidade de committed memory dispon&iacute;vel </li>
<li><strong>TotalVirtualAddressSpace</strong>: Espa&ccedil;o virtual do processo </li>
<li><strong>AvailableVirtualAddressSpace</strong>: Espa&ccedil;o virtual dispon&iacute;vel</li>
</ul>
<p>A pr&oacute;xima pergunta &eacute; como analisar? N&atilde;o responderei isso nesse post.. mas pretendo em breve descrever como funciona o Resource Monitor e o gerenciamento de mem&oacute;ria do SQL Server.</p>
</pre>
<p><a href="http://11011.net/software/vspaste"></a></p>
