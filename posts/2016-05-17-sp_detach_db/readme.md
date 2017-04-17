<a link='https://blogs.msdn.microsoft.com/fcatae/2016/05/17/sp_detach_db/'>sp_detach_db</a>
<p>Esse &eacute; mais um artigo da s&eacute;rie &ldquo;Saga da otimiza&ccedil;&atilde;o com comandos antigos&rdquo;<ul>   <li>Parte 1: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/22/set-statistics-io.aspx">SET STATISTICS IO</a></li>    <li>Parte 2: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/29/dbcc-dropcleanbuffers.aspx">DBCC DROPCLEANBUFFERS</a></li>    <li>Parte 3: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/05/dbcc-showcontig.aspx">DBCC SHOWCONTIG</a></li>    <li>Parte 4: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/12/dbcc-page.aspx">DBCC PAGE</a></li>    <li>Parte 5: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/19/sp-spaceused.aspx">sp_spaceused</a></li>    <li>Parte 6: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/26/dbcc-ind.aspx">DBCC IND</a></li>    <li>Parte 7: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/03/dbcc-indexdefrag.aspx">DBCC INDEXDEFRAG</a></li>    <li>Parte 8: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/10/dbcc-dbreindex.aspx">DBCC DBREINDEX</a></li> </ul><p>No &uacute;ltimo artigo, comentei sobre <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/10/dbcc-dbreindex.aspx">as melhores pr&aacute;ticas para escolha da chave do &iacute;ndice clustered</a>. O objetivo &eacute; minimizar a fragmenta&ccedil;&atilde;o ao mesmo tempo que tentamos ter algum benef&iacute;cio com a ordena&ccedil;&atilde;o.</p><h3>Table Scan</h3><p>At&eacute; agora falamos muito sobre as opera&ccedil;&atilde;o de Table Scan, seja ela usando Heap ou Index scan. Na realidade, vimos que o tempo &eacute; proporcional a quantidade de acesso ao disco. Por exemplo, se realizarmos 500 acessos ao disco com lat&ecirc;ncia de 3ms, ent&atilde;o teremos uma query demorando por volta de 1.500ms. </p><p>Falamos sobre o impacto das leituras read-ahead como otimiza&ccedil;&atilde;o de disco. Isso significa que podemos tentar combinar 50 leituras de blocos de 8kb em uma &uacute;nica leitura de 400kb. A lat&ecirc;ncia de disco geralmente varia pouco em rela&ccedil;&atilde;o ao tamanho do bloco.</p><p>Agora vamos mostrar o impacto de um disco muito lento sobre um table scan.</p><h3>Storage</h3><p>O primeiro passo ser&aacute; movimentar os dados para um disco supostamente mais r&aacute;pido. Existem duas formas para fazer isso: <strong>backup/restore</strong> ou <strong>detach/attach</strong>. A forma mais f&aacute;cil de copiar banco de dados entre m&aacute;quinas &eacute; atrav&eacute;s do <strong>backup/restore</strong>, mas <strong>detach/attach</strong> &eacute; a forma mais simples para movimentar os arquivos para outro disco da mesma m&aacute;quina.</p><p>Come&ccedil;aremos usando o comando <strong>sp_detach_db </strong>para remover a refer&ecirc;ncia o banco de dados <strong>LOJADB </strong>sem apagar os arquivos.</p><blockquote>   <p><a href="images\3515.image_74ED5AA2.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;margin: 0px;padding-right: 0px" border="0" alt="image" src="images\6813.image_thumb_048FF665.png" width="244" height="90"></a></p> </blockquote><p>Em muito casos, &eacute; recomend&aacute;vel configurar o banco de dados como SINGLE_USER. Se esse comando demorar muito, ent&atilde;o &eacute; interessante for&ccedil;ar a desconex&atilde;o dos demais usu&aacute;rios com WITH ROLLBACK IMMEDIATE.</p><blockquote>   <p><strong>ALTER DATABASE lojadb SET SINGLE_USER WITH ROLLBACK IMMEDIATE </strong></p> </blockquote><p>Agora os arquivos do banco de dados podem ser copiados para outro disco.</p><blockquote>   <p><a href="images\6560.image_38C41FAB.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\1817.image_thumb_05F41937.png" width="179" height="128"></a></p> </blockquote><p>Copiei os arquivos MDF e LDF para o disco F.</p><blockquote>   <p><a href="images\3730.image_2EFEB833.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\0447.image_thumb_1C49BE7C.png" width="196" height="100"></a></p> </blockquote><p>Em seguida, rodamos o comando de attach. Muitos podem pensar no <strong>sp_attach_db</strong>, que faz exatamente o que precisamos, mas prefiro usar o CREATE DATABASE. Eles fazem exatamente a mesma coisa.</p><blockquote>   <p><a href="images\4682.image_5A45DFEB.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;margin: 0px;padding-right: 0px" border="0" alt="image" src="images\1715.image_thumb_4E43EFB7.png" width="236" height="87"></a></p> </blockquote><p>Podemos fazer o teste e verificar o tempo total da query, que ficou em 395ms:</p><blockquote>   <p><a href="images\2480.image_3E37B1B1.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\2625.image_thumb_2B82B7FA.png" width="644" height="78"></a></p> </blockquote><p>Esse tempo est&aacute; melhor que <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/29/dbcc-dropcleanbuffers.aspx">o tempo original de 852ms</a>. O tempo de lat&ecirc;ncia desse novo storage foi de apenas 0,3ms!</p><h3>Problema: Sobrecarga do Storage</h3><p>J&aacute; passei por milhares de clientes e situa&ccedil;&otilde;es, mas a hist&oacute;ria &eacute; sempre igual: o novo storage tem uma performance excelente e resolver&aacute; todos os problemas. Essa &eacute; a frase que voc&ecirc; ouve antes da venda. Depois da venda, o desempenho continua excelente e ent&atilde;o conclui-se que a culpa era do storage antigo.</p><p>&Eacute; aqui que nasce um novo problema: sobrecarga do storage. </p><p>Com o tempo, &eacute; comum que compartilhar os recursos de storage (disco, controladora, switch) entre os servidores da empresa. N&atilde;o &eacute; dif&iacute;cil ver LUN&rsquo;s alocadas dentro do mesmo Disk Array ou Hosts sobrecarregando os links de comunica&ccedil;&atilde;o. Assim como &eacute; normal encontrar servidores VMWare armazenando imagens em controladoras compartilhadas com servidores de banco de dados. Essas s&atilde;o as situa&ccedil;&otilde;es de sobrecarga do storage.</p><p>Vou simular uma sobrecarga no storage fazendo duas coisas ao mesmo tempo:</p><ul>   <li>Executando a query no SQL Server</li>    <li>Copiando arquivos entre discos do storage</li> </ul><p>Aqui est&aacute; meu novo storage:</p><blockquote>   <p><a href="images\1055.image_4D6E1A7E.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\6746.image_thumb_75CA2047.png" width="214" height="307"></a></p> </blockquote><p>Iniciei a c&oacute;pia de arquivo:</p><blockquote>   <p><a href="images\4062.image_1BC2614F.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\8358.image_thumb_7DE3DD4D.png" width="365" height="195"></a></p> </blockquote><p>Iniciei a execu&ccedil;&atilde;o da query:</p><blockquote>   <p><a href="images\5025.image_7FB43314.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\1667.image_thumb_01F0BBD1.png" width="290" height="103"></a></p> </blockquote><p>A query executou em 1812ms (4 vezes mais lento do que o baseline de 395ms).</p><p><a href="images\7633.image_77BF2163.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\5684.image_thumb_432155D9.png" width="644" height="83"></a></p><p>Vamos supor que a tabela esteja fragmentada e, por isso, as opera&ccedil;&otilde;es de read-ahead est&atilde;o desligadas:</p><blockquote>   <p><a href="images\3247.image_1940E1A4.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;margin: 0px;padding-right: 0px" border="0" alt="image" src="images\2783.image_thumb_424B80A0.png" width="186" height="57"></a></p> </blockquote><p>Embora isso pare&ccedil;a uma trapa&ccedil;a, &eacute; bem provavel que isso esteja acontecendo no servidor de produ&ccedil;&atilde;o: forwarding records, extent fragmentation, page density, page splits. Ent&atilde;o vamos simular qual seria o tempo em uma tabela fragmentada e com a c&oacute;pia de dados ainda em progresso:</p><p><a href="images\5554.image_4B3B12DF.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\4251.image_thumb_4D779B9B.png" width="644" height="93"></a></p><p>Certamente esse &eacute; nosso recorde: 58.987ms, ou seja, a query ficou rodando aproximadamente 1 minuto.</p><p>Podemos analisar o lat&ecirc;ncia de disco para saber quem &eacute; o culpado: foram realizados 1257 I/O em um per&iacute;odo de 58.987ms. Isso resulta em uma lat&ecirc;ncia m&eacute;dia de 47ms por leitura. Usando o <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/08/checklist-performance-do-servidor-windows.aspx">checklist do windows</a>, podemos classificar o tempo como <strong><u>no limite</u></strong>.</p><ul>   <li><font style="background-color: #ffff00">&lt;1ms : inacredit&aacute;vel </font></li>    <li>&lt;3ms : excelente </li>    <li>&lt;5ms : muito bom </li>    <li>&lt;10ms : dentro do esperado </li>    <li>&lt;20ms : razo&aacute;vel </li>    <li><font style="background-color: #ffff00">&lt;50ms : limite </font></li>    <li>&gt;100ms : ruim </li>    <li>&gt; 1 seg : conten&ccedil;&atilde;o severa de disco </li>    <li>&gt; 15 seg : problemas graves com o storage</li> </ul><p>Por que houve uma degrada&ccedil;&atilde;o t&atilde;o grande? Porque sa&iacute;mos de uma lat&ecirc;ncia de 0,3ms (inacredit&aacute;vel) para 47ms (limite). O problema n&atilde;o &eacute; exatamente o storage, mas a quantidade de I/O necess&aacute;rio para responder a query.</p><h3>Conclus&atilde;o</h3><p>Nesse artigo chegamos ao limite da query:</p><blockquote>   <p><strong>SELECT * FROM produtos WHERE id = 1234</strong></p> </blockquote><p>Ela pode realizar 1257 acessos ao disco para retornar apenas 1 registro. Existem v&aacute;rias formas de diminuir o impacto desses 1257 I/O:</p><ul>   <li>Agregar as opera&ccedil;&otilde;es de I/O usando o Read-ahead e blocos grandes</li>    <li>Manter os dados em cache (mem&oacute;ria)</li>    <li>Atualizar o storage para uma vers&atilde;o mais moderna com maior capacidade de I/O</li> </ul><p>Essa &eacute; a an&aacute;lise de infraestrutura. E qual seria a an&aacute;lise de desenvolvimento? Ser&aacute; que &eacute; poss&iacute;vel reduzir o n&uacute;mero de I/O dessa query? A resposta &eacute; sim! Usando um m&eacute;todo chamado SEEK ao inv&eacute;s de SCAN. </p><p>No pr&oacute;ximo artigo vamos introduzir o conceito do Seek.</p></p>
