IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    CREATE TABLE [Carrito] (
        [Id] int NOT NULL IDENTITY,
        [ProductoId] int NOT NULL,
        [Correo] nvarchar(max) NOT NULL,
        [Cantidad] int NOT NULL,
        CONSTRAINT [PK_Carrito] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    CREATE TABLE [Direccion] (
        [Id] int NOT NULL IDENTITY,
        [Correo] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Calle] nvarchar(max) NOT NULL,
        [NumExt] nvarchar(max) NOT NULL,
        [NumInt] nvarchar(max) NOT NULL,
        [Telefono] nvarchar(max) NOT NULL,
        [Alcaldia] nvarchar(max) NOT NULL,
        [Colonia] nvarchar(max) NOT NULL,
        [CP] nvarchar(max) NOT NULL,
        [Check] bit NOT NULL,
        CONSTRAINT [PK_Direccion] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    CREATE TABLE [imagenesProductos] (
        [Id] int NOT NULL IDENTITY,
        [ProductoId] int NOT NULL,
        [DireccionImage] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_imagenesProductos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    CREATE TABLE [Producto] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        [Categoria] nvarchar(max) NOT NULL,
        [Sexo] nvarchar(max) NOT NULL,
        [Talla] nvarchar(max) NOT NULL,
        [Color] nvarchar(max) NOT NULL,
        [Precio] nvarchar(max) NOT NULL,
        [Existencia] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Producto] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    CREATE TABLE [Usuario] (
        [Correo] nvarchar(450) NOT NULL,
        [Contrasena] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Nivel] nvarchar(max) NOT NULL,
        [DireccionImagePerfil] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Correo])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602111622_inicio')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602111622_inicio', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602204722_inicio2')
BEGIN
    CREATE TABLE [Tarjeta] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Correo] nvarchar(max) NOT NULL,
        [NumTarjeta] nvarchar(max) NOT NULL,
        [FechaVen] nvarchar(max) NOT NULL,
        [CVV] nvarchar(max) NOT NULL,
        [Check] bit NOT NULL,
        CONSTRAINT [PK_Tarjeta] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230602204722_inicio2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230602204722_inicio2', N'7.0.5');
END;
GO

COMMIT;
GO

