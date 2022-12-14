USE [DogExample]
GO
/****** Object:  Table [dbo].[Breed]    Script Date: 01/09/22 12:19:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breed](
	[BreedID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Breed] PRIMARY KEY CLUSTERED 
(
	[BreedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dog]    Script Date: 01/09/22 12:19:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dog](
	[DogID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BreedID] [int] NOT NULL,
	[BirthDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Dog] PRIMARY KEY CLUSTERED 
(
	[DogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Breed] ([BreedID], [Name]) VALUES (1, N'Maltese')
INSERT [dbo].[Breed] ([BreedID], [Name]) VALUES (2, N'Rottweiler')
INSERT [dbo].[Breed] ([BreedID], [Name]) VALUES (3, N'Doberman')
GO
INSERT [dbo].[Dog] ([DogID], [Name], [BreedID], [BirthDate]) VALUES (1, N'Rambo', 1, CAST(N'2022-02-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Dog] ([DogID], [Name], [BreedID], [BirthDate]) VALUES (2, N'Mutt', 2, CAST(N'2020-01-01T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Dog]  WITH CHECK ADD  CONSTRAINT [FK_DogBreed_BreedID] FOREIGN KEY([DogID])
REFERENCES [dbo].[Breed] ([BreedID])
GO
ALTER TABLE [dbo].[Dog] CHECK CONSTRAINT [FK_DogBreed_BreedID]
GO
