<a link='https://blogs.msdn.microsoft.com/fcatae/2016/01/12/perfmon-falso-sentido-de-monitorao/'>Perfmon: Falso Sentido de Monitoração</a>
No post anterior, introduzi <a href="http://blogs.msdn.com/b/fcatae/archive/2016/01/05/monitore-o-consumo-de-recursos-do-banco-de-dados.aspx">a primeira das 9 regras para otimização de performance: </a>
<blockquote><strong>Regra 1: Monitorar o consumo de recursos
</strong><a title="http://blogs.msdn.com/b/fcatae/archive/2016/01/05/monitore-o-consumo-de-recursos-do-banco-de-dados.aspx" href="http://blogs.msdn.com/b/fcatae/archive/2016/01/05/monitore-o-consumo-de-recursos-do-banco-de-dados.aspx">http://blogs.msdn.com/b/fcatae/archive/2016/01/05/monitore-o-consumo-de-recursos-do-banco-de-dados.aspx</a></blockquote>
Monitore o consumo: É fácil falar, mas é difícil fazer. Vamos usar como exemplo alguns dos contadores (Perfmon) mais usados pelos DBA:
<ul>
	<li>Processor
<ul>
	<li>%Processor Time = 65%</li>
</ul>
</li>
	<li>Logical Disk
<ul>
	<li>Average Disk Queue Length = 13</li>
</ul>
</li>
	<li>SQL Buffer Manager
<ul>
	<li>Page Life Expectancy = 140</li>
	<li>Buffer cache hit ratio = 92%</li>
	<li>Lazy Writer/sec = 0.5</li>
</ul>
</li>
	<li>SQL General Statistics
<ul>
	<li>User Connections = 5200</li>
</ul>
</li>
</ul>
Então, posso tirar algumas (falsas) conclusões:
<ol>
	<li>Consumo de CPU está relativamente alto em torno de 65%, que pode indicar que o processador está ocupado demais</li>
	<li>A fila de disco está acima de 2. Isso pode indicar um problema grave de disco</li>
	<li>O contador do Page Life Expectancy (PLE) está abaixo de 300, indicando falta de memória.</li>
	<li>Buffer cache hit ratio está acima de 90%, revelando que a falta de memória não impacta o sistema</li>
	<li>Há um número alto de usuários conectados (5200) e pode estar causando carga no sistema.</li>
</ol>
Essas são apenas hipóteses baseadas nos valores observados. Esses fatos isolados são podem responder a perguntas do tipo: Preciso comprar mais CPU? Devo adicionar memória ao banco de dados? Será que há muitos usuários conectados? Recomendaria o uso de discos SSD?

Infelizmente não é possível tomar nenhuma ação com esses dados.

&nbsp;
<h3>Esqueça números, use gráficos</h3>
É difícil analisar números frios, por isso, sempre que possível use gráficos. O gráfico revela as oscilações nos indicadores e os dias/horários que houve a mudança. Veja o gráfico a seguir com o contador Page Life Expectancy. Que conclusão temos nesse caso?

<a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/4456.image_61A79145.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/7384.image_thumb_3C3D9DD7.png" alt="image" width="644" height="165" border="0" /></a>

Parece que as 10h temos o menor valor.

Note que ainda assim, a análise continua difícil. Posso fazer duas afirmações <u>válidas</u> mas contraditórias:
<ol>
	<li>Está ótimo! O servidor está trabalhando muito bem.</li>
	<li>Esse servidor poderia se beneficiar de aumento de memória.</li>
</ol>
Tudo aqui depende da base de comparação. Se compararmos com os servidores com alta carga, podemos dizer que esse servidor está ótimo (#1). Por outro lado, se compararmos com um servidor tranquilo, poderíamos dizer que o gráfico poderia ser melhor (#2).

Minha opinião é que frequentemente tiramos falsas conclusões do perfmon.

&nbsp;
<h3>Perfmon: Ferramenta de Baseline</h3>
Perfmon é uma ferramenta essencial para monitorar o banco de dados, mas não use como ferramenta primária de troubleshooting.

Como assim? Imagine que o Perfmon seja igual ao medidor de combustível de um carro (de corrida):
<blockquote><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/0474.image_5910FD4C.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border-width: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/0576.image_thumb_5D1DDBCF.png" alt="image" width="129" height="129" border="0" /></a></blockquote>
<p align="left">Esse medidor é importantíssimo, pois não podemos chegar ao nível zero. Entretanto, é muito difícil determinar o desempenho do carro olhando para esse indicador isoladamente. Pense no Perfmon da mesma forma:</p>

<ul>
	<li>
<div align="left">Não use ele para medir performance do sistema</div></li>
	<li>
<div align="left">Não considere ele como principal ferramenta de tuning</div></li>
	<li>
<div align="left">Não tire conclusões precipitadas com base nele</div></li>
</ul>
O correto uso do Perfomance Monitor é fazer “baseline de comparação”:
<ul>
	<li>Estou consumindo mais recurso no mês de janeiro?</li>
	<li>Quanto de recurso foi economizado depois das otimizações?</li>
	<li>Cheguei no esgotamento de recursos?</li>
</ul>
Esse foi um exemplo de trabalho de otimização que fiz em um servidor há um tempo:

<strong>CPU - ANTES</strong>

<a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/8424.image_6CC07791.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border-width: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/4670.image_thumb_71398909.png" alt="image" width="644" height="164" border="0" /></a>

<strong>CPU – DEPOIS</strong>

<a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/2047.image_40A60B51.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border-width: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/6114.image_thumb_5048A713.png" alt="image" width="644" height="165" border="0" /></a>

Parece que houve ganhos correto? Agora veja qual foi a redução no acesso ao disco (quanto menor, melhor):

<strong>IOPS de Disco – ANTES</strong>

<a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/3264.image_78E7131A.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border-width: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/5187.image_thumb_6464544D.png" alt="image" width="644" height="164" border="0" /></a>

<strong>IOPS de Disco – DEPOIS</strong>

<a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/0027.image_05E383DD.png"><img style="padding-top: 0px;padding-left: 0px;padding-right: 0px;border-width: 0px" title="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/2021.image_thumb_77A79B9D.png" alt="image" width="644" height="164" border="0" /></a>

É fácil de fazer comparações usando o Performance Monitor.

&nbsp;
<h3>Conclusão</h3>
Muitas pessoas usam o Perfmon da maneira incorreta, dando o falso sentimento de monitoração.

Não esqueça que o Perfmon é igual ao medidor de combustível. Não deixe o servidor ficar com o tanque vazio. Adicione alertas e monitore por condições críticas. Faça comparações de baseline e procure responder aos seguintes tipos de perguntas:
<ul>
	<li>Estou consumindo mais recurso no mês de janeiro?</li>
	<li>Quanto de recurso foi economizado depois das otimizações?</li>
	<li>Cheguei ao esgotamento de recursos?</li>
</ul>
Essa é a forma correta de usa-lo.

No próximo artigo, vou falar sobre os grandes mitos do Performance Monitor.
