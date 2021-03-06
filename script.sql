USE [NHibernateDemoDB]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/7/2022 3:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstMidName] [nvarchar](max) NULL,
	[AcademicStanding] [nchar](10) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName], [AcademicStanding]) VALUES (2, N'Lewis', N'Jerry', N'0         ')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName], [AcademicStanding]) VALUES (3, N'A Al Arabi', N'Ahmad', N'0         ')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName], [AcademicStanding]) VALUES (4, N'Man', N'Ali', N'0         ')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName], [AcademicStanding]) VALUES (1002, N'Bommer', N'Allan', N'0         ')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName], [AcademicStanding]) VALUES (1003, N'Lewis', N'Jerry', N'1         ')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
