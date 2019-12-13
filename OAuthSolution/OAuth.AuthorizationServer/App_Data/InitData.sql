Create Table T_User
(
	Id varchar(36) primary key not null comment '主键',
    UserName varchar(64) not null comment '用户名',
    Password varchar(128) not null comment '密码'
);

Create Table Credentials
(
	Id varchar(36) primary key not null comment '主键',
    ClientId varchar(64) not null comment '客户端id',
    ClientSecret varchar(64) not null comment '客户密钥',
    GrantTypeMode varchar(64) not null comment '授予类型'
);