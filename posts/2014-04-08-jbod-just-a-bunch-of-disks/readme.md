<a link='https://blogs.msdn.microsoft.com/fcatae/2014/04/08/jbod-just-a-bunch-of-disks/'>JBOD: Just a Bunch of Disks</a>
<p>Estava em um reuni&atilde;o para definir a estrat&eacute;gia de storage do cliente, quando algu&eacute;m comentou (n&atilde;o lembro das palavras exatas, mas era similar a):</p>
<blockquote>
<p>&ldquo;Voc&ecirc;s querem usar um JBOD para guardar os dados?&rdquo;</p>
</blockquote>
<p>Que raios seria um JBOD? Essa &eacute; uma sigla curiosa&hellip; mais curioso &eacute; o seu significado: Just a Bunch of Disks. Essa hist&oacute;ria j&aacute; faz 6 anos e vou dizer que foi um grande aprendizado, porque n&atilde;o tinha a menor ideia sobre Storage. Essa foi uma das grandes motiva&ccedil;&otilde;es que levou a estudar esse assunto e curiosamente meus primeiros posts eram relacionados a disco.</p>
<p>A primeira tentativa foi traduzir a sigla JBOD para o portugu&ecirc;s: ABDD &ndash; Apenas um Bando De Discos, ou seja, n&atilde;o possui absolutamente nenhum significado.</p>
<p>Logo em seguida, um colega me explicou o b&aacute;sico sobre discos e como que o servidor enxergava. A explica&ccedil;&atilde;o foi bem did&aacute;tica e come&ccedil;ou falando sobre como os discos eram fisicamente adicionados em um servidor. Na realidade, o servidor (a m&aacute;quina f&iacute;sica) n&atilde;o tem espa&ccedil;o para adicionar dezenas de discos, por isso, existe um gabinete espec&iacute;fico para adicionar esses discos.</p>
<blockquote>
<p><a href="images\8304.image_41C6FCBF.png"><img title="image" src="images\4214.image_thumb_4BB7FFF8.png" alt="image" width="487" height="366" border="0" /></a></p>
</blockquote>
<p>Esse gabinete estava ligado a um servidor, que enxergava esses discos normalmente como &ldquo;apenas um bando de discos&rdquo;. Isso significa que haveria um monte de letras D:, E:, F:, G:, etc&hellip; cada um representando um disco f&iacute;sico. Portanto, essa &eacute; uma organiza&ccedil;&atilde;o de discos denominada JBOD.</p>
<p>Agora sempre que me falam de JBOD (Just a bunch of disks), imagino que seja literalmente a foto acima: um monte de discos disponiveis para o sistema operacional.</p>
<p>Em geral, no mundo SQL Server, n&atilde;o gostamos do modelo JBOD &ndash; queremos algo que forne&ccedil;a uma redund&acirc;ncia da informa&ccedil;&atilde;o. Da&iacute; surge a express&atilde;o RAID - Redundant Array of Independent Disks, que fornece a capacidade de paridade ou espelhamento dos discos.</p>
<p>Por fim, deixo uma pergunta para ver se o conceito est&aacute; claro. Qual a diferen&ccedil;a entre o JBOD e RAID 0?</p>
