USE [Bazaver2]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CategoriaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Colors]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallesVentas]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVentas](
	[DetallesVentaId] [int] IDENTITY(1,1) NOT NULL,
	[VentaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[ColorId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.DetallesVentas] PRIMARY KEY CLUSTERED 
(
	[DetallesVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallesVentaTMPs]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVentaTMPs](
	[DetallesVentaTmpId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [float] NOT NULL,
	[ColorId] [int] NOT NULL DEFAULT ((0)),
	[CartId] [uniqueidentifier] NOT NULL DEFAULT ('00000000-0000-0000-0000-000000000000'),
 CONSTRAINT [PK_dbo.DetallesVentaTMPs] PRIMARY KEY CLUSTERED 
(
	[DetallesVentaTmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormaDePagoes]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaDePagoes](
	[FormaDePagoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.FormaDePagoes] PRIMARY KEY CLUSTERED 
(
	[FormaDePagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[ProductoId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[Stock] [float] NOT NULL,
	[InventarioId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Inventarios] PRIMARY KEY CLUSTERED 
(
	[InventarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localidads]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidads](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Localidads] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[PrecioMin] [decimal](18, 2) NOT NULL,
	[PrecioMay] [decimal](18, 2) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Codigo] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Productos] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 20/11/2020 11:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](50) NOT NULL,
	[ApellidoCliente] [nvarchar](50) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Comentarios] [nvarchar](max) NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](max) NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Ventas] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd36e1859-3d48-4145-b6b3-d6f50aaa1b7a', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c98106e3-7048-4842-9f93-7d793bd64fb7', N'Customer')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd6691767-6eb8-42f9-8685-1f391690ab31', N'Mayorista')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fe39043a-62b0-453d-80bc-bec2dec7f87a', N'Supplier')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0f21584-54bb-4ded-bb31-2839f87ee6dd', N'User')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ab0ca9b-c9ae-4bbe-8a1e-ce7ad7a8d22a', N'd36e1859-3d48-4145-b6b3-d6f50aaa1b7a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'23ad921f-9eb6-4f62-9499-14516679c9ff', N'd6691767-6eb8-42f9-8685-1f391690ab31')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6b11fe23-4071-40bf-9f1e-c7e18b305358', N'd6691767-6eb8-42f9-8685-1f391690ab31')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'23ad921f-9eb6-4f62-9499-14516679c9ff', N'mayorist@a.a', 0, N'AB1v2iLv9EDUXrx8pqtsPl/AKM3MZhUOUYPiHD/cgeECIDyxWzP/691GRfPxj2IEug==', N'e5a71883-eb29-4dda-a27a-c76e4799f265', NULL, 0, 0, NULL, 0, 0, N'mayorist@a.a')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ab0ca9b-c9ae-4bbe-8a1e-ce7ad7a8d22a', N'admin@a.a', 0, N'AGLoLroDaQHYYdA7zeB2EW7BoHNYVmf3X6zGgLj6/okn0o8v7XzbhQn0Tdh1rCcbew==', N'4df72130-81b6-497e-a32e-d79278c85932', NULL, 0, 0, NULL, 1, 0, N'admin@a.a')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6b11fe23-4071-40bf-9f1e-c7e18b305358', N'mayorist@a.com', 0, N'AIhuoWI+pZJMUx18TFVDPPqUnD0HHpv2VC6tWIo1o8SJm9paEF/SZq2ID8uWfmepaQ==', N'f63891c4-21c6-48c6-8e99-cae66c6888ec', NULL, 0, 0, NULL, 0, 0, N'Mayorista')
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([CategoriaId], [Descripcion]) VALUES (11, N'Mate')
INSERT [dbo].[Categorias] ([CategoriaId], [Descripcion]) VALUES (12, N'Pato')
INSERT [dbo].[Categorias] ([CategoriaId], [Descripcion]) VALUES (10, N'Utensilios')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [Nombre]) VALUES (24, N'Amarillo')
INSERT [dbo].[Colors] ([ColorId], [Nombre]) VALUES (22, N'Azul')
INSERT [dbo].[Colors] ([ColorId], [Nombre]) VALUES (21, N'Rojo')
INSERT [dbo].[Colors] ([ColorId], [Nombre]) VALUES (23, N'Verde')
SET IDENTITY_INSERT [dbo].[Colors] OFF
SET IDENTITY_INSERT [dbo].[DetallesVentas] ON 

INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (2, 1041, 1029, N'Pisapapas', CAST(90.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (3, 1042, 1029, N'Pisapapas', CAST(100.00 AS Decimal(18, 2)), 2, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (4, 1042, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (5, 1042, 1029, N'Pisapapas', CAST(100.00 AS Decimal(18, 2)), 1, 23)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1003, 2042, 1030, N'Abrelatas', CAST(90.00 AS Decimal(18, 2)), 2, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1004, 2043, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 2, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1005, 2044, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1006, 2045, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1007, 2045, 1029, N'Pisapapas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1008, 2046, 1029, N'Pisapapas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1009, 2046, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1010, 2047, 1030, N'Abrelatas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1011, 2047, 1029, N'Pisapapas', CAST(100.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1012, 2048, 1030, N'Abrelatas', CAST(90.00 AS Decimal(18, 2)), 1, 21)
INSERT [dbo].[DetallesVentas] ([DetallesVentaId], [VentaId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId]) VALUES (1013, 2049, 1029, N'Pisapapas', CAST(90.00 AS Decimal(18, 2)), 1, 21)
SET IDENTITY_INSERT [dbo].[DetallesVentas] OFF
SET IDENTITY_INSERT [dbo].[DetallesVentaTMPs] ON 

INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (5, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'202837b5-b3ba-4f25-af6b-bf46403a401c')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (6, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'202837b5-b3ba-4f25-af6b-bf46403a401c')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (7, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 2, 21, N'bf48cd6c-0ce8-4344-8157-11badcc9874e')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (8, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'bf48cd6c-0ce8-4344-8157-11badcc9874e')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (9, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 3, 21, N'9a47c5a0-4dfb-4116-84e5-56b55132cde3')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (10, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'9a47c5a0-4dfb-4116-84e5-56b55132cde3')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (11, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'916c2527-7a1b-44d0-b119-bfa6cdde7b13')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (12, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 2, 21, N'550d0d0a-8578-41ab-88df-bfa35ef1f359')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (13, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'550d0d0a-8578-41ab-88df-bfa35ef1f359')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (14, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'92e4698d-96dd-440b-b301-8ffb90205be9')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (15, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'92e4698d-96dd-440b-b301-8ffb90205be9')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (18, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'189de7b4-7d29-4b32-aa58-ef34e78d72fb')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (19, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'189de7b4-7d29-4b32-aa58-ef34e78d72fb')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (20, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'875e232b-1f0d-493d-a346-bc0b03b1a52a')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (21, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'875e232b-1f0d-493d-a346-bc0b03b1a52a')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (25, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'615dbbc9-72d5-4a93-a52e-970494d36605')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (28, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'07fb331b-354e-4e89-b796-642e1282edea')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (1996, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 2, 21, N'90ec6aa6-9502-4e2d-bc21-1b60efe69346')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (1997, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 3, 21, N'90ec6aa6-9502-4e2d-bc21-1b60efe69346')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (1998, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 2, 21, N'b69299a8-9f81-4428-a60e-53e699409fc3')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (1999, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 2, 21, N'b69299a8-9f81-4428-a60e-53e699409fc3')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2005, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'bb1c6366-18f9-482d-b519-8fcee5e00234')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2010, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'2b03c729-e6cd-474c-a788-b8ad192ff3da')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2011, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'2b03c729-e6cd-474c-a788-b8ad192ff3da')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2013, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'c3a0dac0-8950-497f-aec8-b59d189b4742')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2014, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'c3a0dac0-8950-497f-aec8-b59d189b4742')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2017, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'090798cb-0305-4738-8c44-70f4a9544949')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2018, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'090798cb-0305-4738-8c44-70f4a9544949')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2023, 1030, N'Abrelatas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'7f705dc5-ead3-4089-b222-7245ec83d0f2')
INSERT [dbo].[DetallesVentaTMPs] ([DetallesVentaTmpId], [ProductoId], [Descripcion], [Precio], [Cantidad], [ColorId], [CartId]) VALUES (2024, 1029, N'Pisapapas', CAST(0.00 AS Decimal(18, 2)), 1, 21, N'7f705dc5-ead3-4089-b222-7245ec83d0f2')
SET IDENTITY_INSERT [dbo].[DetallesVentaTMPs] OFF
SET IDENTITY_INSERT [dbo].[Inventarios] ON 

INSERT [dbo].[Inventarios] ([ProductoId], [ColorId], [Stock], [InventarioId]) VALUES (1029, 21, 12, 1)
INSERT [dbo].[Inventarios] ([ProductoId], [ColorId], [Stock], [InventarioId]) VALUES (1029, 23, 19, 2)
INSERT [dbo].[Inventarios] ([ProductoId], [ColorId], [Stock], [InventarioId]) VALUES (1030, 22, 7, 4)
INSERT [dbo].[Inventarios] ([ProductoId], [ColorId], [Stock], [InventarioId]) VALUES (1030, 21, 24, 5)
SET IDENTITY_INSERT [dbo].[Inventarios] OFF
SET IDENTITY_INSERT [dbo].[Localidads] ON 

INSERT [dbo].[Localidads] ([LocalidadId], [Name], [ProvinciaId]) VALUES (1, N'Lobos', 1)
INSERT [dbo].[Localidads] ([LocalidadId], [Name], [ProvinciaId]) VALUES (2, N'Navarro', 1)
INSERT [dbo].[Localidads] ([LocalidadId], [Name], [ProvinciaId]) VALUES (3, N'Roque Perez', 1)
SET IDENTITY_INSERT [dbo].[Localidads] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ProductoId], [Descripcion], [CategoriaId], [PrecioMin], [PrecioMay], [Image], [Codigo]) VALUES (1029, N'Pisapapas', 10, CAST(100.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), N'~/Content/Images/1029.jpg', NULL)
INSERT [dbo].[Productos] ([ProductoId], [Descripcion], [CategoriaId], [PrecioMin], [PrecioMay], [Image], [Codigo]) VALUES (1030, N'Abrelatas', 10, CAST(100.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), N'~/Content/Images/1030.jpg', NULL)
INSERT [dbo].[Productos] ([ProductoId], [Descripcion], [CategoriaId], [PrecioMin], [PrecioMay], [Image], [Codigo]) VALUES (1031, N'Abrelatas', 10, CAST(80.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaId], [Nombre]) VALUES (1, N'Buenos Aires')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (1041, N'bauasd', N'aSDAS', 1, N'asdasd', N'asdd', N'sdadsa', N'dsadads', CAST(N'2020-10-14 00:00:00.000' AS DateTime), N'Entregado')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (1042, N'asdas', N'asdasd', 1, N'asdasd', N'asdasd', N'asdasd', N'asdasd', CAST(N'2020-10-21 00:00:00.000' AS DateTime), N'Entregado')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2042, N'test', N'test', 1, N'test', N'test', N'test', N'test', CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2043, N'asd', N'asd', 1, N'asdasd', N'asd', N'sadas', N'asdasd', CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2044, N'assad', N'sadsad', 1, N'saasd', N'sasasd', N'saddas', N'asdasd', CAST(N'2020-11-04 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2045, N'asdasd', N'sdaads', 1, N'addas', N'sdasda', N'dsasd', N'dsadsa', CAST(N'2020-11-05 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2046, N'asddas', N'dassda', 1, N'sdadas', N'daasd', N'dassda', N'saddsa', CAST(N'2020-11-05 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2047, N'Bautest', N'ApellidoTest', 1, N'DirecTest', N'ComentTest', N'222744444', N'test@test.com', CAST(N'2020-11-08 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2048, N' Bautista', N'González Carpani', 1, N'Manuel Caminos 654', N'Portón Negro', N'2227440806', N'bauti.gonzalezc@hotmail.com', CAST(N'2020-11-08 00:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Ventas] ([VentaId], [NombreCliente], [ApellidoCliente], [LocalidadId], [Direccion], [Comentarios], [Telefono], [Correo], [Fecha], [Estado]) VALUES (2049, N'asd', N'asd', 1, N'asd', N'asd', N'asd', N'asd', CAST(N'2020-11-08 00:00:00.000' AS DateTime), N'Pendiente')
SET IDENTITY_INSERT [dbo].[Ventas] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DetallesVentas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallesVentas_dbo.Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
GO
ALTER TABLE [dbo].[DetallesVentas] CHECK CONSTRAINT [FK_dbo.DetallesVentas_dbo.Colors_ColorId]
GO
ALTER TABLE [dbo].[DetallesVentas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallesVentas_dbo.Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesVentas] CHECK CONSTRAINT [FK_dbo.DetallesVentas_dbo.Productos_ProductoId]
GO
ALTER TABLE [dbo].[DetallesVentas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallesVentas_dbo.Ventas_VentaId] FOREIGN KEY([VentaId])
REFERENCES [dbo].[Ventas] ([VentaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesVentas] CHECK CONSTRAINT [FK_dbo.DetallesVentas_dbo.Ventas_VentaId]
GO
ALTER TABLE [dbo].[DetallesVentaTMPs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallesVentaTMPs_dbo.Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesVentaTMPs] CHECK CONSTRAINT [FK_dbo.DetallesVentaTMPs_dbo.Colors_ColorId]
GO
ALTER TABLE [dbo].[DetallesVentaTMPs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetallesVentaTMPs_dbo.Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesVentaTMPs] CHECK CONSTRAINT [FK_dbo.DetallesVentaTMPs_dbo.Productos_ProductoId]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inventarios_dbo.Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_dbo.Inventarios_dbo.Colors_ColorId]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inventarios_dbo.Productos_ProductoId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([ProductoId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_dbo.Inventarios_dbo.Productos_ProductoId]
GO
ALTER TABLE [dbo].[Localidads]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Localidads_dbo.Provincias_ProvinciaId] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidads] CHECK CONSTRAINT [FK_dbo.Localidads_dbo.Provincias_ProvinciaId]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Productos_dbo.Categorias_CategoriaId] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categorias] ([CategoriaId])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_dbo.Productos_dbo.Categorias_CategoriaId]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Ventas_dbo.Localidads_LocalidadId] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidads] ([LocalidadId])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_dbo.Ventas_dbo.Localidads_LocalidadId]
GO
