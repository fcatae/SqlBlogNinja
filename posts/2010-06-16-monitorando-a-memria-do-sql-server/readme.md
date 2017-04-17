<a link='https://blogs.msdn.microsoft.com/fcatae/2010/06/16/monitorando-a-memria-do-sql-server/'>Monitorando a Memória do SQL Server</a>
<p>Hoje recebi um comentário sobre a utilização de memória no SQL Server e comecei a pensar um pouco mais sobre o assunto. Será que esse é um assunto interessante?</p>  <p>Comentei com um amigo sobre o assunto e ele (que não trabalha em TI) disse que vale a pena. Minha motivação do blog será mostrar um pouco mais sobre os mecanismos de gerenciamento de memória usados no SQL Server.</p>  <p>Para começar a série de artigos, compartilho a imagem de uma utilização crescente de memória e que resultou numa degradação horrível de performance.</p>  <p>&#160;</p>  <p><a href="images\6136.image_2.png"><img style="border-bottom: 0px;border-left: 0px;float: none;margin-left: auto;border-top: 0px;margin-right: auto;border-right: 0px" title="image" border="0" alt="image" src="images\7534.image_thumb.png" width="382" height="239" /></a> </p>  <p>O primeiro conceito importante é falar sobre memória física ou memória RAM. Como vocês sabem, o Windows utiliza memória virtual, que permite colocar as informações em RAM e movê-las para o Paging File quando necessário. Entretanto, no mundo SQL Server estamos interessados somente na memória RAM porque a paginação em disco é muito lenta (não faz sentido fazer cache de dados usando o Page File).</p>  <p>Na linguagem técnica, dizemos que <strong>working set </strong>(veja o artigo <a title="Memory- Working Set" href="http://blogs.msdn.com/b/fcatae/archive/2010/03/31/memory-working-set.aspx">Memory- Working Set</a>) corresponde a quantidade de memória RAM usada por um processo.</p>  <p><em><strong>Atenção: </strong>Apesar do Windows mostrar o working set dos processos, essa medida não contabiliza a memória alocada via AWE. Em outras palavras, evite utilizar o Task Manager para monitorar a quantidade de memória utilizada. Verifique os contadores do Performance Monitor chamados “Total Server Memory”.</em></p>  <p>No próximo artigo, pretendo introduzir o conceito de <strong>Buffer Pool – </strong>principal componente que interage com o Sistema Operacional.</p>