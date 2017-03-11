<a link='https://blogs.msdn.microsoft.com/fcatae/2009/12/17/spinlock-contention/'>Spinlock Contention</a>
<P>Problemas de contenção por spinlock são difíceis de serem identificados. As estatísticas relacionadas com Spinlocks são disponibilizadas através do comando não-documentado:</P>
<BLOCKQUOTE><PRE class="code"><SPAN>DBCC </SPAN>SQLPERF<SPAN>(</SPAN>SPINLOCKSTATS<SPAN>)</SPAN></PRE></BLOCKQUOTE><A href="http://11011.net/software/vspaste"></A>
<P>Um trecho do resultado no SQL Server 2000: </P><PRE>Spinlock Name        Collisions  Spins         Spins/Collision
-------------------- ----------- ------------- ---------------
MUTEX                11693       5823169       498,0047
CONNECTS             0           0             0
SRVPROC              1           0             0
DBT_HASH             0           0             0
LOCK_FREE_LIST       586         39672         67,69966
DES_HASH             257         684           2,661479
BUF_HASH             96          738           7,6875
PSS                  173         27558         159,2948
CURSOR               0           0             0
RES_LOCK_FREELIST    897         4138          4,613155
LOCK_HASH            1073241     124531500     116,0331
QUERYEXEC            874         77134         88,25401
PARALLEL_PAGESUPP    1095        724276        661,4393
BUF_WRITE_LOG        14          0             0
<FONT>SQL_MGR              28810       5199295194    180468,4
</FONT>DROP_TEMPO           25          144           5,76
NHASH_BKT            4           0             0
IHASH_BKT            465         81923         176,1785
CACHEOBJ_DBG         0           0             0
GHOST_HASH           6           131           21,83333
GHOST_FREE           0           0             0
ISSRESOURCE          2           0             0
...
(85 row(s) affected)</PRE>
<P><BR>Como analisar?</P>
<OL>
<LI>A coluna de <STRONG>collisions</STRONG> evidencia os spinlocks que apresentam o maior número de contenção e geralmente estão relacionados com a carga/utilização. No exemplo anterior, LOCK_HASH foi o spinlock com maior número de colisões. <BR></LI>
<LI>A coluna de <STRONG>spins</STRONG> está relacionada com a CPU gasta durante a contenção. SQL_MGR apresentou o maior valor de thread spinning (5199295194). No trecho acima, esse era o causador de problema!</LI></OL>
<P>Sempre imaginei que contenção por spinlock estivesse associado com 100% CPU, pois as threads ficam rodando sem parar. Mas a história não é assim no SQL Server.</P>
<P>Após um determinado número de spinning, a thread entra em um estado de “backoff”: a execução é suspensa e a thread fica ociosa por alguns milissegundos. Portando, a coluna mais importante a ser observada é <STRONG>Spins/Collisions</STRONG>. Foi exatamente isso que aconteceu com o spinlock SQL_MGR: as threads apresentaram contenção, começaram o spinning, entraram em backoff e ficaram em “sleep”. </P>
<P>A partir do SQL Server 2005, temos as colunas adicionais chamadas <STRONG>Sleep Time </STRONG>e <STRONG>Backoffs</STRONG>, que ilustram o tempo gasto em backoff. <BR></P><PRE>Sleep Time (ms)      Backoffs
-------------------- -----------
0                    0
0                    0
301                  994
0                    0
233451               430887
0                    0</PRE>
<P>Uma forma simples de identificar contenção por spinlock é usar o comando DBCC SQLPERF(SPINLOCKSTATS) e identificar os recursos com maior <STRONG>Sleep Time</STRONG> e <STRONG>Backoffs</STRONG>.</P>
