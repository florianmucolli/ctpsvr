using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citiport.Place
{
    public class PlacesFakeData
    {
        public const double BeijingLat = 999.99;
        public const double TaipeiLat = -999.99;


        #region taipei
        public const String Taipei = @"[{'title':'威秀影城','address':'108台北市萬華區武昌街二段87號','phone':'02-2331-5256','latitude':'25.04538','longtitude':'121.504410','imageurl':'1.jpg'},

{'title':'樂聲戲院','address':'108台北市萬華區武昌街二段85號','phone':'02-2311-8628','latitude':'25.04531','longtitude':'121.50469','imageurl':'2.jpg'},

{'title':'in89豪華數位影院','address':'108台北市萬華區武昌街二段89號','phone':'02-2331-5077','latitude':'25.04547','longtitude':'121.50401','imageurl':'3.jpg'},

{'title':'MoePoint萌點女僕咖啡廳','address':'108台北市萬華區中華路一段114巷17號','phone':'02-2311-9488','latitude':'25.04398','longtitude':'121.50785','imageurl':'4.jpg'},

{'title':'三輪車餐飲廣場','address':'108台北市萬華區漢中街69號','phone':'02-2331-5415','latitude':'25.04354','longtitude':'121.50729','imageurl':'5.jpg'},

{'title':'咖哩世界','address':'108台北市萬華區漢中街50巷11號2樓','phone':'02-2311-5112','latitude':'25.04413','longtitude':'121.50705','imageurl':'6.jpg'},

{'title':'菓風小舖','address':'108台北市萬華區武昌街二段87號','phone':'02-2331-5256','latitude':'25.04538','longtitude':'121.504410','imageurl':'7.jpg'},

{'title':'阿毛石鍋燉飯','address':'108台北市萬華區武昌街二段48之1號','phone':'02-2388-8098','latitude':'25.04467','longtitude':'121.50712','imageurl':'8.jpg'},

{'title':'七條龍炭火燒肉','address':'108台北市萬華區武昌街二段10號','phone':'02-2375-4331','latitude':'25.04437','longtitude':'121.50824','imageurl':'9.jpg'},

{'title':'可樂森林','address':'108台北市萬華區西寧南路117號2樓','phone':'02-2389-8805','latitude':'25.04491','longtitude':'121.50665','imageurl':'10.jpg'},

{'title':'台北牛乳大王獅子林店','address':'108台北市萬華區西寧南路36-88號','phone':'02-2331-8191','latitude':'25.04504','longtitude':'121.50651','imageurl':'11.jpg'},

{'title':'幸春三兄妹豆花','address':'108台北市萬華區漢中街23號','phone':'02-2381-2650','latitude':'25.04521','longtitude':'121.50784','imageurl':'12.jpg'},

{'title':'鴉片粉園','address':'108台北市萬華區昆明街108號','phone':'02-2388-4844','latitude':'25.04374','longtitude':'121.50496','imageurl':'13.jpg'},

{'title':'成都大飯店','address':'No. 115, ChéngDōu Rd, Wanhua District
Taipei City 10844','phone':'02-2383-1123','latitude':'25.04330','longtitude':'121.50402','imageurl':'14.jpg'},

{'title':'港九香滿園','address':'108台北市萬華區峨嵋街56號','phone':'02-2311-4663','latitude':'25.04396','longtitude':'121.50495','imageurl':'15.jpg'},

{'title':'馬辣鴛鴦火鍋專賣','address':'108台北市萬華區西寧南路62號','phone':'02-2314-6528','latitude':'25.04381','longtitude':'121.50614','imageurl':'16.jpg'},

{'title':'美觀園','address':'108台北市萬華區峨嵋街36號','phone':'02-2331-7000','latitude':'25.04352','longtitude':'121.50664','imageurl':'17.jpg'},

{'title':'焗本家洋食屋','address':'108台北市萬華區峨嵋街36號','phone':'02-2388-9945','latitude':'25.04344','longtitude':'121.50693','imageurl':'18.jpg'},

{'title':'繼光香香雞','address':'108台北市萬華區漢中街121-1號','phone':'02-2388-2622','latitude':'25.04346','longtitude':'121.50775','imageurl':'19.jpg'},

{'title':'紅磡婚宴會館港式飲茶','address':'108台北市萬華區中華路1段144號','phone':'02-2331-6789','latitude':'25.04322','longtitude':'121.50819','imageurl':'20.jpg'},

{'title':'維多利亞茶餐廳','address':'108台北市萬華區成都路27巷19號','phone':'02-2382-6388','latitude':'25.04317','longtitude':'121.50691','imageurl':'21.jpg'},

{'title':'HotCandy烤棉花糖','address':'108台北市萬華區中華路一段114巷4-23號','phone':'0917-885-271','latitude':'25.04387','longtitude':'121.50785','imageurl':'22.jpg'},

{'title':'大車輪火車壽司','address':'108台北市萬華區峨嵋街53號','phone':'02-2371-2701','latitude':'25.04366','longtitude':'121.50661','imageurl':'23.jpg'},

{'title':'美觀園公共食堂','address':'108台北市萬華區峨嵋街47號','phone':'02-2331-0377','latitude':'25.04361','longtitude':'121.50684','imageurl':'24.jpg'},

{'title':'熊一頂級燒肉料理','address':'108台北市萬華區西寧南路155號','phone':'02-2370-8468','latitude':'25.04353','longtitude':'121.50624','imageurl':'25.jpg'},

{'title':'西門新宿','address':'108台北市萬華區西寧南路72-1號','phone':'','latitude':'25.04324','longtitude':'121.50597','imageurl':'26.jpg'},

{'title':'NICO炭火燒肉冠軍','address':'108台北市萬華區昆明街116號','phone':'02-2370-0289','latitude':'25.04361','longtitude':'121.50492','imageurl':'27.jpg'},

{'title':'丹堤咖啡館','address':'108台北市萬華區成都路107號','phone':'02-2336-2872','latitude':'25.04327','longtitude':'121.50421','imageurl':'28.jpg'},

{'title':'國賓大戲院','address':'No. 88, ChéngDōu Rd, Wanhua District
Taipei City 10845','phone':'02-2361-1222','latitude':'25.04303','longtitude':'121.50455','imageurl':'29.jpg'},

{'title':'田舍手打麵','address':'108台北市萬華區昆明街99號','phone':'02-2389-4218','latitude':'25.04239','longtitude':'121.50476','imageurl':'30.jpg'},

{'title':'星聚點KTV時尚宴','address':'108台北市萬華區成都路81號','phone':'02-2388-6000','latitude':'25.04304','longtitude':'121.50525','imageurl':'31.jpg'},

{'title':'北回木瓜牛奶','address':'108台北市萬華區昆明街130號','phone':'02-2388-5855','latitude':'25.04329','longtitude':'121.50484','imageurl':'32.jpg'},

{'title':'天仁茗茶','address':'108台北市萬華區成都路45號','phone':'02-2311-9902','latitude':'25.04272','longtitude':'121.50646','imageurl':'33.jpg'},

{'title':'明日大飯店','address':'108台北市萬華區成都路23號','phone':'02-2375-5229','latitude':'25.04260','longtitude':'121.50696','imageurl':'34.jpg'},

{'title':'蛋蛋屋','address':'108台北市萬華區成都路15號','phone':'02-2371-3837','latitude':'25.04255','longtitude':'121.50717','imageurl':'35.jpg'},

{'title':'門卡迪炭燒咖啡廳','address':'108台北市萬華區成都路14號','phone':'02-2314-8955','latitude':'25.04240','longtitude':'121.50702','imageurl':'36.jpg'},

{'title':'成都楊桃冰','address':'108台北市萬華區成都路3號','phone':'02-2381-0309','latitude':'25.04264','longtitude':'121.50790','imageurl':'37.jpg'},

{'title':'真善美戲院','address':'108台北市萬華區漢中街116號','phone':'02-2331-2270','latitude':'25.04303','longtitude':'121.50737','imageurl':'38.jpg'},

{'title':'玉林雞腿大王','address':'108台北市萬華區中華路一段114巷9號','phone':'02-2371-4920','latitude':'25.04389','longtitude':'121.50821','imageurl':'39.jpg'},

{'title':'可樂森林Ⅰ店','address':'108台北市萬華區漢中街41-1號','phone':'02-2331-9315','latitude':'25.04379','longtitude':'121.50810','imageurl':'40.jpg'},

{'title':'統一星巴克漢中門市','address':'No. 51, HànZhōng St, Wanhua District
Taipei City 108','phone':'02-2370-5893','latitude':'25.04405','longtitude':'121.50744','imageurl':'41.jpg'},

{'title':'U2電影館-中華館','address':'108台北市萬華區中華路1段90號9樓','phone':'02-2314-7999','latitude':'25.04489','longtitude':'121.50867','imageurl':'42.jpg'},

{'title':'天天利美食坊','address':'108台北市萬華區漢中街32巷1號','phone':'02-2375-6299','latitude':'25.04509','longtitude':'121.50757','imageurl':'43.jpg'},

{'title':'港記酥皇店','address':'108台北市萬華區漢中街6-2號','phone':'02-2375-1967','latitude':'25.04576','longtitude':'121.50783','imageurl':'44.jpg'},

{'title':'Sukiyaki鋤燒鍋物料理','address':'108台北市萬華區西寧南路34號','phone':'02-2314-0825','latitude':'25.04581','longtitude':'121.50673','imageurl':'45.jpg'},

{'title':'天外天精緻麻辣火鍋','address':'108台北市萬華區昆明街76號2樓','phone':'02-2314-0018','latitude':'25.04576','longtitude':'121.50554','imageurl':'46.jpg'},

{'title':'小紅莓自助火鍋城','address':'108台北市萬華區昆明街46號','phone':'02-2370-9900','latitude':'25.04674','longtitude':'121.50583','imageurl':'47.jpg'},

{'title':'百悅商務旅館','address':'108台北市萬華區開封街二段42巷2號','phone':'02-2388-1792','latitude':'25.04619','longtitude':'121.50750','imageurl':'48.jpg'},

{'title':'宏洲旅社','address':'108台北市萬華區漢中街4號','phone':'02-2331-9841','latitude':'25.04597','longtitude':'121.50788','imageurl':'49.jpg'},

{'title':'生活工場Living plus','address':'108台北市萬華區武昌街二段83號','phone':'02-2388-9122','latitude':'25.04525','longtitude':'121.50492','imageurl':'50.jpg'}]";
        #endregion

        #region beijing
        public const String Beijing = @"[{'title':'Login Pub','address':'北京市东城区黑芝麻胡同1号','phone':'013910439133','latitude':'39.93851','longtitude':'116.4030','imageurl':'51.jpg'},

{'title':'Friends','address':'北京市东城区沙井胡同','phone':'010-64070336','latitude':'39.93783','longtitude':'116.4023','imageurl':'52.jpg'},

{'title':'Gongdu','address':'北京市东城区南锣鼓巷71号','phone':'010-51663328','latitude':'39.93805','longtitude':'116.4030','imageurl':'53.jpg'},

{'title':'Shajing Non-Staple Food Store','address':'北京市东城区南锣鼓巷83号','phone':'','latitude':'39.93765','longtitude':'116.4030','imageurl':'54.jpg'},

{'title':'Chengji Xianzha Guozhidian','address':'北京市东城区南锣鼓巷','phone':'010-64013454','latitude':'39.93876','longtitude':'116.4030','imageurl':'55.jpg'},

{'title':'秦唐府七号院courtyard 7','address':'东城区, 北京市, China, 100009','phone':'010-64060777','latitude':'39.93916','longtitude':'116.4027','imageurl':'56.jpg'},

{'title':'胡同儿','address':'东城区, 北京市, China, 100007','phone':'010-64006808','latitude':'39.93923','longtitude':'116.4037','imageurl':'57.jpg'},

{'title':'You Hao Bin Guan','address':'100009中国北京市东城区后圆恩寺胡同7号','phone':'010-64031114','latitude':'39.938557','longtitude':'116.4053','imageurl':''},

{'title':'Saigon Vietnamese Food','address':'北京市东城区鼓楼东大街200号','phone':'010-64044578','latitude':'39.94075','longtitude':'116.3996','imageurl':'59.jpg'},

{'title':'Lianlishu Foreign Food','address':'北京市东城区鼓楼东大街206号','phone':'010-64070868','latitude':'39.94076','longtitude':'116.3990','imageurl':'60.jpg'},

{'title':'北京波菲特酒店','address':'北京市东城区鼓楼东大街281号','phone':'010-64013699','latitude':'39.94089','longtitude':'116.3979','imageurl':''},

{'title':'DEAL','address':'北京市东城区鼓楼东大街280号','phone':'010-64028262','latitude':'39.94071','longtitude':'116.3976','imageurl':'62.jpg'},

{'title':'Yaoji Chaogandian','address':'北京市东城区鼓楼东大街311号-1','phone':'010-84010570','latitude':'39.94085','longtitude':'116.3967','imageurl':'63.jpg'},

{'title':'National Theatre Company of China','address':'北京市东城区帽儿胡同甲45号','phone':'010-64031009','latitude':'39.93694','longtitude':'116.3972','imageurl':'64.jpg'},

{'title':'Bei Jing Xin Xin Shi Zhuang','address':'北京市东城区地安门外大街128号','phone':'','latitude':'39.93593','longtitude':'116.3963','imageurl':''},

{'title':'Jinbaifa','address':'北京市西城区地安门外大街91号','phone':'010-84035296','latitude':'39.93587','longtitude':'116.3960','imageurl':'66.jpg'},

{'title':'Hua Kai Bin Guan','address':'北京市东城区雨儿胡同15号','phone':'010-64070268','latitude':'39.93569','longtitude':'116.4012','imageurl':'67.jpg'},

{'title':'沙漏咖啡','address':'北京市东城区帽儿胡同1号','phone':'010-64023529','latitude':'39.93640','longtitude':'116.4029','imageurl':'68.jpg'},

{'title':'Tibet Cafe','address':'北京市东城区南锣鼓巷97号','phone':'010-64022165','latitude':'39.93685','longtitude':'116.4030','imageurl':'69.jpg'},

{'title':'Hanzhenyuan International Hotel','address':'北京市东城区秦老胡同20号','phone':'010-84025588','latitude':'39.93701','longtitude':'116.40523','imageurl':'70.jpg'},

{'title':'The Central Academy of Drama','address':'北京市东城区东棉花胡同39号','phone':'010-64041781','latitude':'39.93598','longtitude':'116.4044','imageurl':'71.jpg'},

{'title':'Penghao Theatre','address':'北京市东城区东棉花胡同35号','phone':'010-64006472','latitude':'39.93592','longtitude':'116.4061','imageurl':'72.jpg'},

{'title':'Penghao','address':'北京市东城区东棉花胡同35号','phone':'010-64006452','latitude':'39.93578','longtitude':'116.4057','imageurl':'73.jpg'},

{'title':'江湖酒吧','address':'北京市东城区东棉花胡同7号','phone':'010-64014611','latitude':'39.93580','longtitude':'116.4073','imageurl':''},

{'title':'Luo Gu Dong Tian','address':'北京市东城区南锣鼓巷104号','phone':'010-84024729','latitude':'39.93534','longtitude':'116.4032','imageurl':'75.jpg'},

{'title':'Pass by Bar','address':'北京市东城区南锣鼓巷108号','phone':'010-64013336','latitude':'39.93509','longtitude':'116.4032','imageurl':'76.jpg'},

{'title':'paper','address':'北京市东城区鼓楼大街138号','phone':'010-84015080','latitude':'39.94076','longtitude':'116.4024','imageurl':'77.jpg'},

{'title':'Huangwa Caishenmiao','address':'北京市东城区北锣鼓巷','phone':'','latitude':'39.94103','longtitude':'116.4031','imageurl':'78.jpg'},

{'title':'Mao Livehouse','address':'111 Gulou Dongdajie,Beijing,100010','phone':'010-64025080','latitude':'39.94094','longtitude':'116.4035','imageurl':''},

{'title':'Dali Yuanzi','address':'北京市东城区小经厂胡同67号','phone':'010-84041430','latitude':'39.94132','longtitude':'116.4049','imageurl':'80.jpg'},

{'title':'E.A.T Cafe','address':'北京市东城区鼓楼东大街70号','phone':'010-67091383','latitude':'39.94075','longtitude':'116.4043','imageurl':'81.jpg'},

{'title':'古著','address':'北京市东城区鼓楼东大街69号','phone':'','latitude':'39.94097','longtitude':'116.4054','imageurl':'82.jpg'},

{'title':'cafe zarah','address':'北京市东城区鼓楼东大街42号','phone':'010-84039807','latitude':'39.94080','longtitude':'116.4064','imageurl':'83.jpg'},

{'title':'Hao Yun Yue Qi','address':'北京市东城区鼓楼东大街31号','phone':'010-64029875','latitude':'39.94101','longtitude':'116.4075','imageurl':'84.jpg'},

{'title':'Fuda Musical Instruments Shop','address':'北京市东城区鼓楼东大街24号','phone':'010-64029720','latitude':'39.94080','longtitude':'116.4074','imageurl':''},

{'title':'华峰青年酒店','address':'北京市东城区交道口南大街15号','phone':'010-64044548','latitude':'39.94021','longtitude':'116.4082','imageurl':''},

{'title':'美滋齐烧烤','address':'北京市东城区安定门内大街266号','phone':'010-64042544','latitude':'39.94282','longtitude':'116.4084','imageurl':''},

{'title':'Xianlaoman Restaurant','address':'北京市东城区安定门内大街252号','phone':'010-64046944','latitude':'39.94307','longtitude':'116.4082','imageurl':'88.jpg'},

{'title':'Beijing Fengcai','address':'北京市东城区交道口南大街','phone':'','latitude':'39.94396','longtitude':'116.4089','imageurl':'89.jpg'},

{'title':'Aimeng Xiaozhen','address':'北京市东城区方家胡同46号','phone':'010-64001725','latitude':'39.94380','longtitude':'116.4110','imageurl':'90.jpg'},

{'title':'参差咖啡馆','address':'中国北京市东城区安定门内方家胡同46号','phone':'010-84002673','latitude':'39.94378','longtitude':'116.4117','imageurl':'91.jpg'},

{'title':'Guoyao Xiaoju','address':'北京市东城区交道口北三条58号','phone':'010-64031940','latitude':'39.94328','longtitude':'116.4090','imageurl':'92.jpg'},

{'title':'Beijing Chongshi Hotel','address':'北京市东城区交道口北三条57号','phone':'010-64055383','latitude':'39.94345','longtitude':'116.4138','imageurl':'93.jpg'},

{'title':'Fang Jia Yi Er','address':'北京市方家胡同12号','phone':'010-64074480','latitude':'39.94403','longtitude':'116.4156','imageurl':'94.jpg'},

{'title':'Liuxianguan','address':'北京市东城区国子监街28-1号','phone':'010-84048539','latitude':'39.94525','longtitude':'116.4139','imageurl':'95.jpg'},

{'title':'Shengtangxuan','address':'北京市东城区国子监街38号','phone':'010-84047179','latitude':'39.94538','longtitude':'116.4111','imageurl':'96.jpg'},

{'title':'Beijing Temple of Confucius','address':'北京市东城区国子监街13号','phone':'010-84011977','latitude':'39.94659','longtitude':'116.4147','imageurl':'97.jpg'},

{'title':'Confucius International Youth Hostel','address':'北京市东城区五道营胡同38号','phone':'010-64022082','latitude':'39.94837','longtitude':'116.4139','imageurl':'98.jpg'},

{'title':'Gesang Meiduo','address':'北京市东城区雍和宫大街49号','phone':'','latitude':'39.94667','longtitude':'116.4163','imageurl':'99.jpg'},

{'title':'No.56 Private Kitchens','address':'北京市东城区安定门东大街56号','phone':'010-64051888','latitude':'39.94899','longtitude':'116.4139','imageurl':'100.jpg'}]";

        #endregion
       
    }
}