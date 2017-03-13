<a link='https://blogs.msdn.microsoft.com/fcatae/2010/11/10/query-recursiva/'>Query Recursiva</a>
<p>Você sabia que o SQL Server consegue criar uma Query Recursiva? Utilizamos, como exemplo, uma tabela que armazena as informações de MENU de uma página Web.</p>  <blockquote>   <p><a href="images\6813.image_13D5E3C1.png"><img style="border-right-width: 0px;margin: 0px;padding-left: 0px;padding-right: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px;padding-top: 0px" title="image" border="0" alt="image" src="images\6013.image_thumb_0A99A880.png" width="160" height="244" /></a></p> </blockquote>  <blockquote></blockquote>  <blockquote>   <pre class="code"><font size="1"><span style="color: blue">CREATE TABLE </span>tbMenu
    </font><font size="1"><span style="color: gray">(
    </span>id <span style="color: blue">INT </span><span style="color: gray">NOT NULL </span><span style="color: blue">IDENTITY</span><span style="color: gray">(</span>1<span style="color: gray">,</span>1<span style="color: gray">) </span><span style="color: blue">PRIMARY KEY</span></font><font size="1"><span style="color: gray">, 
    </span>idPai <span style="color: blue">INT </span></font><font size="1"><span style="color: gray">NULL, 
    </span>Nome <span style="color: blue">VARCHAR</span><span style="color: gray">(</span>30</font><font size="1"><span style="color: gray">) NOT NULL
    )

</span><span style="color: blue">INSERT </span>tbMenu <span style="color: gray">(</span>idPai<span style="color: gray">,</span>Nome<span style="color: gray">) </span></font><font size="1"><span style="color: blue">VALUES 
</span><span style="color: gray">(NULL,</span><span style="color: red">'Menu'</span><span style="color: gray">),(</span>1<span style="color: gray">,</span><span style="color: red">'Vestuario'</span><span style="color: gray">),(</span>1<span style="color: gray">,</span><span style="color: red">'Brinquedo'</span><span style="color: gray">),(</span>1<span style="color: gray">,</span><span style="color: red">'Informatica'</span></font><font size="1"><span style="color: gray">),
(</span>2<span style="color: gray">,</span><span style="color: red">'Terno'</span><span style="color: gray">),(</span>2<span style="color: gray">,</span><span style="color: red">'Casaco'</span><span style="color: gray">),(</span>2<span style="color: gray">,</span><span style="color: red">'Sapato'</span><span style="color: gray">),(</span>2<span style="color: gray">,</span><span style="color: red">'Meia'</span><span style="color: gray">),(</span>3<span style="color: gray">,</span><span style="color: red">'Carrinho'</span></font><font size="1"><span style="color: gray">),
(</span>3<span style="color: gray">,</span><span style="color: red">'Boneca'</span><span style="color: gray">),(</span>4<span style="color: gray">,</span><span style="color: red">'Netbook'</span><span style="color: gray">),(</span>4<span style="color: gray">,</span><span style="color: red">'Webcam'</span><span style="color: gray">),(</span>4<span style="color: gray">,</span><span style="color: red">'Desktop'</span></font><font size="1"><span style="color: gray">)
            
</span><span style="color: blue">SELECT </span><span style="color: gray">* </span><span style="color: blue">FROM </span>tbMenu</font></pre>
</blockquote>

<p>Conhecendo a relação entre os itens do MENU, como podemos obter uma visualização de forma hierárquica? Ou como criar uma consulta que verifica que o produto Webcam, da categoria Informática, está dentro do Menu Principal?</p>

<p>&#160;</p>

<p><strong><font size="3">Conceito</font></strong></p>

<p>A idéia da query recursiva é montar o resultado por níveis, determinando quem são os registros “raízes”, depois os “descendentes de primeira ordem”, em seguida, “descendentes de segunda ordem”, e por aí vai.</p>

<ol>
  <li>Obter todos os registros de nível 1 – Esses são chamados de registros âncora (anchors) </li>

  <li>Com base nos níveis âncoras, selecionar todos os registros do nível 2 (processo recursivo) </li>

  <li>Com base nos registros de nível 2, selecionar todos os registros do nível 3 </li>

  <li>… e assim por diante… </li>
</ol>

<p><strong>Resultado:</strong></p>

<blockquote>
  <p><a href="images\3771.image_419386B9.png"><img style="border-right-width: 0px;padding-left: 0px;padding-right: 0px;border-top-width: 0px;border-bottom-width: 0px;border-left-width: 0px;padding-top: 0px" title="image" border="0" alt="query recursiva usando cte" src="images\5736.image_thumb_6E3C4092.png" width="266" height="270" /></a></p>
</blockquote>

<p><strong><font size="3">Sintaxe</font></strong></p>

<p>A sintaxe utilizada para query recursiva é feita através do auxílio das <strong>Common Table Expression (CTE)</strong>. Sempre utiliza-se uma query inicial determinada de âncora, que contém os registros raízes. Em seguida, os resultados são combinados através de uma operação de UNION ALL com a “query recursiva”: ela possui uma auto-referência. </p>

<blockquote>
  <pre class="code"><span style="color: blue">WITH </span>cteMenuNivel<span style="color: gray">(</span>id<span style="color: gray">,</span>Nome<span style="color: gray">,</span>Nivel<span style="color: gray">,</span>NomeCompleto<span style="color: gray">)
</span><span style="color: blue">AS
</span><span style="color: gray">(
    </span><span style="color: green">-- Ancora
    </span><span style="color: blue">SELECT </span>id<span style="color: gray">,</span>Nome<span style="color: gray">,</span>1 <span style="color: blue">AS </span><span style="color: red">'Nivel'</span><span style="color: gray">,</span><span style="color: magenta">CAST</span><span style="color: gray">(</span>Nome <span style="color: blue">AS VARCHAR</span><span style="color: gray">(</span>255<span style="color: gray">)) </span><span style="color: blue">AS </span><span style="color: red">'NomeCompleto' 
    </span><span style="color: blue">FROM </span>tbMenu <span style="color: blue">WHERE </span>idPai <span style="color: gray">IS NULL
    
    </span><span style="color: blue">UNION </span><span style="color: gray">ALL
    
    </span><span style="color: green">-- Parte RECURSIVA
    </span><span style="color: blue">SELECT 
        </span>m<span style="color: gray">.</span>id<span style="color: gray">,</span>m<span style="color: gray">.</span>Nome<span style="color: gray">,</span>c<span style="color: gray">.</span>Nivel <span style="color: gray">+ </span>1 <span style="color: blue">AS </span><span style="color: red">'Nivel'</span><span style="color: gray">,
        </span><span style="color: magenta">CAST</span><span style="color: gray">((</span>c<span style="color: gray">.</span>NomeCompleto <span style="color: gray">+ </span><span style="color: red">'/' </span><span style="color: gray">+ </span>m<span style="color: gray">.</span>Nome<span style="color: gray">) </span><span style="color: blue">AS VARCHAR</span><span style="color: gray">(</span>255<span style="color: gray">)) </span><span style="color: red">'NomeCompleto' 
    </span><span style="color: blue">FROM </span>tbMenu m <span style="color: gray">INNER JOIN </span>cteMenuNivel c <span style="color: blue">ON </span>m<span style="color: gray">.</span>idPai <span style="color: gray">= </span>c<span style="color: gray">.</span>id
    
<span style="color: gray">)
</span><span style="color: blue">SELECT </span>Nivel<span style="color: gray">,</span>NomeCompleto <span style="color: blue">FROM </span>cteMenuNivel</pre>
</blockquote>

<p>&#160;</p>

<p><strong><font size="3">Performance</font></strong></p>

<p>O desempenho de <strong>query recursiva</strong> usando <strong>Common Table Expression</strong> é excelente para tabela com pouco volume de dados, mas há uma degradação perceptível quando usada em tabelas críticas de sistema e com mais de 10000 registros (comprovado em cliente!). A explicação para esse fato é feita através do plano de execução:</p>

<p>&#160;</p>

<p><a href="images\2627.image_1FEEF1D5.png"><img style="border-bottom: 0px;border-left: 0px;padding-left: 0px;padding-right: 0px;border-top: 0px;border-right: 0px;padding-top: 0px" title="image" border="0" alt="image" src="images\2543.image_thumb_755310F7.png" width="726" height="214" /></a></p>

<p>&#160;</p>

<ul>
  <li><strong>Passo 1:</strong> Os resultados da query “âncora” são obtidos a partir de uma operação de leitura da tabela</li>

  <li><strong>Passo 2: </strong>Os operadores de “Compute Scalar” realizam os cálculos e transformações de tipo de dados</li>

  <li><strong>Passo 3 e 4: </strong>O resultado parcial é armazenado em uma <strong>Tabela Temporária (Index Spool), </strong>que&#160; serve como fonte de dados para a recursão (Passo 4)</li>

  <li><strong>Passo 5: </strong>Como parte do processo recursivo, as informações da tabela são lidas novamente</li>

  <li><strong>Passo 6: </strong>Os novos níveis são identificados através da operação de JOIN entre tabelas. Nesse caso, a operação realizada foi de NESTED LOOP </li>

  <li><strong>Passo 7: </strong>Os registros do nível seguinte são armazenados na Tabela Temporária e o processo volta ao <strong>Passo 4</strong></li>

  <li><strong>Quando não forem produzidos mais registros, o processo termina. </strong></li>
</ul>

<p>Quanto maior o número de passos executados no processo recursivo, maior o impacto na performance da query. Se fosse usada uma tabela com 1 milhão de registros, porém, houvesse poucas repetições dos passo 4-7, o desempenho seria ótimo. </p>

<p><strong>Portanto, o problema não é exatamente o tamanho da tabela ou sua criticidade, mas a quantidade de registros retornados e o número de passos executados. </strong></p>
