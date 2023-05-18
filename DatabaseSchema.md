USE [OneDaily]
GO
/****** Object:  Table [dbo].[Conversation]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversation](
	[ConversationId] [bigint] IDENTITY(1,1) NOT NULL,
	[MatchId] [bigint] NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
 CONSTRAINT [PK__Conversa__311E7E9A8369CA2D] PRIMARY KEY CLUSTERED 
(
	[ConversationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interest]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interest](
	[InterestId] [bigint] IDENTITY(1,1) NOT NULL,
	[InterestName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Interest__0F5A1FAD554DD714] PRIMARY KEY CLUSTERED 
(
	[InterestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[MatchId] [bigint] IDENTITY(1,1) NOT NULL,
	[User1Id] [bigint] NULL,
	[User2Id] [bigint] NULL,
	[MatchDate] [date] NULL,
	[MatchStatus] [nvarchar](50) NULL,
	[user1_status] [bigint] NULL,
	[user2_status] [bigint] NULL,
 CONSTRAINT [PK__Matches__9D7FCBA32DB0CC74] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [bigint] IDENTITY(1,1) NOT NULL,
	[ConversationId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[ContentType] [nvarchar](50) NULL,
	[TimeStamp] [datetime2](7) NULL,
 CONSTRAINT [PK__Messages__0BBF6EE6C8A84911] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [bigint] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](255) NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Bio] [nvarchar](max) NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NULL,
	[LastLogin] [datetime2](7) NULL,
 CONSTRAINT [PK__Users__B9BE370F3DFEC949] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInterest]    Script Date: 5/17/2023 4:57:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInterest](
	[UserInterestId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[InterestId] [bigint] NOT NULL,
 CONSTRAINT [PK__User_Int__AD516BA98A764D26] PRIMARY KEY CLUSTERED 
(
	[UserInterestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Conversation] ON 
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (1, 1, CAST(N'2023-04-30T22:43:17.4566603' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (2, NULL, CAST(N'2023-05-14T01:48:46.6122819' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (3, NULL, CAST(N'2023-05-14T02:53:30.3462945' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (4, NULL, CAST(N'2023-05-14T18:38:39.8073434' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (5, NULL, CAST(N'2023-05-16T21:15:23.8307581' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (6, NULL, CAST(N'2023-05-16T22:14:11.9735107' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (7, NULL, CAST(N'2023-05-16T22:27:16.8530685' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (8, NULL, CAST(N'2023-05-17T05:02:08.2274286' AS DateTime2), NULL)
GO
INSERT [dbo].[Conversation] ([ConversationId], [MatchId], [StartTime], [EndTime]) VALUES (9, 30, CAST(N'2023-05-17T05:26:25.6467536' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Conversation] OFF
GO
SET IDENTITY_INSERT [dbo].[Interest] ON 
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (12, N'Art')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (2, N'Books')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (9, N'Cars')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (5, N'Chess')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (7, N'Coffee')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (4, N'Crime')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (14, N'Dancing')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (10, N'Health')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (8, N'Music')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (15, N'Photography')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (13, N'Singing')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (1, N'Sports')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (3, N'TV/Movies')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (6, N'Video Games')
GO
INSERT [dbo].[Interest] ([InterestId], [InterestName]) VALUES (11, N'Writing')
GO
SET IDENTITY_INSERT [dbo].[Interest] OFF
GO
SET IDENTITY_INSERT [dbo].[Match] ON 
GO
INSERT [dbo].[Match] ([MatchId], [User1Id], [User2Id], [MatchDate], [MatchStatus], [user1_status], [user2_status]) VALUES (1, 1, 2, CAST(N'2023-04-29' AS Date), N'Matched', 1, 1)
GO
INSERT [dbo].[Match] ([MatchId], [User1Id], [User2Id], [MatchDate], [MatchStatus], [user1_status], [user2_status]) VALUES (3, 3, 2, CAST(N'2023-04-29' AS Date), NULL, 3, 3)
GO
INSERT [dbo].[Match] ([MatchId], [User1Id], [User2Id], [MatchDate], [MatchStatus], [user1_status], [user2_status]) VALUES (30, 29, 50, CAST(N'2023-05-16' AS Date), N'Matched', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Match] OFF
GO
SET IDENTITY_INSERT [dbo].[Message] ON 
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (4, 4, 29, N'This is a sample message', N'text', CAST(N'2023-05-15T10:30:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (5, 4, 29, N'This is another sample message', N'text', CAST(N'2023-05-15T10:30:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (6, 4, 29, N'This is yet another sample message', N'text', CAST(N'2023-05-15T10:30:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (7, 4, 29, N'1', N'text', CAST(N'2023-05-15T17:55:13.7600000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (8, 4, 29, N'Hello', N'text', CAST(N'2023-05-15T19:17:03.7700000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (9, 4, 29, N'Hello', N'text', CAST(N'2023-05-15T19:20:39.2366667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (10, 4, 29, N'Match?', N'text', CAST(N'2023-05-15T19:26:28.9366667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (11, 4, 29, N'I can text now', N'text', CAST(N'2023-05-16T13:06:34.9633333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (12, 4, 29, N'This is cool', N'text', CAST(N'2023-05-16T13:08:06.1800000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (13, 4, 29, N'What’s crtackiig', N'text', CAST(N'2023-05-16T13:39:38.9933333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (14, 4, 29, N'1', N'text', CAST(N'2023-05-16T14:04:34.7766667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (15, 4, 29, N'11', N'text', CAST(N'2023-05-16T14:09:44.0500000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (16, 4, 29, N'123', N'text', CAST(N'2023-05-16T14:11:17.3700000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (17, 4, 29, N'Hello', N'text', CAST(N'2023-05-16T14:12:37.2600000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (18, 5, 42, N'Helloo', N'text', CAST(N'2023-05-16T14:15:31.6633333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (19, 5, 48, N'Aloha', N'text', CAST(N'2023-05-16T14:15:47.6233333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (21, 5, 42, N'How are you', N'text', CAST(N'2023-05-16T14:55:13.7633333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (22, 5, 42, N'How are you', N'text', CAST(N'2023-05-16T14:55:15.0300000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (24, 5, 48, N'Hey that’s mean', N'text', CAST(N'2023-05-16T14:58:16.2766667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (25, 6, 42, N'Hello mate', N'text', CAST(N'2023-05-16T15:14:18.3433333' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (26, 6, 29, N'How is it going', N'text', CAST(N'2023-05-16T15:14:30.7366667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (27, 7, 42, N'Hello', N'text', CAST(N'2023-05-16T15:27:23.5500000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (28, 7, 29, N'Hello', N'text', CAST(N'2023-05-16T15:27:38.1900000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (29, 7, 29, N'What is music', N'text', CAST(N'2023-05-16T21:47:54.9166667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (30, 7, 29, N'Who knows', N'text', CAST(N'2023-05-16T21:47:59.2166667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (31, 7, 29, N'Wassup', N'text', CAST(N'2023-05-16T21:53:48.9966667' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (32, 7, 29, N'All the same color again', N'text', CAST(N'2023-05-16T21:53:58.2000000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (33, 7, 29, N'Aloga', N'text', CAST(N'2023-05-16T22:00:43.8800000' AS DateTime2))
GO
INSERT [dbo].[Message] ([MessageId], [ConversationId], [UserId], [Content], [ContentType], [TimeStamp]) VALUES (34, 7, 42, N'Wassup', N'text', CAST(N'2023-05-16T22:01:02.0200000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Message] OFF
GO
INSERT [dbo].[Status] ([StatusId], [Status]) VALUES (1, N'Accepted')
GO
INSERT [dbo].[Status] ([StatusId], [Status]) VALUES (2, N'Declined')
GO
INSERT [dbo].[Status] ([StatusId], [Status]) VALUES (3, N'Pending')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (1, N'test', N'user', N'newupdate', N'testuser@example.com', N'$2a$11$9AbxZCiwlw44pos2cX7g/edu9VyoylbKcapz2sBpP0ysS7RQovXqm', NULL, N'this is my bio', NULL, CAST(N'2023-04-24T14:45:46.5566667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (2, NULL, NULL, N'asdf', N's@d.d', N'$2a$11$VqwINKwtXszM3/nx9KhPreDxzK3JxD/.8lHxxBpCafmZH7JW2JyLC', NULL, NULL, NULL, CAST(N'2023-04-24T19:42:14.9066667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (3, NULL, NULL, N'casey', N'daddycasey@dfjsl.sdjfkl', N'$2a$11$mY4LhiNfri6vdMV9DJIkcOOQRwjIFTh6rcAnIFqd4UkrtVeEATXEi', NULL, NULL, NULL, CAST(N'2023-04-24T20:49:39.8100000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (12, NULL, NULL, N'tesasdftuser', N'testuseasdfr@example.com', N'$2a$11$gcXnQUWnrK/Y9l0L3b67ruhN/hyl6iWsVFdfkBVBUHNCc2hXIWP7G', NULL, NULL, NULL, CAST(N'2023-04-26T13:48:01.0166667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (15, NULL, NULL, N'testccuser', N'testusezzzzzr@example.com', N'$2a$11$Kiv5a58GtuJaPI.jLLePX.SqGAX3rpcu5kCT6Ls3PER7FC5czAMpi', NULL, NULL, NULL, CAST(N'2023-04-26T14:08:55.5400000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (17, NULL, NULL, N'Shawn', N'sadf@gmai.com', N'$2a$11$U9dKlWZpU6wQ/H5TNoJTcOuujpq6C2tNZbPTW7zUmCnfBwELxAxei', NULL, NULL, NULL, CAST(N'2023-04-26T19:59:03.8000000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (27, NULL, NULL, N'Testusermayfirst', N'Hello@email.com', N'$2a$11$19nq6NgVCqzFf7Acn9V5Heo4MaRT23Mnh.TJjMYZuUVu1lw9sTy6a', NULL, NULL, NULL, CAST(N'2023-05-01T13:08:39.7533333' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (29, N'James', N'Litton', N'1', N'one@example.net', N'$2a$11$cBj3H39wvKvYgMGzTBNBzeiVKYoa25V0QwIxvLQUdkPpnxoleFLhC', NULL, N'This is my bio', NULL, CAST(N'2023-05-01T19:07:09.7733333' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (30, NULL, NULL, N'Asdfs', N'asdfasdfasdf', N'$2a$11$IOD7QeLz/zc6yolPa7aDnOVuhQBL30iGtZ9RLzKSBttNu31PxIJo2', NULL, NULL, NULL, CAST(N'2023-05-03T13:23:30.9066667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (31, NULL, NULL, N'This is a test user ', N'asdfasdf', N'$2a$11$CyQNn4fCk2dAEbTVdkIlS.UomOGz1J9XVqDu1ScWLIznM3vnbvYwe', NULL, NULL, NULL, CAST(N'2023-05-03T13:28:13.1400000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (32, NULL, NULL, N'Newuser', N'12333333', N'$2a$11$qTyuCDwkM5urceRoKI7cruu.fakTO4rL243vKQM3lzkiAZYTyqooi', NULL, NULL, NULL, CAST(N'2023-05-03T13:30:57.4966667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (33, NULL, NULL, N'Sadfasdf', N'asdfasdfdas', N'$2a$11$0B4ABDE9P.fW5.tifyfLtuGoJj9onZl4mEvGk8nPbsgP5KPpKvVSu', NULL, NULL, NULL, CAST(N'2023-05-03T13:32:14.8833333' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (34, NULL, NULL, N'Add', N'asdf', N'$2a$11$MN/Iuf3n2NYWglHlViyEieAPreUCcLHHTvzKOVKrrzP0zf9GXHybe', NULL, NULL, NULL, CAST(N'2023-05-03T13:33:59.5266667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (35, NULL, NULL, N'Pleasework', N'321', N'$2a$11$QHu/XwtU4tsyoDOH9gW20uieOw9f2ZUTwSiCIl/UukOHE9JZTCNrS', NULL, NULL, NULL, CAST(N'2023-05-03T13:36:11.1700000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (36, NULL, NULL, N'Jamesisanidioto', N'asdfsadf', N'$2a$11$FVGkhFJ11YMxX5NpVw1v/ePgCj5p67IEHAdPGJVq4Dm9Mg7rgei8G', NULL, NULL, NULL, CAST(N'2023-05-03T21:35:32.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (37, NULL, NULL, N'Shawnsadf', N'asdfsadfasdfasdfadsfafsdasdf', N'$2a$11$5sfHt.h23.MeBwjKrXMUguoa.lk1hMGyfbktrqOhZHeR8rEVw1JdO', NULL, NULL, NULL, CAST(N'2023-05-07T12:02:46.9600000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (38, N'FirstName', N'LastName', N'TestUser', N'Email@email.email', N'$2a$11$iURiB/45XKoEIkcXLzdvbOF7PELX/EyoAnet7UY2cG6.AkwKtD9T.', NULL, N'This is a new bio of mine', NULL, CAST(N'2023-05-08T14:40:33.2666667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (39, NULL, NULL, N'A', N'a', N'$2a$11$RA.UL7guYopVGl049IXczu5Fl.seU4cT6dLIc7MGp9hosJgXUB9Dy', NULL, NULL, NULL, CAST(N'2023-05-08T20:46:07.4733333' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (40, N'Kaitlyn', N'CROUSER', N'Kcrouser', N'1', N'$2a$11$jvmnaZTe1YCrkrLOnfxc9.fhi0UlCVsblN8HwblXBS9zFvt2tMIju', NULL, N'I am short', NULL, CAST(N'2023-05-11T22:42:37.4700000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (41, NULL, NULL, N'Liam', N'Liam@Liam.Liam', N'$2a$11$1KrUYCByM8yChgnptk9Go.ZeYYGGn3E/FyHkA2I7/Fin2.5FSZefG', NULL, NULL, NULL, CAST(N'2023-05-12T19:40:45.8266667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (42, NULL, NULL, N'2', N'2', N'$2a$11$SwbFnWhH0nP3oiPaivQ7i.VjOXlrlOwpri6RDX4UnLBJqrdHokbP2', NULL, NULL, NULL, CAST(N'2023-05-13T19:33:08.8766667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (47, NULL, NULL, N'Cwong11', N'11111', N'$2a$11$cAGgNJedUr7tlY4q7n0SwuBKQ9xQ3N027ukVxSs/Z5Q.JlY/jk7pu', NULL, NULL, NULL, CAST(N'2023-05-13T19:48:36.8666667' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (48, NULL, NULL, N'3', N'3', N'$2a$11$//XLj7kod.aVNgTHGrPf3.fTO1m3q6x5BNBMhkY3CwWGS3vhAeRH6', NULL, NULL, NULL, CAST(N'2023-05-16T14:14:53.8000000' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Username], [Email], [PasswordHash], [DateOfBirth], [Bio], [ProfilePicture], [CreatedAt], [LastLogin]) VALUES (50, NULL, NULL, N'Liam1', N'Liam1', N'$2a$11$SXesTlKcvK0z9GQe8mU1f.nQnhL4oy3rWenW5STnIlqe0pwVMTZDK', NULL, NULL, NULL, CAST(N'2023-05-16T22:23:00.1833333' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInterest] ON 
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (4, 2, 1)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (5, 2, 2)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (6, 2, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (7, 1, 5)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (32, 40, 8)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (33, 40, 9)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (34, 40, 14)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (35, 40, 7)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (36, 40, 10)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (37, 40, 6)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (38, 40, 11)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (39, 40, 15)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (40, 40, 1)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (41, 40, 4)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (42, 40, 2)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (43, 40, 5)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (44, 40, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (45, 40, 13)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (46, 40, 12)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (47, 42, 14)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (48, 42, 10)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (49, 42, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (50, 42, 13)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (51, 42, 6)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (52, 42, 9)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (53, 42, 8)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (54, 42, 11)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (55, 42, 4)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (56, 42, 15)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (57, 47, 7)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (58, 29, 15)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (59, 29, 5)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (60, 29, 4)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (61, 29, 10)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (62, 29, 14)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (63, 29, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (64, 29, 13)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (65, 29, 1)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (66, 29, 8)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (67, 29, 9)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (68, 48, 7)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (69, 48, 14)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (70, 48, 13)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (71, 48, 12)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (72, 48, 6)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (73, 48, 15)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (74, 48, 2)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (75, 48, 3)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (76, 48, 11)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (79, 50, 7)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (80, 50, 4)
GO
INSERT [dbo].[UserInterest] ([UserInterestId], [UserId], [InterestId]) VALUES (81, 50, 15)
GO
SET IDENTITY_INSERT [dbo].[UserInterest] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Interest__DFDA5A9D75B96092]    Script Date: 5/17/2023 4:57:12 PM ******/
ALTER TABLE [dbo].[Interest] ADD  CONSTRAINT [UQ__Interest__DFDA5A9D75B96092] UNIQUE NONCLUSTERED 
(
	[InterestName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__AB6E6164232B07E4]    Script Date: 5/17/2023 4:57:12 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__Users__AB6E6164232B07E4] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC57249F9C6C8]    Script Date: 5/17/2023 4:57:12 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__Users__F3DBC57249F9C6C8] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Conversation] ADD  CONSTRAINT [DF__Conversat__start__48CFD27E]  DEFAULT (getdate()) FOR [StartTime]
GO
ALTER TABLE [dbo].[Match] ADD  CONSTRAINT [DF__Matches__match_d__44FF419A]  DEFAULT (getdate()) FOR [MatchDate]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF__Messages__timest__4D94879B]  DEFAULT (getdate()) FOR [TimeStamp]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__Users__created_a__398D8EEE]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [FK__Conversat__match__47DBAE45] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [FK__Conversat__match__47DBAE45]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Status] FOREIGN KEY([user1_status])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Status]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Status1] FOREIGN KEY([user2_status])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Status1]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_User] FOREIGN KEY([User2Id])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_User]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_User1] FOREIGN KEY([User1Id])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_User1]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Messages__conver__4BAC3F29] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[Conversation] ([ConversationId])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Messages__conver__4BAC3F29]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK__Messages__sender__4CA06362] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK__Messages__sender__4CA06362]
GO
ALTER TABLE [dbo].[UserInterest]  WITH CHECK ADD  CONSTRAINT [FK__User_Inte__inter__403A8C7D] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interest] ([InterestId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInterest] CHECK CONSTRAINT [FK__User_Inte__inter__403A8C7D]
GO
ALTER TABLE [dbo].[UserInterest]  WITH CHECK ADD  CONSTRAINT [FK__User_Inte__user___3F466844] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UserInterest] CHECK CONSTRAINT [FK__User_Inte__user___3F466844]
GO
