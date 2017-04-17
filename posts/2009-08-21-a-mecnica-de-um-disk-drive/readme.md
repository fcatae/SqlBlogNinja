<a link='https://blogs.msdn.microsoft.com/fcatae/2009/08/21/a-mecnica-de-um-disk-drive/'>A mecânica de um Disk Drive</a>
<P>Como tirar melhor proveito da performance do disco? <BR></P>
<P>Lembro-me de um curso que tive sobre Storage, no qual o instrutor começava perguntando se alguém sabia o que era um disk drive. Ao mesmo tempo que a resposta parecia óbvia ("Lógico que sim!!!"), todos na classe sabiam que havia algo mais na pergunta. Ele deixou claro que queria começar do zero e logo mostrou algumas ilustrações de disco.</P>
<P>Primeiro, foram descritos os principais componentes de um disk drive:</P>
<UL>
<LI>Platter - São os discos magnéticos que armazenam os dados. </LI>
<LI>Head (Cabeçote) - Dispositivo responsável por realizar a leitura/gravação em disco. </LI>
<LI>Arm/Actuator (Atuador) - Corresponde a parte móvel que permite a movimentação da cabeça para posicionamento. </LI>
<LI>Spindle (Motor) - Esse é o motor que gira em velocidade constante. </LI></UL>
<P><A href="images\image_2.png"><IMG title="image" border="0" alt="image" src="images\image_thumb.png" width="392" height="271"></A> </P>
<P>Em cada platter, podemos imaginar vários círculos concêntricos com tamanhos variados. Cada círculo corresponde a um track e o conjunto de tracks (em um formato tridimensional), a um cilindro.</P>
<P><A href="images\image_4.png"><IMG title="image" border="0" alt="image" src="images\image_thumb_1.png" width="402" height="221"></A> </P>
<P>Finalmente, cada track é dividido em vários setores - na grande maioria dos discos, cada setor possui 512 bytes.</P>
<P><A href="images\image_6.png"><IMG title="image" border="0" alt="image" src="images\image_thumb_2.png" width="350" height="207"></A> </P>
<P>Vou tentar descrever o que acontece quando uma operação de leitura é realizada:</P>
<OL>
<OL>
<LI>A informação a ser lida é traduzida em uma coordenada no disco, seguindo o formato CHS (Cylinder/Head/Sector) </LI>
<LI>O atuador posiciona o cabeçote no cilindro/track correspondente ao dado </LI>
<LI>O motor gira até a posição correspondente do setor dentro do track </LI>
<LI>A leitura é realizada através do cabeçote correspondente ao platter </LI></OL></OL>
<P>Prestem bastante atenção aos pontos 2 e 3. <BR></P>
<BLOCKQUOTE>
<P><I>Quanto tempo que o atuador precisa para posicionar o cabeçote no cilindro correspondente?</I></P></BLOCKQUOTE>
<BLOCKQUOTE>
<P><I>Resposta: Seek Time.</I></P>
<P><EM></EM></P>
<P><I></I></P>
<P><I>Quanto tempo que o motor necessita para posicionar o cabeçote no setor correspondente?</I></P>
<P><I>Resposta: Rotation Latency Time. </I></P>
<P><EM></EM></P></BLOCKQUOTE>
<P>Essas informações estão presentes na especificação do disco.</P>
<P>EXEMPLO:</P>
<BLOCKQUOTE>
<P>Disco Seagate Savvio</P>
<P><A href="http://www.seagate.com/www/en-us/products/servers/savvio/savvio_15k.2/">http://www.seagate.com/www/en-us/products/servers/savvio/savvio_15k.2/</A> 
<TABLE border="1" cellSpacing="0" cellPadding="0">
<TBODY>
<TR>
<TD vAlign="top" width="160">
<P>PERFORMANCE</P></TD>
<TD vAlign="top" width="91">&nbsp;</TD></TR>
<TR>
<TD vAlign="top" width="160">
<P>Spindle Speed</P></TD>
<TD vAlign="top" width="91">
<P>15,000 rpm</P></TD></TR>
<TR>
<TD vAlign="top" width="160">
<P>Average latency</P></TD>
<TD vAlign="top" width="91">
<P>2.0 msec</P></TD></TR>
<TR>
<TD vAlign="top" width="160">
<P>Random read seek time</P></TD>
<TD vAlign="top" width="91">
<P>3.2 msec</P></TD></TR>
<TR>
<TD vAlign="top" width="160">
<P>Random write seek time</P></TD>
<TD vAlign="top" width="91">
<P>3.5 msec</P></TD></TR></TBODY></TABLE></P></BLOCKQUOTE>
<P>No próximo post, continuaremos olhando esses números.</P>
