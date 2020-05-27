IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Servicos] (
    [Id] uniqueidentifier NOT NULL,
    [Usuario] nvarchar(450) NOT NULL,
    [Titulo] nvarchar(100) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Servicos_Usuario] ON [Servicos] ([Usuario]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200509140135_CreateTableServico', N'3.1.3');

GO

