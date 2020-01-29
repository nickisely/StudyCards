USE [StudyCards]
GO

/****** Object:  Table [dbo].[StudyCard]    Script Date: 1/28/2020 8:16:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudyCard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[SubGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_StudyCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudyCard]  WITH CHECK ADD  CONSTRAINT [FK_StudyCard_SubGroup] FOREIGN KEY([SubGroupId])
REFERENCES [dbo].[SubGroup] ([Id])
GO

ALTER TABLE [dbo].[StudyCard] CHECK CONSTRAINT [FK_StudyCard_SubGroup]
GO


