USE [master]
GO
/****** Object:  Database [ventas]    Script Date: 18/12/2016 21:54:07 ******/
CREATE DATABASE [ventas]
 
ALTER DATABASE [ventas] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ventas] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ventas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ventas] SET RECOVERY FULL 
GO
ALTER DATABASE [ventas] SET  MULTI_USER 
GO
ALTER DATABASE [ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ventas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ventas', N'ON'
GO
USE [ventas]
GO
/****** Object:  StoredProcedure [dbo].[reporte_factura]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[reporte_factura] 
@idPedido nvarchar(5)
as
select

pd.idPedido,
pr.nombre as Descripcion, pr.precioUnitario as 'Precio Venta',
pd.cantidad as Cantidad,pd.descuento as Descuento,
(cl.nombre+' '+cl.apPaterno) as Cliente,
(ve.nombre+' '+ve.apPaterno)as Vendedor,
ca.nombre as Categoria,
mp.nombre as 'Modo Pago'

from pedido pd inner join detalleFactura df
on pd.idPedido=df.idPedido
inner join cliente cl
on cl.idCliente=pd.idCliente
inner join producto pr
on pr.idProducto=pd.idProducto
inner join categoria ca
on ca.idCategoria=pr.idCategoria
inner join vendedor ve
on ve.idVendedor=pd.idVendedor
inner join factura fa
on fa.numFactura=df.numFactura
inner join modoPago mp
on mp.numPago=fa.numPago
where pd.idPedido=@idPedido

GO
/****** Object:  StoredProcedure [dbo].[sp_cliente_adc]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_cliente_adc](
@codigo varchar(5),
@nombre varchar(50),
@apPaterno varchar(25),
@apMaterno varchar(25),
@dni varchar(8),
@direccion varchar(50),
@telefono varchar(20)
)
as
insert into cliente values(@codigo,@nombre,@apPaterno,@apMaterno,@dni,@direccion,@telefono)

GO
/****** Object:  StoredProcedure [dbo].[sp_lista_clientes]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_lista_clientes]
@pageIndex int=1,
@pageSize int=10,
@pageCount int=0 out
as
set @pageCount=(select count(1) from cliente)/@pageSize
select*from (select row_number()over (order by idCliente)RowId,* from cliente)cliente where idCliente between(@pageSize*(@pageIndex-1)+1)and(@pageIndex*@pageSize)

GO
/****** Object:  StoredProcedure [dbo].[sp_producto_categoria]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_producto_categoria]
@idCategoria varchar(5)
as
select*from producto p inner join categoria c
on p.idCategoria=c.idCategoria
where c.idCategoria=@idCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_venta]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_reporte_venta]
@idVenta numeric(18,0)
as
select
v.idVenta,
(ve.nombre+' '+ve.apPaterno+' '+ve.apMaterno)as Trabajador,
(cl.nombre+' '+cl.apPaterno+' '+cl.apMaterno)as Cliente,
cl.direccion,cl.dni,cl.telefono,
v.fecha,v.total,v.IVA,v.descuento,
pr.nombre,pr.precioUnitario,
dv.cantidad,dv.numFactura,dv.subTotal,
(dv.cantidad*pr.precioUnitario-v.descuento)as total_parcial

from detalleVenta dv inner join producto pr
on dv.idProducto=pr.idProducto
inner join venta v
on dv.idVenta=v.idVenta
inner join vendedor ve
on ve.idVendedor=v.idVendedor
inner join cliente cl
on cl.idCliente=v.idCliente
where v.idVenta=@idVenta

GO
/****** Object:  Table [dbo].[categoria]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [nvarchar](5) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__categori__8A3D240C1538A73E] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cliente]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idCliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apPaterno] [varchar](30) NOT NULL,
	[apMaterno] [varchar](30) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](30) NOT NULL,
	[dni] [numeric](8, 0) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalleVenta]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleVenta](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[numFactura] [numeric](18, 0) NOT NULL,
	[idVenta] [numeric](18, 0) NOT NULL,
	[subTotal] [real] NOT NULL,
	[idProducto] [nvarchar](5) NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_detalleVenta] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC,
	[numFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[factura]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[numFactura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[IVA] [real] NOT NULL,
	[total] [real] NOT NULL,
	[numPago] [int] NOT NULL,
	[descuento] [money] NULL,
 CONSTRAINT [PK__factura__C989668BFDF3359B] PRIMARY KEY CLUSTERED 
(
	[numFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[modoPago]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modoPago](
	[numPago] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](25) NOT NULL,
	[otroDetalles] [nvarchar](50) NULL,
 CONSTRAINT [PK__modoPago__56E7C501338E87C8] PRIMARY KEY CLUSTERED 
(
	[numPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[producto]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [nvarchar](5) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[precioUnitario] [money] NOT NULL,
	[idCategoria] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK__producto__07F4A132F0C57D04] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vendedor]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendedor](
	[idVendedor] [nvarchar](5) NOT NULL,
	[nombre] [nvarchar](30) NOT NULL,
	[apPaterno] [nvarchar](30) NOT NULL,
	[apMaterno] [nvarchar](30) NOT NULL,
	[dni] [nvarchar](8) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__vendedor__A6693F936F5918BB] PRIMARY KEY CLUSTERED 
(
	[idVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venta]    Script Date: 18/12/2016 21:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idVenta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[total] [real] NOT NULL,
	[idCliente] [numeric](18, 0) NOT NULL,
	[idVendedor] [nvarchar](5) NOT NULL,
	[fecha] [date] NOT NULL,
	[descuento] [money] NULL,
	[IVA] [money] NOT NULL,
 CONSTRAINT [PK__pedido__A9F619B72DC663B9] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK__detalleFa__idPed__239E4DCF] FOREIGN KEY([idVenta])
REFERENCES [dbo].[venta] ([idVenta])
GO
ALTER TABLE [dbo].[detalleVenta] CHECK CONSTRAINT [FK__detalleFa__idPed__239E4DCF]
GO
ALTER TABLE [dbo].[detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_detalleFactura_factura] FOREIGN KEY([numFactura])
REFERENCES [dbo].[factura] ([numFactura])
GO
ALTER TABLE [dbo].[detalleVenta] CHECK CONSTRAINT [FK_detalleFactura_factura]
GO
ALTER TABLE [dbo].[detalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_detalleFactura_producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[detalleVenta] CHECK CONSTRAINT [FK_detalleFactura_producto]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_factura_modoPago] FOREIGN KEY([numPago])
REFERENCES [dbo].[modoPago] ([numPago])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_factura_modoPago]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK__producto__idCate__164452B1] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK__producto__idCate__164452B1]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[cliente] ([idCliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_vendedor] FOREIGN KEY([idVendedor])
REFERENCES [dbo].[vendedor] ([idVendedor])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_vendedor]
GO
USE [master]
GO
ALTER DATABASE [ventas] SET  READ_WRITE 
GO
