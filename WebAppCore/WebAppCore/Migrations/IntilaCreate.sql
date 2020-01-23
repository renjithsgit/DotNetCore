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

