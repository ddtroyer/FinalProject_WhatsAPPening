CREATE TABLE [dbo].[ActivitiesList]
(
	[Id] INT NOT NULL PRIMARY KEY, 	
	[Category] NVARCHAR(50) NOT NULL, 	
	[Image] NVARCHAR(MAX) NULL, 
	[Link] NVARCHAR(MAX) NULL,
	[Venue] NVARCHAR(50) NOT NULL, 
	[PricePerPerson] NVARCHAR(50) NOT NULL,
	[StreetAddress] NVARCHAR(50) NOT NULL, 
	[City] NVARCHAR(50) NOT NULL, 
	[State] NVARCHAR(50) NOT NULL, 
	[Zip] NVARCHAR(50) NOT NULL, 
	[PhoneNumber] NVARCHAR(50) NULL, 
	[MovieName] NVARCHAR(50) NULL, 
	[MovieDescription] NVARCHAR(50) NULL, 
	[StartTime] NVARCHAR(50) NULL, 
	[LengthOfTime] NVARCHAR(50) NULL,
	[DaysOpen] NVARCHAR(50) NULL, 
	[TimesOpen] NVARCHAR(50) NULL
)
