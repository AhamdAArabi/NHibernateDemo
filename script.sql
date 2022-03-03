USE [NHibernateDemoDB]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 3/3/2022 3:14:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[FirstMidName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName]) VALUES (2, N'Lewis', N'Jerry')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName]) VALUES (3, N'A Al Arabi', N'Ahmad')
INSERT [dbo].[Student] ([ID], [LastName], [FirstMidName]) VALUES (4, N'Man', N'Ali')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
