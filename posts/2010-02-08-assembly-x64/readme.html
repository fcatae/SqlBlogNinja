<a link='https://blogs.msdn.microsoft.com/fcatae/2010/02/08/assembly-x64/'>Assembly x64</a>
<P>Esses dias estive trabalhando em um problema complicado envolvendo o engine do SQL Server rodando assembly .NET. A&nbsp;análise foi feita em um dump de memória x64 e achei que essa seria uma ótima oportunidade para escrever um blog sobre esse assunto.</P>
<P>&nbsp;</P>
<P><STRONG>Registradores</STRONG></P>
<P>A arquitetura x64, também conhecida como AMD64 ou Intel-EMT64, utiliza os mesmos registradores da arquitetura x86 (32-bits: EAX, EBX, ECX, EDX, ESI, EDI) e as versões estendidas 64-bits: RAX, RBX, RCX, RDX, RSI e RDI. Existem 8 novos registradores nomeados R8, R9, .., R15 para serem utilizados livremente.</P>
<TABLE border="1" cellSpacing="0" cellPadding="0">
<TBODY>
<TR>
<TD vAlign="top">
<P><STRONG>Register</STRONG></P></TD>
<TD vAlign="top">
<P><STRONG>Status</STRONG></P></TD>
<TD vAlign="top">
<P><STRONG>Use</STRONG></P></TD></TR>
<TR>
<TD vAlign="top">
<P>RAX</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Return value register</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RCX</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>First integer argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RDX</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Second integer argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>R8</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Third integer argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>R9</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Fourth integer argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>R10:R11</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Must be preserved as needed by caller; used in syscall/sysret instructions</P></TD></TR>
<TR>
<TD vAlign="top">
<P>R12:R15</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Must be preserved by callee</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RDI</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Must be preserved by callee</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RSI</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Must be preserved by callee</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RBX</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Must be preserved by callee</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RBP</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>May be used as a frame pointer; must be preserved by callee</P></TD></TR>
<TR>
<TD vAlign="top">
<P>RSP</P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Stack pointer</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM0</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>First FP argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM1</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Second FP argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM2</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Third FP argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM3</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Fourth FP argument</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM4:XMM5</P></TD>
<TD vAlign="top">
<P>Volatile</P></TD>
<TD vAlign="top">
<P>Must be preserved as needed by caller</P></TD></TR>
<TR>
<TD vAlign="top">
<P>XMM6:XMM15 </P></TD>
<TD vAlign="top">
<P>Nonvolatile</P></TD>
<TD vAlign="top">
<P>Must be preserved as needed by callee. </P></TD></TR></TBODY></TABLE>
<P>Ref: MSDN - Register Usage - <A title="http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx" href="http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx">http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx</A></P>
<P><STRONG>Calling Convention</STRONG></P>
<P>O padrão utilizado no Windows x64 é fast call, no qual os primeiros 4 parâmetros na chamada de função são passados através dos registradores RCX, RDX, R8 e R9. Parâmetros adicionais devem ser passados através da stack.</P>
<P><STRONG>Stack</STRONG></P>
<P>A função chamadora (caller) é responsável por reservar o espaço para passagem de parâmetros para a função chamada (callee). Na plataforma x64, essa área é de no mínimo 4 parâmetros (8 bytes) mesmo quando não há parâmetros especificados. </P>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/Assemblyx64_13487/image_2.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/Assemblyx64_13487/image_thumb.png" width="360" height="345"></A> </P>
<P>Ref: MSDN – Stack Allocation</P>
<P><STRONG>Exemplo:</STRONG></P>
<DIV id="codeSnippetWrapper" class="csharpcode-wrapper">
<BLOCKQUOTE><PRE class="csharpcode"><SPAN class="kwrd">__int64</SPAN> comando(<SPAN class="kwrd">__int64 </SPAN>a, <SPAN class="kwrd">__int64 </SPAN>b, <SPAN class="kwrd">__int64 </SPAN>c, <SPAN class="kwrd">__int64 </SPAN>d, <SPAN class="kwrd">__int64 </SPAN>e)<BR>{<BR>    <SPAN class="kwrd">return</SPAN> a+b+c+d+e;<BR>}<BR></PRE><PRE class="csharpcode"><BR><SPAN class="kwrd">int</SPAN> _tmain(<SPAN class="kwrd">int</SPAN> argc, _TCHAR* argv[])<BR>{<BR>    <SPAN class="kwrd">__int64 </SPAN>resultado;<BR>    <BR>    resultado = comando(0x1111111111, 0x2222222222, </PRE><PRE class="csharpcode">                        0x333333333333, 0x444444444444, </PRE><PRE class="csharpcode">                        0x55555555); </PRE><PRE class="csharpcode"><BR><BR>    <SPAN class="kwrd">return</SPAN> 0;<BR>}</PRE></BLOCKQUOTE><BR></DIV>
<P><STRONG>_tmain():</STRONG> Os 4 primeiros parâmetros são passados através dos registradores RCX, RDX, R8, R9, e o quinto parâmetro é passado pela stack. O valor de retorno da função é feito no registrador RAX.</P>
<BLOCKQUOTE><PRE class="csharpcode">00000001`3f992dd6 mov   qword ptr [rsp+20h],55555555h
00000001`3f992ddf mov r9,444444444444h
00000001`3f992de9 mov r8,333333333333h
00000001`3f992df3 mov rdx,2222222222h
00000001`3f992dfd mov rcx,1111111111h
00000001`3f992e07 call    Console64!comando
00000001`3f992e0c mov     qword ptr [rsp+30h],rax</PRE></BLOCKQUOTE>


.csharpcode, .csharpcode pre
{
	font-size: small;
	color: black;
	font-family: consolas, "Courier New", courier, monospace;
	background-color: #ffffff;
	/*white-space: pre;*/
}
.csharpcode pre { margin: 0em; }
.csharpcode .rem { color: #008000; }
.csharpcode .kwrd { color: #0000ff; }
.csharpcode .str { color: #006080; }
.csharpcode .op { color: #0000c0; }
.csharpcode .preproc { color: #cc6633; }
.csharpcode .asp { background-color: #ffff00; }
.csharpcode .html { color: #800000; }
.csharpcode .attr { color: #ff0000; }
.csharpcode .alt 
{
	background-color: #f4f4f4;
	width: 100%;
	margin: 0em;
}
.csharpcode .lnum { color: #606060; }



.csharpcode, .csharpcode pre
{
	font-size: small;
	color: black;
	font-family: consolas, "Courier New", courier, monospace;
	background-color: #ffffff;
	/*white-space: pre;*/
}
.csharpcode pre { margin: 0em; }
.csharpcode .rem { color: #008000; }
.csharpcode .kwrd { color: #0000ff; }
.csharpcode .str { color: #006080; }
.csharpcode .op { color: #0000c0; }
.csharpcode .preproc { color: #cc6633; }
.csharpcode .asp { background-color: #ffff00; }
.csharpcode .html { color: #800000; }
.csharpcode .attr { color: #ff0000; }
.csharpcode .alt 
{
	background-color: #f4f4f4;
	width: 100%;
	margin: 0em;
}
.csharpcode .lnum { color: #606060; }

<P><STRONG>comando():</STRONG> Os parâmetros são armazenados na stack usando a área previamente reservada pelo chamador. Essa área de home de parâmetros é responsabilidade do callee e, por isso, otimizações de código podem utilizar essa área para outras finalidades.</P>
<BLOCKQUOTE><PRE class="csharpcode">00000001`3f992d70 mov     qword ptr [rsp+20h],r9
00000001`3f992d75 mov     qword ptr [rsp+18h],r8
00000001`3f992d7a mov     qword ptr [rsp+10h],rdx
00000001`3f992d7f mov     qword ptr [rsp+8],rcx
00000001`3f992d84 push    rdi
00000001`3f992d85 mov     rcx,qword ptr [rsp+18h]
00000001`3f992d8a mov     rax,qword ptr [rsp+10h]
00000001`3f992d8f add     rax,rcx
00000001`3f992d92 add     rax,qword ptr [rsp+20h]
00000001`3f992d97 add     rax,qword ptr [rsp+28h]
00000001`3f992d9c add     rax,qword ptr [rsp+30h]
00000001`3f992da1 pop     rdi
00000001`3f992da2 ret</PRE></BLOCKQUOTE>
<P>


.csharpcode, .csharpcode pre
{
	font-size: small;
	color: black;
	font-family: consolas, "Courier New", courier, monospace;
	background-color: #ffffff;
	/*white-space: pre;*/
}
.csharpcode pre { margin: 0em; }
.csharpcode .rem { color: #008000; }
.csharpcode .kwrd { color: #0000ff; }
.csharpcode .str { color: #006080; }
.csharpcode .op { color: #0000c0; }
.csharpcode .preproc { color: #cc6633; }
.csharpcode .asp { background-color: #ffff00; }
.csharpcode .html { color: #800000; }
.csharpcode .attr { color: #ff0000; }
.csharpcode .alt 
{
	background-color: #f4f4f4;
	width: 100%;
	margin: 0em;
}
.csharpcode .lnum { color: #606060; }
</P>
<P>Overview of x64 Calling Conventions <BR><A title="http://msdn.microsoft.com/en-us/library/ms235286.aspx" href="http://msdn.microsoft.com/en-us/library/ms235286.aspx">http://msdn.microsoft.com/en-us/library/ms235286.aspx</A></P>
<P><BR>Register Usage <BR><A title="http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx" href="http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx">http://msdn.microsoft.com/en-us/library/9z1stfyw.aspx</A></P>
<P><BR>Parameter Passing <BR><A title="http://msdn.microsoft.com/en-us/library/zthk2dkh.aspx" href="http://msdn.microsoft.com/en-us/library/zthk2dkh.aspx">http://msdn.microsoft.com/en-us/library/zthk2dkh.aspx</A></P>
<P><BR>Stack Allocation <BR><A title="http://msdn.microsoft.com/en-us/library/ew5tede7.aspx" href="http://msdn.microsoft.com/en-us/library/ew5tede7.aspx">http://msdn.microsoft.com/en-us/library/ew5tede7.aspx</A></P>
