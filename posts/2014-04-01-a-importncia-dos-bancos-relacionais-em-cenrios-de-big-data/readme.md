<a link='https://blogs.msdn.microsoft.com/fcatae/2014/04/01/a-importncia-dos-bancos-relacionais-em-cenrios-de-big-data/'>A importância dos bancos relacionais em cenários de Big Data</a>
<p>No mês de março tive o privilégio de escrever para o Editorial do <a href="http://msdn.microsoft.com/pt-br/aa570311" target="_blank">MSDN Newsletter</a>. Tenho acompanhado um pouco o cenário de Big Data e, com um pouco de conhecimento do mercado corporativo, decidi falar sobre onde o SQL Server se encaixa. Segue o texto na íntegra:</p>  <blockquote>   <p>Neste mês anunciamos o lançamento oficial do SQL Server 2014, que estará disponível comercialmente em 1° de Abril.</p> </blockquote>  <blockquote>   <p><strong>Em meio a todo o alvoroço do Big Data, qual seria a importância de um banco de dados relacional como o SQL Server?</strong> Todos falam de Big Data como uma estratégia diferencial para as empresas. A fim de me manter atualizado sobre esse assunto, tenho estudado NoSQL e Hadoop para saber como empregar melhor essas tecnologias no nosso dia a dia. Estava curioso para saber se seriam essas as ferramentas que levariam à adoção do Big Data em massa. <strong>A realidade é que muitas empresas têm interesse, mas o caminho mais fácil parece ser através de um tradicional banco de dados relacional.</strong></p>    <p>Ambientes corporativos possuem uma variedade de sistemas interligados. Desde sistemas usando tecnologia de ponta como também aplicações legadas que não podem ser desativadas. É arriscado jogar todos os sistemas no lixo e começar do zero um sistema unificado. Em raras ocasiões há justificativa para tamanho investimento. Portanto, a convivência de diferentes sistemas é um requisito primordial nas empresas. É nesse meio que o banco de dados relacional brilha. Além das características essenciais como auditoria, controle de acesso e backup de dados, ele possui o conceito de separação do modelo lógico e físico.</p>    <p>O modelo lógico de dados foi concebido por Codd (1970), no qual o banco de dados relacional é composto por tabelas e relacionamentos usando chaves primárias e estrangeiras. O desenvolvedor utiliza comandos padronizados SQL ou extensões específicas como T-SQL. O modelo físico de dados permite definir as estruturas de armazenamento, que a grosso modo seria a definição dos índices necessários para suportar as consultas. </p>    <p>A modelagem física, ao contrário da modelagem lógica, é um processo iterativo e pode ser ajustada no dia a dia. Um administrador de banco de dados pode extrair métricas de uso dos dados e otimizar a forma de armazenamento sem a necessidade de alterar o código da aplicação. SQL Server 2014 trará agora o diferencial da tecnologia &quot;in-memory&quot;, capaz de melhorar o desempenho em 10 vezes e reduzir o espaço consumido pelos dados. Todas essas funcionalidades podem ser adotadas pelas aplicações baseadas no banco de dados SQL Server, bastando migrar para a nova versão e ajustando o modelo físico.</p>    <p><strong>Ao observar essa evolução, minha conclusão é que as tecnologias possuem seu nicho específico e nenhuma delas canibaliza as demais.</strong> Big Data é o grande &quot;hype&quot;, que estende as funções analíticas sobre os dados armazenados, gerando a demanda por novas tecnologias. Enquanto que o NoSQL especializa a tarefa de aquisição de dados em escala, o Hadoop evolui a ideia de &quot;map-reduce&quot; para aumentar a capacidade analítica. O banco de dados relacional continua firme em sua posição e mais vivo do que nunca como uma plataforma crítica de integração de sistemas.</p> </blockquote>  <p>Com o lançamento oficial do SQL Server 2014, estou trabalhando em uma surpresa. Fiquem ligado!</p>