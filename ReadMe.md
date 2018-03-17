产生式系统推理

班级：HC001209     姓名：叶森茂     学号：201230836

 
一、实验目的  
1. 理解并掌握产生式系统的基本原理； 
2. 掌握产生式系统的组成部分，以及正向推理和逆向推理过程。
 
二、实验要求 
1. 结合课本内容, 以动物识别系统为例，实现小型产生式系统; 
 2. 要求: 正向推理中能根据输入的初始事实，正确地识别所能识别的动物；逆向推理中能根据所给的动物给出动物的特征。  

三、实验算法 
1.  如何表示事实和特征的知识；
将规则转化成相应的数字编号，存放入AI1和AI2中
AI1 中存放不能推出具体动物的规则，在遍历AI1中的过程后，动态数据库将会变为一个中间态；AI2中存放能够推出具体动物的规则，遍历AI2中的规则就能够找出匹配的动物。
从复选框中输入动物的特征。
2. 指出综合数据库和规则库分别使用哪些函数实现的？
规则库存放于AI1.txt和AI2.txt中，调用FileStream读取文档，遍历规则库。集合“data”表示动态数据库，通过Set.Add和Set.Remove对数据库更新。
3. 规则库的匹配算法是什么？如何选用可用规则集中的规则？分别使用哪些函数实现的？ 
     将动态数据库表示为一个集合类型，通过Set.isSubset判断当前规则的前提是否为动态数据库的子集，如果匹配成功则通过Set.add    更新动态数据库，或者成功并结束退出。
4.关键的函数有哪些？
DgForm                                             绘制界面
Set.add                                        往集合中增加元素
Set.remove                                     从集合中移除元素
Set.isSubset                                     判断是否为子集

四、	实验结果

![image](https://github.com/senmaoy/production-system/blob/master/动物查询系统.png)

