set nocount on;
use master;
go

if db_id('StuMgt') is null
	create database StuMgt;
go

use StuMgt;
go

-- ������ݱ��������ɾ��
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

-- ������������ݱ�
create table dbo.school
(
	schoolNO nchar(10),
	schoolName nchar(10),
	primary key(schoolNO)
);
insert into dbo.school(schoolNO,schoolName) values('0000001',N'�人�Ƽ���ѧ');


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

insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS001',N'����','123321', 'M','CS1401','1995-10-11',N'�����人');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS002',N'������','123321','M','CS1401','1995-07-07',N'����');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCS003',N'����','123321',  'F','CS1402','1994-10-15',N'�Ϻ�');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT001',N'����','123321',  'M','CT1401','1995-02-13',N'�㶫����');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT002',N'������','123321','F','CT1402','1994-12-29',N'�����人');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SCT003',N'�Ž�','123321',  'M','CT1402','1995-07-11',N'�����人');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE001',N'֣��Զ','123321','M','SE1401','1995-08-11',N'��������');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE002',N'��⿵','123321','M','SE1401','1994-12-27',N'�����Ͼ�');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SSE003',N'����', '123321', 'M','SE1401','1994-11-25',N'�㽭����');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SNT001',N'�ܾ�', '123321', 'F','NT1401','1995-03-22',N'���պϷ�');
insert into dbo.Student(StuNo,StuName,StuPass_Word,Sex,ClassId,Birthday,Native_Place) values('SNS001',N'������','123321','F','NS1401','1995-05-28',N'�Ĵ��ɶ�');

create table dbo.DB_Teacher
(
T_No         nchar(20)  not null,
T_Name       nchar(20)  not null,
T_Pass_Word  nchar(20)  not null
);
insert into dbo.DB_Teacher values('201413137115',N'����','123321');

create table dbo.Change
(
	Change_Id           nchar(8) not null,
	StuNo               char(6)           not null,
	Change_Code         char(5)           not null,
	Create_Date         SmallDateTime              not null,
	Change_Descriptions nchar(4000)     null
);
insert into dbo.Change(Change_Id,StuNo,Change_Code,Create_Date,Change_Descriptions) values('00000001','SCT001','C0002',GETDATE(),N'�����뿪���Լ�����ҵ����ѧһ��');

create table dbo.Reward
(
	Reward_Id           nchar(8) not null,
	StuNo               char(6)           not null,
	Reward_Code         char(5)           not null,
	Create_Date         SmallDateTime              not null,
	Reward_Descriptions nchar(4000)     null,
	ReWard_Condition    int
);

insert into dbo.Reward(Reward_Id,StuNo,Reward_Code,Create_Date,Reward_Descriptions,ReWard_Condition)values('00000001','SCS001','R0001',GETDATE(),N'�ɼ����죬���У�صȽ�',0);
insert into dbo.Reward(Reward_Id,StuNo,Reward_Code,Create_Date,Reward_Descriptions,ReWard_Condition)values('00000002','SSE002','R0002',GETDATE(),N'�ɼ����죬���Уһ�Ƚ�',1);

create table dbo.Punishment
(
	Punishment_Id           nchar(8) not null,
	StuNo                   char(6)           not null,
	Punishment_Code         char(5)           not null,
	Create_Date             SmallDateTime              not null,
	Punishment_Enable       nchar(1)           not null,
	Punishment_Descriptions nchar(4000)     null
);

insert into dbo.Punishment(Punishment_Id,StuNo,Punishment_Code,Create_Date,Punishment_Enable,Punishment_Descriptions) values('00000001','SNT001','P0002',GETDATE(),'Y',N'��У�ڼ䣬�����ش��󣬼Ǵ��');
create table dbo.Department
(
	Department_Id   char(3)     not null,
	Department_Name nchar(50) not null
);

insert into dbo.Department(Department_Id,Department_Name) values('DCS',N'�������ѧϵ');
insert into dbo.Department(Department_Id,Department_Name) values('DCT',N'���������ϵ');
insert into dbo.Department(Department_Id,Department_Name) values('DSE',N'�������ϵ');
insert into dbo.Department(Department_Id,Department_Name) values('DNT',N'���繤��ϵ');
insert into dbo.Department(Department_Id,Department_Name) values('DNS',N'��Ϣ��ȫϵ');

create table dbo.Classes
(
	Class_Id      char(6)     not null,
	Class_Name    nchar(50) not null,
	Class_Monitor char(6)     not null,
	Department_Id char(3)     not null
);

insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CS1401',N'�������ѧ14��1��','SCS001','DCS');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CS1402',N'�������ѧ14��2��','SCS003','DCS');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CT1401',N'���������14��1��','SCT001','DCT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('CT1402',N'���������14��2��','SCT002','DCT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('SE1401',N'�������14��1��','SSE003','DSE');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('NT1401',N'���繤��14��1��','SNT001','DNT');
insert into dbo.Classes(Class_Id,Class_Name,Class_Monitor,Department_Id) values('NS1401',N'��Ϣ��ȫ14��1��','SNS001','DNS');

create table dbo.Change_Config
(
	Change_Code         char(5)     not null,
	Change_Descriptions nchar(50) null
);
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0001',N'תϵ');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0002',N'��ѧ');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0003',N'��ѧ');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0004',N'��ѧ');
insert into dbo.Change_Config(Change_Code,Change_Descriptions) values('C0005',N'��ҵ');

create table dbo.Reward_Levels_Config
(
	Reward_Code         char(5)     not null,
	Reward_Descriptions nchar(50) null
);
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0001',N'У�صȽ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0002',N'Уһ�Ƚ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0003',N'У���Ƚ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0004',N'У���Ƚ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0005',N'ϵһ�Ƚ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0006',N'ϵ���Ƚ�ѧ��');
insert into dbo.Reward_Levels_Config(Reward_Code,Reward_Descriptions) values('R0007',N'ϵ���Ƚ�ѧ��');

create table dbo.Punish_Levels_Config
(
	Punish_Code         char(5)     not null,
	Punish_Descriptions nchar(50) null
);
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0001',N'����');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0002',N'���ؾ���');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0003',N'�ǹ�');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0004',N'�Ǵ��');
insert into dbo.Punish_Levels_Config(Punish_Code,Punish_Descriptions) values('P0005',N'����');


-- ��������Լ��

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


-- �������Լ��
alter table dbo.Change add constraint fk_Change_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Change add constraint fk_Change_Change_Code foreign key (Change_Code) references dbo.Change_Config(Change_Code);

alter table dbo.Reward add constraint fk_Reward_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Reward add constraint fk_Reward_Reward_Code foreign key (Reward_Code) references dbo.Reward_Levels_Config(Reward_Code);

alter table dbo.Punishment add constraint fk_Punishment_StuNo foreign key (StuNo) references dbo.Student(StuNo);
alter table dbo.Punishment add constraint fk_Punishment_Punishment_Code foreign key (Punishment_Code) references dbo.Punish_Levels_Config(Punish_Code);

alter table dbo.Classes add constraint fk_Classes_Class_Monitor foreign key (Class_Monitor) references dbo.Student(StuNo);
alter table dbo.Classes add constraint fk_Classes_Department_Id foreign key (Department_Id) references dbo.Department(Department_Id);


