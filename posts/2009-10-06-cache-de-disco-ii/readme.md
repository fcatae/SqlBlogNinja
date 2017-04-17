<a link='https://blogs.msdn.microsoft.com/fcatae/2009/10/06/cache-de-disco-ii/'>Cache de Disco II</a>
<P>No último post sobre "Cache de Disco”, comentei sobre a importância do Write-Cache. </P>
<P>Entretanto, existe um risco em deixá-lo habilitado.</P>
<BLOCKQUOTE>
<P><EM>O que acontece com a memória cache se houver falta de energia?</EM></P>
<P><EM></EM></P></BLOCKQUOTE>
<P>As informações gravadas em cache são voláteis e podem ser perdidas se acabar a energia elétrica. Isso pode causar perda de dados e estrago nas estruturas internas das tabelas e do banco de dados.</P>
<P>Portanto, a resposta é <U>sempre</U> evitar a falta de energia elétrica (caso esteja com <STRONG>write-cache</STRONG> habilitado). <BR></P>
<UL>
<LI><STRONG>Uso de no-breaks nos servidores com disco local: </STRONG>Garante que o servidor e seus dispositivos possam efetuar a gravação de dados antes de acabar a energia elétrica. <BR></LI>
<LI><STRONG>Controladoras com bateria:</STRONG> Existem controladoras que possuem bateria para manter os dados em cache mesmo quando desligada. Quando o servidor é ligado novamente, a controladora descarrega o conteúdo do cache para os discos. Mas não esqueça de conferir o tempo de vida das baterias e trocá-las conforme a recomendação do fabricante. <BR></LI>
<LI><STRONG>Storage: </STRONG>Normalmente há fontes de alimentação redundante e que devem ser ligadas em diferentes redes elétricas. Em geral, os geradores de energia dos Data Centers garantem que não haverá falta de energia. </LI></UL>
<P>No próximo post, farei os comentários sobre cache de leitura (de novo!) e as limitações do cache de escrita.</P>
