<a link='https://blogs.msdn.microsoft.com/fcatae/2009/12/27/estatsticas/'>Estatísticas</a>
<P>Como verificar as estatísticas relacionadas a uma tabela?</P>
<BLOCKQUOTE><PRE class="code"><SPAN>SELECT 
        </SPAN>[LastUpdate] <SPAN>= </SPAN><SPAN>STATS_DATE</SPAN><SPAN>(</SPAN><SPAN>object_id</SPAN><SPAN>, </SPAN>stats_id<SPAN>), 
        </SPAN>[Table] <SPAN>= </SPAN><SPAN>OBJECT_NAME</SPAN><SPAN>(</SPAN><SPAN>object_id</SPAN><SPAN>), 
        </SPAN>[Statistic] <SPAN>= </SPAN>name 
<SPAN>FROM </SPAN><SPAN>sys</SPAN><SPAN>.</SPAN><SPAN>stats 
</SPAN><SPAN>WHERE </SPAN><SPAN>object_id </SPAN><SPAN>= </SPAN><SPAN>OBJECT_ID</SPAN><SPAN>(</SPAN><SPAN>'tbUsuario'</SPAN><SPAN>)
</SPAN></PRE></BLOCKQUOTE>
<P><A href="images\image_2.png"><IMG title="image" border="0" alt="image" src="images\image_thumb.png" width="365" height="73"></A> </P>
<P>As estatísticas podem ter origens distintas:</P>
<UL>
<LI>Criadas explicitamente com CREATE STATISTICS</LI>
<LI>Implicitamente pelo CREATE INDEX</LI>
<LI>Criadas pelo otimizador (Auto-stats)</LI>
<LI>Hipotéticas (usadas pelo Database Tuning Wizard)</LI></UL>
