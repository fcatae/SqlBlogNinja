<a link='https://blogs.msdn.microsoft.com/fcatae/2009/09/02/discos-dedicados-de-dados-e-log/'>Discos dedicados de Dados e Log</a>
<P>&nbsp;</P>
<P>Nas visitas a clientes, é muito comum ouvir perguntas sobre como otimizar a performance dos discos. </P>
<P>A primeira recomendação que fazemos é para manter os arquivos de Dados e Log em discos separados. Por exemplo:</P>
<UL>
<LI>Disco L: arquivos LDF (Log)</LI>
<LI>Disco R: arquivos MDF/NDF (Dados)</LI>
<LI>Disco S: arquivos MDF/NDF (Dados)</LI>
<LI>Disco T: arquivos MDF/NDF (Dados)</LI></UL>
<P><BR>Em um disco de 15k RPM, o tempo médio de escrita é de <STRONG>5,5ms</STRONG>. Se colocarmos o arquivo de Log em um disco dedicado, é possível obter tempos de <STRONG>2ms</STRONG> por escrita!</P>
<P>Vamos aos cenários: <BR>&nbsp;</P>
<P><B><U>Cenário 1: Leitura de Arquivos de Dados</U></B></P>
<P><STRONG><U></U></STRONG></P>
<P>Consideramos as operações de leitura de dados, que cada hora é lida uma página diferente e em posição distinta no disco. Para cada requisição de leitura, será necessário <STRONG>posicionar no track </STRONG>e, em seguida, <STRONG>posicionar no setor</STRONG>.&nbsp;&nbsp; <BR></P>
<P>
<TABLE border="1" cellSpacing="0" cellPadding="0">
<TBODY>
<TR>
<TD vAlign="top" width="128">
<P>Operação: Leitura</P></TD>
<TD vAlign="top" width="96">
<P>Tempo (ms)</P></TD></TR>
<TR>
<TD vAlign="top" width="128">
<P>Posicionar o track</P></TD>
<TD vAlign="top" width="96">
<P>3,2</P></TD></TR>
<TR>
<TD vAlign="top" width="128">
<P>Posicionar o setor</P></TD>
<TD vAlign="top" width="96">
<P>2,0</P></TD></TR>
<TR>
<TD vAlign="top" width="128">
<P>Tempo Total</P></TD>
<TD vAlign="top" width="96">
<P>5,2</P></TD></TR></TBODY></TABLE></P>
<P><BR>O tempo médio para a operação completar será de 5,2ms.</P>
<P><B><U>Cenário 2: Escrita no Transaction Log</U></B></P>
<P>As escritas no arquivo de transaction log são sequenciais. Isso significa que, após o primeiro posicionamento do cabeçote no track, as operações seguintes precisam apenas realizar o posicionamento de setor. <BR>&nbsp;</P>
<P>
<TABLE border="1" cellSpacing="0" cellPadding="0">
<TBODY>
<TR>
<TD vAlign="top" width="127">
<P>Operação: Escrita</P></TD>
<TD vAlign="top" width="96">
<P>Tempo (ms)</P></TD></TR>
<TR>
<TD vAlign="top" width="127">
<P>Posicionar o setor</P></TD>
<TD vAlign="top" width="96">
<P>2.0</P></TD></TR>
<TR>
<TD vAlign="top" width="127">
<P>Tempo Total</P></TD>
<TD vAlign="top" width="96">
<P>2.0</P></TD></TR></TBODY></TABLE></P>
<P><BR>Por isso, dizemos que as escritas no transaction log tiram vantagem do fato de serem sequenciais e o tempo médio da operação é de apenas 2ms.</P>
<P><B><U>Cenário 3: Arquivos de Dados e Log no mesmo disco físico</U></B></P>
<P>Quando colocamos os arquivos de Data (MDF/NDF) e Log (LDF) no mesmo disco físico, observamos que o tempo de escrita em log aumenta para 5,5ms. Isso ocorre porque as operações de leitura/escritas são intercaladas e o cabeçote deve sempre ser reposicionado, deixando de tirar proveito do fato das escritas em log serem sequenciais. <BR></P>
<P>
<TABLE border="1" cellSpacing="0" cellPadding="0">
<TBODY>
<TR>
<TD vAlign="top" width="127">
<P>Operação: Escrita</P></TD>
<TD vAlign="top" width="96">
<P>Tempo (ms)</P></TD></TR>
<TR>
<TD vAlign="top" width="127">
<P>Posicionar o track</P></TD>
<TD vAlign="top" width="96">
<P>3,5</P></TD></TR>
<TR>
<TD vAlign="top" width="127">
<P>Posicionar o setor</P></TD>
<TD vAlign="top" width="96">
<P>2,0</P></TD></TR>
<TR>
<TD vAlign="top" width="127">
<P>Tempo Total</P></TD>
<TD vAlign="top" width="96">
<P>5,5</P></TD></TR></TBODY></TABLE></P>
<P><B>Conclusão: </B></P>
<P>Nunca misture os arquivos de Dados e Log, porque há impacto direto no tempo de escrita do Transaction Log. Como observamos, toda operação de escrita terá a necessidade de reposicionar o cabeçote no track correto, aumentando o tempo de resposta.</P>
<P>Ao colocar o arquivo de Transaction Log em um disco dedicado, teremos uma performance otimizada para as escritas sequenciais.</P>
