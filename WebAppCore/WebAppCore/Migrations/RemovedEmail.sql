IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Department] (
    [dept_id] int NOT NULL,
    [dept_name] varchar(20) NULL,
    CONSTRAINT [PK__Departme__DCA6597455DFCF34] PRIMARY KEY ([dept_id])
);

GO

CREATE TABLE [Employee] (
    [emp_id] int NOT NULL,
    [dept_id] int NULL,
    [mngr_id] int NULL,
    [emp_name] varchar(20) NULL,
    [salary] int NULL,
    CONSTRAINT [PK__Employee__1299A86160218078] PRIMARY KEY ([emp_id]),
    CONSTRAINT [FK__Employee__dept_i__286302EC] FOREIGN KEY ([dept_id]) REFERENCES [Department] ([dept_id]) ON DELETE NO ACTION,
    CONSTRAINT [FK__Employee__mngr_i__276EDEB3] FOREIGN KEY ([mngr_id]) REFERENCES [Employee] ([emp_id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Employee_dept_id] ON [Employee] ([dept_id]);

GO

CREATE INDEX [IX_Employee_mngr_id] ON [Employee] ([mngr_id]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200121135157_InitialCreate', N'3.1.1');

GO

ALTER TABLE [Employee] ADD [emp_email] nvarchar(20) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200121135636_AddedEmail', N'3.1.1');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'emp_email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Employee] DROP COLUMN [emp_email];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200121140213_RemovedEmail', N'3.1.1');

GO

