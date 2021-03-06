USE [master]
GO

CREATE DATABASE [ZonaGamer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZonaGamer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZonaGamer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZonaGamer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZonaGamer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ZonaGamer] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZonaGamer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZonaGamer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZonaGamer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZonaGamer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZonaGamer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZonaGamer] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZonaGamer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZonaGamer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZonaGamer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZonaGamer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZonaGamer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZonaGamer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZonaGamer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZonaGamer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZonaGamer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZonaGamer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZonaGamer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZonaGamer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZonaGamer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZonaGamer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZonaGamer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZonaGamer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZonaGamer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZonaGamer] SET RECOVERY FULL 
GO
ALTER DATABASE [ZonaGamer] SET  MULTI_USER 
GO
ALTER DATABASE [ZonaGamer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZonaGamer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZonaGamer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZonaGamer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ZonaGamer] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ZonaGamer', N'ON'
GO
ALTER DATABASE [ZonaGamer] SET QUERY_STORE = OFF
GO
USE [ZonaGamer]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](40) NULL,
	[Sexo] [nvarchar](1) NULL,
	[Fecha_nac] [date] NULL,
	[Tipo_documento] [nvarchar](20) NOT NULL,
	[Num_documento] [nvarchar](15) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ingreso](
	[idDetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idIngreso] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[Precio_Compra] [money] NOT NULL,
	[Precio_Venta] [money] NOT NULL,
	[Stock_inicial] [int] NOT NULL,
	[Stock_Actual] [int] NOT NULL,
	[Fecha_produccion] [date] NOT NULL,
 CONSTRAINT [PK_Detalle_Ingreso] PRIMARY KEY CLUSTERED 
(
	[idDetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Ventas]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ventas](
	[idDetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idVentas] [int] NOT NULL,
	[idDetalle_ingreso] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_Venta] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
 CONSTRAINT [PK_Detalle_Ventas] PRIMARY KEY CLUSTERED 
(
	[idDetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Apellido] [nvarchar](40) NOT NULL,
	[Sexo] [nvarchar](1) NOT NULL,
	[Fecha_nac] [date] NOT NULL,
	[Cedula] [nvarchar](15) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Acceso] [nvarchar](20) NOT NULL,
	[Usuario] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingreso](
	[idIngreso] [int] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[idProveedor] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Tipo_comprobante] [nvarchar](20) NOT NULL,
	[Serie] [nvarchar](5) NOT NULL,
	[Correlativo] [nvarchar](7) NOT NULL,
	[Igv] [decimal](4, 2) NULL,
	[Estado] [nvarchar](7) NOT NULL,
 CONSTRAINT [PK_Ingreso] PRIMARY KEY CLUSTERED 
(
	[idIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacion]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacion](
	[idPresentacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
 CONSTRAINT [PK_Presentacion] PRIMARY KEY CLUSTERED 
(
	[idPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[idCategoria] [int] NOT NULL,
	[idPresentacion] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Razon_social] [nvarchar](150) NOT NULL,
	[Tipo_documento] [nvarchar](20) NOT NULL,
	[Num_documento] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](10) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[idVentas] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Tipo_Comprobante] [nvarchar](20) NOT NULL,
	[Serie] [nvarchar](4) NOT NULL,
	[Correlativo] [nvarchar](7) NOT NULL,
	[Igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[idVentas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalle_Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ingreso_Ingreso] FOREIGN KEY([idIngreso])
REFERENCES [dbo].[Ingreso] ([idIngreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Ingreso] CHECK CONSTRAINT [FK_Detalle_Ingreso_Ingreso]
GO
ALTER TABLE [dbo].[Detalle_Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ingreso_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[Detalle_Ingreso] CHECK CONSTRAINT [FK_Detalle_Ingreso_Producto]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ventas_Detalle_Ingreso] FOREIGN KEY([idDetalle_ingreso])
REFERENCES [dbo].[Detalle_Ingreso] ([idDetalle_ingreso])
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_Detalle_Ventas_Detalle_Ingreso]
GO
ALTER TABLE [dbo].[Detalle_Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Ventas_Ventas] FOREIGN KEY([idVentas])
REFERENCES [dbo].[Ventas] ([idVentas])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Detalle_Ventas] CHECK CONSTRAINT [FK_Detalle_Ventas_Ventas]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Ingreso_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [FK_Ingreso_Empleado]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [FK_Ingreso_Proveedor] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[Proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [FK_Ingreso_Proveedor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Presentacion] FOREIGN KEY([idPresentacion])
REFERENCES [dbo].[Presentacion] ([idPresentacion])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Presentacion]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Cliente]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Empleado]
GO
/****** Object:  StoredProcedure [dbo].[spanular_ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spanular_ingreso]
@idIngreso int
as
update Ingreso set Estado='Anulado'
where idIngreso=@idIngreso
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_Categoria]
@textobuscar nvarchar(50)
as
select * from Categoria
where Nombre like @textobuscar + '%'  --Alt +39

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_apellido]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_apellido]
@textobuscar nvarchar(50)
as
select * from Cliente
where Apellido like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_num_documento]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_num_documento]
@textobuscar nvarchar(50)
as
select * from Cliente
where Num_documento like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_empleado_apellidos]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento  Buscar Trabajador Apellidos
create proc [dbo].[spbuscar_empleado_apellidos]
@textobuscar varchar(50)
as
SELECT * FROM Empleado
where Apellido like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_empleado_cedula]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento  Buscar Trababajador Num Documento
create proc [dbo].[spbuscar_empleado_cedula]
@textobuscar varchar(8)
as
SELECT * FROM Empleado
where Cedula like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_ingreso_fecha]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar nvarchar(20),
@textobuscar2 nvarchar(20)
as
select i.idIngreso,(t.Apellido+' '+t.Nombre) as Empleado,
p.Razon_social as Proveedor,i.Tipo_comprobante, 
i.Serie,i.Correlativo,i.Estado,
sum(d.Precio_Compra*d.Stock_inicial) as Total
from Detalle_Ingreso d inner join Ingreso i
on d.idIngreso=i.idIngreso
inner join Proveedor p
on i.idProveedor=p.idProveedor
inner join Empleado t
on i.idEmpleado=t.idEmpleado
group by
i.idIngreso,t.Apellido+' '+t.Nombre,p.Razon_social,i.Fecha,
i.Tipo_comprobante, i.Serie,i.Correlativo,i.Estado
having i.Fecha>=@textobuscar and i.Fecha<=@textobuscar2
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion_nombre]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_presentacion_nombre]
@textobuscar nvarchar(50)
as
select * from Presentacion
where Nombre like @textobuscar + '%'  

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_producto_nombre]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_producto_nombre]
@textobuscar nvarchar(50)
as
SELECT top  100 dbo.Producto.idProducto, dbo.Producto.Codigo, dbo.Producto.Nombre, 
dbo.Producto.Descripcion, dbo.Producto.idCategoria, 
dbo.Categoria.Nombre AS Categoria, dbo.Producto.idPresentacion, 
dbo.Presentacion.Nombre AS Presentacion
FROM            dbo.Producto INNER JOIN dbo.Categoria 
ON dbo.Producto.idCategoria = dbo.Categoria.idCategoria 
INNER JOIN dbo.Presentacion 
ON dbo.Producto.idPresentacion = dbo.Presentacion.idPresentacion
where dbo.Producto.Nombre like @textobuscar + '%'
order by dbo.Producto.idProducto desc

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar nvarchar(20)
as
select * from Proveedor
where Num_documento like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar nvarchar(150)
as
select * from Proveedor
where Razon_social like @textobuscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_venta_fecha]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_venta_fecha]
@textobuscar nvarchar(50),
@textobuscar2 nvarchar(50)
as
select v.idVentas,
(t.Apellido+' '+t.Nombre) as Empleado,
(c.Apellido+' '+c.Nombre) as Cliente,
v.Fecha,v.Tipo_comprobante,v.Serie,v.Correlativo,
sum((d.Cantidad*d.Precio_Venta)-d.Descuento) as Total
from Detalle_Ventas d inner join Ventas v
on d.idVentas=v.idVentas
inner join Cliente c
on v.idCliente=c.idCliente
inner join Empleado t
on v.idEmpleado=t.idEmpleado
group by v.idVentas,
(t.Apellido+' '+t.Nombre),
(c.Apellido+' '+c.Nombre),
v.Fecha,v.Tipo_comprobante,v.Serie,v.Correlativo
having v.Fecha>=@textobuscar and v.Fecha>=@textobuscar2
GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_codigo]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscararticulo_venta_codigo]
@textobuscar varchar(50)
as
select d.idDetalle_ingreso,a.Codigo,a.Nombre,c.Nombre as Categoria,
p.Nombre as Presentacion,d.stock_actual,d.Precio_Compra,
d.Precio_Venta
from Producto a inner join Categoria c
on a.idcategoria=c.idcategoria
inner join Presentacion p
on a.idpresentacion = p.idpresentacion
inner join Detalle_Ingreso d
on a.idProducto=d.idProducto
inner join Ingreso i
on i.idIngreso=d.idIngreso
where a.Codigo = @textobuscar
and d.Stock_Actual>0
and i.Estado<>'ANULADO'
GO
/****** Object:  StoredProcedure [dbo].[spbuscararticulo_venta_nombre]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscararticulo_venta_nombre]
@textobuscar varchar(50)
as
select d.idDetalle_ingreso,a.Codigo,a.Nombre,c.Nombre as Categoria,
p.Nombre as Presentacion,d.stock_actual,d.Precio_Compra,
d.Precio_Venta
from Producto a inner join Categoria c
on a.idcategoria=c.idcategoria
inner join Presentacion p
on a.idpresentacion = p.idpresentacion
inner join Detalle_Ingreso d
on a.idProducto=d.idProducto
inner join Ingreso i
on i.idIngreso=d.idIngreso
where a.Nombre like @textobuscar + '%'
and d.Stock_Actual>0
and i.Estado<>'ANULADO'
GO
/****** Object:  StoredProcedure [dbo].[spdisminuir_stock]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spdisminuir_stock]
@idDetalle_ingreso int,
@Cantidad int
as
update Detalle_Ingreso set Stock_Actual=Stock_Actual-@Cantidad
where idDetalle_ingreso=@idDetalle_ingreso
GO
/****** Object:  StoredProcedure [dbo].[speditar_Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_Categoria]
@idCategoria int,
@Nombre nvarchar(50),
@Descripcion nvarchar(250)
as
update Categoria set Nombre=@Nombre,
Descripcion=@Descripcion
where idCategoria=@idCategoria

GO
/****** Object:  StoredProcedure [dbo].[speditar_cliente]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_cliente]
@idcliente int output,
@nombre nvarchar(50),
@apellido nvarchar(40),
@sexo nvarchar (1),
@fecha_nac date,
@tipo_documento nvarchar (20),
@num_documento nvarchar(15),
@direccion nvarchar(100),
@telefono nvarchar(10),
@email nvarchar(50)
as
update Cliente set Nombre=@nombre, Apellido=@apellido, Sexo=@sexo, 
Fecha_nac=@fecha_nac, Tipo_documento=@tipo_documento, Num_documento=@num_documento,
Direccion=@direccion, Telefono=@telefono, Email=@email
where idCliente=@idcliente

GO
/****** Object:  StoredProcedure [dbo].[speditar_empleado]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento  Editar Trabajador
create proc [dbo].[speditar_empleado]
@idempleado int,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nac date,
@cedula varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar (20),
@usuario varchar (20),
@password varchar(20)
as
update Empleado set Nombre=@nombre,Apellido=@apellidos,Sexo=@sexo,
Fecha_nac=@fecha_nac,
Cedula=@cedula,
direccion=@direccion,telefono=@telefono,email=@email,
acceso=@acceso,usuario=@usuario,password=@password
where idEmpleado=@idempleado
GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_presentacion]
@idpresentacion int,
@nombre nvarchar(50),
@descripcion nvarchar(250)
as
update Presentacion set Nombre=@nombre, Descripcion=@descripcion
where idPresentacion=@idpresentacion

GO
/****** Object:  StoredProcedure [dbo].[speditar_Producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_Producto]
@idProducto int,
@Codigo nvarchar(50),
@Nombre nvarchar(50),
@Descripcion nvarchar(250),
@idCategoria int,
@idPresentacion int
as
update Producto set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion,idCategoria=@idCategoria,idPresentacion=@idPresentacion
where idProducto=@idProducto

GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social nvarchar(150),
@tipo_documento nvarchar(20),
@num_documento nvarchar(11),
@direccion nvarchar(100),
@telefono nvarchar(10),
@email nvarchar(50)
as
update Proveedor set Razon_social=@razon_social,Tipo_documento=@tipo_documento,Num_documento=@num_documento,
Direccion=@direccion,Telefono=@telefono,email=@email
where idProveedor=@idproveedor

GO
/****** Object:  StoredProcedure [dbo].[speliminar_Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_Categoria]
@idCategoria int
as
delete from Categoria
where idCategoria=@idCategoria

GO
/****** Object:  StoredProcedure [dbo].[speliminar_cliente]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_cliente]
@idcliente int
as
delete from Cliente
where idCliente=@idcliente

GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from Presentacion
where idPresentacion=@idpresentacion

GO
/****** Object:  StoredProcedure [dbo].[speliminar_producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_producto]
@idProducto int
as
delete from Producto
where idProducto=@idProducto

GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]
@idproveedor int
as
delete from Proveedor
where idProveedor=@idproveedor

GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento  Eliminar Trabajador
create proc [dbo].[speliminar_trabajador]
@idtrabajador int
as
delete from Empleado
where idEmpleado=@idtrabajador
GO
/****** Object:  StoredProcedure [dbo].[speliminar_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_venta]
@idVentas int
as
delete from Ventas
where idVentas=@idVentas
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_Categoria]
@idCategoria int output,
@Nombre nvarchar(50),
@Descripcion nvarchar(250)
as
insert into Categoria (Nombre,Descripcion)
values (@Nombre,@Descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_cliente]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_cliente]
@idcliente int output,
@nombre nvarchar(50),
@apellido nvarchar(40),
@sexo nvarchar (1),
@fecha_nac date,
@tipo_documento nvarchar (20),
@num_documento nvarchar(15),
@direccion nvarchar(100),
@telefono nvarchar(10),
@email nvarchar(50)
as
insert into Cliente(Nombre, Apellido, Sexo, Fecha_nac, Tipo_documento, Num_documento, Direccion, Telefono, Email)
values (@Nombre, @Apellido, @Sexo, @Fecha_nac, @Tipo_documento, @Num_documento, @Direccion, @Telefono, @Email)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_detalle_ingreso]
@idDetalle_ingreso int output,
@idIngreso int,
@idProducto int,
@Precio_Compra money,
@Precio_Venta money,
@Stock_Inicial int,
@Stock_Actual int,
@Fecha_Produccion date

as
insert into Detalle_Ingreso (idIngreso,idProducto,Precio_Compra,
Precio_Venta,Stock_inicial,Stock_Actual,Fecha_produccion)
values (@idIngreso,@idProducto,@Precio_Compra,
@Precio_Venta,@Stock_inicial,@Stock_Actual,@Fecha_produccion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_detalle_venta]
@idDetalle_venta int output,
@idVentas int,
@idDetalle_ingreso int,
@Cantidad int,
@Precio_Venta money,
@Descuento money
as
insert into Detalle_Ventas(idVentas,idDetalle_ingreso,Cantidad,
Precio_Venta,Descuento)
values(@idVentas,@idDetalle_ingreso,@Cantidad,
@Precio_Venta,@Descuento)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_empleado]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento  Insertar Trabajador
create proc [dbo].[spinsertar_empleado]
@idempleado int output,
@nombre varchar(20),
@apellidos varchar(40),
@sexo varchar(1),
@fecha_nac date,
@cedula varchar(8),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar (20),
@usuario varchar (20),
@password varchar(20)
as
insert into Empleado(Nombre,Apellido,Sexo,Fecha_nac,Cedula,
Direccion,Telefono,Email, Acceso,Usuario,Password)
values (@nombre,@apellidos,@sexo,@fecha_nac,
@cedula,@direccion,@telefono,@email,@acceso,@usuario,@password)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_ingreso]
@idIngreso int=null output,
@idEmpleado int,
@idProveedor int,
@Fecha date,
@Tipo_comprobante nvarchar(20),
@Serie nvarchar(4),
@Correlativo nvarchar(7),
@Igv decimal(4,2),
@Estado nvarchar(7)
as
insert into Ingreso(idEmpleado,idProveedor,Fecha,Tipo_comprobante,
Serie,Correlativo,Igv,Estado)
values(@idEmpleado,@idProveedor,@Fecha,@Tipo_comprobante,
@Serie,@Correlativo,@Igv,@Estado)
--Obtener el codigo autogenerado
SET @idIngreso=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre nvarchar(50),
@descripcion nvarchar(250)
as
insert into Presentacion (Nombre,Descripcion)
values (@nombre,@descripcion)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_producto]
@idProducto int output,
@Codigo nvarchar(50),
@Nombre nvarchar(50),
@Descripcion nvarchar(250),
@idCategoria int,
@idPresentacion int
as
insert into Producto (Codigo, Nombre, Descripcion,idCategoria,idPresentacion)
values (@Codigo,@Nombre,@Descripcion,@idCategoria,@idPresentacion)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social nvarchar(150),
@tipo_documento nvarchar(20),
@num_documento nvarchar(11),
@direccion nvarchar(100),
@telefono nvarchar(10),
@email nvarchar(50)
as
insert into Proveedor(Razon_social, Tipo_documento,Num_documento,Direccion,Telefono,email)
values(@razon_social, @tipo_documento,@num_documento,@direccion,@telefono,@email)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_venta]
@idVentas int=null output,
@idCliente int,
@idEmpleado int,
@Fecha date,
@Tipo_comprobante nvarchar(20),
@Serie nvarchar(4),
@Correlativo nvarchar(7),
@Igv decimal(4,2)
as 
insert into Ventas( idCliente,idEmpleado,Fecha,Tipo_Comprobante,
Serie,Correlativo,Igv)
values ( @idCliente,@idEmpleado,@Fecha,@Tipo_Comprobante,
@Serie,@Correlativo,@Igv)
set @idVentas=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[splogin]
@usuario varchar(20),
@password varchar(20)
as
select idEmpleado, Apellido, Nombre, Acceso
from Empleado
where Usuario=@usuario and Password=@password
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_Categoria]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_Categoria]
as
select top 200 * from Categoria
order by idCategoria desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_cliente]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_cliente]
as
select top 100 * from Cliente
order by Apellido asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_detalle_ingreso]
@textobuscar int
as
select d.idProducto,a.Nombre as Producto, d.Precio_Compra,
d.Precio_Venta,d.Stock_inicial,d.Fecha_produccion,(d.Stock_inicial*
d.Precio_Compra) as Subtotal
from Detalle_Ingreso d inner join Producto a
on d.idProducto=a.idProducto
where d.idIngreso=@textobuscar
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_detalle_venta]
@textobuscar int
as
select d.idDetalle_ingreso, a.Nombre as Producto,
d.cantidad,d.Precio_Venta,d.Descuento,
((d.Precio_Venta*d.cantidad)-d.Descuento) as Subtotal
from Detalle_Ventas d inner join Detalle_Ingreso di
on d.idDetalle_ingreso=di.iddetalle_ingreso
inner join Producto a
on di.idProducto=a.idProducto
where d.idVentas=@textobuscar
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_empleado]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Procedimiento Mostrar Trabajador
create proc [dbo].[spmostrar_empleado]
as
SELECT  * FROM Empleado
order by Apellido asc
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ingreso]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_ingreso]
as
select top 100 i.idIngreso,(t.Apellido+' '+t.Nombre) as Empleado,
p.Razon_social as Proveedor,i.Tipo_comprobante, 
i.Serie,i.Correlativo,i.Estado,
sum(d.Precio_Compra*d.Stock_inicial) as Total
from Detalle_Ingreso d inner join Ingreso i
on d.idIngreso=i.idIngreso
inner join Proveedor p
on i.idProveedor=p.idProveedor
inner join Empleado t
on i.idEmpleado=t.idEmpleado
group by
i.idIngreso,t.Apellido+' '+t.Nombre,p.Razon_social,i.Fecha,
i.Tipo_comprobante, i.Serie,i.Correlativo,i.Estado
order by i.idIngreso desc
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_presentacion]
as
select top 100 * from presentacion
order by idPresentacion desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_producto]
as
SELECT top  100 dbo.Producto.idProducto, dbo.Producto.Codigo, dbo.Producto.Nombre, 
dbo.Producto.Descripcion, dbo.Producto.idCategoria, 
dbo.Categoria.Nombre AS Categoria, dbo.Producto.idPresentacion, 
dbo.Presentacion.Nombre AS Presentacion
FROM            dbo.Producto INNER JOIN dbo.Categoria 
ON dbo.Producto.idCategoria = dbo.Categoria.idCategoria 
INNER JOIN dbo.Presentacion 
ON dbo.Producto.idPresentacion = dbo.Presentacion.idPresentacion
order by dbo.Producto.idProducto desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_venta]
as
select top 100 v.idVentas,
(t.Apellido+' '+t.Nombre) as Empleado,
(c.Apellido+' '+c.Nombre) as Cliente,
v.Fecha,v.Tipo_comprobante,v.Serie,v.Correlativo,
sum((d.Cantidad*d.Precio_Venta)-d.Descuento) as Total
from Detalle_Ventas d inner join Ventas v
on d.idVentas=v.idVentas
inner join Cliente c
on v.idCliente=c.idCliente
inner join Empleado t
on v.idEmpleado=t.idEmpleado
group by v.idVentas,
(t.Apellido+' '+t.Nombre),
(c.Apellido+' '+c.Nombre),
v.Fecha,v.Tipo_comprobante,v.Serie,v.Correlativo
order by v.idVentas desc
GO
/****** Object:  StoredProcedure [dbo].[spmpstrar_proveedor]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmpstrar_proveedor]
as
select top 100 * from Proveedor
order by Razon_social asc

GO
/****** Object:  StoredProcedure [dbo].[spreporte_venta]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spreporte_venta]
@idVenta int
as
SELECT 
v.idVentas,(t.Apellido+' '+t.Nombre) as Empleado,
(c.Apellido+' '+c.Nombre) as Cliente,
c.Direccion,c.Telefono,c.Num_documento,
v.Fecha,v.Tipo_Comprobante,v.Serie,v.Correlativo,
v.Igv,a.Nombre,dv.Precio_Venta,dv.Cantidad,dv.Descuento,
(dv.Cantidad*dv.Precio_Venta-dv.Descuento) as Total_Parcial
FROM  Detalle_Ventas dv inner join Detalle_Ingreso di
on dv.idDetalle_ingreso=di.iddetalle_ingreso
inner join Producto a
on a.idProducto=di.idProducto
INNER JOIN Ventas v
ON v.idVentas = dv.idVentas
INNER JOIN Cliente c
ON v.idCliente = c.idCliente
INNER JOIN Empleado t
ON t.idEmpleado = v.idEmpleado
where v.idVentas=@idVenta
GO
/****** Object:  StoredProcedure [dbo].[spstock_producto]    Script Date: 06/02/2020 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spstock_producto]
as
SELECT dbo.Producto.Codigo, dbo.Producto.Nombre, 
dbo.Categoria.Nombre AS Categoria, 
sum(dbo.Detalle_Ingreso.Stock_inicial) as Cantidad_Ingreso, 
sum(dbo.Detalle_Ingreso.Stock_Actual) as Cantidad_Stock,
(sum(dbo.Detalle_Ingreso.Stock_inicial)-
sum(dbo.Detalle_Ingreso.Stock_Actual)) as Cantidad_Venta
FROM dbo.Producto INNER JOIN dbo.Categoria 
ON dbo.Producto.idCategoria = dbo.Categoria.idCategoria 
INNER JOIN dbo.Detalle_Ingreso
ON dbo.Producto.idProducto = dbo.Detalle_Ingreso.idProducto 
INNER JOIN dbo.Ingreso
ON dbo.Detalle_Ingreso.idIngreso = dbo.Ingreso.idIngreso
where Ingreso.Estado<>'ANULADO'
group by dbo.Producto.Codigo, dbo.Producto.Nombre, 
dbo.Categoria.Nombre
GO
USE [master]
GO
ALTER DATABASE [ZonaGamer] SET  READ_WRITE 
GO
