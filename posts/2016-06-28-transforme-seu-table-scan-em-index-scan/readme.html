<a link='https://blogs.msdn.microsoft.com/fcatae/2016/06/28/transforme-seu-table-scan-em-index-scan/'>Transforme seu Table Scan em Index Scan</a>
Covered index é uma técnica importante no mundo de banco de dados. Entretanto, existe um caso que não é possível usar covered index:
<blockquote>SELECT * FROM tabela</blockquote>
Esse comando é conhecido como SELECT ALL, pois retorna todas as colunas da tabela. Não é comum criar um Covered Index com todas as colunas da tabela, pois nesse caso o índice seria tão “gordo” quando a tabela. Nesse caso, a solução é transformar a tabela em um índice.
<blockquote>CREATE <strong>CLUSTERED </strong>INDEX cidx ON tabela (id)</blockquote>
Esse comando transforma a estrutura Heap da tabela em uma BTree. Isso significa que todas as operações de Table Scan são convertidas em Clustered Index Scan. Se começarmos a pesquisar os detalhes, vamos descobrir que um Table Scan (usando o IAM Scan) é mais rápido do que um Clustered Index Scan. Entretanto, vamos dizer que na prática eles são praticamente iguais. Isso ocorre porque os tamanhos das estruturas são muito próximos.

&nbsp;
<h3>Paradoxo do Clustered Index</h3>
Toda documentação indica que as tabelas devem possuir um Clustered Index. Se você fizer uma pesquisa na Internet, vai notar que existem vários artigos concordando com essa opinião. Portanto, podemos dizer que é “<strong>recomendado sempre criar um clustered index na tabela para melhorar o desempenho do banco de dados</strong>”. Por outro lado, existe um problema grave que acontece frequentemente nos ambientes de produção, que é a fragmentação da tabela. Se a tabela fosse uma Heap e não tivesse índice clustered, então não haveria fragmentação.

Chamo isso de “paradoxo do clustered index”: criar um índice clustered piora o desempenho do banco de dados.

Embora a recomendação seja criar um índice clustered, não adianta criar aleatoriamente o índice. A escolha das colunas certas é fundamental. Ao escolher as colunas de um clustered index, prefira sempre:
<ul>
	<li>Tipo de dados pequeno (ex: Prefira INTEGER = 4 bytes ao invés de VARCHAR extensos)</li>
	<li>Valores incrementais (ex: 1, 2, 3, … )</li>
	<li>Campos que não sofrem modificação (ex: evite campos como LastUpdate)</li>
	<li>Campos usados em GROUP BY</li>
</ul>
Um bom exemplo são campos IDENTITY.

Contra-exemplos são os GUID (aqueles hexadecimais “C5EC2000-3AAA-4069-A20D-03204B3030FF”) e campos VARCHAR (nome, sobrenome, endereço), A escolha inadequada de uma chave para o índice clustered impacta diretamente na fragmentação do banco de dados. Infelizmente, exemplos ruins são aqueles que não faltam.
<blockquote>Primary Key são frequentemente vistos como contra-exemplos, a menos que sejam IDENTITY</blockquote>
Minha recomendação é sempre criar um clustered index nas tabelas usando preferencialmente os campos IDENTITY (nem que seja necessário criar um).
