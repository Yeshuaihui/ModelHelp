declare orderNum_02_cursor cursor scroll
for SELECT 
a.name 'column', 
b.name 'type',
a.isnullable,
CAST(c.value as nvarchar(200)) [description],
case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then 1 else 0 end  isBiaoshi, 
case when exists(SELECT 1 FROM sysobjects where xtype='PK' and name in ( SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid ))) then 1 else 0 end  isPK,
d.name tablename
FROM syscolumns a inner join sysobjects d on a.id=d.id
LEFT OUTER JOIN systypes b ON a.xusertype = b.xusertype
LEFT OUTER JOIN sys.extended_properties c ON a.id = c.major_id AND a.colid = c.minor_id
where d.name='{$TableName}' 
order by a.id,a.colorder
declare @columnName nvarchar(200) ,@type nvarchar(200),@isNull bit,@description nvarchar(200),@isBiaoshi bit,@isPK bit,@tablename nvarchar(200)
open orderNum_02_cursor

declare @AllClass nvarchar(max)=''
fetch First from orderNum_02_cursor into @columnName,@type,@isNull,@description,@isBiaoshi,@isPK,@tablename  --into的变量数量必须与游标查询结果集的列数相同

set @AllClass=@AllClass+'namespace {$NameSpace}'+db_name()
set @AllClass=@AllClass+'\n'+'{'
set @AllClass=@AllClass+'\n'+'    using System.ComponentModel.DataAnnotations;'
set @AllClass=@AllClass+'\n'+'    using System;'
set @AllClass=@AllClass+'\n'+'    [Serializable]'
set @AllClass=@AllClass+'\n'+'    public partial class '+@tablename
set @AllClass=@AllClass+'\n'+'    {'

while @@fetch_status=0  --提取成功，进行下一条数据的提取操作 
 begin
	declare @CrsType nvarchar(20)
	if @description is null begin
	set @description=''
	end
	if  @type='int'
     begin
		set @CrsType='int'
	 end
	 else if @type='bigint' 
	 begin
		set @CrsType='long'
	 end
     else if @type='datetime'  
	 begin
		set @CrsType='DateTime'
	 end
	 else if @type='decimal' 
	 begin
		set @CrsType='decimal'
	 end 
	 else if @type='bit' 
	 begin
		set @CrsType='bool'
	 end 
	 else if @type='uniqueidentifier'
	 begin
		set @CrsType='Guid'
	 end
	 else if @type='float'
	 begin
		set @CrsType='decimal'
	 end
	 else if @type='tinyint'
	 begin
		set @CrsType='int'
	 end
	 else begin
		set @CrsType='string'
	 end
	 if @isNull=1 and @CrsType!='string' begin
		set @CrsType=@CrsType+'?'
	 end
	set @AllClass=@AllClass+'\n'+ '        /// <summary>'
	set @AllClass=@AllClass+'\n'+ '        ///'+REPLACE( REPLACE(REPLACE(@description, CHAR(13) , ''),char(10),''),CHAR(13) + CHAR(10),'')+''
	set @AllClass=@AllClass+'\n'+ '        /// </summary>'
	if @isBiaoshi=1 and @isPK=1 begin
		set @AllClass=@AllClass+'\n'+'        [Key]'
	end
	set @AllClass=@AllClass+'\n'+ '        public '+@CrsType+' '+@columnName+'{get;set;}'
	fetch next from orderNum_02_cursor into @columnName,@type,@isNull,@description,@isBiaoshi,@isPK,@tablename   --into的变量数量必须与游标查询结果集的列数相同
 end  
set @AllClass=@AllClass+'\n'+'    }'
set @AllClass=@AllClass+'\n'+'}'
close orderNum_02_cursor
deallocate orderNum_02_cursor
select @AllClass