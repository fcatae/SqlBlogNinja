<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/26/dbcc-memorystatus-parte-i/'>DBCC MEMORYSTATUS (Parte I)</a>
<p>Esse comando DBCC MEMORYSTATUS sempre foi muito &uacute;til para investigar o consumo de mem&oacute;ria no SQL Server. No tempo do SQL 2000, era imposs&iacute;vel determinar a distribui&ccedil;&atilde;o de mem&oacute;ria sem o aux&iacute;lio desse comando n&atilde;o-documentado. A partir do SQL 2005, algumas informa&ccedil;&otilde;es podem ser encontradas em DMV&rsquo;s. </p>
<p>Esse post mostra como acompanhar a vis&atilde;o do SQL Server em rela&ccedil;&atilde;o ao ambiente externo (Sistema Operacional e outros processos). </p>
<p>O gerenciador de mem&oacute;ria (Memory Manager) pode alocar mem&oacute;ria virtual atrav&eacute;s de uma API denominada VirtualAlloc(). Nessa API, o espa&ccedil;o de mem&oacute;ria &eacute; previamente reservado e depois &ldquo;comitado&rdquo;. </p>
<blockquote>
<pre class="code"><span style="font-family: courier new,courier">Memory Manager                           KB          
---------------------------------------- ----------- 
VM Reserved                                 67639392 
VM Committed                                  505752 
Locked Pages Allocated                      59652352 
Reserved Memory                                 1024 
Reserved Memory In Use                             0 </span></pre>
</blockquote>
<p><a href="http://11011.net/software/vspaste"></a></p>
<p>No exemplo acima, observamos que o SQL Server reservou um espa&ccedil;o de aproximadamente 67GB (67639392 kb), representado por <strong>VM Reserved</strong>. A quantidade m&aacute;xima de mem&oacute;ria reservada &eacute; de 7TB para a plataforma 64-bits, ou seja, n&atilde;o h&aacute; grande preocupa&ccedil;&atilde;o. Se o servidor &eacute; de 32-bits, ent&atilde;o esse limite &eacute; de apenas 2GB.</p>
<p>O pr&oacute;ximo passo &eacute; investigar a quantidade de mem&oacute;ria &ldquo;comitada&rdquo; (<strong>VM Committed</strong>). Essa &eacute; a quantidade de mem&oacute;ria utilizada pelo SQL Server ainda usando a API VirtualAlloc(). Essa mem&oacute;ria pode ser paginada para disco (Pagefile) a qualquer momento. O exemplo apresenta 505MB (505752 kb) utilizados pelo SQL Server, valor muito pr&oacute;ximo ao que ser&aacute; reportado pelo Task Manager.</p>
<p>Observamos a mem&oacute;ria alocada atrav&eacute;s de Locked Pages e AWE, que corresponde a aproximadamente 59GB (59652352 kb) &ndash; <strong>Locked</strong> <strong>Pages Allocated</strong>. Essa mem&oacute;ria nunca ser&aacute; paginada. Para que o SQL Server tenha permiss&atilde;o para utilizar essa mem&oacute;ria, necessita-se do privil&eacute;gio <a target="_blank" href="http://blogs.msdn.com/b/fcatae/archive/2010/07/02/lock-pages-in-memory.aspx">Locked Pages in Memory</a>.</p>
<p>Por fim, o SQL Server deixa alocado 1MB de mem&oacute;ria em caso de emerg&ecirc;ncia (<strong>Reserved Memory</strong>). Por exemplo, uma situa&ccedil;&atilde;o cr&iacute;tica durante uma opera&ccedil;&atilde;o de ROLLBACK ocorre quando h&aacute; falta de mem&oacute;ria no servidor e nenhuma mem&oacute;ria pode ser alocada. Para garantir que as estruturas m&iacute;nimas sejam registradas no banco de dados, o banco de dados pode utilizar temporariamente <em>Reserved Memory</em>. (Felizmente) Nunca vi essa situa&ccedil;&atilde;o ocorrer. </p>
