<a link='https://blogs.msdn.microsoft.com/fcatae/2010/04/20/shared-memory/'>Shared Memory</a>
<P><STRONG>Pergunta: </STRONG>Por que não posso apagar um arquivo DLL que está em uso no Windows?</P>
<P>Para responder essa pergunta, começarei com uma outra pergunta: Qual a diferença entre <STRONG><EM>Shared </EM></STRONG>e <STRONG><EM>Private Working Set</EM>? </STRONG>(veja os números em WS Private e WS Shareable/Shared na figura abaixo).</P>
<P><A href="images\image_5.png"><IMG title="image" border="0" alt="image" src="images\image_thumb.png" width="323" height="347"></A> </P>
<P>A resposta está na tradução: shared corresponde a memória compartilhada, enquanto que private é exclusiva do processo. </P>
<P>O fato de compartilhar memória permite realizar transferência de dados entre os processos. Por exemplo, um dos protocolos de comunicação do SQL Server é Shared Memory <EM>(Desenvolvedores: há um exemplo de como compartilhar memória no MSDN – Named Memory Object).</EM></P>
<P><STRONG>Será que existe algum outro uso para Shared Memory?</STRONG></P>
<P>Por incrível que pareça sim! Todas as DLL são carregadas na forma de Shared Memory. O Sistema Operacional carrega a imagem da DLL uma única vez na memória RAM e permite que todos os processos compartilhem esse arquivo através do mapeamento de memória virtual. Como o Windows marca esse mapeamento como read-only, o conteúdo em memória é idêntico ao conteúdo em disco. Caso haja falta de memória, a DLL não será copiada para o Page File porque as informações estão sempre disponíveis em disco. Sempre que uma DLL está em uso por um processo, ela funciona como um “Page File” para o Windows. Se houver necessidade de paginação, o Windows utiliza o próprio arquivo para preencher a memória RAM. </P>
<P><STRONG>Voltando a pergunta: </STRONG>Por que não posso apagar uma DLL que está em uso?</P>
<P>Um arquivo DLL é sempre carregado como <STRONG>File-Backed Section</STRONG>, ao invés de <STRONG>Page-File-Backed Section</STRONG>. Assim como não é possível deletar o Page File, não é possível apagar um arquivo DLL em uso.</P>
<P><STRONG>Referência</STRONG></P>
<BLOCKQUOTE>
<P>MSDN - Creating Named Shared Memory <BR><A title="http://msdn.microsoft.com/en-us/library/aa366551(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366551(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa366551(VS.85).aspx</A></P></BLOCKQUOTE>
<BLOCKQUOTE>
<P>File-Backed and Page-File-Backed Sections <BR><A title="http://msdn.microsoft.com/en-us/library/ff545754(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/ff545754(VS.85).aspx">http://msdn.microsoft.com/en-us/library/ff545754(VS.85).aspx</A></P></BLOCKQUOTE>
