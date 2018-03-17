open System.Drawing
open System.Windows.Forms
open System.Drawing
open System.IO

let jj="有奶 哺乳动物 有毛发 有羽毛 鸟 会飞 生蛋 有爪 有犬齿 目盯前方 食肉动物 吃肉 有蹄 有蹄动物 反刍食物".Split()
let jjj="偶蹄动物 黄褐色 黑色条纹 黑色斑点 长腿 长脖子 有暗斑点 白色 黑色条纹 不会飞 黑白色 会游泳 善飞 不怕风浪".Split()
type DgForm() as this =
     inherit Form()
     let chbs1 = [|for i in 0..jj.Length-1->new CheckBox(Text=jj.[i],Location=Point(10,15+25*i))|]
     let grb1 = new GroupBox(Text="特征",Location=Point(20,10))
     let chbs2 = [|for i in 0..jjj.Length-1->new CheckBox(Text=jjj.[i],Location=Point(10,15+25*i))|]
     let grb2 = new GroupBox(Text=" ",Location=Point(120,10))
     let btn1 = new Button(Text ="提交", Location=Point(250,300))
     let btn2 = new TextBox(Text="输出结果",Location=Point(250,100))
     do btn1.Click.Add(fun e ->

            btn2.Text<-"NULL"
            let mutable data =set[]
            for chb in chbs1 do 
              if chb.Checked=true then data<- data.Add chb.Text
            for chb in chbs2 do 
              if chb.Checked=true then data<- data.Add chb.Text
            printfn "%A" data
            let eval x=
                match x with
                |"有奶" ->"1"
                |"哺乳动物" ->"2"
                |"有毛发" ->"3"
                |"有羽毛" ->"4"
                |"鸟" ->"5"
                |"会飞" ->"6"
                |"生蛋" ->"7"
                |"有爪" ->"8"
                |"有犬齿" ->"9"
                |"目盯前方" ->"10"
                |"食肉动物" ->"11"
                |"吃肉" ->"12"
                |"有蹄" ->"13"
                |"有蹄动物" ->"14"
                |"反刍食物" ->"15"
                |"偶蹄动物" ->"16"
                |"黄褐色" ->"17"
                |"黑色条纹" ->"18"
                |"黑色斑点" ->"20"
                |"长腿" ->"22"
                |"长脖子" ->"23"
                |"有暗斑点" ->"24"
                |"白色" ->"26"
                |"不会飞" ->"28"
                |"黑白色" ->"29"
                |"会游泳" ->"31"
                |"善飞" ->"33"
                |"不怕风浪" ->"34"
                |_->"100"
            let inverteval x=
                match x with
                |"19"->"老虎"
                |"21"->"金钱豹"
                |"25"->"长颈鹿"
                |"27"->"斑马"
                |"30"->"鸵鸟"
                |"32"->"企鹅"
                |"35"->"海燕"
                |_->"cuowu"
            for i in data do
              let temp= eval i
              data<-Set.add temp data
              data<-Set.remove i data
            let mutable fs = new FileStream("C:\Users\ey\Desktop\AI\AI1.txt",FileMode.Open)
            let mutable ffs = new FileStream("C:\Users\ey\Desktop\AI\AI2.txt",FileMode.Open)
            let sr = new StreamReader(fs)
            let ssr = new StreamReader(ffs)
            //System.Console.Write "输入数据"
            //let data = System.Console.Read()
            let mutable m=sr.ReadLine().Split()
            let mutable l=m.Length
            while(m<>[|"000"|]) do
                 l<-m.Length
                 let mutable dd= set m
                 dd<-Set.remove m.[l-1] dd
                 if Set.isSubset dd data then data<-data.Add m.[l-1]
                 m<-sr.ReadLine().Split()

            let mutable mm=ssr.ReadLine().Split()
            let mutable ll=mm.Length
            let mutable ttemp=""
            while(mm<>[|"000"|]) do
                 ll<-mm.Length
                 let mmlast=mm.[ll-1]
                 let mutable ddd= set mm
                 ddd<-Set.remove mmlast ddd
                 mm<-ssr.ReadLine().Split()
                 if Set.isSubset ddd data 
                 then 
                     data<-data.Add mmlast
                     let tttemp = ttemp+" "+inverteval mmlast 
                     ttemp<-tttemp
                    
                     btn2.Text<-ttemp
                     //mm<-[|"000"|]
            printfn "%s"  ttemp     
            fs.Close()
            ffs.Close()
            data<- set[]
          )
     do for chb in chbs1 do grb1.Controls.Add(chb)
     do for chb in chbs2 do grb2.Controls.Add(chb)
     do this.Controls.Add(grb1)
     do this.Controls.Add(grb2)
     do this.Controls.Add(btn1)
     do this.Controls.Add(btn2)
     do for c in grb1.Controls do c.AutoSize<-true
     do for c in grb2.Controls do c.AutoSize<-true
     do grb1.Size<-Size(90,400)
     do grb2.Size<-Size(90,400)
     do btn1.Size<-Size(90,45)
     do btn2.AutoSize<-true
     do btn2.WordWrap<-true
let frm1 = new DgForm(Text="动物查询系统",Width=400,Height=500)

Application.Run(frm1)

