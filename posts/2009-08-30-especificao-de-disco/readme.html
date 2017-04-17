<a link='https://blogs.msdn.microsoft.com/fcatae/2009/08/30/especificao-de-disco/'>Especificação de Disco</a>
<p>No post anterior, comentei sobre a parte mec&acirc;nica do disco. Agora vamos ler a especifica&ccedil;&atilde;o de um disco e entender de que forma podemos otimizar sua performance ao m&aacute;ximo.</p>
<p>Escolhi um disco Savvio 15K RPM 146GB. <br /><a href="http://www.seagate.com/www/en-us/products/servers/savvio/savvio_15k.2"><span style="font-size: xx-small">http://www.seagate.com/www/en-us/products/servers/savvio/savvio_15k.2</span></a></p>
<p>A especifica&ccedil;&atilde;o do disco &eacute; semelhante ao quadro abaixo:</p>
<table style="width: 419px;margin-left: -1.5pt;border-collapse: collapse" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td style="background: #909090;padding: 1.5pt" width="265"><span style="color: #ffffff">Capacity</span></td>
<td style="background: #909090;padding: 1.5pt" width="152">&nbsp;&nbsp;</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Formatted Capacity</td>
<td style="padding: 1.5pt" width="152">146.8 GB</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Interface</td>
<td style="padding: 1.5pt" width="152">3-Gbit/s SAS</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">External Transfer Rate <br />(Host to/from Buffer)</td>
<td style="padding: 1.5pt" width="152">300 MB/s</td>
</tr>
<tr>
<td style="background: #909090;padding: 1.5pt" width="265"><span style="color: #ffffff">Performance</span></td>
<td style="background: #909090;padding: 1.5pt" width="152">&nbsp;&nbsp;</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Spindle Speed</td>
<td style="padding: 1.5pt" width="152">15K RPM</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Average Latency (ms)</td>
<td style="padding: 1.5pt" width="152">2.0 ms</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Average Read/Write Seek Time</td>
<td style="padding: 1.5pt" width="152">2.9/3.3 ms</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Track-to-track Time</td>
<td style="padding: 1.5pt" width="152">0.2 ms</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Sustained Transfer Rate <br />(Outer to Inner)</td>
<td style="padding: 1.5pt" width="152">160 - 122MB/s</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Internal Transfer Rate <br />(Buffer to/from Disk)</td>
<td style="padding: 1.5pt" width="152">160 MB/s (max)</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Cache <br />(Internal Buffer)</td>
<td style="padding: 1.5pt" width="152">16 MB</td>
</tr>
<tr>
<td style="background: #909090;padding: 1.5pt" width="265"><span style="color: #ffffff">Configuration</span></td>
<td style="background: #909090;padding: 1.5pt" width="152">&nbsp;&nbsp;</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Disks</td>
<td style="padding: 1.5pt" width="152">2</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Heads</td>
<td style="padding: 1.5pt" width="152">4</td>
</tr>
<tr>
<td style="padding: 1.5pt" width="265">Sector Size</td>
<td style="padding: 1.5pt" width="152">512 bytes</td>
</tr>
</tbody>
</table>
<p>A <b>interface</b> corresponde a forma de comunica&ccedil;&atilde;o entre o disco e a controladora, sendo as mais comuns: ATA, SATA, SCSI, SAS e FC. No exemplo do disco Savvio, a interface usada &eacute; SAS com 3-GBit, que permite a transfer&ecirc;ncia de 300 MB/s.</p>
<p>Em seguida, observamos a velocidade de rota&ccedil;&atilde;o do disco (<b>spindle speed</b>). Em servidores, as velocidades mais comuns s&atilde;o 7200, 10000 e 15000 RPM - enquanto meu notebook roda a modestos 5400 RPM. A velocidade do motor influencia diretamente na performance do disco, portanto, vamos ficar de olho nele!</p>
<p>Os tempos de posicionamento:</p>
<ul>
<li><b>Average Latency</b>: Tempo necess&aacute;rio para posicionar o cabe&ccedil;ote no setor correspondente. Esse tempo depende exclusivamente da velocidade de rota&ccedil;&atilde;o do motor (spindle)</li>
<li><b>Average Read/Write Seek Time</b>: Tempo m&eacute;dio necess&aacute;rio para o atuador posicionar o cabe&ccedil;ote no track correspondente.</li>
<li><b>Track-to-track Time</b>: Tempo necess&aacute;rio para o atuador movimentar-se para o track adjacente.</li>
</ul>
<p>Seguindo os valores especificados para o disco, &eacute; necess&aacute;rio aproximadamente 3ms para posicionar o cabe&ccedil;ote no track e mais 2ms para posicionar no setor correto. Caso seja necess&aacute;rio deslizar o cabe&ccedil;ote para o track seguinte, ent&atilde;o ser&atilde;o gastos mais 0,2ms. Essas opera&ccedil;&otilde;es de milissegundos s&atilde;o uma eternidade para o computador, por isso, o tempo de acesso corresponde normalmente ao gargalo.</p>
<p>Uma vez posicionado no setor correto, a leitura inicia-se com uma taxa de transfer&ecirc;ncia entre 122-160 MB/s. Essa informa&ccedil;&atilde;o pode ser obtida atrav&eacute;s do <b>Sustained Transfer Rate</b> ou <b>Internal Transfer Rate</b>.</p>
<p>Todos os discos apresentam um cache interno denominado <b>Buffer</b>.</p>
<p>Por fim, temos a caracter&iacute;stica geom&eacute;trica do disco: 2 platters, 4 heads e setores de 512 bytes.</p>
<p>Comparando alguns discos:&nbsp;</p>
<ul>
<li>Disco 1: Constellation 160GB</li>
<li>Disco 2: Savvio 10k RPM 73GB</li>
<li>Disco 3: Savvio 15k RPM 73GB</li>
<li>Disco 4: Savvio 15k RPM 146GB</li>
</ul>
<table style="width: 423px" class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Disco</td>
<td style="width: 46.5pt;padding: 0in" width="62">1</td>
<td style="width: 47.25pt;padding: 0in" width="63">2</td>
<td style="width: 48pt;padding: 0in" width="64">3</td>
<td style="width: 44.25pt;padding: 0in" width="59">4</td>
</tr>
<tr>
<td style="width: 129.75pt;background: #a6a6a6;padding: 0in" width="173"><span style="color: #ffffff">Capacity</span></td>
<td style="width: 46.5pt;background: #a6a6a6;padding: 0in" width="62">&nbsp;</td>
<td style="width: 47.25pt;background: #a6a6a6;padding: 0in" width="63">&nbsp;</td>
<td style="width: 48pt;background: #a6a6a6;padding: 0in" width="64">&nbsp;</td>
<td style="width: 44.25pt;background: #a6a6a6;padding: 0in" width="59">&nbsp;</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Capacity (GB)</td>
<td style="width: 46.5pt;padding: 0in" width="62">160</td>
<td style="width: 47.25pt;padding: 0in" width="63">73</td>
<td style="width: 48pt;padding: 0in" width="64">73</td>
<td style="width: 44.25pt;padding: 0in" width="59">146</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Interface</td>
<td style="width: 46.5pt;padding: 0in" width="62">SATA</td>
<td style="width: 47.25pt;padding: 0in" width="63">SAS</td>
<td style="width: 48pt;padding: 0in" width="64">SAS</td>
<td style="width: 44.25pt;padding: 0in" width="59">SAS</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">External Transfer Rate (MB/s)</td>
<td style="width: 46.5pt;padding: 0in" width="62">300</td>
<td style="width: 47.25pt;padding: 0in" width="63">300</td>
<td style="width: 48pt;padding: 0in" width="64">300</td>
<td style="width: 44.25pt;padding: 0in" width="59">300</td>
</tr>
<tr>
<td style="width: 129.75pt;background: #a6a6a6;padding: 0in" width="173"><span style="color: #ffffff">Performance</span></td>
<td style="width: 46.5pt;background: #a6a6a6;padding: 0in" width="62">&nbsp;</td>
<td style="width: 47.25pt;background: #a6a6a6;padding: 0in" width="63">&nbsp;</td>
<td style="width: 48pt;background: #a6a6a6;padding: 0in" width="64">&nbsp;</td>
<td style="width: 44.25pt;background: #a6a6a6;padding: 0in" width="59">&nbsp;</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Spindle Speed (RPM)</td>
<td style="width: 46.5pt;padding: 0in" width="62">7200</td>
<td style="width: 47.25pt;padding: 0in" width="63">10k</td>
<td style="width: 48pt;padding: 0in" width="64">15K</td>
<td style="width: 44.25pt;padding: 0in" width="59">15K</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Average Latency (ms)</td>
<td style="width: 46.5pt;padding: 0in" width="62">4.16</td>
<td style="width: 47.25pt;padding: 0in" width="63">3.0</td>
<td style="width: 48pt;padding: 0in" width="64">2.0</td>
<td style="width: 44.25pt;padding: 0in" width="59">2.0</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Average Seek Time (ms)</td>
<td style="width: 46.5pt;padding: 0in" width="62">8.5/9.5</td>
<td style="width: 47.25pt;padding: 0in" width="63">3.8/4.4</td>
<td style="width: 48pt;padding: 0in" width="64">2.9/3.3</td>
<td style="width: 44.25pt;padding: 0in" width="59">2.9/3.3</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Track-to-track Time (ms)</td>
<td style="width: 46.5pt;padding: 0in" width="62">0.8</td>
<td style="width: 47.25pt;padding: 0in" width="63">0.2</td>
<td style="width: 48pt;padding: 0in" width="64">0.2</td>
<td style="width: 44.25pt;padding: 0in" width="59">0.2</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Transfer Rate (MB/s)</td>
<td style="width: 46.5pt;padding: 0in" width="62">N/A</td>
<td style="width: 47.25pt;padding: 0in" width="63">89-55</td>
<td style="width: 48pt;padding: 0in" width="64">160-122</td>
<td style="width: 44.25pt;padding: 0in" width="59">160-122</td>
</tr>
<tr>
<td style="width: 129.75pt;padding: 0in" width="173">Cache (MB)</td>
<td style="width: 46.5pt;padding: 0in" width="62">32</td>
<td style="width: 47.25pt;padding: 0in" width="63">16</td>
<td style="width: 48pt;padding: 0in" width="64">16</td>
<td style="width: 44.25pt;padding: 0in" width="59">16</td>
</tr>
</tbody>
</table>
<p></p>
<p>Esse resultado mostra que a capacidade do disco n&atilde;o tem rela&ccedil;&atilde;o com performance. Devemos sempre olhar a velocidade de rota&ccedil;&atilde;o do disco &ndash; 15000 RPM &eacute; o disco mais r&aacute;pido. Outro ponto interessante &eacute; que a interface n&atilde;o influenciou na escolha do disco. Todas as interfaces permitem a transfer&ecirc;ncia de 300 MB/s, muito superior ao Transfer Rate dos discos.</p>
