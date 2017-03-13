<a link='https://blogs.msdn.microsoft.com/fcatae/2017/03/06/historia-do-hekaton-parte-1/'>A História do Hekaton - Parte 1</a>
<table cellspacing="5" cellpadding="2" border="1">
<tbody>
<tr>
<td valign="top">Originalmente publicado no Lab27: <a href="http://www.lab27.com.br/a-histria-do-hekaton-parte-1/" title="http://www.lab27.com.br/a-histria-do-hekaton-parte-1/">http://www.lab27.com.br/a-histria-do-hekaton-parte-1/</a></td>
</tr>
</tbody>
</table>
&nbsp;

Hekaton é uma funcionalidade que faz parte do “In-Memory Database” e está disponível a partir do SQL Server 2014.

Neste post quero mostrar um lado diferente do Hekaton. Vejo muita gente falando sobre a melhoria significativa de desempenho ao manter as tabelas em memória. Entretanto, o Hekaton não é exatamente isso! E, se fosse, deveria ser chamado de <a href="https://technet.microsoft.com/en-us/library/ms178015(v=sql.90).aspx">DBCC PINTABLE</a>.
<h3>Introdução</h3>
A funcionalidade denominada Hekaton nasceu a partir de uma constatação simples: as consultas T-SQL demoram milissegundos, enquanto que códigos nativos rodam em microssegundos. Veja o exemplo abaixo:

<a href="http://lab27.blob.core.windows.net/wordpress/2015/02/image.png"><img title="image" border="0" alt="image" src="http://lab27.blob.core.windows.net/wordpress/2015/02/image_thumb.png" width="318" height="172" /></a>

Esse código é centenas de vezes mais rápido do que o equivalente em T-SQL:

<a href="http://lab27.blob.core.windows.net/wordpress/2015/02/image1.png"><img title="image" border="0" alt="image" src="http://lab27.blob.core.windows.net/wordpress/2015/02/image_thumb1.png" width="153" height="69" /></a>

Qual o motivo dessa diferença de desempenho? Um grupo de pesquisadores da Microsoft Research junto com o time de desenvolvimento SQL Server trouxeram a possibilidade de empregar .NET como forma de codificação nativa no servidor. Afinal, por que não permitir que o SQL Server atinja esse desempenho de microssegundos? Além disso, por que não remover as sincronizações de thread entre CPUs, garantindo escalabilidade ao produto?

Assim nasceu a ideia do Hekaton…
<h3>Otimizando o lado do SQL Server</h3>
Como fazer o SQL Server ter um desempenho semelhante ao código nativo?
<ol>
 	<li><strong>Adoção de índices Hash </strong>– Como os índices clustered e non-clustered são baseados em estruturas B+ Trees, as operações de consulta (singleton lookup) percorrem os non-leaf nodes e se tornam operações bastante custosas. Uma forma de otimizar é adotar índices sem a hierarquia de árvore. Índices hash são mais rápidos. O principal parâmetro de ajuste em um índice Hash é o número de buckets: quanto maior o número de buckets, melhor o desempenho ao custo de maior espaço utilizado.</li>
 	<li><strong>Compilação em código nativo </strong>– Enquanto os comandos T-SQL são interpretados e gerenciados por uma máquina de estado, o código .NET é compilado em código de máquina. O ganho de desempenho é direto.</li>
 	<li><strong>Não há bloqueios ou locks </strong>– Isso é incrível! Assim como no exemplo do código .NET, não há necessidade de usar bloqueios explícitos.</li>
</ol>
<h3>Não há bloqueios ou locks</h3>
Estou repetindo esse último item: não há locks envolvidos. Essa mudança é tão profunda que envolve mudanças significativas na forma como o Hekaton acessa as informações.

Por exemplo, no modelo atual os registros ficam armazenados em páginas de 8Kb. Portanto, múltiplos registros podem compartilhar uma mesma página e requerem o uso de Latches e Locks para sincronizar o acesso.

<a href="http://lab27.blob.core.windows.net/wordpress/2015/02/image2.png"><img title="image" border="0" alt="image" src="http://lab27.blob.core.windows.net/wordpress/2015/02/image_thumb2.png" width="268" height="223" /></a>

Hekaton, por outro lado, mantém uma lista ligada de registros. Essa lista é protegida por spinlocks, não sendo necessário realizar a operação de Latch/UnLatch. Essa é uma economia significativa de recursos, pois evita as transições para Kernel Mode e reduz o custo total de thread context switch.

Agora temos um código mais limpo:

<a href="http://lab27.blob.core.windows.net/wordpress/2015/02/image3.png"><img title="image" border="0" alt="image" src="http://lab27.blob.core.windows.net/wordpress/2015/02/image_thumb3.png" width="240" height="121" /></a>

A utilização de spinlock, no entanto, requer que os dados estejam previamente em memória. Não pode haver operações de leitura de disco enquanto as threads possuem spinlock. Em outras palavras, o Hekaton não utiliza PAGEIOLATCH ou PAGELATCH. Isso significa que todos os registros devem ficar em memória previamente.
<h3>Qual a diferença com DBCC PINTABLE?</h3>
Quem tem mais tempo de SQL Server (7.0, 2000, 2005) talvez se lembre do lendário e obsoleto comando DBCC PINTABLE. Esse comando garantia que a tabela ficasse em memória e o ganho de desempenho era decorrente da redução na quantidade de acesso ao disco. Na realidade, a eficácia do PINTABLE sempre foi muito questionável. A arquitetura do SQL Server garante que os dados mais acessados são mantidos em memória e, portanto, não há motivos que justificam seu uso. Esse foi um dos motivos pelo qual a Microsoft descontinuou esse comando.

Se alguém perguntar sobre qual a diferença entre Hekaton e DBCC PINTABLE, responda que eles são completamente diferentes.

O segredo do Hekaton é utilizar estruturas baseadas em registros e protegidas por spinlocks. Manter as tabelas em memória é um pré-requisito da arquitetura atual (e que pode ser melhorado no futuro).
<h3>Conclusão</h3>
Esqueça que isso tem alguma semelhança com DBCC PINTABLE, pois o Hekaton não utiliza o Buffer Pool. Ele possui uma estrutura à parte. A proposta do Hekaton era trazer o desempenho do código .NET para dentro do SQL Server.

Nesa primeira parte, apresentei os principais motivadores para o surgimento do Hekaton. Entretanto, houve uma série de evoluções na tecnologia até chegar à sua forma final. Se você conhece bem o Hekaton, sabe que não existe código .NET (e sim código em C) e que existem índices na forma de B-Tree para o Hekaton. Deixarei essa discussão para uma parte 2.

Você gostou do artigo? Deixe seu comentário com sugestões.

Fabricio Catae (<a href="http://twitter.com/fcatae">@fcatae</a>)
