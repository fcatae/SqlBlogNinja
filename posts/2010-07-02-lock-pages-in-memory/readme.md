<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/02/lock-pages-in-memory/'>Lock Pages in Memory</a>
<p>Quando um processo aloca memória, as chamadas são convertidas em comandos <a href="http://msdn.microsoft.com/en-us/library/aa366890(VS.85).aspx" target="_blank">VirtualAllocEx()</a> para o gerenciador de memória do Windows. Toda essa memória é denominada <strong>memória virtual</strong>, que pode ser alocada em Page file ou RAM. Além disso, o Sistema Operacional tem a liberdade de paginada a qualquer instante e de forma transparente ao processo.</p>  <p>Quando a memória virtual está presente em RAM, então dizemos que essa memória faz parte do Working Set do processo. Já discuti um pouco sobre esse assunto nos posts <a href="http://blogs.msdn.com/b/fcatae/archive/2010/04/20/shared-memory.aspx" target="_blank">Shared Memory</a> e <a href="http://blogs.msdn.com/b/fcatae/archive/2010/03/31/memory-working-set.aspx" target="_blank">Working Set</a>. Do ponto de vista do SQL Server, queremos sempre que essa memória virtual utilize RAM ao invés de Pagefile.</p>  <p>Existem mecanismos do Windows que garantem 100% que a memória alocada seja memória RAM. Esses são:</p>  <ul>   <li>VirtualLock</li>    <li>AWE</li>    <li>Large Pages</li> </ul>  <p>Qualquer uma dessas API pode ser usada pelo processo para garantir que a memória fique em RAM.</p>  <p>Do ponto de vista do Windows, alocar memória RAM é um risco de segurança: um processo mal-educado pode alocar toda a memória da máquina e deixar o Sistema Operacional instável. </p>  <p>Aqui entra o conceito de <strong>Lock Pages in Memory</strong>. O administrador pode decidir qual usuário/processo tem privilégio para alocar diretamente memória RAM, sem necessitar de Page File.</p>  <p>&#160;</p>  <h4>SQL Server e Lock Pages in Memory</h4>  <p>SQL Server tira proveito do privilégio “Lock Pages in Memory” tanto na plataforma 32 ou 64 bits. Para configurá-lo, basta entrar no <strong>Local Security Policy </strong>(Run… <em>secpol.msc</em>), expandir a pasta &quot;<strong>User Rights Assignments</strong>” e adicionar a conta de serviço do SQL Server ao privilégio “<strong>Lock Pages in Memory</strong>”.</p>  <p>&#160;</p>  <p><a href="images\1067.image_2.png"><img style="border-bottom: 0px;border-left: 0px;float: none;margin-left: auto;border-top: 0px;margin-right: auto;border-right: 0px" title="image" border="0" alt="image" src="images\4544.image_thumb.png" width="386" height="310" /></a> </p>  <p>Após adicionar esse privilégio, basta fazer um restart do serviço SQL e tudo já está configurado! A partir de agora, o SQL Server utiliza as API de AWE e Large Pages – o código do SQL, não faz uso do VirtualLock.</p>  <p>Específico do 64-bits: Após dar o privilégio de “Lock Pages in memory”, o SQL Server passa a alocar memória usando o mecanismo de AWE. Ao contrário do 32-bits, não é necessário usar o sp_configure para habilitar o AWE.</p>  <p>&#160;</p>  <h4>Vantagem</h4>  <p>A vantagem imediata é que a memória alocada ficará 100% em RAM e não haverá problema de paginação em disco. Uma outra vantagem é que a memória AWE e Large Page não necessitam de Page File, uma vez que elas nunca serão paginadas.</p>  <p>&#160;</p>  <h4>Desvantagem</h4>  <p>A memória alocada através da API de AWE e Large Pages não conta no Working Set do processo. Por isso, o Task Manager é incapaz de mostrar a quantidade correta de memória usada pelo SQL Server. O jeito é, portanto, usar o Performance Monitor para determinar a memória usada pelo SQL.</p>  <p>Veja o post <a href="http://blogs.msdn.com/b/fcatae/archive/2010/03/31/memory-working-set.aspx" target="_blank">Working Set</a>.</p>  <p>&#160;</p>  <h4>Referências</h4>  <p>Slava descreve como SQL Server tira proveito do privilégio Lock Pages in memory em seu blog.</p>  <blockquote>   <p>Slava Oks -&#160; Using Lock Pages In memory on 64 bit platform     <br /><a title="http://blogs.msdn.com/b/slavao/archive/2005/08/31/458545.aspx" href="http://blogs.msdn.com/b/slavao/archive/2005/08/31/458545.aspx">http://blogs.msdn.com/b/slavao/archive/2005/08/31/458545.aspx</a></p> </blockquote>  <p>&#160;</p>  <p>Windows apresenta funcionalidades de Address Windowing Extension (AWE) usado para ultrapassar a barreira de 3GB imposta pela plataforma 32-bits, mas que ainda está disponível em 64-bits.</p>  <blockquote>   <p>MSDN – AllocateUserPhysicalPages API     <br /><a title="http://msdn.microsoft.com/en-us/library/aa366528(v=VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366528(v=VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa366528(v=VS.85).aspx</a></p> </blockquote>  <blockquote>   <p>MSDN – Address Windowing Extension (AWE)<a title="http://msdn.microsoft.com/en-us/library/aa366527(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366527(VS.85).aspx">       <br />http://msdn.microsoft.com/en-us/library/aa366527(VS.85).aspx</a></p> </blockquote>  <p>&#160;</p>  <p>A utilização de Large Page permite utilizar blocos maiores de memória RAM ao invés de páginas de 4kb. Isso diminui o overhead de mapeamento de memória e custo em Page Table Entries. Para utilizar essa funcionalidade, basta chamar a API VirtualAllocEX com o parâmetro MEM_LARGE_PAGES.</p>  <blockquote>   <p>MSDN - Large Page Support     <br /><a title="http://msdn.microsoft.com/en-us/library/aa366720(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366720(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa366720(VS.85).aspx</a></p>    <p>MSDN – VirtualAllocEx API     <br /><a title="http://msdn.microsoft.com/en-us/library/aa366890(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366890(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa366890(VS.85).aspx</a></p> </blockquote>  <p>&#160;</p>  <p>Apesar de não ser utilizada pelo SQL Server, o VirtualLock garante que a memória virtual não seja paginada. </p>  <blockquote>   <p>MSDN – VirtualLock API     <br /><a title="http://msdn.microsoft.com/en-us/library/aa366895(VS.85).aspx" href="http://msdn.microsoft.com/en-us/library/aa366895(VS.85).aspx">http://msdn.microsoft.com/en-us/library/aa366895(VS.85).aspx</a></p></blockquote>