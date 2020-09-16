SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmpId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](max) NOT NULL,
	[EmployeeNo] [int] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ProjectName] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[CabId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Cab_CabId] FOREIGN KEY([CabId])
REFERENCES [dbo].[Cab] ([CabId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Cab_CabId]
GO