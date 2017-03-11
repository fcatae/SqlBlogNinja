<a link='https://blogs.msdn.microsoft.com/fcatae/2015/10/14/lock-convoy/'>Lock Convoy</a>
<p>Voc&ecirc; sabe o que &eacute; Lock Convoy? (Dica: n&atilde;o tem nada a ver com os locks e bloqueios do SQL Server).</p>
<blockquote>
<p>J&aacute; havia presenciado esse problema na faculdade. Fomos fazer um trabalho em grupo com 20 pessoas. A matem&aacute;tica era que, se uma pessoa conseguiria fazer o trabalho em 8 horas, ent&atilde;o terminar&iacute;amos em quest&atilde;o de minutos ao juntar 20 pessoas. O resultado foi exatamente o oposto. Demoramos mais tempo discutindo a distribui&ccedil;&atilde;o de tarefa ao inv&eacute;s de fazer a tarefa. Lock convoy!</p>
</blockquote>
<p>Esse comportamento chamado LOCK CONVOY ocorre quando v&aacute;rias threads tentam acessar um mesmo recurso e perdem mais tempo do que se fosse apenas por uma thread. Seria algo como uma "escalabilidade negativa" devido ao bloqueio.</p>
<p>Enquanto levantava refer&ecirc;ncias, encontrei outras varia&ccedil;&otilde;es para esse comportamento, como por exemplo: <a href="https://en.wikipedia.org/wiki/Thundering_herd_problem">Thundering herd problem (Wikipedia)</a>. L&aacute; encontramos uma refer&ecirc;ncia para a ocorr&ecirc;ncia do problema no Linux.</p>
<blockquote>
<p><em>A discussion of this observation on Linux <br /></em><a title="https://lkml.org/lkml/2004/5/2/108" href="https://lkml.org/lkml/2004/5/2/108"><em>https://lkml.org/lkml/2004/5/2/108</em></a></p>
</blockquote>
<p>Esse problema n&atilde;o &eacute; uma exclusividade do Linux. Enfrentamos um problema similar no Kernel do Windows ao trabalhar com uma limita&ccedil;&atilde;o do dispatcher lock, mas que foi resolvido pelo Arun Kishan.</p>
<blockquote>
<p><em>Arun Kishan <br /></em><a title="https://channel9.msdn.com/shows/Going+Deep/Arun-Kishan-Farewell-to-the-Windows-Kernel-Dispatcher-Lock/" href="https://channel9.msdn.com/shows/Going+Deep/Arun-Kishan-Farewell-to-the-Windows-Kernel-Dispatcher-Lock/"><em>https://channel9.msdn.com/shows/Going+Deep/Arun-Kishan-Farewell-to-the-Windows-Kernel-Dispatcher-Lock/</em></a></p>
</blockquote>
<p>O problema &eacute; minimizado no SQL Server usando uma execu&ccedil;&atilde;o de thread em modo cooperativo.</p>
<blockquote>
<p><em>SQL Scheduler: Cooperative Mode <br /></em><a title="http://blogs.msdn.com/b/fcatae/archive/2011/03/09/sql-scheduler-cooperative-mode.aspx" href="http://blogs.msdn.com/b/fcatae/archive/2011/03/09/sql-scheduler-cooperative-mode.aspx"><em>http://blogs.msdn.com/b/fcatae/archive/2011/03/09/sql-scheduler-cooperative-mode.aspx</em></a></p>
</blockquote>
<h3>Solu&ccedil;&atilde;o (?)</h3>
<p>A solu&ccedil;&atilde;o &eacute; ser mais r&aacute;pido (individualmente) ou diminuir o paralelismo. No caso de computadores, podemos usar processadores com clocks mais r&aacute;pidos. Note que isso &eacute; ligeiramente diferente de adicionais mais CPU ou Cores.</p>
<p>No pr&oacute;ximo post, vou ilustrar esse comportamento usando um exemplo do nosso cotidiano (pelo menos em S&atilde;o Paulo se aplica quase que diariamente) &ndash; o tr&acirc;nsito de carros.</p>
