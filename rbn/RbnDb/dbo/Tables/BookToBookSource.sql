CREATE TABLE [dbo].[BookToBookSource](
	[BookToBookSourceId] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookSourceId] [int] NOT NULL,
 CONSTRAINT [PK_BookToBookSource_BookSourceId] PRIMARY KEY CLUSTERED 
(
	[BookToBookSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BookToBookSource]  WITH CHECK ADD  CONSTRAINT [FK_BookToBookSource_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO

ALTER TABLE [dbo].[BookToBookSource] CHECK CONSTRAINT [FK_BookToBookSource_Book]
GO

ALTER TABLE [dbo].[BookToBookSource]  WITH CHECK ADD  CONSTRAINT [FK_BookToBookSource_BookSource] FOREIGN KEY([BookSourceId])
REFERENCES [dbo].[BookSource] ([BookSourceId])
GO

ALTER TABLE [dbo].[BookToBookSource] CHECK CONSTRAINT [FK_BookToBookSource_BookSource]
GO
