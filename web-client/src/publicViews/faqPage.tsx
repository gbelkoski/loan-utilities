import { Container, makeStyles } from '@material-ui/core';
import React from 'react';

const useStyles = makeStyles(() => ({
    root: {
      position: "relative",
      backgroundColor:"white",
      marginTop:30
    }
  }));
  

const FAQPage: React.FC = () => {
    const classes = useStyles();
    return (
        <Container className={classes.root}>
        <div>
            <br/>
            <h3>Општи кредитни услови што треба да исполни кредитобарателот:</h3>
            <ul>
                <li>Возраст од најмалку 20 години на денот на склучување на договорот за кредит</li>
                <li>Возраст од најмногу 65 години на денот на доспевање на последната рата на кредитот</li>
                <li>Вработен на неопределено време, ако е вработен на определено тогаш рочноста на кредитот не може да е подолга од датумот на завршување на договорот за вработување</li>
                <li>Добра кредитна историја во македонско кредитно биро и кредитен регистар во некој изминат период во зависност од Банката вообичаено проверката се прави за последните 3 месеци.</li>
                <li>Минимален месечен приход од 10.000 ден. износот се менува во во зависност од интерните критериуми на банката.</li>
                <li>Рата/Плата износот на месечната рата не може да надмине 1/3 или 1/2 (една половина) од платата на клиентот. Показателот Рата/Плата се разликува во зависност од интерните критериуми на Банката.</li>
            </ul>
            <br/>
            <h3>Дефиниција на Кредит</h3>
            <b>Кредит</b> е договор со кој доверителот му позајмува на должникот одреден износ средства кој должникот треба да ги врати во одреден временски период притоа плаќајќи одреден надомест(камати и трошоци) за користење на добиениот заем. <br/>
            <b>Ненаменски кредит</b> е кредит за кој во договорот меѓу должникот и доверителот не е дефинирано за што ќе се користат средствата од заемот, тоа е дискреционо право на кредитокорисникот. <br/>
            <b>Наменски кредит</b> е кредит за кој точно е утврдена намената на средствата (пр: станбен- за купување на стан, автомобилски- за купување на автомобил...), заемот вообичаено се исплаќа од страна на Банката директно на сметка на продавачот на производите
            или услугите.<br/>
            <b>Необезбеден кредит</b> е договор за кредит во кој кредитобарателот не дава под залог било каков имот како гаранција дека ќе го врати кредитот.<br/> <b>Обезбеден кредит</b>- кредит каде кредитоткорисникот гарантира дека ќе го врати заемот со залог
            на некој вид имот (стан,земјиште,автомобил). Во случај да не го врати заемот Банката има право да го продаде имотот што бил даден по залог за да ги наплати своите побарувања.<br/>
            <br/>
            <h4>Видови кредити:</h4> <b>Потрошувачки кредит -</b> ненаменски вообичаено необезбеден кредит, лица најчесто со максимални износи до 20.000 ЕУР и со рок до 10 години.<br/> <b>Брзи кредити -</b> ненаменски необезбедени потрошувачки кредити што вообичено
            се одобруваат за само неколку часа. <br/><b> Станбен кредит -</b> наменски обезбеден кредит за купување недвижен имот, како обезбедување на кредитот служи недвижениот имот што е предмет на купопродажба. <br/><b>Хипотекарен -</b> обезбеден најчесто
            ненаменски потрошувачки кредит со залог на недвижен имот во сопственост на кредитобарателот. <br/><b>Кредит обезбеден со депозит -</b> ненаменски кредит обезбеден со залог на депозит кој кредитокорисникот го орочува во Банката за време на рочноста
            на кредитот.<br/><b>Пензионерски -</b> ненаменски потрошувачки кредит за кредитирање на лица со остварено право на пензија.  АВТОМОБИЛСКИ – наменски обезбеден кредит за купување патничко или товарно возило. Средствата се исплаќаат дирекно на продавачот
            на возилот. Купеното возило служи како обезбедување на кредитот.<br/><b>ЕДУ - за школување -</b> наменски кредит вообичаено необезбеден за финансирање на образовни трошоци.<br/><b>Еко-зелен -</b> наменски кредит вообичаено необезбеден за купување
            на производи и услуги за подобрување на енергетска ефикасност и слични “ЕКО” технологии.
            <br/>
            <br/>
            <h3>Општи Поими:</h3>
            <b>Рефинансирање:</b> рефинансирање претставува земање на нов кредит од иста или друга Банка за враќање на предходно земен кредит. Вообичаено рефинансирање се прави поради добивање на кредит со поголем износ и/или пониски каматни стапки.
            <br/><b>Аморт план:</b> амортизационен план е документ кој го издава Банката на кој се прикажани во месечните рати за отплата со точни износи и датуми на кој треба да се извршат уплатите. <br/><b>Ануитет:</b> ануитет или месечна рате е вкупниот месечен
            износ што клиентот треба плати при редовна отплата на кредитот. Ануитетот може да се состои од главница, камата и други трошоци. <br/><b>Главница:</b> Позајмениот износ во моментот на склучување на договорот за кредит. <br/><b>Преостаната главница:</b>    Вкупниот износ на кредитот минус до моментот отплатена главница преку месечните рати. <br/><b>Грејс период:</b> период во кој должникот отплаќа само камата но не и главница <br/><b>LTV (Loan to Value):</b> се однесува на обезбедените кредити (станбени,хипотекарни...)
            и го означува односот на вредноста на кредитот и вредноста на залогот(обезбедувањето). Правилото е дека вредноста на кредитот е секогаш помала за најмалку 10% од вредноста на обезбедувањето. Пример: Вредност на обезбедување 10.000 ЕУР, Износ на кредит
            9.000 ЕУР, LTV=90%
            <br/>
            <br/>
            <h3>Камати</h3>
            <b>Камата:</b> Tрошокот на позајмувањето или цената што се плаќа за позајмувањето средства. Каматата вообичаено се изразува на годишно ниво како %(процент) од преостанатата главница. <br/><b>Интеркаларна камата:</b> Kамата што се пресметува и наплатува
            само од моментот кога се одобрува кредитот до моментот кога ќе почне отплатата на истиот, поточно до наплата на првата рата. <br/><b>Фискна каматна стапка:</b> Kаматна стапка со гарантирана непроменлива висина за одреден временски период
            <br/><b>Референтна каматна стапка:</b> Пазарна каматна стапка која ја одредуваат условите на финансиските пазари таа е независна од желбите на било кој поединечен учесник на пазарот. Референтната каматна стапка служи за реално непристрасно одредување
            на цената на позајмените средства. <br/><b>Варијабилна каматна стапка:</b> Варијабилната каматна стапка е збир од две стапки, референтна каматна стапка која се менува во зависност од пазарните движења и фиксен додаток(маргина) кој гарантирано останува
            ист во целиот период на отплата на кредитот. Вообичаено се изразува како Референтната стапка + додатокот (пр: 6 месечен ЕУРИБОР + 3% или Благајнички Записи + 4%). <br/><b>Прилагодлива каматна стапка:</b> Каматна стапка чија вредност по сопствена желба
            ја одредува Банката и може да се промени во било кое време со еднострана одлука на Банката.
            <br/>
            <br/>
            <h3>Трошоци</h3>
            <b>Административен трошок</b> е трошокот за обработка на апликацијата на кредитот и може да се наплати дури и ако кредитот не е одобрен, во зависност од Банката и кредитот изнесува од 300 до 1.300 ден. <br/><b>Провизија за одобрување: </b> Се наплаќа
            од износот на одобрениот кредит и вообичаено изнесува 1-2% од одобрениот износ на кредит. <br/><b>Проверка во МКБ:</b> Во моментот на апликација Банката ја проверува кредитната историја на личноста која аплицира за кредитот во МКБ (Македонско кредитно
            биро). Трошокот за оваа проверка изнесува околу 300 ден. и банката го наплаќа од клиентот. <br/><b>Процена на вредност на залог (хипотека):</b> Кај кредитите обезбедени со недвижен имот (станбени,хипотекарни) или движен имот (автомобилски) се врши
            проценка на вредноста на имотот од страна на овластени проценители. Трошокот на проценката изнесува најмалку 2.000 Ден. и се наплаќа од клиентот.Трошокот и зависи од локацијата, големината и видот на заложениот имот. <br/><b>Упис на залог (хипотека) во регистар на заложен имот</b>    Имотот даден под залог како обезбедување на кредит задолжително се упишува во регистрите на заложен недвижен или движен имот. Трошокот отприлика изнесува 1000 ден. и се наплаќа од кредитокорисникот. <br/><b>Премија за осигурување на залог (хипотека)</b>    Заложениот имот се осигурува. Недвижниот имот со полиса за осигурување од пожар, поплава или сл. Додека за движниот имот(моторни возила) задолжително е КАСКО осигурување. Трошокот за осигурителните полиси е на товар на клиентот и се повторува годишно
            за време на траење на договорот за кредит. <br/><b>Премија ЗА осигурување на живот:</b> Кај некои потрошувачки кредити задолжително е обезбедување на кредитот со полиса за кредитно животно осигурување. Трошокот на полисата зависи од полот, возраста,
            професијата на клиентот, изностот на кредитот и сл. <br/><b>Премија за осигурување од незгода:</b> Полисата за осигурување од незгода исто така е потребна како обезбедување кај некој видови кредити. Трошокот кој изнесува отприлика 1.000 ден годишно
            е на товар на клиентот. <br/><b>Меници:</b> Меницата е хартија од вредност која и дава безусловно право на Банката да изврши наплата на своите побарувања од клиентот. Вообичаено трошокот за меница изнесува 500 ден. <br/><b>Адвокатски трошоци за изготвување на договор</b>    За договори за кредит за износи над 10.000 ЕУР во денарска противвредност задолжително е да се обезбеди адвокатски печат и потпис. Се наплаќа од кредитобарателот според адвокатска тарифа. <br/><b>Солемизација / нотарски акт</b> Во зависност од износот
            и типот на кредит може да биде потребна потврда(солемизација) на договорот за кредит на нотар или изготвување на нотарски акт. Трошоците се најчесто на товар на клиентот и се наплаќаат според тарифата за извршување нотарски работи.
            <br/>
            <br/>
            <h3>Обезбедување (Колатерал)</h3>
            Наједноставно кажано, колатералот е некој вид имот или платежен инструмент приложен од страна на клиентот, како гаранција или обезбедување во однос на идната отплата на кредитот.
            <br/>
            <br/>
            <h4>Видови Обезбедување:</h4>
            <b>Административна Забрана</b> е основен вид на обезбедување (платежен инструмент) со кој се прави директна наплата на ратите од платата на кредитокорисникот во моментот на исплата на платата. <br/><b>Меница</b> е инструмент за обезбедување на наплата,
            со која кредитокорисникот и дава безусловно право на Банката да си ги наплати побарувањата. <br/><b>Траен Налог</b> е инструмент за наплата со кој кредитокорисникот ја овластува банката автоматски да ги наплаќа ратите по кредит од неговата трансакциска
            сметка до целосно подмирување на обрските. <br/><b>Гарант (Жирант)</b> е лице кое гарантира дека во случај кредитобарателот да не ги подмирува своите обврските по основ на кредитот Банката може да бара наплата на кредитот од личните средства на Гарантот.
            Од гарантот може да се бара исполнување на обврската дури откако главниот должник нема да ја исполни обврската во определениот рок (супсидијарна гаранција). <br/><b>Гарант Платец (Жирант)</b> е лице кое гарантира како главен должник за целата обврска
            и Банката може да бара нејзино исполнување било од главниот должник, било од гарантот-платец или од двајцата во исто време. <br/><b>Кокредитобарател –</b> слично на гарант платецот е лице кое гарантира како главен должник за целата обврска и Банката
            може да бара нејзино исполнување било од главниот должник, било од кокредитобарателот или од двајцата во исто време. <br/><b>Кредитно-животно осигурување -</b> полиса со која во случај на настанување на осигурениот настан пред да биде целосно исплатен
            кредитот, осигурителната компаниja го исплаќа целиот износ на кредитот на банката. <br/><b>Потврување на Договор (Солемизација)</b> е нотарска потврда на договор за кредит со кој се зголемува правната сигурност на двете страни од договорот и се олеснува
            извршувањето на наплата во случај на ненавремено помирување на обврските. <br/><b>Хипотека – Залог на недвижен имот</b> е договор со кој клиентот гарантира со сопствен недвижен имот дека ќе го исплаќа кредитот а во случај да не го стори тоа Банката
            може да си ги наплати своите побарувања преку продажба на недвижниот имот на клиентот.<br/><b>Залог на движен имот</b> е ист вид на обезбедување како хипотеката само што клиентот гарантира со некој друг вид на имот (пр: автомобил, машини, производи)
            <br/><b>Залог на депозит</b> клиентот гарантира за враќање на позајмениот износ со давање под залог на парични средства во одреден износ. <br/><b>Залог на хартии од вредност</b> исто како другите видови залози со тоа што тука во залог се оставаат
            Хартии од вредност прифатливи за Банката.
            <br/>
            <br/>
        </div>
        </Container>
      )
}

export default FAQPage;