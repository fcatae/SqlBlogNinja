<a link='https://blogs.msdn.microsoft.com/fcatae/2010/04/16/desafio-usando-order-by-dentro-de-uma-view/'>Desafio: Usando ORDER BY dentro de uma VIEW</a>
<P>Deixo compartilhar uma situação que ocorreu no trabalho: o desenvolvedor utilizava uma view para retornar os dados ordenados. Segundo ele, o comando abaixo funcionava no SQL 2000, mas deixou de funcionar no SQL 2005.</P>
<BLOCKQUOTE>
<P><SPAN>CREATE VIEW </SPAN>vwOperacao <BR><SPAN>AS <BR>SELECT </SPAN><SPAN>* </SPAN><SPAN>FROM </SPAN>tbOperacao <BR><SPAN>ORDER BY </SPAN>data</P></BLOCKQUOTE>
<BLOCKQUOTE><PRE class="code"><FONT color="#ff0000">Msg 1033, Level 15, State 1, Procedure vwOperacao, Line 4
The ORDER BY clause is invalid in views, inline functions, <BR>derived tables, subqueries, and common table expressions, <BR>unless TOP or FOR XML is also specified.</FONT></PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A>
<P>Seguindo as orientações da própria mensagem, ele decidiu utilizar a seguinte notação:</P>
<BLOCKQUOTE><PRE class="code"><SPAN>CREATE VIEW </SPAN>vwOperacao 
<SPAN>AS
SELECT TOP </SPAN>100 <SPAN>PERCENT </SPAN><SPAN>* </SPAN><SPAN>FROM </SPAN>tbOperacao
<SPAN>ORDER BY </SPAN>data</PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A>
<P>Qual o problema nisso? Ao consultar a View, os resultados não obedecem ao ORDER BY.</P>
<BLOCKQUOTE><PRE class="code"><SPAN>select </SPAN><SPAN>* </SPAN><SPAN>FROM </SPAN>vwOperacao <SPAN>WHERE </SPAN>oper <SPAN>= </SPAN><SPAN>'JOE'</SPAN></PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A>
<P><STRONG>Perguntas:</STRONG></P>
<P>1) Por que o comando ORDER BY é inválido em VIEWS (Erro 1033) exceto se houver a expressão TOP?</P>
<P>2) Por que os resultados retornam fora de ordem apesar do ORDER BY estar definido na View?</P>
<P>3) Qual seria uma correção rápida? (sim, existe um quebra-galho!)</P>
<P><STRONG>Quem souber a resposta, por favor, poste nos comentários! (Utilize o script anexado no post para criar a tabela)</STRONG></P>
<p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Components.PostAttachments/00/09/99/76/11/DesafioOrderBy.sql">DesafioOrderBy.sql</a></p>
