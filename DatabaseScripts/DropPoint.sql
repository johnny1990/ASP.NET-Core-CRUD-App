﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DropPoint](
	[DropPointId] [int] IDENTITY(1,1) NOT NULL,
	[DropPointName] [nvarchar](max) NOT NULL,
	[NewDropPointName] [nvarchar](max) NULL,
	[RouteId] [int] NOT NULL,
 CONSTRAINT [PK_DropPoint] PRIMARY KEY CLUSTERED 
(
	[DropPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DropPoint]  WITH CHECK ADD  CONSTRAINT [FK_DropPoint_Route_RouteId] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([RouteId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DropPoint] CHECK CONSTRAINT [FK_DropPoint_Route_RouteId]
GO
