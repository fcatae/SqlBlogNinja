<a link='https://blogs.msdn.microsoft.com/fcatae/2010/07/28/spinlock-e-hyper-thread/'>Spinlock e Hyper-Thread</a>
<p>&#160;</p>  <p>Algo curioso que estive vendo hoje..</p>  <p>Encontrei um disassembly do SQL Server rodando na minha máquina com o código do Spinlock (em vermelho):</p>  <blockquote>   <pre class="code">sqlservr!Spinlock&lt;60,7,0&gt;::SpinToAcquireOptimistic+0x3d:
00000000`01aca459 33c9            xor     ecx,ecx
00000000`01aca45b 85db            test    ebx,ebx
00000000`01aca45d 7412            je      00000000`01aca471
<font color="#ff0000">00000000`01aca45f 8b07            mov     eax,dword ptr [rdi]
00000000`01aca461 85c0            test    eax,eax
00000000`01aca463 7407            je      00000000`01aca46c
00000000`01aca465 90              nop
00000000`01aca466 03cd            add     ecx,ebp
00000000`01aca468 3bcb            cmp     ecx,ebx
00000000`01aca46a 72f3            jb      00000000`01aca45f</font>
00000000`01aca46c 4c8b442438      mov     r8,qword ptr [rsp+38h]</pre>
</blockquote>

<p>Um comentário curioso: a instrução NOP no endereço 01aca465 não realiza nada, mas permite que processadores com Hyper-Threading façam a mudança de contexto para o próximo processador lógico. Esse comportamento torna a função “Hyper-Threading Friendly” e economiza energia!</p>
