ALTER TABLE [Employee] ADD [emp_email] nvarchar(20) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200122232809_AddedEmailAgain', N'3.1.1');

GO

