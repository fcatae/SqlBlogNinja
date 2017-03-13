<a link='https://blogs.msdn.microsoft.com/fcatae/2010/10/28/monitorando-alta-cpu-atravs-da-ring-buffer/'>Monitorando Alta CPU através da RING BUFFER</a>
<p>Alto consumo de CPU, como monitorar? Recentemente, li um comentário interessante postado pelo Fernando Garcia no post <a href="http://blogs.msdn.com/b/fcatae/archive/2010/09/30/monitorar-ring-buffer.aspx" target="_blank">Como Monitorar com Ring Buffer</a>. Ele mencionou o uso do RING BUFFER para diagnosticar alto consumo de CPU. Isso é algo fantástico para um DBA que não tem acesso remoto ao servidor, ou seja, não pode abrir o Task Manager para ver o gráfico dos processadores. </p>  <ul>   <li>Script Disponível em <a href="http://blogs.msdn.com/b/sql_pfe_blog/archive/2009/07/17/sql-high-cpu-scenario-troubleshooting-using-sys-dm-exec-query-stats-and-ring-buffer-scheduler-monitor-ring-buffer-in-sys-dm-os-ring-buffers.aspx" target="_blank">SQL High CPU scenario troubleshooting</a> </li>    <li>Encontrei o mesmo código dentro do <a href="http://blogs.msdn.com/b/psssql/archive/2007/02/21/sql-server-2005-performance-statistics-script.aspx" target="_blank">SQL Server 2005 Performance Statistics Script</a>, o famoso <strong>PerfStats</strong> </li> </ul>  <p>Coloquei o script para rodar em produção e é fantástico, ele funciona muito bem! Fiz algumas alterações para otimizar sua performance. No final, ficou assim:</p>  <blockquote>   <pre class="code"><span style="color: blue">WITH </span>ScheduleMonitorResults <span style="color: blue">AS
</span><span style="color: gray">(
    </span><span style="color: blue">SELECT 
      </span><span style="color: magenta">DATEADD</span><span style="color: gray">(</span>ms<span style="color: gray">, 
        (</span><span style="color: blue">select </span>[ms_ticks]<span style="color: gray">-</span>[timestamp] <span style="color: blue">from </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_os_sys_info</span><span style="color: gray">), 
        </span><span style="color: magenta">GETDATE</span><span style="color: gray">())          </span><span style="color: blue">AS </span><span style="color: red">'EventDateTime'</span><span style="color: gray">, 
      </span><span style="color: magenta">CAST</span><span style="color: gray">(</span>record <span style="color: blue">AS xml</span><span style="color: gray">)   </span><span style="color: blue">AS </span><span style="color: red">'record'
    </span><span style="color: blue">FROM </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_os_ring_buffers
    </span><span style="color: blue">WHERE </span>ring_buffer_type <span style="color: gray">= </span><span style="color: red">'RING_BUFFER_SCHEDULER_MONITOR' 
    </span><span style="color: gray">AND    </span>[timestamp] <span style="color: gray">&gt; 
               (</span><span style="color: blue">select </span>[ms_ticks] <span style="color: gray">- </span>10<span style="color: gray">*</span>60000  <span style="color: green">-- Last 10 minutes
                                  </span><span style="color: gray">- </span>100       <span style="color: green">-- Round up 
                </span><span style="color: blue">from </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_os_sys_info</span><span style="color: gray">)
)
</span><span style="color: blue">SELECT 
    </span><span style="color: magenta">CONVERT </span><span style="color: gray">(</span><span style="color: blue">varchar</span><span style="color: gray">, </span>EventDateTime<span style="color: gray">, </span>126<span style="color: gray">) </span><span style="color: blue">AS </span>EventTime<span style="color: gray">, 
    </span>SysHealth<span style="color: gray">.</span>value<span style="color: gray">(</span><span style="color: red">'ProcessUtilization[1]'</span><span style="color: gray">,</span><span style="color: red">'int'</span><span style="color: gray">) </span><span style="color: blue">AS </span><span style="color: red">'CPU (SQL Server)'</span><span style="color: gray">,
    100 - </span>SysHealth<span style="color: gray">.</span>value<span style="color: gray">(</span><span style="color: red">'SystemIdle[1]'</span><span style="color: gray">,</span><span style="color: red">'int'</span><span style="color: gray">) </span><span style="color: blue">AS </span><span style="color: red">'CPU (All Processes)'
</span><span style="color: blue">FROM </span>ScheduleMonitorResults <span style="color: gray">CROSS APPLY 
    </span>record<span style="color: gray">.</span>nodes<span style="color: gray">(</span><span style="color: red">'/Record/SchedulerMonitorEvent/SystemHealth'</span><span style="color: gray">) </span>T<span style="color: gray">(</span>SysHealth<span style="color: gray">)
</span><span style="color: blue">ORDER BY </span>EventDateTime <span style="color: blue">DESC</span></pre>
</blockquote>

<p>O resultado fornece o histórico do consumo de CPU nos últimos 10 minutos.</p>

<blockquote>
  <p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/4621.image_78FFAB01.png"><img style="border-bottom: 0px;border-left: 0px;padding-left: 0px;padding-right: 0px;border-top: 0px;border-right: 0px;padding-top: 0px" title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/8831.image_thumb_6910663D.png" width="365" height="198" /></a></p>
</blockquote>

<p>Isso mostra que o consumo de CPU da máquina variou entre 5-25%, apesar do processo do SQL Server não consumir nada. </p>
