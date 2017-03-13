<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/05/como-usar-select-with-nolock-para-melhorar-a-performance/'>Como usar SELECT WITH NOLOCK para melhorar a Performance?</a>
Pode parecer uma dica simples demais, mas tenho observado muitas dúvidas quanto ao uso do NOLOCK. No tempo do SQL 2000, a própria Microsoft (que ninguém me ouça dizendo isso!) recomendava o uso indiscriminado do NOLOCK [sem referência]. Por esse motivo, decidi explicar um pouco seu funcionamento.
<blockquote><strong>Conhece o checklist de Performance de servidor?</strong>
<ul>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/08/checklist-performance-do-servidor-windows.aspx">Checklist: Performance do Servidor (Windows)</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/15/checklist-performance-do-servidor-sql.aspx">Checklist: Performance do Servidor (SQL)</a></li>
</ul>
</blockquote>
SQL Server utiliza mecanismos de bloqueio (LOCK) para garantir a integridade de dados. O fato é que muitas vezes o bloqueio (LOCK) impacta diretamente na performance do sistema. Por exemplo, veja os dois comandos:
<blockquote><span style="font-family: courier new;color: #0000ff;font-size: x-small"><span style="font-family: courier new;font-size: x-small">1)</span> SELECT</span> <span style="font-family: courier new;color: #ff00ff;font-size: x-small">COUNT</span><span style="font-family: courier new;color: #808080;font-size: x-small">(</span><span style="font-family: courier new;color: #000000;font-size: x-small">Nome</span><span style="font-family: courier new;color: #808080;font-size: x-small">)</span> <span style="font-family: courier new;color: #0000ff;font-size: x-small">FROM</span><span style="font-family: courier new;color: #000000;font-size: x-small"> <span style="background-color: #ffff00">TabelaPessoas</span></span>

<span style="font-family: courier new;font-size: x-small">2) <span style="font-family: courier new;color: #0000ff;font-size: x-small">INSERT</span><span style="font-family: courier new;color: #000000;font-size: x-small"> <span style="background-color: #ffff00">TabelaPessoas</span></span> <span style="font-family: courier new;color: #808080;font-size: x-small">(</span><span style="font-family: courier new;color: #000000;font-size: x-small">Nome</span><span style="font-family: courier new;color: #808080;font-size: x-small">)</span> <span style="font-family: courier new;color: #0000ff;font-size: x-small">VALUES </span><span style="font-family: courier new;color: #808080;font-size: x-small">(</span><span style="font-family: courier new;color: #ff0000;font-size: x-small">'Fabricio'</span><span style="font-family: courier new;color: #808080;font-size: x-small">)`</span></span></blockquote>
Se forem executados simultaneamente, os comandos efetuarão leitura (SELECT) e escrita (INSERT) contra a mesma tabela. Entretanto, o banco de dados garante a integridade e executa um comando por vez. Em outras palavras, o comando de SELECT não pode ocorrer no mesmo instante que o INSERT. Esse é um caso simples e inofensivo, mas pense agora nos sistemas de grande porte.

Um banco de dados que precisa executar 100 transações por segundo, mas precisa gerar alguns relatórios rápidos. As transações correspondem aos INSERTS, enquanto que os relatórios são SELECT. Como podemos melhorar a performance dos INSERT que concorrem com comandos SELECT?
<h2>Solução: Uso de NOLOCK</h2>
O comando SELECT permite o uso de uma opção denominada NOLOCK, evitando assim os bloqueios com os comandos de INSERT. O uso é simples, bastando adicionar algumas palavras após a declaração da tabela.
<blockquote><span style="font-family: courier new;color: #0000ff;font-size: x-small">SELECT</span> <span style="font-family: courier new;color: #ff00ff;font-size: x-small">COUNT</span><span style="font-family: courier new;color: #808080;font-size: x-small">(</span><span style="font-family: courier new;color: #000000;font-size: x-small">Nome</span><span style="font-family: courier new;color: #808080;font-size: x-small">)</span> <span style="font-family: courier new;color: #0000ff;font-size: x-small">FROM</span><span style="font-family: courier new;color: #000000;font-size: x-small"> <span style="background-color: #ffff00">TabelaPessoas WITH (NOLOCK)</span></span></blockquote>
Dessa forma, o comando <strong>WITH (NOLOCK)</strong> indica que não será necessário bloquear a tabela durante a leitura dos dados.
<h2>Recomendação</h2>
O uso de NOLOCK indiscrinado pode causar problemas transitórios devido a movimentação de dados sem bloqueios. Veja os exemplos <a href="http://blogs.msdn.com/b/fcatae/archive/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i.aspx" target="_blank">Efeitos colaterais do NOLOCK – Parte I</a> e <a href="http://blogs.msdn.com/b/fcatae/archive/2010/06/02/efeitos-colaterais-do-with-nolock-parte-ii.aspx" target="_blank">Efeitos colaterais do NOLOCK – Parte 2</a>.

A partir do SQL Server 2005/2008, existe uma solução mais elegante que é o uso do READ COMMITTED SNAPSHOT no banco de dados. O melhor de tudo é que essa é uma configuração do banco de dados e não necessita alteração em código.
<blockquote><strong>Links relacionados</strong>
<ul>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/05/como-usar-select-with-nolock-para-melhorar-a-performance.aspx">Como usar SELECT WITH NOLOCK para melhorar a Performance?</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/06/nolock-ou-with-nolock-qual-a-sintaxe-correta.aspx">Qual a sintaxe correta: NOLOCK ou WITH (NOLOCK)?</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/11/update-with-nolock-como-funciona.aspx">NOLOCK e INSERT/UPDATE/DELETE</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/10/13/problemas-com-nolock-sql-server.aspx">Problemas com NOLOCK</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/04/28/efeitos-colaterais-do-with-nolock-parte-i.aspx">Efeitos colaterais do NOLOCK – Parte 1</a></li>
	<li><a href="http://blogs.msdn.com/b/fcatae/archive/2010/06/02/efeitos-colaterais-do-with-nolock-parte-ii.aspx">Efeitos colaterais do NOLOCK – Parte 2</a></li>
</ul>
</blockquote>
&nbsp;
