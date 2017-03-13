<a link='https://blogs.msdn.microsoft.com/fcatae/2016/05/31/aprendi-sql-com-comandos-obsoletos/'>Aprendi SQL com comandos obsoletos</a>
Foram 10 artigos escritos sobre a “Saga da otimização com comandos antigos”, na qual usei o objetivo era mostrar alguns conceitos importantes do SQL Server.
<ul>
	<li>Parte 1: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/22/set-statistics-io.aspx">SET STATISTICS IO</a></li>
	<li>Parte 2: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/29/dbcc-dropcleanbuffers.aspx">DBCC DROPCLEANBUFFERS</a></li>
	<li>Parte 3: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/05/dbcc-showcontig.aspx">DBCC SHOWCONTIG</a></li>
	<li>Parte 4: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/12/dbcc-page.aspx">DBCC PAGE</a></li>
	<li>Parte 5: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/19/sp-spaceused.aspx">sp_spaceused</a></li>
	<li>Parte 6: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/26/dbcc-ind.aspx">DBCC IND</a></li>
	<li>Parte 7: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/03/dbcc-indexdefrag.aspx">DBCC INDEXDEFRAG</a></li>
	<li>Parte 8: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/10/dbcc-dbreindex.aspx">DBCC DBREINDEX</a></li>
	<li>Parte 9: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/17/sp-detach-db.aspx">sp_detach_db</a></li>
	<li>Parte 10: <a href="https://blogs.msdn.microsoft.com/fcatae/2016/05/24/set-showplan_text/">SET SHOWPLAN_TEXT</a></li>
</ul>
Assim aprendi como funciona um banco de dados:
<ol>
	<li>O importante é sempre medir I/O</li>
	<li>Existem duas estruturas de dados importantes: Heaps e B-Trees</li>
	<li>Fragmentação de dados impacta diretamente o desempenho do Table Scan</li>
</ol>
<h2>Table Scan</h2>
Embora muita gente (eu inclusive!) diga que Table Scan e Desempenho não combinam, precisamos compreender a importância do Table Scan em um banco de dados relacional. Essa é a operação mais eficiente para ler um grande número de registros, sendo superior a qualquer forma de Index Seek/Row Lookup. Por isso, o Table Scan é uma operação presente em grandes Data Warehousing e não podemos ignorá-la.

Como principal fundamento do Table Scan, o Read-Ahead (também chamado de read prefetch) é usado para consolidar múltiplas solicitações de I/O em apenas uma requisição. A diferença em desempenho é brutal e pode melhorar em 10x.

O principal inimigo do Table Scan é a fragmentação dos dados em disco, que impede o SQL de realizar read-aheads. Isso pode se manifestar em estruturas do tipo Heap ou B-Tree.

&nbsp;
<h2>Relendo os Artigos</h2>
Quando pensei em escrever os artigos sobre desempenho de banco de dados, achei que seria importante ressaltar o conceito de IAM Scan. O motivo é simples: há pouca documentação sobre essa operação. Decidi escrever os artigos usando um tema sarcástico: “otimização com comandos antigos” e, agora que conclui, acabei me arrependendo por não conseguir dar o foco correto à série.

Por isso, recomendo que entendam que cada artigos possui uma motivação por trás:
<ul>
	<li><strong>A importância de medir I/O e o cuidado com o Cache em memória</strong>
<ul>
	<li>Parte 1: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/22/set-statistics-io.aspx">SET STATISTICS IO</a></li>
	<li>Parte 2: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/03/29/dbcc-dropcleanbuffers.aspx">DBCC DROPCLEANBUFFERS</a></li>
</ul>
</li>
	<li><strong>Estrutura Heap e sua fragmentação</strong>
<ul>
	<li>Parte 3: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/05/dbcc-showcontig.aspx">DBCC SHOWCONTIG</a></li>
	<li>Parte 4: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/12/dbcc-page.aspx">DBCC PAGE</a></li>
	<li>Parte 5: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/19/sp-spaceused.aspx">sp_spaceused</a></li>
</ul>
</li>
	<li><strong>Estrutura B-Tree e sua fragmentação</strong>
<ul>
	<li>Parte 6: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/04/26/dbcc-ind.aspx">DBCC IND</a></li>
	<li>Parte 7: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/03/dbcc-indexdefrag.aspx">DBCC INDEXDEFRAG</a></li>
	<li>Parte 8: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/10/dbcc-dbreindex.aspx">DBCC DBREINDEX</a></li>
</ul>
</li>
	<li><strong>Impacto da fragmentação</strong>
<ul>
	<li>Parte 9: <a href="http://blogs.msdn.com/b/fcatae/archive/2016/05/17/sp-detach-db.aspx">sp_detach_db</a></li>
</ul>
</li>
	<li><strong>Por que Table Scan quando um índice resolve?</strong>
<ul>
	<li>Parte 10: <a href="https://blogs.msdn.microsoft.com/fcatae/2016/05/24/set-showplan_text/">SET SHOWPLAN_TEXT</a></li>
</ul>
</li>
</ul>
Meu artigo favorito é a <a href="https://blogs.msdn.microsoft.com/fcatae/2016/04/19/sp_spaceused/">Parte 5: sp_spaceused</a>, na qual fica explícito um comportamento indesejado das Heaps.

Todos os artigos tentam mostrar os problemas que impactam diretamente o desempenho o Table Scan.

O último artigo (<a href="https://blogs.msdn.microsoft.com/fcatae/2016/05/24/set-showplan_text/">Parte 10: SET SHOWPLAN_TEXT</a>) mostra que, quando se retornam POUCOS registros, então um índice funciona melhor. No próximo artigo, gostaria de discutir mais e falar sobre o "fim do table scan".
