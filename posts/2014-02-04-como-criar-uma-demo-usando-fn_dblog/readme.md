<a link='https://blogs.msdn.microsoft.com/fcatae/2014/02/04/como-criar-uma-demo-usando-fn_dblog/'>Como criar uma demo usando fn_dblog</a>
<p>Esses dias estive olhando v&aacute;rios artigos sobre SQL Server em busca de inspira&ccedil;&atilde;o. Descobri que a fun&ccedil;&atilde;o fn_dblog &eacute; uma das mais usadas para montar uma demonstra&ccedil;&atilde;o de &ldquo;internals&rdquo; do SQL Server. &Oacute;timo, pois agora &eacute; minha vez de mostrar algo sobre ela.</p>
<p><strong>Exemplo: </strong></p>
<blockquote>
<p>Podemos usar a fun&ccedil;&atilde;o fn_dblog para ilustrar o que acontece com um comando UPDATE ap&oacute;s passar por uma replica&ccedil;&atilde;o transacional.</p>
</blockquote>
<blockquote>
<p><strong>select * from ::fn_dblog(null,null)</strong></p>
</blockquote>
<ul>
<li>UPDATE (normal):</li>
</ul>
<blockquote>
<p><a href="images\5344.image_53B97E31.png"><img style="border: 0px currentcolor" title="image" src="images\7357.image_thumb_5C3CDD7B.png" alt="image" width="315" height="72" border="0" /></a></p>
</blockquote>
<ul>
<li>UPDATE (com replica&ccedil;&atilde;o):</li>
</ul>
<blockquote>
<p><a href="images\6403.image_4BC46C80.png"><img style="border: 0px currentcolor" title="image" src="images\0572.image_thumb_498A7475.png" alt="image" width="315" height="92" border="0" /></a></p>
<p>Como m&aacute;gica, revelamos que um comando UPDATE foi substitu&iacute;do pelo par de comandos (DELETE, INSERT).</p>
</blockquote>
<p>Esse foi um r&aacute;pido exemplo do porqu&ecirc; essa fun&ccedil;&atilde;o <strong>fn_dblog </strong>&eacute; t&atilde;o usada em demonstra&ccedil;&otilde;es - ela mostra muita coisa interessante e invis&iacute;veis ao olho humano.</p>
<p>A fun&ccedil;&atilde;o <strong>db_fnlog </strong>executa a leitura sequencial do log. Ela utiliza uma l&oacute;gica praticamente id&ecirc;ntica ao LogReader (sim, aquele rob&ocirc; usado pela replica&ccedil;&atilde;o transacional e Change Data Capture), usando o mecanismo chamado de &ldquo;Log Scan&rdquo;.</p>
<p>O seu funcionamento &eacute; bastante simples:</p>
<ol>
<li>Primeiro se localiza o in&iacute;cio do log (que normalmente corresponde ao &uacute;ltimo checkpoint nas bases de recovery simple)</li>
<li>Depois, os registros do log s&atilde;o carregados em mem&oacute;ria e decodificados no formato de tabela</li>
</ol>
<p>Agora v&atilde;o as minhas dicas sobre como montar uma Demo do Transaction Log:</p>
<p><strong>1. Comece &ldquo;limpando&rdquo; os logs usando o comando de CHECKPOINT</strong></p>
<p>A fun&ccedil;&atilde;o fn_dblog sempre procura o &uacute;ltimo checkpoint realizado. Ao &ldquo;limpar&rdquo; o log, somente tr&ecirc;s registros s&atilde;o reportados:</p>
<blockquote>
<p><a href="images\4213.image_6B09A404.png"><img title="image" src="images\3404.image_thumb_68CFABF9.png" alt="image" width="314" height="67" border="0" /></a></p>
</blockquote>
<p>O comando CHECKPOINT grava o ponto de in&iacute;cio (LOP_BEGIN_CKPT), descarrega as p&aacute;ginas em disco, atualiza a p&aacute;gina de boot com o &uacute;ltimo LSN (LOP_XACT_CKPT &ndash;&gt; LCX_BOOT_PAGE_CKPT) e finaliza sua transa&ccedil;&atilde;o (LOP_END_CKPT).</p>
<p><strong>2. Domine o conceito do Log Sequence Number (LSN)</strong></p>
<p>Sempre que voc&ecirc; olhar o arquivo de log, vai se deparar com o conceito de LSN. Com a fun&ccedil;&atilde;o <strong>db_fnlog</strong> n&atilde;o &eacute; diferente, pois a primeira coluna corresponde ao &ldquo;Current LSN&rdquo;. Assim recomendo que se acostume com o formato desse identificador.</p>
<blockquote>
<p>Log Sequence Number (LSN) <br /><a title="http://blogs.msdn.com/b/fcatae/archive/2010/02/24/log-sequence-number-lsn.aspx" href="http://blogs.msdn.com/b/fcatae/archive/2010/02/24/log-sequence-number-lsn.aspx">http://blogs.msdn.com/b/fcatae/archive/2010/02/24/log-sequence-number-lsn.aspx</a></p>
</blockquote>
<p>Resumindo: o primeiro hexadecimal corresponde ao Virtual Log File (VLF), enquanto que o segundo e o terceiro s&atilde;o o offset de deslocamento (LogBlock + Slot). </p>
<p><strong>3. Conhe&ccedil;a as estruturas de aloca&ccedil;&atilde;o do SQL Server</strong></p>
<p>Os cursos de internals normalmente falam das p&aacute;ginas GAM, SGAM e IAM e depois citam as estruturas de Allocation Unit, Partition e HoBT. Todas essas informa&ccedil;&otilde;es est&atilde;o presentes no log.</p>
<ul>
<li>Context</li>
<li>PartitionId</li>
<li>AllocUnitId (AllocUnitName)</li>
<li>Page ID / Slot ID</li>
</ul>
<p>A coluna <strong>AllocUnitName</strong> apresenta o nome do objeto, entretanto, essa informa&ccedil;&atilde;o n&atilde;o &eacute; armazenada no log. Na realidade, a fun&ccedil;&atilde;o determina o nome do objeto a partir do <strong>AllocUnitId</strong>.</p>
<p><strong>4. Por curiosidade, procure entender o que significa o Transaction SID e SPID.</strong></p>
<blockquote>
<p>Acredito que os &ldquo;amigos do sp_who&rdquo; saibam bem o significado de SPID. Em rela&ccedil;&atilde;o ao Transaction SID, procure pela fun&ccedil;&atilde;o SUSER_SNAME. Voc&ecirc; pode se surpreender! </p>
</blockquote>
<p><strong>5. Essa fun&ccedil;&atilde;o &eacute; <span style="text-decoration: underline">n&atilde;o documentada</span>. Portanto, evite rodar em uma base de produ&ccedil;&atilde;o. </strong></p>
<p>Uma alternativa &eacute; usar o XEvent. Veja o blog do Luti:</p>
<blockquote>
<p>Estudando o TLog usando xEvents <br /><a title="http://luticm.blogspot.com.br/2012/05/estudando-o-tlog-usando-xevents.html" href="http://luticm.blogspot.com.br/2012/05/estudando-o-tlog-usando-xevents.html">http://luticm.blogspot.com.br/2012/05/estudando-o-tlog-usando-xevents.html</a></p>
</blockquote>
