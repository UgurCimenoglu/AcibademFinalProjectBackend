USE [master]
GO
/****** Object:  Database [AdoNetDeneme]    Script Date: 2/14/2022 5:53:52 AM ******/
CREATE DATABASE [AdoNetDeneme]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdoNetDeneme', FILENAME = N'C:\Users\ugurc\AdoNetDeneme.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AdoNetDeneme_log', FILENAME = N'C:\Users\ugurc\AdoNetDeneme_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AdoNetDeneme] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdoNetDeneme].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdoNetDeneme] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdoNetDeneme] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdoNetDeneme] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdoNetDeneme] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdoNetDeneme] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdoNetDeneme] SET  MULTI_USER 
GO
ALTER DATABASE [AdoNetDeneme] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdoNetDeneme] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdoNetDeneme] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdoNetDeneme] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AdoNetDeneme] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AdoNetDeneme] SET QUERY_STORE = OFF
GO
USE [AdoNetDeneme]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AdoNetDeneme]
GO
/****** Object:  Table [dbo].[Installments]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Installments] [int] NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Installments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Policies]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Policies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleQuery]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleQuery](
	[Id] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
	[PolicyId] [int] NOT NULL,
	[InstallmentId] [int] NOT NULL,
 CONSTRAINT [PK_SaleQuery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[PolicyId] [int] NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[PricePerInstallment] [decimal](18, 0) NOT NULL,
	[RemainingInstallment] [int] NOT NULL,
	[TotalInstallment] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Users__A9D105341599BD9D] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SaleQuery]    Script Date: 2/14/2022 5:53:52 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SaleQuery] ON [dbo].[SaleQuery]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SaleQuery]  WITH CHECK ADD  CONSTRAINT [FK_SaleQuery_Installments] FOREIGN KEY([InstallmentId])
REFERENCES [dbo].[Installments] ([Id])
GO
ALTER TABLE [dbo].[SaleQuery] CHECK CONSTRAINT [FK_SaleQuery_Installments]
GO
ALTER TABLE [dbo].[SaleQuery]  WITH CHECK ADD  CONSTRAINT [FK_SaleQuery_Policies] FOREIGN KEY([PolicyId])
REFERENCES [dbo].[Policies] ([Id])
GO
ALTER TABLE [dbo].[SaleQuery] CHECK CONSTRAINT [FK_SaleQuery_Policies]
GO
ALTER TABLE [dbo].[SaleQuery]  WITH CHECK ADD  CONSTRAINT [FK_SaleQuery_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SaleQuery] CHECK CONSTRAINT [FK_SaleQuery_Users]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Users]
GO
/****** Object:  StoredProcedure [dbo].[addNewUser]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[addNewUser]    
(  
@Id int,
@FirstName nvarchar(100),
@LastName nvarchar(100),    
@Email nvarchar(100),   
@PasswordSalt varbinary(max),
@PasswordHash varbinary(max),    
@Status bit
)    
as    
begin 
	insert into Users(FirstName,LastName,Email,PasswordSalt,PasswordHash,Status)
	values(@FirstName,@LastName,@Email,@PasswordSalt,@PasswordHash,@Status)  
end
GO
/****** Object:  StoredProcedure [dbo].[addSalesQuery]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[addSalesQuery]
(
@UserId int,
@PolicyId int,
@InstallmentId int
)
AS
begin
SET NOCOUNT ON;
Declare @NewID UNIQUEIDENTIFIER =  NEWID();
INSERT INTO SaleQuery(Id,userId,policyId,InstallmentId) values(@NewID,@UserId,@PolicyId,@InstallmentId)
SELECT @NewID
END
GO
/****** Object:  StoredProcedure [dbo].[CheckMailCount]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CheckMailCount](@Email nvarchar(100))    
as    
begin     
select Count(*) from Users where Email = @Email    
end     
GO
/****** Object:  StoredProcedure [dbo].[GetAllInstallments]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[GetAllInstallments]
 as begin
 select * from Installments
 end;
GO
/****** Object:  StoredProcedure [dbo].[GetAllPolicies]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[GetAllPolicies]
 as begin
 select * from Policies
 end;
GO
/****** Object:  StoredProcedure [dbo].[GetAllSoldPolicies]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllSoldPolicies]
as 
begin 
select P.Name as PolicyName,U.FirstName+ ' ' +U.LastName as FullName, Sales.TotalInstallment,Sales.TotalPrice,Sales.RemainingInstallment,Sales.PricePerInstallment from Sales 
JOIN  Policies AS P  on Sales.PolicyId = p.Id
LEFT JOIN Users As U on Sales.UserId = U.Id;
end;
GO
/****** Object:  StoredProcedure [dbo].[GetSoldPoliciesByEmail]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetSoldPoliciesByEmail](
@Email nvarchar(50)
)
as 
begin 
select P.Name as PolicyName, U.FirstName+ ' ' +U.LastName as FullName, Sales.TotalInstallment,Sales.TotalPrice,Sales.RemainingInstallment,Sales.PricePerInstallment from Sales 
LEFT JOIN  Policies AS P  on Sales.PolicyId = p.Id
LEFT JOIN Users As U on Sales.UserId = U.Id
 where Sales.Email = @Email;
end;
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[GetUserByEmail](
@Email nvarchar(50)
)
as 
begin
select * from Users where Email = @Email;
end
GO
/****** Object:  StoredProcedure [dbo].[Pay]    Script Date: 2/14/2022 5:53:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Pay](
@Id nvarchar(50)
)
AS
BEGIN

DECLARE @UserId int, @PolicyId int,@InstallmentId int ,@Email nvarchar(50)
 
select @UserId = UserId, @PolicyId = PolicyId, @InstallmentId = InstallmentId from SaleQuery where Id = @Id;

select @Email = Email from Users where Id = @UserId;

DECLARE @TotalPrice decimal, @Installment int

select @TotalPrice = Price from Policies where Id = @PolicyId;

select @Installment = Installments from Installments where Id = @InstallmentId;

DECLARE @PricePerInstallment decimal = @TotalPrice/@Installment 

INSERT INTO Sales(UserId,Email,PolicyId,TotalPrice,PricePerInstallment,RemainingInstallment,TotalInstallment) values(@UserId,@Email,@PolicyId,@TotalPrice,@PricePerInstallment,@Installment,@Installment)
END
GO
USE [master]
GO
ALTER DATABASE [AdoNetDeneme] SET  READ_WRITE 
GO
