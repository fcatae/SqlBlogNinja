<a link='https://blogs.msdn.microsoft.com/fcatae/2016/07/05/exame-70-473-designing-and-implementing-cloud-data-platform-solutions/'>Exame 70-473: Designing and Implementing Cloud Data Platform Solutions</a>
Semana passada fiz a prova 70-473.
<blockquote>70-473 Designing and Implementing Cloud Data Platform Solutions
<a title="https://www.microsoft.com/pt-br/learning/exam-70-473.aspx" href="https://www.microsoft.com/pt-br/learning/exam-70-473.aspx">https://www.microsoft.com/pt-br/learning/exam-70-473.aspx</a></blockquote>
&nbsp;
<h3>SQL Server</h3>
Embora o título fale sobre “cloud data platform”, as perguntas foram restritas ao mundo SQL Server em diferentes cenários:
<ul>
	<li>IAAS: Instalações do SQL Server em máquinas virtuais – A primeira dificuldade é conhecer a nomenclatura das máquinas do Azure (A, D, G), pois há várias perguntas envolvendo o tamanho da máquina e tipo do disco (HDD ou SSD). É importante conhecer as opções do Premium Azure Storage e entender como montar clusters no ambiente do Azure.</li>
	<li>PAAS: Uso da plataforma do SQL Database – Esse é um modelo diferente de banco de dados, cujos recursos de hardware (CPU, memória e disco) são abstraídos pelo conceito de DTU. Nesse caso os processos de HA/DR são automatizados pelo Azure, sendo necessário apenas usar o Portal.</li>
	<li>SQL DW: Dentro do Azure, existe um serviço chamado SQL Data Warehousing. A arquitetura do SQL DW se assemelha mais ao SQL PDW, sendo composto por uma série de máquinas. A grande diferença entre esse modelo e o SQL Database (PAAS) é o fato de que o processamento (CPU) e armazenamento (disco) são escalados de forma independente. Assim, é possível aumentar o poder de processamento (medido em DTW) conforme a necessidade.</li>
	<li>SQL 2014: Com o SQL 2016 recém-lançado, a prova ainda cobre os recursos do SQL Server 2014 de integração com o Azure. Há questões que falam sobre hybrid-cloud, na qual é criada uma VPN entre o Azure e o ambiente On-Premise.</li>
</ul>
&nbsp;
<h3>Azure</h3>
As questões abordam a interação com o banco de dados de três formas distintas:
<ul>
	<li>Portal do Azure: Existem perguntas sobre as funcionalidades disponibilizadas pelo Portal do Azure. Por isso, é importante navegar no site e conhecer quais são as ferramentas disponíveis para diagnosticar problemas de desempenho, modificar o acesso de usuários, etc.</li>
	<li>Powershell: Se você não está acostumado ao Powershell, então certamente esse será um tópico complicado. Algumas (poucas) questões mostravam o provisionamento de máquinas e rotinas de automação usando Powershell.</li>
	<li>T-SQL: Esse é o bom e velho T-SQL e as DMVs. Se você conhece o Azure, então provavelmente sabe que existem restrições no SQL Database (ou SQL DW). Por exemplo, ao invés de usar o SQL Profiler, é necessário usar XEvents.</li>
</ul>
&nbsp;
<h3>Tecnologias</h3>
As questões envolviam cenários interessantes:
<ul>
	<li>Migração de dados: conheça as formas de mover os dados de um lado para o outro. Isso inclui a migração de dados entre SQL 2014 e SQL DB (bcp, BACPAC, SSMS), como também o caso tradicional de mover dados entre instâncias SQL (backup/restore, log shipping, mirrring, etc).</li>
	<li>Consolidação de bancos de dados: em vários cenários de migração de ambiente On-Premise para Azure, as questões abordavam estratégia de consolidação de banco de dados. Qual o modelo ideal (IAAS ou PAAS)? Qual o tamanho de máquina ideal? Elastic pool? Qual o mecanismo de alta disponibilidade final?</li>
	<li>Segurança: foram várias perguntas envolvendo os quesitos de segurança. Por isso, recomendo que saibam o básico sobre certificados, TDE, row encryption e auditoria. Adicionalmente, é importante saber configurar um firewall nos cenários de IAAS e PAAS.</li>
</ul>
&nbsp;
<h3></h3>
<h3>Conclusão</h3>
A prova foi difícil. O formato da prova envolve vários cenários e, por isso, perde-se muito tempo lendo textos extensos em inglês. Tecnicamente são abordados conceitos simples, mas envolvidos em cenários complexos. Por exemplo, as perguntas de alta disponibilidade dependiam de requerimentos do usuário – que não estavam claros no texto, sendo necessário deduzir informações a partir de outros pontos.

Quer uma dica de como passar? Leia esse EBOOK gratuito:
<blockquote><!-- [if lt IE 9]&gt;-->
	<script src="https://blogs.msdn.microsoft.com/microsoft_press/wp-content/themes/microsoft/js/html5.js"></script>
	Free ebook: Microsoft Azure Essentials Migrating SQL Server Databases to Azure | Microsoft Press blog

https://blogs.msdn.microsoft.com/microsoft_press/2016/05/11/free-ebook-microsoft-azure-essentials-migrating-sql-server-databases-to-azure/<script src="https://www.google-analytics.com/plugins/ga/inpage_linkid.js" type="text/javascript"></script><script src="https://ssl.google-analytics.com/ga.js" type="text/javascript"></script><script type="text/javascript">// 3e3):(d.fillText(String.fromCharCode(55357,56835),0,0),0!==d.getImageData(16,16,1,1).data[0])):!1}function e(a){var c=b.createElement("script");c.src=a,c.type="text/javascript",b.getElementsByTagName("head")[0].appendChild(c)}var f,g;c.supports={simple:d("simple"),flag:d("flag")},c.DOMReady=!1,c.readyCallback=function(){c.DOMReady=!0},c.supports.simple&amp;&amp;c.supports.flag||(g=function(){c.readyCallback()},b.addEventListener?(b.addEventListener("DOMContentLoaded",g,!1),a.addEventListener("load",g,!1)):(a.attachEvent("onload",g),b.attachEvent("onreadystatechange",function(){"complete"===b.readyState&amp;&amp;c.readyCallback()})),f=c.source||{},f.concatemoji?e(f.concatemoji):f.wpemoji&amp;&amp;f.twemoji&amp;&amp;(e(f.twemoji),e(f.wpemoji)))}(window,document,window._wpemojiSettings);
		
// ]]&gt;</script><script src="https://blogs.msdn.microsoft.com/microsoft_press/wp-includes/js/wp-emoji-release.min.js?ver=4.2.7" type="text/javascript"></script><script src="https://code.jquery.com/jquery-1.11.3.min.js" type="text/javascript"></script><script src="https://blogs.msdn.microsoft.com/microsoft_press/wp-content/plugins/simple-follow-me-social-buttons-widget/assets/js/front-widget.js?ver=3.3.3" type="text/javascript"></script><script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js" type="text/javascript"></script><script src="https://blogs.msdn.microsoft.com/microsoft_press/wp-content/themes/microsoft/js/single.js?ver=05272016" type="text/javascript"></script><script src="https://blogs.msdn.microsoft.com/microsoft_press/wp-content/themes/microsoft/js/social-counts.js?ver=05272016" type="text/javascript"></script><script type="text/javascript">// </script><!-- Begin Custom CSS --><!-- End Custom CSS --></blockquote>
<div id="page" class="site container-fluid">
<div id="site-content" class="site-content row">
<div id="primary" class="content-area col-sm-9">
<div id="single-content" class="div-content"><article id="post-22837" class="post-22837 post type-post status-publish format-standard hentry category-uncategorized tag-azure tag-ebooks tag-it-pros tag-new-books tag-sql-server">
<div class="entry-content single">
<blockquote><a href="https://msdnshared.blob.core.windows.net/media/2016/05/9781509302925.jpg"><img title="" src="https://msdnshared.blob.core.windows.net/media/2016/05/9781509302925_thumb.jpg" alt="" width="201" height="244" align="left" border="0" /></a></blockquote>
&nbsp;

</div>
</article></div>
</div>
</div>
</div>
