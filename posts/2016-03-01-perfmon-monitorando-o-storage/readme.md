<a link='https://blogs.msdn.microsoft.com/fcatae/2016/03/01/perfmon-monitorando-o-storage/'>Perfmon: Monitorando o Storage</a>
<p>O principal recurso de um banco de dados é o storage, pois é lá onde os dados ficam armazenados. Antigamente o storage eram discos SCSI conectados ao servidor. Hoje os discos ficam escondidos atrás de várias camadas de virtualização:</p>  <ul>   <li>Discos SCSI/SAS/FC estão associados a um Arrays de Disco</li>    <li>Arrays de disco ficam conectados a uma Controladora de Disco</li>    <li>Controladora de Disco cria uma redundância dos discos (RAID1/5)</li>    <li>Controladora de Disco permite criar Discos Lógicos (LUN) sobre as redundâncias de disco</li>    <li>Disco Lógico (LUN) é gerenciado pelo Frontend do Storage</li>    <li>Disco Lógico (LUN) possui um Cache de Escrita para agilizar escritas pequenas e aleatórias</li>    <li>Frontend do Storage estão conectados com os Switches de Fiber Channel</li>    <li>Switches de Fiber Channel estão conectados com os Hosts (Servidor) pela HBA</li>    <li>Servidor (Hosts) monta as unidades lógicas (LUN) como discos locais</li>    <li>Discos locais são gerenciados pelo Partition Manager e Volume Manager</li>    <li>Discos locais recebem a formatação NTFS do Windows</li>    <li>SQL Server cria os arquivos MDF e LDF nos discos locais</li> </ul>  <p>Portanto, o processo de comunicação com o storage pode enfrentar uma série de problemas ao longo do seu caminho. A forma mais fácil de determinar a causa do problema é monitorando com o Performance Monitor.</p>  <p>São apenas 3 etapas:</p>  <ol>   <li>Calculamos a carga no storage em relação a IOPS</li>    <li>Calculamos a carga no storage em relação a MB</li>    <li>Calculamos o tempo de resposta do storage</li> </ol>  <p>Primeiro verificamos a quantidade de IOPS que o servidor está exercendo contra o storage:</p>  <ul>   <li>Disk Reads/sec</li>    <li>Disk Writes/sec</li>    <li>Disk Transfers/sec (corresponde a Reads + Writes)</li> </ul>  <p>Aqui temos um exemplo de um servidor com uma taxa variando de 1000-2000 IOPS. Como referência, um único disco SCSI pode executar aproximadamente 150 IOPS. Portanto, essa carga equivale de 7 a 13 discos SCSI.</p>  <p><a href="images\1258.image_1B7FF44E.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\2063.image_thumb_5C9C548A.png" width="644" height="164" /></a></p>  <p>Em seguida, medimos a a taxa de transferência. Observamos que a taxa fica em torno de 100MB/s. Como referência, uma HBA de 2Gbit consegue transferir aproximadamente 200MB/s.</p>  <p><a href="images\6180.image_0B8427D1.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\6445.image_thumb_4D1E641D.png" width="644" height="164" /></a></p>  <p>Por fim, medimos o tempo de resposta do storage e verificamos que os tempos ultrapassam 100ms. Adicionalmente podemos comparar com o “outstanding I/O”, que mostra o enfileiramento na HBA. Como referência, o tempo de serviço de um disco SCSI costuma ser de 5ms e discos SSD possuem latência de apenas 0,1ms.</p>  <p><a href="images\5148.image_55A1C367.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\8156.image_thumb_274ACE6B.png" width="644" height="164" /></a></p>  <p>Análise: Observamos que o tempo de resposta não é compatível com o tempo de disco usual (5ms). Recomendamos que o storage tenha uma performance de pelo menos 10 discos SCSI dedicados para a LUN. </p>  <h3>Servidor com Carga Pesada</h3>  <p>Vamos ao segundo exemplo. Dessa vez, vou colocar tudo no mesmo gráfico para analisar a carga:</p>  <ul>   <li>IOPS: variando de 2000 a 6000 com picos chegando a 10000</li>    <li>Banda: média de 200MB/s com picos de 400, 1000 e 1600MB/s</li> </ul>  <p><a href="images\4274.image_06C61F6A.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\8738.image_thumb_11860770.png" width="644" height="164" /></a></p>            <p>Comentários: estamos lidando com alta carga contra o storage.</p>  <ul>   <li>10000 IOPS é praticamente um storage dedicado para o servidor</li>    <li>1000MB/s é suficiente para causar gargalo em HBA de 8Gbit</li>    <li>1000MB/s normalmente requer um Switch FC dedicado</li> </ul>  <p>O tempo de resposta: encontra-se abaixo de 10ms com algumas variações próximas a 20ms. Adicionando o enfileiramento de disco, observamos que a fila aumenta rapidamente. </p>  <p><a href="images\6787.image_58058829.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\2553.image_thumb_5E4EEF68.png" width="644" height="164" /></a></p>  <p>Análise: O tempo de resposta do disco está excelente. A carga é extremamente alta (praticamente um storage dedicado) e com tempo de resposta de 10ms. O enfileiramento não deve ser encarado como problema.</p>  <h3>Disco de Log de um Servidor com Baixa Carga</h3>  <p>Começamos novamente analisando os contadores relacionados a carga IOPS e Transferência (MB/s). Aqui temos uma carga praticamente nula com menos de 50 IOPS e inferior a 10 MB/s. Como referência, podemos usar um disco SCSI realizando 150 IOPS e uma Fiber Channel transmitindo 200&#160; MB/s.</p>  <p><a href="images\7571.image_58966673.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\7024.image_thumb_1C6D2B7C.png" width="644" height="164" /></a></p>  <p>No tempo de resposta, vamos analisar somente a latência de escrita. Para isso, ajustamos o gráfico para 0 a 20 milissegundos. Observamos que a latência varia bruscamente entre 2 a 15ms.</p>  <p><a href="images\5531.image_2C0FC73E.png"><img title="image" style="border-top: 0px;border-right: 0px;border-bottom: 0px;padding-top: 0px;padding-left: 0px;border-left: 0px;padding-right: 0px" border="0" alt="image" src="images\8272.image_thumb_29699C3E.png" width="644" height="164" /></a></p>  <p>Análise: Esse disco de log apresenta uma taxa de escrita muito baixa. Entretanto, ele apresenta indícios de que existem gargalos com o storage devido às variações bruscas nos tempos de latência. Se o desempenho estivesse adequado, a latência seria praticamente constante. Embora não haja impacto no sistema atual, esse problema poderá se manifestar quando houver aumento de carga no sistema.</p>  <p>Como esse problema afeta uma LUN com disco de log (escritas pequenas e sequenciais), a carga deveria ser absorvida pelo cache do frontend do storage. Portanto, as variações bruscas de tempo indicam um gargalo no Volume Manager do Windows, Switch FC ou no Frontend do Storage. </p>  <p>Após investigação, determinamos que havia problema no Frontend do Storage (fan-out ratio), ou seja, a porta do frontend estava sobrecarregada com um número muito alto de hosts. A solução foi rebalancear os hosts entre as demais portas do storage.</p>  <p>&#160;</p>  <h3>Conclusão</h3>  <p>Performance Monitor é a melhor ferramenta para analisar o tempo de resposta do storage, pois permite determinar a carga do sistema (IOPS e MB/s) e medir o tempo de resposta. </p>