<a link='https://blogs.msdn.microsoft.com/fcatae/2014/03/25/logs-circulares/'>Logs Circulares</a>
<p>Semana passada alguém me perguntou sobre esse “Ring Buffer”. É incrível a coincidência de que sempre que falo sobre memória, alguém comenta sobre esse recurso. Esse assunto sempre volta a tona, eu mesmo já escrevi um post sobre <a href="http://blogs.msdn.com/b/fcatae/archive/2010/09/30/monitorar-ring-buffer.aspx">Ring Buffer</a> e agora estou escrevendo novamente.</p>  <blockquote>   <p><strong>O que é um Ring Buffer?        <br /></strong>A tradução literal é um log circular.</p> </blockquote>  <p>Esse é um componente base disponibilizado pelo SQLOS para os demais componentes do SQL Server. Qualquer funcionalidade pode registrar uma informação no log circular. Essas informações ficam em memória e são perdidas em caso de restart do serviço.</p>    <h3>Como posso enxergar os logs?</h3>  <p>Utilize a DMV sys.dm_os_ring_buffers para observar todas as entradas. Nesse caso, temos 3140 registros cadastrados.</p>  <blockquote>   <p><a href="images\6683.image_2BB9EF6E.png"><img title="image" border="0" alt="image" src="images\0763.image_thumb_64D35D21.png" width="316" height="117" /></a></p> </blockquote>    <h3>Quantos logs circulares existem?</h3>  <p>Existe uma única DMV chamada sys.dm_os_ring_buffers (note que “buffers” está no plural), que representa vários logs circulares. Para identificar todos os diferentes logs circulares, podemos usar o campo “ring_buffer_type”:</p>  <blockquote>   <p><a href="images\6153.image_06528CB1.png"><img title="image" border="0" alt="image" src="images\1134.image_thumb_75DA1BB5.png" width="423" height="259" /></a></p> </blockquote>  <p>Embora a DMV represente a união de todos os registros, cada tipo (ring_buffer_type) representa um “log circular físico”. É semelhante a uma view, que referencia a várias tabelas.</p>    <h3>Como ler as informações?</h3>  <p>Os dados ficam armazenados na coluna <strong>record</strong>, enquanto que a hora é registrada em <strong>timestamp</strong>.</p>  <blockquote>   <p><a href="images\8424.image_4EA26331.png"><img title="image" border="0" alt="image" src="images\7416.image_thumb_3E29F236.png" width="498" height="173" /></a></p> </blockquote>  <p>Podemos transformar o campo <strong>record </strong>em tipo XML, facilitando o uso de XQuery para as consultas.</p>  <blockquote>   <p><a href="images\2465.image_5D6F29BA.png"><img title="image" border="0" alt="image" src="images\8750.image_thumb_6F4E4E38.png" width="438" height="173" /></a></p> </blockquote>  <p>Em relação ao <strong>timestamp</strong>, é preciso fazer uma mágica para apresentar o formato de data/hora. </p>  <blockquote>   <p><font face="Consolas">SELECT        <br /></font><font face="Consolas"><strong>&#160;&#160;&#160; DATEADD (ms,          <br />&#160;&#160;&#160;&#160;&#160;&#160;&#160; [timestamp] - (SELECT ms_ticks FROM sys.dm_os_sys_info),           <br />&#160;&#160;&#160;&#160;&#160;&#160;&#160; GETDATE()) AS timestamp          <br /></strong></font><font face="Consolas">       <br /> FROM sys.dm_os_ring_buffers order by timestamp desc</font></p> </blockquote>  <blockquote>   <p><a href="images\8203.image_0BED5ABD.png"><img title="image" border="0" alt="image" src="images\5305.image_thumb_3BAB033C.png" width="152" height="109" /></a></p> </blockquote>    <h3>Conclusão</h3>  <p>A análise dos logs circulares é bem interessante e permite identificar uma série de comportamentos do SQL Server. Embora esses logs já existam nativamente, é possível criar logs customizados usando XEvents. A partir daí que temos grandes poderes para compreender como funciona as minúcias do SQL Server.</p>