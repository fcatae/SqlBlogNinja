<a link='https://blogs.msdn.microsoft.com/fcatae/2010/03/10/background-task-log-writer/'>Background Task: Log Writer</a>
<p><strong>Log writer</strong> é um processo dedicado que auxilia na escrita de log para todos os bancos de dados. Apesar de ser único no servidor, ele realiza escrita em todos os arquivos de Transaction Log. </p>  <p>Dentro do SQL Server, o <strong>log writer </strong>corresponde a uma <em>task </em>de sistema que roda continuamente desde o startup da instância.</p>  <blockquote>   <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_exec_requests 
</span><span style="color: blue">WHERE </span>command <span style="color: gray">=</span><span style="color: red">'LOG WRITER'</span></pre>
</blockquote>
<a href="http://11011.net/software/vspaste"></a>

<blockquote>
  <p>&#160;<a href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/BackgroundTaskLogWriter_12F3A/image_2.png"><img style="border-right-width: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px" title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/BackgroundTaskLogWriter_12F3A/image_thumb.png" width="364" height="33" /></a></p>
</blockquote>

<p>&#160;</p>

<p>Em um sistema com baixa atividade de escrita, é normal observar a tarefa em modo de “espera” por trabalho:</p>

<blockquote>
  <pre class="code"><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span><span style="color: green">sys</span><span style="color: gray">.</span><span style="color: green">dm_os_waiting_tasks
</span><span style="color: blue">WHERE </span>session_id <span style="color: gray">= </span>4</pre>
</blockquote>
<a href="http://11011.net/software/vspaste"></a>

<blockquote>
  <p><a href="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/BackgroundTaskLogWriter_12F3A/image_4.png"><img style="border-bottom: 0px;border-left: 0px;border-top: 0px;border-right: 0px" title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/BackgroundTaskLogWriter_12F3A/image_thumb_1.png" width="528" height="30" /></a> </p>
</blockquote>

<p>A coluna <strong>wait_duration_ms </strong>mostra o tempo de inatividade do log writer. No exemplo acima, não houve escrita em log nos últimos 68 segundos (wait_duration_ms = 68726). Ao realizar uma transação, o log writer é “acordado” para escrever no Transaction Log. </p>
