set nocount on;
use master;
go

if db_id('StuMgt') is null
	create database StuMgt;
go

use StuMgt;
go

-- 如果数据表存在则将其删除
if object_id('school') is not null
	drop table dbo.school;
go

if object_id('Reward') is not null
	drop table dbo.Reward;
go

if object_id('Punishment') is not null
	drop table dbo.Punishment;
go

if object_id('Change') is not null
	drop table dbo.Change;
go

if object_id('Classes') is not null
	drop table dbo.Classes;
go

if object_id('Department') is not null
	drop table dbo.Department;
go

if object_id('Student') is not null
	drop table dbo.Student;
go

if object_id('Change_Config') is not null
	drop table dbo.Change_Config;
go

if object_id('Reward_Levels_Config') is not null
	drop table dbo.Reward_Levels_Config;
go

if object_id('Punish_Levels_Config') is not null
	drop table dbo.Punish_Levels_Config;
go

if object_id('DB_Teacher') is not null
	drop table dbo.DB_Teacher;
go

-- 创建并填充数据表
create table dbo.school
(
	schoolNO nchar(10),
	schoolName nchar(10),
	primary key(schoolNO)
);
insert into dbo.school(schoolNO,schoolName) values('0000001',N'武汉科技大学');


create table dbo.Student
(
	StuNo        char(6)     not null,
	StuName      nchar(20) not null,
	StuPass_Word      nchar(20) not null,
	Sex          char(1)     not null,
	ClassId      char(6)     null,
	Birthday     date        null,
	Native_Place nchar(50) null,
	School       nchar(10) null
);

insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS001',N'邹明','123321', 'M','CS1401','1995-10-11',N'湖北武汉');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS002',N'刘华博','123321','M','CS1401','1995-07-07',N'北京');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS003',N'邱泽','123321',  'F','CS1402','1994-10-15',N'上海');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT001',N'范举','123321',  'M','CT1401','1995-02-13',N'广东广州');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT002',N'柯欣航','123321','F','CT1402','1994-12-29',N'湖北武汉');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT003',N'杜晋','123321',  'M','CT1402','1995-07-11',N'湖北武汉');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE001',N'郑绍远','123321','M','SE1401','1995-08-11',N'湖北荆州');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE002',N'朱光康','123321','M','SE1401','1994-12-27',N'江苏南京');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE003',N'邹文', '123321', 'M','SE1401','1994-11-25',N'浙江杭州');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SNT001',N'曹景', '123321', 'F','NT1401','1995-03-22',N'安徽合肥');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SNS001',N'汤光熙','123321','F','NS1401','1995-05-28',N'四川成都');

create table dbo.DB_Teacher
(
T_No         nchar(20)  not null,
T_Name       nchar(20)  not null,
T_Pass_Word  nchar(20)  not null
);
insert into dbo.DB_Teacher values('201413137115',N'李哲','123321');

create table dbo.Change
(
	Change_Id           nchar(8) not null,
	StuNo               char(6)           not null,
	Change_Code         char(5)           not null,
	Create_Date         SmallDateTime              not null,
	Change_Descriptions nchar(4000)     null
);
insert into dbo.Change(Change_Id,StuNo,Change_Code,Create_Date,Change_Descriptions) values('00000001','SCT001','C0002',GETDATE(),N'由于想开创自己的事业，休学一年');

create table dbo.Reward
(
	Reward_Id           nchar(8) not null,
	StuNo               char(6)           not null,
	Reward_Code         char(5)           not null,
	Create_Date         SmallDateTime              not null,
	Reward_Descriptions nchar(4000)     null,
	ReWard_Condition    int
);

insert into dbo.Reward(Reward_Id,StuNo,Reward_Code,Create_Date,Reward_Descriptions,ReWard_Condition)values('00000001','SCS001','R0001',GETDATE(),N'成绩优异，获得校特等奖',0);
insert into dbo.Reward(Reward_Id,StuNo,Reward_Code,Create_Date,Reward_Descriptions,ReWard_Condition)values('00000002','SSE002','R0002',GETDATE(),N'成绩优异，获得校一等奖',1);

create table dbo.Punishment
(
	Punishment_Id           nchar(8) not null,
	StuNo                   char(6)           not null,
	Punishment_Code         char(5)           not null,
	Create_Date             SmallDateTime              not null,
	Punishment_Enable       nchar(1)           not null,
	Punishment_Descriptions nchar(4000)     null
);

insert into dbo.Punishment(Punishment_Id,StuNo,Punishment_Code,Create_Date,Punishment_Enable,Punishment_Descriptions) values('00000001','SNT001','P0002',GETDATE(),'Y',N'在校期间，犯严重错误，记大过');
create table dbo.Department
(
	Department_Id   char(3)     not null,
	Department_Name nchar(50) not null
);

insert into dbo.Department(Department_Id,Department_Name) values('DCS',N'计算机科学系');
insert into dbo.Department(Department_Id,Department_Name) values('DCT',N'计算机技术系');
insert into dbo.Department(Department_Id,Department_Name) values('DSE',N'软件工程系');
insert into dbo.Department(Department_Id,Department_Name) values('DNT',N'网络工程系');
insert into dbo.Department(Department_Id,Department_Name) values('DNS',N'信息安全系');

create table dbo.Classes
(
	Class_Id      char(6)     not null,
	Class_Name    nchar(50) not null,
	Class_Monitor char(6)     not null,
	Department_Id char(3)     not null
);

insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CS1401',N'计算机科学14级1班','SCS001','DCS');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CS1402',N'计算机科学14级2班','SCS003','DCS');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CT1401',N'计算机技术14级1班','SCT001','DCT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CT1402',N'计算机技术14级2班','SCT002','DCT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('SE1401',N'软件工程14级1班','SSE003','DSE');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('NT1401',N'网络工程14级1班','SNT001','DNT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('NS1401',N'信息安全14级1班','SNS001','DNS');

create table dbo.Change_Config
(
	Change_Code         char(5)     not null,
	Change_Descriptions nchar(50) null
);
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0001',N'转系');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0002',N'休学');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0003',N'复学');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0004',N'退学');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0005',N'毕业');

create table dbo.Reward_Levels_Config
(
	Reward_Code         char(5)     not null,
	Reward_Descriptions nchar(50) null
);
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0001',N'校特等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0002',N'校一等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0003',N'校二等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0004',N'校三等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0005',N'系一等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0006',N'系二等奖学金');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0007',N'系三等奖学金');

create table dbo.Punish_Levels_Config
(
	Punish_Code         char(5)     not null,
	Punish_Descriptions nchar(50) null
);
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0001',N'警告');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0002',N'严重警告');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0003',N'记过');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0004',N'记大过');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0005',N'开除');


-- 增加主键约束

alter table dbo.Student              add constraint pk_StuNo         primary key(StuNo);
alter table dbo.DB_Teacher           add constraint pk_T_Name        primary key(T_No);
alter table dbo.Change               add constraint pk_Change_Id     primary key(Change_Id);
alter table dbo.Reward               add constraint pk_Reward_Id     primary key(Reward_Id);
alter table dbo.Punishment           add constraint pk_Punishment_Id primary key(Punishment_Id);
alter table dbo.Department           add constraint pk_Department_Id primary key(Department_Id);
alter table dbo.Classes              add constraint pk_Class_Id      primary key(Class_Id);
alter table dbo.Change_Config        add constraint pk_change_config primary key(Change_Code);
alter table dbo.Reward_Levels_Config add constraint pk_reward_config primary key(Reward_Code);
alter table dbo.Punish_Levels_Config add constraint pk_punish_config primary key(Punish_Code);


-- 增加外键约束
alter table dbo.Change add constraint fk_Change_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Change add constraint fk_Change_Change_Code foreign key (Change_Code) references dbo.Change_Config(Change_Code);

alter table dbo.Reward add constraint fk_Reward_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Reward add constraint fk_Reward_Reward_Code foreign key (Reward_Code) references dbo.Reward_Levels_Config(Reward_Code);

alter table dbo.Punishment add constraint fk_Punishment_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Punishment add constraint fk_Punishment_Punishment_Code foreign key (Punishment_Code) references dbo.Punish_Levels_Config(Punish_Code);

alter table dbo.Classes add constraint fk_Classes_Class_Monitor foreign key (Class_Monitor) references dbo.Student(StuNo);
alter table dbo.Classes add constraint fk_Classes_Department_Id foreign key (Department_Id) references dbo.Department(Department_Id);


