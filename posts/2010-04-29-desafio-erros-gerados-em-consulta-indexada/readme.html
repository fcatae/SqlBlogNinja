<a link='https://blogs.msdn.microsoft.com/fcatae/2010/04/29/desafio-erros-gerados-em-consulta-indexada/'>Desafio: Erros gerados em consulta indexada</a>
<P>&nbsp;</P>
<P>No <A href="http://blogs.msdn.com/fcatae/archive/2010/04/17/desafio-usando-order-by-dentro-de-uma-view.aspx" target="_blank">desafio anterior</A>, comentamos sobre a restrição de uso do ORDER BY dentro de uma View. Dessa vez, o desafio está relacionado a uma consulta que passa a gerar erros após a criação de índices.</P>
<P>Imagine uma tabela composta pelos campos (ID, Nome, Idade) como na figura abaixo e uma consulta para determinar o número de pessoas com mais de 18 anos. <BR></P>
<BLOCKQUOTE>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/Desafio_E14B/image_2.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/Desafio_E14B/image_thumb.png" width="159" height="105"></A> </P></BLOCKQUOTE>
<BLOCKQUOTE><PRE class="code"><SPAN>SELECT </SPAN>Menores <SPAN>= </SPAN><SPAN>COUNT</SPAN><SPAN>(*) </SPAN><SPAN>FROM </SPAN>vwLista
<SPAN>WHERE </SPAN>campoNome <SPAN>= </SPAN><SPAN>'Idade' </SPAN><SPAN>and </SPAN><SPAN>CAST</SPAN><SPAN>(</SPAN>campoValor <SPAN>as INT</SPAN><SPAN>) &gt; </SPAN>18</PRE><A href="http://11011.net/software/vspaste"></A><PRE class="code">Menores
-----------
5

(1 row(s) affected)</PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A><SPAN>
<P><BR></P></SPAN><A href="http://11011.net/software/vspaste"></A>
<P>Os dados foram expostos a partir de uma view, definida sobre as tabelas <FONT face="Courier New">ListaItem</FONT>, <FONT face="Courier New">ColunaItem</FONT> e <FONT face="Courier New">DetalheItem</FONT>.</P>
<BLOCKQUOTE><PRE class="code"><SPAN>CREATE VIEW </SPAN>vwLista 
<SPAN>AS
SELECT </SPAN>l<SPAN>.</SPAN>listaId<SPAN>, </SPAN>c<SPAN>.</SPAN>campoNome<SPAN>, </SPAN>i<SPAN>.</SPAN>campoValor <BR><SPAN>FROM </SPAN>dbo<SPAN>.</SPAN>ListaItem l 
    <SPAN>INNER JOIN </SPAN>dbo<SPAN>.</SPAN>DetalheItem i <SPAN>ON </SPAN>l<SPAN>.</SPAN>listaId <SPAN>= </SPAN>i<SPAN>.</SPAN>listaId 
    <SPAN>INNER JOIN </SPAN>dbo<SPAN>.</SPAN>ColunaItem c <SPAN>ON </SPAN>c<SPAN>.</SPAN>colId <SPAN>= </SPAN>i<SPAN>.</SPAN>colunaId</PRE></BLOCKQUOTE>
<P>Com o objetivo de melhorar o desempenho, foram criados os seguintes índices:</P>
<BLOCKQUOTE><PRE class="code"><SPAN>CREATE INDEX </SPAN>idxColId <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>colId<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxColName <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>campoNome<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxValor <SPAN>ON </SPAN>DetalheItem<SPAN>(</SPAN>campoValor<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxLista <SPAN>ON </SPAN>ListaItem<SPAN>(</SPAN>listaId<SPAN>)
</SPAN><SPAN>CREATE INDEX </SPAN>idxColNameId <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>campoNome<SPAN>,</SPAN>colId<SPAN>)</SPAN></PRE></BLOCKQUOTE>
<P>Após essas mudanças, a query começou a retornar erros. </P>
<BLOCKQUOTE><PRE class="code"><SPAN>SELECT </SPAN>Menores <SPAN>= </SPAN><SPAN>COUNT</SPAN><SPAN>(*) </SPAN><SPAN>FROM </SPAN>vwLista
<SPAN>WHERE </SPAN>campoNome <SPAN>= </SPAN><SPAN>'Idade' </SPAN><SPAN>and </SPAN><SPAN>CAST</SPAN><SPAN>(</SPAN>campoValor <SPAN>as INT</SPAN><SPAN>) &gt; </SPAN>18</PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A><A href="http://11011.net/software/vspaste"></A>
<BLOCKQUOTE><PRE class="code"><FONT color="#ff0000">Msg 245, Level 16, State 1, Line 12
Conversion failed when converting the varchar value <BR>'Admin' to data type int.</FONT></PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A>
<P><STRONG></STRONG>&nbsp;</P>
<P><STRONG>Perguntas:</STRONG></P>
<BLOCKQUOTE>
<P>1) Por que a query começou a falhar após a criação de índices?</P>
<P>2) Qual o problema na forma que foi escrita a query? Qual a forma correta de escrevê-la? (erro conceitual)</P>
<P>3) Como reescrever a View de forma a evitar esse tipo de erro?</P>
<P>4) Existe alguma alternativa para evitar esse tipo de erro sem alterar o código existente?</P></BLOCKQUOTE>
<P><STRONG></STRONG>&nbsp;</P>
<P><STRONG>Escreva sua resposta nos comentários. Estou curioso para saber quais serão as soluções propostas.</STRONG></P>
<P>&nbsp;</P>
<P>Script para criação de tabela e dados:</P>
<TABLE border="1" width="100%" bgColor="#efefef">
<TBODY>
<TR>
<TD><PRE class="code"><FONT size="1"><SPAN>   CREATE TABLE </SPAN>ListaItem
<SPAN>    (</SPAN>listaId <SPAN>INT</SPAN><SPAN>, </SPAN>nome <SPAN>VARCHAR</SPAN><SPAN>(</SPAN>10<SPAN>), </SPAN>itemId <SPAN>INT</SPAN></FONT><FONT size="1"><SPAN>)

</SPAN><SPAN>   CREATE TABLE </SPAN>ColunaItem
<SPAN>    (</SPAN>colId <SPAN>INT</SPAN><SPAN>, </SPAN>campoNome <SPAN>VARCHAR</SPAN><SPAN>(</SPAN>10<SPAN>), </SPAN>campoTipo <SPAN>VARCHAR</SPAN><SPAN>(</SPAN>10</FONT><FONT size="1"><SPAN>))

</SPAN><SPAN>   CREATE TABLE </SPAN>DetalheItem
    <SPAN>(</SPAN>itemId <SPAN>INT IDENTITY</SPAN><SPAN>(</SPAN>1<SPAN>,</SPAN>1</FONT><FONT size="1"><SPAN>),
     </SPAN>listaId <SPAN>INT</SPAN><SPAN>, </SPAN>colunaId <SPAN>INT</SPAN><SPAN>, </SPAN>campoValor <SPAN>VARCHAR</SPAN><SPAN>(</SPAN>256</FONT><FONT size="1"><SPAN>))

</SPAN><SPAN>   INSERT </SPAN>ListaItem <SPAN>(</SPAN>listaId<SPAN>, </SPAN>nome<SPAN>) </SPAN></FONT><FONT size="1"><SPAN>VALUES 
    </SPAN><SPAN>(</SPAN>1<SPAN>,</SPAN><SPAN>'ADM'</SPAN><SPAN>), (</SPAN>2<SPAN>,</SPAN><SPAN>'USR1'</SPAN><SPAN>), (</SPAN>3<SPAN>,</SPAN><SPAN>'USR2'</SPAN><SPAN>), (</SPAN>4<SPAN>,</SPAN><SPAN>'USR3'</SPAN><SPAN>), (</SPAN>5<SPAN>,</SPAN><SPAN>'USR4'</SPAN></FONT><FONT size="1"><SPAN>)

</SPAN><SPAN>   INSERT </SPAN>ColunaItem <SPAN>(</SPAN>colId<SPAN>, </SPAN>campoTipo<SPAN>, </SPAN>campoNome<SPAN>) </SPAN></FONT><FONT size="1"><SPAN>VALUES
    </SPAN><SPAN>(</SPAN>1<SPAN>,</SPAN><SPAN>'CHAR'</SPAN><SPAN>,</SPAN><SPAN>'Nome'</SPAN><SPAN>), (</SPAN>2<SPAN>,</SPAN><SPAN>'INT'</SPAN><SPAN>,</SPAN><SPAN>'Idade'</SPAN></FONT><FONT size="1"><SPAN>)

</SPAN><SPAN>   INSERT </SPAN>DetalheItem <SPAN>(</SPAN>listaId<SPAN>, </SPAN>colunaId<SPAN>, </SPAN>campoValor<SPAN>) </SPAN></FONT><FONT size="1"><SPAN>VALUES 
    </SPAN><SPAN>(</SPAN>1<SPAN>,</SPAN>1<SPAN>,</SPAN><SPAN>'Admin'</SPAN><SPAN>), (</SPAN>1<SPAN>,</SPAN>2<SPAN>,</SPAN><SPAN>'31'</SPAN><SPAN>), (</SPAN>2<SPAN>,</SPAN>1<SPAN>,</SPAN><SPAN>'User A'</SPAN><SPAN>), (</SPAN>2<SPAN>,</SPAN>2<SPAN>,</SPAN><SPAN>'25'</SPAN></FONT><FONT size="1"><SPAN>),     
    (</SPAN>3<SPAN>,</SPAN>1<SPAN>,</SPAN><SPAN>'User B'</SPAN><SPAN>), (</SPAN>3<SPAN>,</SPAN>2<SPAN>,</SPAN><SPAN>'26'</SPAN><SPAN>), (</SPAN>4<SPAN>,</SPAN>1<SPAN>,</SPAN><SPAN>'User C'</SPAN><SPAN>), (</SPAN>4<SPAN>,</SPAN>2<SPAN>,</SPAN><SPAN>'19'</SPAN></FONT><FONT size="1"><SPAN>),     
    (</SPAN>5<SPAN>, </SPAN>1<SPAN>, </SPAN><SPAN>'User D'</SPAN><SPAN>), (</SPAN>5<SPAN>, </SPAN>2<SPAN>, </SPAN><SPAN>'21'</SPAN></FONT><FONT size="1"><SPAN>)
    
</SPAN><SPAN>   CREATE INDEX </SPAN>idxColunaId <SPAN>ON </SPAN>DetalheItem<SPAN>(</SPAN>colunaId</FONT><SPAN><FONT size="1">)
</FONT></SPAN><FONT size="1"><SPAN>   GO
   
   CREATE VIEW </SPAN>vwLista 
</FONT><FONT size="1"><SPAN>   AS
   SELECT </SPAN>l<SPAN>.</SPAN>listaId<SPAN>, </SPAN>c<SPAN>.</SPAN>campoNome<SPAN>, </SPAN>i<SPAN>.</SPAN>campoValor <SPAN>FROM </SPAN>dbo<SPAN>.</SPAN>ListaItem l 
      <SPAN>INNER JOIN </SPAN>dbo<SPAN>.</SPAN>DetalheItem i <SPAN>ON </SPAN>l<SPAN>.</SPAN>listaId <SPAN>= </SPAN>i<SPAN>.</SPAN>listaId 
      <SPAN>INNER JOIN </SPAN>dbo<SPAN>.</SPAN>ColunaItem c <SPAN>ON </SPAN>c<SPAN>.</SPAN>colId <SPAN>= </SPAN>i<SPAN>.</SPAN>colunaId
</FONT><SPAN><FONT size="1">   GO

</FONT></SPAN><FONT size="1"><SPAN>   -- Criacao dos indices adicionais: a query para de funcionar
</SPAN><SPAN>   CREATE INDEX </SPAN>idxColId <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>colId</FONT><FONT size="1"><SPAN>)
</SPAN><SPAN>   CREATE INDEX </SPAN>idxColName <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>campoNome</FONT><FONT size="1"><SPAN>)
</SPAN><SPAN>   CREATE INDEX </SPAN>idxValor <SPAN>ON </SPAN>DetalheItem<SPAN>(</SPAN>campoValor</FONT><FONT size="1"><SPAN>)
</SPAN><SPAN>   CREATE INDEX </SPAN>idxLista <SPAN>ON </SPAN>ListaItem<SPAN>(</SPAN>listaId</FONT><FONT size="1"><SPAN>)
</SPAN><SPAN>   CREATE INDEX </SPAN>idxColNameId <SPAN>ON </SPAN>ColunaItem<SPAN>(</SPAN>campoNome<SPAN>, </SPAN>colId</FONT><SPAN><FONT size="1">)
</FONT></SPAN></PRE></TD></TR></TBODY></TABLE>
<P><A href="http://11011.net/software/vspaste"></A>&nbsp;</P>
<p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Components.PostAttachments/00/10/00/47/42/desafio.sql">desafio.sql</a></p>
