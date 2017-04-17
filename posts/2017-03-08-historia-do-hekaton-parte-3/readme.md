<a link='https://blogs.msdn.microsoft.com/fcatae/2017/03/08/historia-do-hekaton-parte-3/'>A História do Hekaton – Parte 3</a>
<table cellspacing="5" cellpadding="2" border="1">
<tbody>
<tr>
<td valign="top">Originalmente publicado no Lab27: <a href="http://www.lab27.com.br/a-histria-do-hekaton-parte-1/" title="http://www.lab27.com.br/a-histria-do-hekaton-parte-1/">http://www.lab27.com.br/a-histria-do-hekaton-parte-1/</a></td>
</tr>
</tbody>
</table>
&nbsp;

&nbsp;

Bem vindo ao último post da série Hekaton!
<blockquote>No <a href="https://blogs.msdn.microsoft.com/fcatae/2017/03/06/historia-do-hekaton-parte-1/">primeiro post</a> da série, disse que o Hekaton é completamente diferente do DBCC PINTABLE. No <a href="https://blogs.msdn.microsoft.com/fcatae/2017/03/07/historia-do-hekaton-parte-2/">segundo post</a>, expliquei um pouco sobre as mudanças que ocorreram no Hekaton em relação ao projeto inicial.</blockquote>
Agora quero terminar falando sobre a integração do Hekaton em relação aos componentes do SQL Storage Engine.

Hekaton é independente da maioria dos componentes tradicionais do SQL Server. A memória utilizada vem de um Memory Broker dedicado denominado XTP. Não há integração com Lock Manager (não tem locks!), Access Method, Buffer Manager, Page Manager, etc. O sistema de arquivo não utiliza MDF ou LDF, pois não são usados mais blocos de 8Kb. Da mesma forma, o mecanismo de Checkpoint é completamente diferente daquele conhecido pelos DBAs. Enfim, será que ele usa alguma coisa do SQL Server atual?
<h3>Projeto Hekaton</h3>
Hekaton nasceu com um objetivo claro: melhorar o desempenho transacional através da redução do número de instruções executadas. Uma das premissas do projeto era que esse recurso seria uma funcionalidade do banco de dados, integrado aos recursos de backup e alta disponibilidade. Ele não seria um projeto a parte, como é o caso do Analysis Services ou o AppFabric (codename Velocity).
<h3>Arquivos de Dados</h3>
No sistema de arquivo tradicional (MDF e NDF), dizemos que ocorrem “in-place updates”. Nesse caso, as atualizações podem ocorrer fisicamente na mesma página de dados várias vezes e o SQL Server garante a integridade dos dados usando Latches. Portanto, um comando de update não afeta o tamanho ocupado da tabela:
<blockquote>UPDATE tabela SET registro = registro + 1</blockquote>
No Hekaton, os arquivos são denominados de Checkpoint File Pairs (CFP), que correspondem aos arquivos de “data” e “delta”. Ambos os arquivos são denominados de “append-only” e não permitem modificação de dados. Assim, um comando de UPDATE é transformado em um par de comandos INSERT/DELETE:
<blockquote>INSERT tabela (registro) VALUES (@registro+1)

DELETE tabela WHERE registro = @registro</blockquote>
Mas como esse par de comandos afeta os arquivos “append-only”, então interpretamos os comandos apenas como inserções de registros:
<blockquote>[data file] INSERT tabela (registro) VALUES (registro + 1)

[delta file] INSERT registroApagado (registro) VALUES (registro)</blockquote>
Em um primeiro momento, isso tudo parece confuso. É difícil de entender que existam dois arquivos de dados (“data” e “delta”) e também um arquivo de log (“LDF”). Isso explica porque existe um processo novo denominado MERGE.

<a href="http://blogs.technet.com/b/dataplatforminsider/archive/2013/10/11/in-memory-oltp-how-durability-is-achieved-for-memory-optimized-tables.aspx">In-Memory OLTP: How Durability is Achieved for Memory-Optimized Tables</a>
<a href="http://blogs.technet.com/b/dataplatforminsider/archive/2013/10/11/in-memory-oltp-how-durability-is-achieved-for-memory-optimized-tables.aspx" title="http://blogs.technet.com/b/dataplatforminsider/archive/2013/10/11/in-memory-oltp-how-durability-is-achieved-for-memory-optimized-tables.aspx">http://blogs.technet.com/b/dataplatforminsider/archive/2013/10/11/in-memory-oltp-how-durability-is-achieved-for-memory-optimized-tables.aspx</a>

<a href="http://blogs.technet.com/b/dataplatforminsider/archive/2014/01/22/merge-operation-in-memory-optimized-tables.aspx">Merge Operation in Memory-Optimized Tables</a>
<a href="http://blogs.technet.com/b/dataplatforminsider/archive/2014/01/22/merge-operation-in-memory-optimized-tables.aspx" title="http://blogs.technet.com/b/dataplatforminsider/archive/2014/01/22/merge-operation-in-memory-optimized-tables.aspx">http://blogs.technet.com/b/dataplatforminsider/archive/2014/01/22/merge-operation-in-memory-optimized-tables.aspx</a>

Os arquivos CFP existem em um File Group dedicado.
<h3>Log Manager</h3>
Embora o Hekaton mantenha a tabela em memória, o SQL Server garante que não haverá perda de dados. Essa característica é garantida pelo bom e velho Log Manager. Assim como todos os demais componentes transacionais, o Hekaton utiliza o Log Manager para registrar todas as transações executadas. Os logs gerados são diferentes dos INSERTs tradicionais e são mais compactos. Uma das vantagens de usar o Log Manager é que automaticamente o banco de dados seria replicado para um servidor remoto usando o recurso do Always On (Availability Group) ou Log shipping.

Hekaton utiliza o mesmo arquivo LDF para gravar seus logs. Não existe um “log dedicado” para essa funcionalidade.
<h3>File Stream</h3>
Você pode estranhar bastante, mas o Hekaton utiliza o recurso de File Stream!

Veja isso: <a href="https://technet.microsoft.com/en-us/library/gg492195.aspx">sp_filestream_force_garbage_collection</a>. Curioso não?

Os arquivos CFP do Hekaton ficam armazenados em um “container” do FileStream (na prática, corresponde a um diretório). Como o backup funciona normalmente com File Stream, automaticamente o backup funciona com o Hekaton. Essa foi uma grande sacada do time do SQL Server! Não é a primeira vez que uma funcionalidade depende do File Stream… para aqueles mais antigos, talvez se lembrem do SQL Server 2005 com o Full-Text Search, que também usava os containers do File Stream.
<h5></h5>
<h3>Conclusão</h3>
Terminamos aqui a série sobre a História do Hekaton, no qual o objetivo era falar mais sobre os desafios de projeto (desde sua concepção inicial), da sua implementação (procedures compiladas) e integração com o resto do SQL Server. Deixei de cobrir uma série de detalhes, como por exemplo o versionamento de linhas e também as rotinas de background (checkpoint, garbage collector). Isso mostra como esse assunto é extenso (e interminável)!
