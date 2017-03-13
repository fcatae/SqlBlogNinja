<a link='https://blogs.msdn.microsoft.com/fcatae/2010/06/02/efeitos-colaterais-do-with-nolock-parte-ii/'>Efeitos Colaterais do WITH (NOLOCK) – Parte II</a>
<p>Como havia mostrado no <a href="http://blogs.msdn.com/fcatae/archive/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i.aspx" target="_blank">post anterior</a>, o uso do NOLOCK pode causar comportamentos estranhos. Nesse post, vou concentrar a atenção para o ERRO 601.</p>  <blockquote>   <pre class="code"><span style="color: #ff0000;font-size: x-small"><font size="2">Msg 601, Level 12, State 3, Line 1
Could not continue scan with NOLOCK due to data movement.
</font></span></pre>
</blockquote>

<p><a href="http://11011.net/software/vspaste"><font size="2"></font></a></p>

<p>A interpretação usual é que o erro foi decorrente de uma situação de acesso concorrente, na qual as estruturas são modificadas durante uma operação de <em>Table/Index Scan</em>. O próprio Books Online orienta a aplicação a executar o comando novamente (<em><a href="http://msdn.microsoft.com/en-us/library/ms187373.aspx" target="_blank">If you receive the error message 601 when READUNCOMMITTED is specified … retry your statement</a></em>). Como o NOLOCK acessa a tabela sem <em>locks</em>, pode acontecer erros de acesso simultâneo. Esse é o famoso comportamento denominado <em>by design</em>. </p>

<p>(No SQL 2000, havia uma <a href="http://support.microsoft.com/kb/815008" target="_blank">situação semelhante relacionada com o Bookmark Lookup</a>. Esse comportamento foi resolvido no SQL2005/2008 com a mudança do operador de Bookmark Lookup para um Nested Loop)</p>

<blockquote>
  <p><strong>Links relacionados</strong></p>

  <ul>
    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/05/como-usar-select-with-nolock-para-melhorar-a-performance.aspx">Como usar SELECT WITH NOLOCK para melhorar a Performance?</a> </li>

    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/06/nolock-ou-with-nolock-qual-a-sintaxe-correta.aspx">Qual a sintaxe correta: NOLOCK ou WITH (NOLOCK)?</a> </li>

    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/update-with-nolock-como-funciona.aspx">NOLOCK e INSERT/UPDATE/DELETE</a> </li>

    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/13/problemas-com-nolock-sql-server.aspx">Problemas com NOLOCK</a> </li>

    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i.aspx">Efeitos colaterais do NOLOCK – Parte 1</a> </li>

    <li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/06/02/efeitos-colaterais-do-with-nolock-parte-ii.aspx">Efeitos colaterais do NOLOCK – Parte 2</a></li>
  </ul>
</blockquote>

<p><strong>Qual o outro problema do NOLOCK?</strong></p>

<p>Essa mensagem de erro possui um comportamento bastante inconveniente, que é sua baixa severidade (Msg 601, Level 12, State 3). Quando <em>Table/Index Scans </em>são realizados com a hint <strong>NOLOCK</strong>, os erros de consistência de dados gerados pelo <em>Access Manager</em> ou <em>Buffer Manager </em>são automaticamente convertidos no erro 601 – ou deveria dizer, encobertos?</p>

<p>A situação que me deparei essa semana foi uma corrupção de banco de dados (erro extremamente crítico!), que foi convertido no erro 601.</p>

<p>Rodamos o comando:</p>

<blockquote>
  <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span>tabela </pre>
</blockquote>

<p>O resultado foi uma mensagem de corrupção de banco de dados com severidade 24 e os erros foram registrados no ERRORLOG.</p>

<blockquote>
  <p><span style="font-family: courier new;color: #ff0000;font-size: x-small"><font size="2">Msg 824, Level 24, State 2, Line 2 
        <br />SQL Server detected a logical consistency-based I/O error: incorrect pageid (expected 1:153; actual 257:16843009). It occurred during a read of page (1:153) in database ID 11 at offset 0x00000000132000 in file 'D:\MSSQL\DATA\impcustDb.mdf'.&#160; Additional messages in the SQL Server error log or system event log may provide more detail. This is a severe error condition that threatens database integrity and must be corrected immediately. Complete a full database consistency check (DBCC CHECKDB). This error can be caused by many factors; for more information, see SQL Server Books Online. </font></span></p>
  <span style="font-family: courier new;color: #ff0000;font-size: x-small"></span></blockquote>

<p>Porém, a aplicação usava a hint NOLOCK:</p>

<blockquote>
  <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span>tabela <span style="color: gray">(</span><span style="color: blue">NOLOCK</span><span style="color: gray">)</span></pre>
</blockquote>

<p>Durante a execução da query, retornava-se a mensagem abaixo e ninguém foi notificado sobre o problema.</p>

<blockquote>
  <pre class="code"><span style="color: #ff0000">Msg 601, Level 12, State 3, Line 1
Could not continue scan with NOLOCK due to data movement.
</span></pre>
</blockquote>



<p>Isso significa que o erro 601 pode mascarar erros críticos! </p>

<p>Uma alternativa para o uso do NOLOCK seria habilitar a opção de READ COMMITTED SNAPSHOT do banco de dados.</p>

<blockquote>
  <pre class="code"><span style="color: blue">ALTER DATABASE </span>&lt;Database&gt; <span style="color: blue">SET READ_COMMITTED_SNAPSHOT ON </span></pre>
</blockquote>



<p>As leituras versionadas não causam bloqueios ou deadlocks nas operações de escrita (Update, Insert, Delete). Existe, no entanto, um custo adicional ao utilizar a opção de snapshot, que seria a utilização do TempDB para armazenamento de versões.</p>

<p>&#160;</p>

<h3>Conclusão</h3>

<p>Encontrou erros 601? </p>

<ul>
  <li>Verifique a frequência dos erros. Se o problema ocorre sempre, então vale a pena verificar a integridade dos dados com DBCC CHECKDB ou CHECKTABLE. </li>

  <li>Faça um teste sem NOLOCK para verificar se a query funciona corretamente </li>

  <li>Utilize o READ_COMMITTED_SNAPSHOT como uma alternativa ao NOLOCK </li>
</ul>
