USE [Teste]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 22/02/2019 20:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
	[ISBN] [nvarchar](13) NULL,
	[Language] [nvarchar](2) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SpI_Book]    Script Date: 22/02/2019 20:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SpI_Book] (
	@Title	nvarchar(100),
	@Description	nvarchar(1000),
	@ISBN	nvarchar(13),
	@Language	nvarchar(2)
)

AS

BEGIN TRY

	BEGIN TRAN

	INSERT INTO [dbo].[Book] (
		Title,
		Description,
		ISBN,
		Language
	) VALUES (
		@Title,
		@Description,
		@ISBN, 
		@Language
	)

	COMMIT TRAN

	SELECT CAST(SCOPE_IDENTITY() as bigint) AS Result, 'Success' AS ErrorMessage

END TRY

BEGIN CATCH

	IF @@ERROR > 0 BEGIN

		SELECT -1 AS Result, ERROR_MESSAGE() AS ErrorMessage
		ROLLBACK TRAN

	END	
		
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SpS_Book]    Script Date: 22/02/2019 20:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[SpS_Book] (
	@Id	int
)

AS

SELECT ID, Title, Description, ISBN, Language
FROM [dbo].[Book]
WHERE ID = @Id

GO
