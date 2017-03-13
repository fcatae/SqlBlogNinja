<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/12/o-que-um-resource-semaphore/'>O que é um Resource Semaphore?</a>
<p>Semana passada consegui um &oacute;timo exemplo de um problema relacionado com a falta de mem&oacute;ria. No caso, a lentid&atilde;o do sistema estava relacionada com espera por recursos denominados &ldquo;Resource Semaphore&rdquo; &ndash; um problema comum para muitos sistemas. </p>
<p>Afinal, o que &eacute; um Resource Semaphore e como resolv&ecirc;-lo?</p>
<p><strong>Resposta Curta: </strong></p>
<blockquote>
<p><em>Resource Semaphore &eacute; um controle normal e interno do SQL Server, que &eacute; usado para evitar a sobrecarga de queries dentro do servidor. A resolu&ccedil;&atilde;o deste tipo de espera deve ser feita otimizando a query ou aumentando a quantidade de mem&oacute;ria do servidor.</em></p>
</blockquote>
<p><strong>Resposta Longa:</strong></p>
<p>A fim de explicar melhor o significado do Resource Semaphore, gostaria de dar um exemplo de uma <span style="text-decoration: underline">situa&ccedil;&atilde;o real</span> que enfrentei na semana passada.</p>
<p>Imagine o cen&aacute;rio de um servidor com 64GB de mem&oacute;ria que recebe simultaneamente 8 queries para serem processadas. Ap&oacute;s o processo de compila&ccedil;&atilde;o, determina-se que ser&aacute; utilizado HASH JOIN para fazer o relacionamento entre tabelas.</p>
<p>As opera&ccedil;&otilde;es de HASH JOIN s&atilde;o muito custosas e dependem do tamanho da tabela. No nosso caso real, as tabelas apresentam milh&otilde;es de registros (curiosidade: uma das tabelas tem 30 bilh&otilde;es de linhas!)</p>
<p>O otimizador SQL apresenta a estimativa de que essa query utilizar&aacute; 7GB de mem&oacute;ria de espa&ccedil;o tempor&aacute;rio para processar toda essa massa de dados.</p>
<p>Embora o servidor tenha 64GB de mem&oacute;ria dispon&iacute;vel, o Sistema Operacional utiliza por volta de 10GB. Assim, resta 54GB de mem&oacute;ria para o SQL Server.</p>
<p><strong>Pergunta: </strong>O que ocorre com o servidor SQL quando as 8 queries rodam simultaneamente? Considere que o servidor apresenta 54GB dispon&iacute;vel e cada query utiliza 7GB.</p>
<p>Uma matem&aacute;tica simples (8 queries x 7GB = 56GB) diz que faltar&aacute; mem&oacute;ria para o SQL Server.</p>
<p><strong>Resposta: </strong>H&aacute; um controle de concorr&ecirc;ncia dentro do SQL Server que evita m&uacute;ltiplos comandos executarem ao mesmo tempo, caso a soma de todos os recursos ultrapasse a mem&oacute;ria dispon&iacute;vel do SQL Server.</p>
<p>&nbsp;</p>
<h5>Monitorando o Servidor</h5>
<p>Utilizaremos uma DMV chamada sys.dm_exec_query_memory_grants para acompanhar a utiliza&ccedil;&atilde;o de mem&oacute;ria.</p>
<blockquote>
<pre class="code"><span style="color: blue">select </span><span style="color: gray">* </span><span style="color: blue">from </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_exec_query_memory_grants</span></pre>
</blockquote>
<p>O resultado est&aacute; apresentado (resumidamente) abaixo:</p>
<p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/7573.image_6.png"><img height="97" width="455" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/8004.image_thumb_2.png" alt="image" border="0" title="image" style="border-bottom: 0px;border-left: 0px;border-top: 0px;border-right: 0px" /></a> </p>
<p><strong>Interpreta&ccedil;&atilde;o:</strong></p>
<ol>
<li>Somente as sess&otilde;es que utilizam grande quantidade de mem&oacute;ria est&atilde;o listadas nessa DMV. Uma query bem otimizada n&atilde;o apareceria nessa view.</li>
<li>Todas as requisi&ccedil;&otilde;es come&ccedil;aram por volta das <strong>6:57 &ndash; 6:59</strong>, conforme mostra a coluna <strong>request_time</strong>.</li>
<li>Todas as queries est&atilde;o solicitando <strong>7814936kb</strong> de mem&oacute;ria (coluna <strong>requested_memory_kb</strong>) para uso tempor&aacute;rio, mem&oacute;ria denominada de Workspace = &ldquo;Espa&ccedil;o de trabalho&rdquo;.&nbsp; Isso n&atilde;o corresponde a Buffer Cache ou Procedure Cache.</li>
<li>Somente 4 queries conseguiram obter a mem&oacute;ria necess&aacute;ria para <span style="text-decoration: underline">iniciar o processamento</span>, que s&atilde;o as sess&otilde;es 74, 80, 89 e 75. Observe que a coluna <strong>grant_time </strong>corresponde ao &ldquo;hor&aacute;rio que o servidor concedeu mem&oacute;ria&rdquo;.</li>
<li>As demais sess&otilde;es (104, 111, 97, 90) est&atilde;o esperando por mem&oacute;ria. Enquanto isso, elas ficam suspensas at&eacute; que haja recursos suficientes para rod&aacute;-las. Por isso, observamos que <strong>grant_time = NULL</strong>.</li>
</ol>
<p>O passo 5 &eacute; exatamente o controle de concorr&ecirc;ncia do SQL Server: se n&atilde;o h&aacute; recursos suficientes para rodar todas as queries simultaneamente, ent&atilde;o algumas ficam enfileiradas esperando at&eacute; que a carga no servidor diminua.</p>
<p>Durante esse momento, a sess&atilde;o do usu&aacute;rio fica bloqueada por um RESOURCE_SEMAPHORE.</p>
<p>&nbsp;</p>
<p><strong>Como resolver?</strong></p>
<p>A presen&ccedil;a de RESOURCE_SEMAPHORE indica a falta de recurso no servidor para processar as requisi&ccedil;&otilde;es. Portanto, a resolu&ccedil;&atilde;o desse tipo de problema envolve:</p>
<ul>
<li>Otimizar a query com o objetivo de diminuir o tamanho do Workspace a ser utilizado. Ex: evitar opera&ccedil;&otilde;es de HASH e SORT envolvendo tabelas grandes.</li>
<li>Aumentar a quantidade de mem&oacute;ria RAM no servidor. </li>
</ul>
