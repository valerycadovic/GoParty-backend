CREATE TABLE [dbo].[Events] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    [Address] [nvarchar](max) NOT NULL,
    [Comment] [nvarchar](max),
    [CreatedOn] [datetime] NOT NULL,
    [ModifiedOn] [datetime] NOT NULL,
    [StartTime] [datetime] NOT NULL,
    [CityId] [int] NOT NULL,
    [CreatedById] [uniqueidentifier] NOT NULL,
    [ModifiedById] [uniqueidentifier] NOT NULL,
    [StatusId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Events] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Users] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Login] [nvarchar](max) NOT NULL,
    [Password] [nvarchar](max) NOT NULL,
    [CityId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Contacts] (
    [Id] [uniqueidentifier] NOT NULL,
    [Value] [nvarchar](max) NOT NULL,
    [ContactTypeId] [int] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[ContactTypes] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.ContactTypes] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[UserImages] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [UserId] [uniqueidentifier],
    CONSTRAINT [PK_dbo.UserImages] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Roles] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Permissions] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Permissions] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[EventImages] (
    [Id] [uniqueidentifier] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.EventImages] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[EventStatuses] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.EventStatuses] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Tags] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.Tags] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[RolePermissions] (
    [RoleId] [int] NOT NULL,
    [PermissionId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RolePermissions] PRIMARY KEY ([RoleId], [PermissionId])
)
CREATE TABLE [dbo].[UserRoles] (
    [UserId] [uniqueidentifier] NOT NULL,
    [RoleId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY ([UserId], [RoleId])
)
CREATE TABLE [dbo].[EventTags] (
    [EventId] [uniqueidentifier] NOT NULL,
    [TagId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.EventTags] PRIMARY KEY ([EventId], [TagId])
)
CREATE INDEX [IX_City_Id] ON [dbo].[Events]([CityId])
CREATE INDEX [IX_CreatedBy_Id] ON [dbo].[Events]([CreatedById])
CREATE INDEX [IX_ModifiedBy_Id] ON [dbo].[Events]([ModifiedById])
CREATE INDEX [IX_Status_Id] ON [dbo].[Events]([StatusId])
CREATE INDEX [IX_City_Id] ON [dbo].[Users]([CityId])
CREATE INDEX [IX_ContactType_Id] ON [dbo].[Contacts]([ContactTypeId])
CREATE INDEX [IX_User_Id] ON [dbo].[Contacts]([UserId])
CREATE INDEX [IX_User_Id] ON [dbo].[UserImages]([UserId])
CREATE INDEX [IX_Id] ON [dbo].[EventImages]([Id])
CREATE INDEX [IX_Role_Id] ON [dbo].[RolePermissions]([RoleId])
CREATE INDEX [IX_Permission_Id] ON [dbo].[RolePermissions]([PermissionId])
CREATE INDEX [IX_User_Id] ON [dbo].[UserRoles]([UserId])
CREATE INDEX [IX_Role_Id] ON [dbo].[UserRoles]([RoleId])
CREATE INDEX [IX_Event_Id] ON [dbo].[EventTags]([EventId])
CREATE INDEX [IX_Tag_Id] ON [dbo].[EventTags]([TagId])
ALTER TABLE [dbo].[Events] ADD CONSTRAINT [FK_dbo.Events_dbo.Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Events] ADD CONSTRAINT [FK_dbo.Events_dbo.Users_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [dbo].[Users] ([Id])
ALTER TABLE [dbo].[Events] ADD CONSTRAINT [FK_dbo.Events_dbo.Users_ModifiedById] FOREIGN KEY ([ModifiedById]) REFERENCES [dbo].[Users] ([Id])
ALTER TABLE [dbo].[Events] ADD CONSTRAINT [FK_dbo.Events_dbo.EventStatuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[EventStatuses] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_dbo.Users_dbo.Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [dbo].[Cities] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Contacts] ADD CONSTRAINT [FK_dbo.Contacts_dbo.ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactTypes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Contacts] ADD CONSTRAINT [FK_dbo.Contacts_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[UserImages] ADD CONSTRAINT [FK_dbo.UserImages_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
ALTER TABLE [dbo].[EventImages] ADD CONSTRAINT [FK_dbo.EventImages_dbo.Events_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Events] ([Id])
ALTER TABLE [dbo].[RolePermissions] ADD CONSTRAINT [FK_dbo.RolePermissions_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[RolePermissions] ADD CONSTRAINT [FK_dbo.RolePermissions_dbo.Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permissions] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[UserRoles] ADD CONSTRAINT [FK_dbo.UserRoles_dbo.Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[UserRoles] ADD CONSTRAINT [FK_dbo.UserRoles_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EventTags] ADD CONSTRAINT [FK_dbo.EventTags_dbo.Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EventTags] ADD CONSTRAINT [FK_dbo.EventTags_dbo.Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id]) ON DELETE CASCADE
