# 数据库表生成C#实体类
## 目前支持SqlServer、MySql两种数据库
## SqlServer数据库执行的是Config下面的SqlServer.sql，如果有需要可以自己修改成自己想要的
## MySql数据库中可以在Config下的config中配置类型匹配规则，也可以自己修改
## 添加功能：继承Sql帮助类，当勾选功能后，将会根据数据类型继承不同的数据库基类，目前支持SqlServer、MySql
## Ysh.CreateSql中声明了模型继承的数据库父类，该类目前可以根据对象修改的属性去生成对应的增删改查语句，后期可以拿得语句之后交给dapper执行

