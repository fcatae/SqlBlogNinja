<a link='https://blogs.msdn.microsoft.com/fcatae/2010/02/24/log-sequence-number-lsn/'>Log Sequence Number (LSN)</a>
<P>Com o objetivo de manter as propriedades ACID (Atomicity, Consistency, Isolation e Durability), as transações efetuadas em banco de dados utilizam registros de log com informações de undo/redo de suas operações. Cada operação é identificada unicamente através do Log Sequence Number (LSN). Esse identificador incremental permite identificar a sequencia de gravação de log.</P>
<P>Esse número é dividido em 3 partes: logical file/offset/slot.</P>
<P><STRONG>Exemplo:</STRONG></P>
<BLOCKQUOTE>
<P>000000cd:000000b0:0001 <BR>000000cd:000000b8:0001 <BR>000000cd:000000b8:0002 <BR>000000cd:000000c0:0001 <BR>000000cd:000000c0:0002 <BR>000000cd:000000c0:0003 <BR>000000cd:000000c8:0001 <BR>000000cd:000000c8:0002 <BR>000000cd:000000c8:0003 <BR>000000cd:000000c8:0004</P></BLOCKQUOTE>
<P>Aqui temos:</P>
<UL>
<LI>10 log record (cada um identificado por um LSN) </LI>
<LI>4 log buffers (cd:b0, cd:b8, cd:c0, cd:c8) </LI>
<LI>1 logical log file (000000cd) </LI></UL>
<P><STRONG>Logical Log File</STRONG></P>
<P>No exemplo anterior, observamos que as gravações são realizadas no logical log file identificado por 000000cd = 205. Existe uma forma simples para identificar qual o arquivo corresponde. Primeiro, procuramos qual o "FileID" correspondente ao FSeqNo = 205 (000000cd). Depois consultamos o nome do arquivo no catálogo sys.database_files.</P>
<BLOCKQUOTE><PRE class="csharpcode"><SPAN class="kwrd">dbcc</SPAN> loginfo</PRE>

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
</BLOCKQUOTE>

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

<BLOCKQUOTE>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LogSequenceNumberLSN_12BCE/image_2.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LogSequenceNumberLSN_12BCE/image_thumb.png" width="349" height="73"></A>&nbsp;</P></BLOCKQUOTE>
<BLOCKQUOTE><PRE class="csharpcode"><SPAN class="kwrd">select</SPAN> file_id, physical_name <SPAN class="kwrd">from</SPAN> sys.database_files</PRE></BLOCKQUOTE>
<BLOCKQUOTE>
<P><A href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LogSequenceNumberLSN_12BCE/image_4.png"><IMG title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/LogSequenceNumberLSN_12BCE/image_thumb_1.png" width="412" height="43"></A> 

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
</P></BLOCKQUOTE>
