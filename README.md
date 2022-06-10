 # Brick Game
                                                                      
  ### Опис на играта
  
  Во оваа игра, играчот ја поместува платформата од една до друга страна со цел да го удри топчето и да не му дозволи да падне. Целта на играта е да се елиминираат сите цигли кои што се наоѓаат непосредно над платформата на горниот дел од екранот. Циглите ги елиминираме на тој начин што со топчето треба да удриме во нив. Во случај ако топчето падне на дното од екранот, играчот губи, на екранот му се појавува Message Box при што може да направи избор дали сака да игра повторно или не. Доколку играчот одбере да игра пак, играта се вклучува пак а во спротивно целата апликација се гаси. Ако успее да ги елиминира сите цигли тогаш тој победува. Во горниот лев агол од играта во секое време може да се видат поени кои во тој момент играчот ги има. Во момент кога победува, му излегува порака во истиот дел кај поените дека победил и начин на кој може да започне со нова игра, истото се случува и при пораз на играчот. 
  
 ### Опис на решение на проблем
  
   Најпрвин на почетокот креиравме форма со црна позадина, на горниот дел од формата поставивме 36 цигли во најразлични бои, а во долниот дел е платформата и топчето. Платформата се движи со притискање на копчињата Left и Right на тастатура. Во моментот кога играта започнува поставивме музика која играчот може да ја слуша во текот на целата игра, исто така во моментот кога играчот ќе загуби започнува друг вид на музика. Играта се состои од 7 функции сместени во една класа - public partial class Form1 : Form во кои е имплементирана нејзината логика. Името на секоја функција всушност го опишува проблемот кој се решава во самата функција. Не постојат некои специфични правила на игра, играта е доста едноставна за играње и разбирање, играчот има само една задача - да се потруди топчето да не стигне до долниот дел од платформата бидејќи во тој момент губи. Циглите се бришат во момент кога ќе бидат во интеракција со топчето.
   
   
 ### Опис на функција "setupGame()"
   
  Функцијата setupGame() ни служи при почување на нова игра да ги сетираме сите вредности и елементи на почетен старт. Па така тука првин кажуваме дека при почеток на нова игра да почне да работи тајмерот за играта и музиката која е наменета додека трае играта да се вклучи, а со тоа музиката за крај на игра да се стопира. Променливата која ни служи да означиме дали е крај се поставува на false и со тоа знаеме дека играта е активна. Платформата и топчето при активирање на нова игра секогаш ги позиционираме на својата почетна позиција. Бројачот кој ни служи за тоа колку цигли сме елиминирале го поставуваме на нула и текстот кој ни служи да ни кажува колку ни е скорот го сетираме во почетната вредност односно да пишува дека немаме сеуште елиминирано ниту една цигла. Променливите кои се задолжени за поместување на платформата и на топчето во соодвените насоки им поставуваме default вредност. За крај имаме и loop кој ни служи да ги најдеме сите цигли кои имаат вредност на tag - "block" и ако се од тип PictureBox за да на секоја нова игра секоја таква цигла има нова боја која се добива рандом. Оваа функција подоцна се повикува во функцијата placeBlocks() која ни овозможува нова игра.
  
  ![Screenshot (257)](https://user-images.githubusercontent.com/80158055/173099468-3ab11937-a423-4449-b13e-a5b49c4d18d8.png)
  
  
### Изглед на играта Brick Game
![iepo1B](https://user-images.githubusercontent.com/80158055/173099646-82fc9c30-008e-4574-880c-de89c0e23a3f.gif)



