create table [dbo].[Logs]
(
	[Id] uniqueidentifier default newid() primary key,
	[ErrorTime] datetime not null,
	[Level] nvarchar(10) not null,
	[Message] nvarchar(1000),
	[Username] nvarchar(100),
	[ExceptionType] nvarchar(100),
	[StackTrace] nvarchar(max)
)