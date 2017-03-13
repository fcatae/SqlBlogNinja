<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/12/spinlock-parte-i/'>Spinlock (Parte I)</a>
<p>Tenho recebido uma s&eacute;rie de emails perguntando sobre SPINLOCK e infelizmente n&atilde;o tive tempo para escrever muito sobre o assunto. H&aacute; um post antigo: <a target="_blank" href="http://blogs.msdn.com/b/fcatae/archive/2009/12/17/spinlock-contention.aspx">Spinlock Contention</a>, mas vejo que falta mais coisa. Vou escrever esse artigo para dar uma id&eacute;ia sobre o spinlock e, em seguida, mostrarei seu funcionamento.</p>
<p>Primeiro, devemos traduzir literalmente a palavra spinlock:</p>
<ul>
<li>SPIN = Rodar</li>
<li>LOCK = Bloqueio</li>
</ul>
<p>Isso d&aacute; uma pista inicial de que a estrutura de Spinlock corresponde a um <span style="text-decoration: underline">lock</span> na qual a <span style="text-decoration: underline">thread </span>fica <span style="text-decoration: underline">rodando</span>, muito semelhante a um loop infinito. </p>
<p>Em T-SQL, isso corresponde a um c&oacute;digo assim:</p>
<blockquote>
<pre class="code"><span style="color: blue">SET LOCK_TIMEOUT </span>0

<span style="color: blue">SpinLoop:
    
    UPDATE </span>tabela <span style="color: blue">SET </span>coluna <span style="color: gray">= </span><span style="color: red">'bla'
    </span><span style="color: blue">IF </span><span style="color: magenta">@@ERROR </span><span style="color: gray">&lt;&gt;</span>0 <span style="color: blue">goto </span>SpinLoop   </pre>
</blockquote>
<p><a href="http://11011.net/software/vspaste"></a></p>
<p>Analisando o c&oacute;digo em uma situa&ccedil;&atilde;o na qual a tabela est&aacute; bloqueada, observamos que esse c&oacute;digo utiliza um LOOP INFINITO at&eacute; que a tabela seja atualizada. </p>
<p>Meu experimento foi colocar um bloqueio propositalmente na tabela e em seguida rodar o SpinLock. O resultado foram 34074 mensagens repetidas como apresentadas abaixo, podendo dizer assim que houve 1 colis&atilde;o e 34074 spins:</p>
<blockquote>
<pre class="code"><span style="color: #ff0000">Msg 1222, Level 16, State 56, Line 3
Lock request time out period exceeded.
Msg 1222, Level 16, State 56, Line 3
Lock request time out period exceeded.
Msg 1222, Level 16, State 56, Line 3
Lock request time out period exceeded.
...
Msg 1222, Level 16, State 56, Line 3
Lock request time out period exceeded.</span></pre>
</blockquote>
<p>A vantagem desse c&oacute;digo &eacute; que nenhum LOCK &eacute; efetivamente utilizado. Por outro lado, a CPU vai para 100% imediatamente.</p>
<blockquote>
<p><strong>O OBJETIVO DESSE C&Oacute;DIGO &Eacute; ILUSTRAR A <span style="text-decoration: underline">ID&Eacute;IA</span> POR TR&Aacute;S DO SPINLOCK. JAMAIS USE ESTE C&Oacute;DIGO! </strong></p>
</blockquote>
<p>No pr&oacute;ximo post, colocarei a descri&ccedil;&atilde;o do &ldquo;verdadeiro&rdquo; spinlock.</p>
