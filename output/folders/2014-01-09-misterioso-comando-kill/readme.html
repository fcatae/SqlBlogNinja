<a link='https://blogs.msdn.microsoft.com/fcatae/2014/01/09/misterioso-comando-kill/'>Misterioso Comando KILL</a>
<p>Estou gastando o terceiro post para falar sobre o comando KILL. Se você não leu os outros, dê uma olhada:</p>  <blockquote>   <p>1. <a href="http://blogs.msdn.com/b/fcatae/archive/2014/01/06/desafio-comando-kill-demorado-infinito.aspx">Desafio: Comando KILL demorado (infinito)</a>       <br />2. <a href="http://blogs.msdn.com/b/fcatae/archive/2014/01/07/significado-wait-type-preemptive-os-pipeops.aspx">Qual o significado de PREEMPTIVE_OS_PIPEOPS?</a></p> </blockquote>  <p>Dessa vez, vou mostrar como que o comando KILL realmente funciona e como que ele consegue “matar” os processos.</p>    <h1>DBCC STACKDUMP</h1>  <p>Sim, esse é o comando que usaremos. Antigamente existia um comando chamado DBCC PSS (Process Session Structure), mas dessa vez não tem jeito. Temos que usar alguns artifícios diferentes. </p>  <p>Ao rodar o comando:</p>  <blockquote>   <p><strong>DBCC STACKDUMP</strong></p> </blockquote>  <p>Observamos que são gerados 3 arquivos no diretório do log. </p>  <blockquote>   <p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/8611.image_20E55902.png"><img title="image" style="margin: 0px" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/5415.image_thumb_7BE79888.png" width="181" height="73" /></a></p> </blockquote>  <p>Abriremos o arquivo TXT, que contém uma descrição textual sobre o <em>memory dump</em>.</p>  <blockquote>   <p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/5736.image_367FEF9A.png"><img title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/1104.image_thumb_531C6B6D.png" width="470" height="212" /></a></p> </blockquote>  <p>Agora vou procurar pela minha sessão 52: utilize o Find –&gt; “m_sessionId = 52”. </p>  <blockquote>   <p><a href="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/2727.image_32584A8B.png"><img title="image" border="0" alt="image" src="https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/01/28/29/metablogapi/2570.image_thumb_61A9C015.png" width="531" height="140" /></a></p> </blockquote>  <p>Essas são as propriedades da sessão (aos programadores C++, esse é um objeto chamado <em>CSession</em> e propriedade <em>m_fKill </em>). Podemos até dizer que a DMV <em>sys.dm_exec_sessions</em> corresponde a lista completa de todos os objetos <em>CSession.</em> </p>  <p>Voltando ao assunto. Ao executar o comando KILL, ele apenas sinaliza a respectiva sessão para que ela aborte o quanto antes. Nessa situação, a verificação é feita logo depois da espera PREEMPTIVE_OS_PIPEOPS. O código fonte é semelhante com isso:</p>    <blockquote>   <pre>function xp_cmdshell ( process_name ) 
{
    CreateProcess( process_name );
    </pre>

  <pre>    SetStatus( SUSPENDED, PREEMPTIVE_OS_PIPEOPS );
  </pre>

  <pre>    WaitResponse( process.stdout );

    SetStatus( RUNNING, NULL  );

  </pre>

  <pre>    if ( this.m_fKill == 1 ) {
        abort();
    }
}
  </pre>
</blockquote>

<p><strong>Conclusão: </strong>O comando KILL não mata ninguém. Ele serve apenas para mudar a flag <em>m_fKill</em> , que permite a própria sessão abortar a execução.</p>
