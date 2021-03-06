USE [StudyCards]
GO

/****** Object:  Table [dbo].[SubGroup]    Script Date: 1/28/2020 8:16:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[GroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SubGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubGroup]  WITH CHECK ADD  CONSTRAINT [FK_SubGroup_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO

ALTER TABLE [dbo].[SubGroup] CHECK CONSTRAINT [FK_SubGroup_Group]
GO


