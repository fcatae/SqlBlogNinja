<a link='https://blogs.msdn.microsoft.com/fcatae/2010/02/17/atualizando-as-estatistica-apos-index-rebuild/'>Atualizando as estatistica apos INDEX REBUILD</a>
<P>Sabe-se que as estatísticas são atualizadas durante a recriação de índice (ALTER INDEX REBUILD). Então, surge uma dúvida: <STRONG>se o processo noturno de manutenção realiza o rebuild de índice diariamente, ainda é necessário atualizar as estatísticas?</STRONG></P>
<P>Com o objetivo de responder essa pergunta, vamos criar um cenário para teste com as tabelas tbUsuario e tbObjetos.</P>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_2.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_thumb.png" width="387" height="143"></A> </P>
<P>Foram criados os <STRONG>índices</STRONG> e as <STRONG>estatísticas</STRONG> nas tabelas:</P>
<BLOCKQUOTE><PRE class="code"><SPAN>CREATE INDEX </SPAN>idxUsuarioId <SPAN>ON </SPAN>tbObjetos<SPAN>(</SPAN>UsuarioId<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxNome <SPAN>ON </SPAN>tbUsuario<SPAN>(</SPAN>Nome<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxTipo <SPAN>ON </SPAN>tbObjetos<SPAN>(</SPAN>Tipo<SPAN>)
</SPAN><SPAN>CREATE STATISTICS </SPAN>statIdade <SPAN>ON </SPAN>tbUsuario<SPAN>(</SPAN>Idade<SPAN>)
</SPAN><SPAN>CREATE STATISTICS </SPAN>statUsuario <SPAN>ON </SPAN>tbObjetos<SPAN>(</SPAN>UsuarioId<SPAN>, </SPAN>ObjetoId<SPAN>)</SPAN></PRE></BLOCKQUOTE>
<P><SPAN><FONT color="#000000"><BR>Através do comando <STRONG>UPDATE STATISTICS</STRONG>, atualizamos todas as estatísticas manualmente:</FONT></SPAN></P>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_4.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_thumb_1.png" width="314" height="160"></A> </P>
<DIV>
<P><BR>No dia seguinte, rodamos um Rebuild das tabelas:</P>
<BLOCKQUOTE><PRE class="code"><SPAN>ALTER INDEX </SPAN>pkUsuario <SPAN>ON </SPAN>tbUsuario <SPAN>REBUILD
ALTER INDEX </SPAN>pkObjetos <SPAN>ON </SPAN>tbObjetos <SPAN>REBUILD</SPAN></PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A><A href="http://11011.net/software/vspaste"></A>
<P><BR>Observamos quais estatísticas foram atualizadas:</P>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_6.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/CreateTable_BFE3/image_thumb_2.png" width="313" height="160"></A> </P></DIV>
<P><BR><STRONG>Conclusão: </STRONG>Somente as estatísticas associadas aos índices foram atualizadas. As estatísticas associadas aos demais índices ou criadas manualmente (inclusive auto-create stats) não são atualizadas durante o Rebuild de índice.&nbsp;&nbsp;</P>
<P>Portanto, o comentário de atualizar estatística após o rebuild de índices é válido, </P>
