<a link='https://blogs.msdn.microsoft.com/fcatae/2009/10/19/background-task-lazy-writer/'>Background Task: Lazy Writer</a>
<P><STRONG>Lazy writer </STRONG>é o processo responsável por escrever os dados em disco de forma assíncrona, além de desempenhar um papel importante no gerenciamento de memória.</P>
<UL>
<LI>Escrita assíncrona de dados? </LI></UL>
<BLOCKQUOTE>
<P>Sim! Os comandos UPDATE/INSERT/DELETE são gravados no Transaction Log de forma síncrona, mas realizam as modificações dos dados em memória. Nesse momento, o comando finaliza e o controle retorna ao usuário. Em background, o processo de lazy writer transfere as informações para os arquivos de Dados. <BR></P></BLOCKQUOTE>
<UL>
<LI>Qual o papel do Lazy writer no gerenciamento de memória?</LI></UL>
<BLOCKQUOTE>
<P>Durante a execução do Lazy writer, o tamanho do Buffer Pool (também conhecido como Data Cache) é recalculado e libera-se memória se necessário. </P></BLOCKQUOTE>
<P>Apenas como curiosidade, o Lazy writer é um processo de sistema e pode ser observado através da query:</P>
<P><SPAN>&nbsp;&nbsp; SELECT</SPAN><SPAN>*</SPAN><SPAN>FROM</SPAN><SPAN>sys</SPAN><SPAN>.</SPAN><SPAN>dm_exec_requests <BR></SPAN><SPAN>&nbsp;&nbsp; WHERE</SPAN>command <SPAN>=</SPAN><SPAN>'LAZY WRITER'</SPAN></P><A href="http://11011.net/software/vspaste"></A>
<P>Ao rodar o SELECT anterior na minha máquina, observamos que o lazy writer roda como SessionID 4 em background.</P>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LazyWriter_142E8/image_2.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LazyWriter_142E8/image_thumb.png" width="407" height="39"></A> </P>
<P>Em servidores de arquitetura NUMA, uma instância SQL Server possui um Lazy writer para cada Memory Node.</P>
