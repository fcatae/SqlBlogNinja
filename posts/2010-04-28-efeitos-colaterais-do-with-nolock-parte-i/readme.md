<a link='https://blogs.msdn.microsoft.com/fcatae/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i/'>Efeitos colaterais do WITH (NOLOCK) – Parte I</a>
<p>Nesse post vou comentar sobre a utilização da hint NOLOCK e os efeitos colaterais associados. Todo mundo diz que NOLOCK é importante para performance e que, sem esse artifício, ocorreriam bloqueios desnecessários e situações de <em>deadlocks</em>. Com certeza isso é verdade, pois não são alocadas estruturas de <em>table</em>, <em>page</em>, <em>row </em>ou <em>key lock</em>. Por outro lado, poucas pessoas conhecem os efeitos colaterais dessa <em>hint</em>. Um exemplo muito curioso foi descrito por <a href="http://blogs.msdn.com/sqlcat/archive/2007/02/01/previously-committed-rows-might-be-missed-if-nolock-hint-is-used.aspx" target="_blank">Lubor Kollar</a>, que mostrou um SELECT fazendo leitura do mesmo registro duas vezes – ou perdendo registros! (sem crises: a situação é bastante específica e depende de vários fatores ocorrendo ao mesmo tempo).</p>  <blockquote>   <p><strong>Links relacionados</strong></p>    <ul>     <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/05/como-usar-select-with-nolock-para-melhorar-a-performance.aspx">Como usar SELECT WITH NOLOCK para melhorar a Performance?</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/06/nolock-ou-with-nolock-qual-a-sintaxe-correta.aspx">Qual a sintaxe correta: NOLOCK ou WITH (NOLOCK)?</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/update-with-nolock-como-funciona.aspx">NOLOCK e INSERT/UPDATE/DELETE</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/13/problemas-com-nolock-sql-server.aspx">Problemas com NOLOCK</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i.aspx">Efeitos colaterais do NOLOCK – Parte 1</a> </li>      <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/06/02/efeitos-colaterais-do-with-nolock-parte-ii.aspx">Efeitos colaterais do NOLOCK – Parte 2</a></li>   </ul> </blockquote>  <p>A utilização da hint NOLOCK pode causar erros transitórios decorrentes do acesso concorrente às mesmas informações. Por exemplo, imagine a situação de um comando DELETE apagando os registros que são lidos durante uma operação SELECT no mesmo instante. Estou copiando literalmente o exemplo do <a href="http://blogs.msdn.com/craigfr/archive/2007/06/12/query-failure-with-read-uncommitted.aspx" target="_blank">Craig Freedman</a>. Primeiro criamos as tabelas:</p>  <blockquote>   <pre class="code"><span style="color: blue">CREATE TABLE </span>t1 <span style="color: gray">(</span>k <span style="color: blue">INT</span><span style="color: gray">,</span>data <span style="color: blue">INT</span><span style="color: gray">)
</span>INSERTt1 <span style="color: blue">VALUES</span><span style="color: gray">(</span>0<span style="color: gray">,</span>0<span style="color: gray">), (</span>1<span style="color: gray">,</span>1<span style="color: gray">)

</span><span style="color: blue">CREATE TABLE </span>t2 <span style="color: gray">(</span>pk <span style="color: blue">INT PRIMARY KEY</span><span style="color: gray">)
</span>INSERTt2 <span style="color: blue">VALUES</span><span style="color: gray">(</span>0<span style="color: gray">), (</span>1<span style="color: gray">)
</span></pre>
</blockquote>


<p>Na <strong>sessão 1</strong>, iniciamos uma transação que atualiza T2 e mantém bloqueios na tabela:</p>

<blockquote>
  <pre class="code"><span style="color: blue">BEGIN TRAN
UPDATE </span>t2 <span style="color: blue">SET </span>pk <span style="color: gray">= </span>pk <span style="color: blue">WHERE </span>pk <span style="color: gray">= </span>0</pre>
  </blockquote>


<p>Na <strong>sessão 2</strong>, rodamos a query com a hint NOLOCK. Note que a query fica esperando a liberação do lock da tabela T2.</p>

<blockquote>
  <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span>t1 <span style="color: blue">WITH </span><span style="color: gray">(</span><span style="color: blue">NOLOCK</span><span style="color: gray">)
</span><span style="color: blue">WHERE </span><span style="color: gray">EXISTS (</span><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span>t2 <span style="color: blue">WHERE </span>t1<span style="color: gray">.</span>k <span style="color: gray">= </span>t2<span style="color: gray">.</span>pk<span style="color: gray">)

</span></pre>
</blockquote>


<p>Na <strong>sessão 1</strong>, completamos a transação e apagamos um registro da tabela T1 – que está sendo utilizado na sessão 2.</p>

<blockquote>
  <pre class="code"><span style="color: blue">DELETE </span>t1 <span style="color: blue">WHERE </span>k <span style="color: gray">= </span>0
<span style="color: blue">COMMIT TRAN</span></pre>
</blockquote>

<p>Na <strong>sessão 2</strong>, o comando SELECT falha!</p>

<blockquote>
  <pre class="code"><font color="#ff0000">Msg 601, Level 12, State 3, Line 1
Could not continue scan with NOLOCK due to data movement.</font></pre>
</blockquote>

<pre class="code"><font color="#ff0000"></font></pre>

<h3>Explicação</h3>

<p>Na sessão 2, o comando SELECT realiza uma operação de leitura de T1 enquanto que, no exato momento, a sessão 1 está apagando o registro de T1. Acessos concorrentes e sem bloqueios! Do ponto de vista do SQL Server, um erro de consistência pode ocorrer a qualquer instante. <strong>Qual explicação?</strong> NOLOCK<strong>:</strong> solicitamos que nenhum <em>lock </em>seja obtido na tabela. </p>

<p>Analisando microscopicamente, o comando SELECT iniciou a operação de <em>Table Scan </em>em T1, realizando a leitura do registro k=0, e depois ficou bloqueado na tabela T2. Antes de avançar na leitura da tabela, uma outra sessão apagou o registro k=0 e liberou o bloqueio em T2. SELECT continua a operação de <em>Table Scan </em>fazendo a leitura a partir do registro k=0 para buscar k=1, mas… cade o registro k=0? Ele foi apagado. Nesse momento, o <em>table scan </em>foi cancelado com o erro 601 – severity 12. Note que esse erro apresenta baixa severidade porque foi uma consequência de uma situação transitória.</p>

<p>Na sessão <a href="http://msdn.microsoft.com/en-us/library/ms187373.aspx" target="_blank">Table Hints</a> do do Books Online, a situação é descrita como transitória e que, caso a aplicação receba esse erro, deve re-tentar executar o comando.</p>

<blockquote>
  <p><font size="2" face="Courier New">If you receive the error message 601 when READUNCOMMITTED is specified, resolve it as you would a deadlock error (1205), and retry your statement.</font></p>
</blockquote>

<p><font size="2" face="Courier New"></font></p>

<h3>Conclusão</h3>

<p>Lembre-se que há pontos negativos no uso indiscriminado de NOLOCK. Além do comportamento de “leituras sujas”, podem ser encontrados problemas de consistência durante operações de <em>Table/Index Scan</em>. </p>

<p>No próximo post, mostrarei um segundo problema relacionado com o NOLOCK: erros críticos podem ser encobertos pela utilização da hint.</p>

<p>&#160;</p>

<h3>Referências</h3>

<blockquote>
  <p>Table Hints 
    <br /><a title="http://msdn.microsoft.com/en-us/library/ms187373.aspx" href="http://msdn.microsoft.com/en-us/library/ms187373.aspx">http://msdn.microsoft.com/en-us/library/ms187373.aspx</a></p>
</blockquote>

<blockquote>
  <p>Troubleshooting Error 601 
    <br /><a title="http://technet.microsoft.com/en-us/library/bb326281.aspx" href="http://technet.microsoft.com/en-us/library/bb326281.aspx">http://technet.microsoft.com/en-us/library/bb326281.aspx</a></p>
</blockquote>

<blockquote>
  <p>Lubor Kollar 
    <br /><a title="http://blogs.msdn.com/sqlcat/archive/2007/02/01/previously-committed-rows-might-be-missed-if-nolock-hint-is-used.aspx" href="http://blogs.msdn.com/sqlcat/archive/2007/02/01/previously-committed-rows-might-be-missed-if-nolock-hint-is-used.aspx">http://blogs.msdn.com/sqlcat/archive/2007/02/01/previously-committed-rows-might-be-missed-if-nolock-hint-is-used.aspx</a></p>
</blockquote>

<blockquote>
  <p>Craig Freedman 
    <br /><a title="http://blogs.msdn.com/craigfr/archive/2007/06/12/query-failure-with-read-uncommitted.aspx" href="http://blogs.msdn.com/craigfr/archive/2007/06/12/query-failure-with-read-uncommitted.aspx">http://blogs.msdn.com/craigfr/archive/2007/06/12/query-failure-with-read-uncommitted.aspx</a></p></blockquote>
