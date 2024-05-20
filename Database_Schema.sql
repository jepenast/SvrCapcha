-- Generado por Oracle SQL Developer Data Modeler 23.1.0.087.0806
--   en:        2024-04-14 13:58:03 COT
--   sitio:      SQL Server 2012
--   tipo:      SQL Server 2012



CREATE TABLE tbAnswer (
     IdAnwer UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL, 
     idCaptcha UNIQUEIDENTIFIER NOT NULL , 
     Answer NVARCHAR (50) NOT NULL , 
     Result BIT NOT NULL , 
     TimeStamp DATETIME NOT NULL 
    )
GO

ALTER TABLE tbAnswer ADD CONSTRAINT PK_Answer PRIMARY KEY CLUSTERED (IdAnwer)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbAttempsCaptcha 
    (
     IdAttemp UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL, 
     KeyApp UNIQUEIDENTIFIER NOT NULL , 
     Attemp INTEGER NOT NULL , 
     TimeStampStart DATETIME NOT NULL , 
     TimeStampLast DATETIME NOT NULL 
    )
GO

ALTER TABLE tbAttempsCaptcha ADD CONSTRAINT PK_AttempsCaptcha PRIMARY KEY CLUSTERED (IdAttemp)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbCaptcha 
    (
     IdCapcha UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL, 
     KeyApp UNIQUEIDENTIFIER NOT NULL , 
     Image NVARCHAR (MAX) NOT NULL , 
     TimeStamp DATETIME NOT NULL 
    )
GO 

CREATE NONCLUSTERED INDEX 
    idx_Capcha ON tbCaptcha 
    ( 
     TimeStamp DESC , 
     KeyApp 
    ) 
GO

ALTER TABLE tbCaptcha ADD CONSTRAINT PK_Capcha PRIMARY KEY CLUSTERED (IdCapcha)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbErrorLog 
    (
     IdLogError INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     Proccess NVARCHAR (128) NOT NULL , 
     DateLog DATETIME NOT NULL , 
     ErrNumber INTEGER NOT NULL , 
     ErrMessage NVARCHAR (4000) NOT NULL , 
     ErrLine INTEGER NOT NULL , 
     ErrSeverity NVARCHAR (128) NOT NULL , 
     ErrState NVARCHAR (50) NOT NULL 
    )
GO 

CREATE NONCLUSTERED INDEX 
    idx_ErrorLog ON tbErrorLog 
    ( 
     DateLog DESC , 
     Proccess 
    ) 
GO

ALTER TABLE tbErrorLog ADD CONSTRAINT PK_ErrorLog PRIMARY KEY CLUSTERED (IdLogError)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbKeyApp 
    (
     [Key] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL , 
     NameApp NVARCHAR (50) NOT NULL , 
     [Value] NVARCHAR (100) NOT NULL , 
     Owner UNIQUEIDENTIFIER NOT NULL , 
     TypeApp INTEGER NOT NULL , 
     URLAPP NVARCHAR (255) NOT NULL 
    )
GO

ALTER TABLE tbKeyApp ADD CONSTRAINT tbKeyApp_PK PRIMARY KEY CLUSTERED ("Key")
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbLockApp 
    (
     IdReg UNIQUEIDENTIFIER NOT NULL , 
     KeyApp UNIQUEIDENTIFIER NOT NULL , 
     StartDim DATETIME NOT NULL , 
     EndDim DATETIME NOT NULL 
    )
GO 

    


CREATE NONCLUSTERED INDEX 
    idx_LockApp ON tbLockApp 
    ( 
     KeyApp , 
     StartDim 
    ) 
GO

ALTER TABLE tbLockApp ADD CONSTRAINT PK_LockApp PRIMARY KEY CLUSTERED (IdReg)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbLogEvent 
    (
     IdLogEvent INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     Event NVARCHAR (1000) NOT NULL , 
     DateLog DATETIME NOT NULL , 
     Status NVARCHAR (20) NOT NULL 
    )
GO 

    


CREATE NONCLUSTERED INDEX 
    idx_LogEvent ON tbLogEvent 
    ( 
     DateLog DESC , 
     Event 
    ) 
GO

ALTER TABLE tbLogEvent ADD CONSTRAINT PK_LogEvent PRIMARY KEY CLUSTERED (IdLogEvent)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbOwner 
    (
     IdOwner UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL, 
     Idregister UNIQUEIDENTIFIER NOT NULL , 
     Name NVARCHAR (100) NOT NULL , 
     EmailContact NVARCHAR (150) NOT NULL 
    )
GO 

    


CREATE NONCLUSTERED INDEX 
    idx_Owner ON tbOwner 
    ( 
     Idregister , 
     Name 
    ) 
GO

ALTER TABLE tbOwner ADD CONSTRAINT PK_Owner PRIMARY KEY CLUSTERED (IdOwner)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbTimeLife (
     idReg UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() NOT NULL , 
     KEYAPP UNIQUEIDENTIFIER NOT NULL , 
     TimeStampInit DATETIME NOT NULL , 
     TimeStampEnd DATETIME NOT NULL , 
     LockoutTime INTEGER NOT NULL , 
     Active BIT NOT NULL 
    )
GO 

    


CREATE NONCLUSTERED INDEX 
    idx_TimeLife ON tbTimeLife 
    ( 
     KEYAPP , 
     TimeStampInit , 
     TimeStampEnd 
    ) 
GO

ALTER TABLE tbTimeLife ADD CONSTRAINT PK_TimeLife PRIMARY KEY CLUSTERED (idReg)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE tbTypeValue 
    (
     idType INTEGER NOT NULL IDENTITY NOT FOR REPLICATION, 
     TypeName NVARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE tbTypeValue ADD CONSTRAINT PK_TypeValue PRIMARY KEY CLUSTERED (idType)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO
ALTER TABLE tbTypeValue ADD CONSTRAINT UN_TypeValue UNIQUE NONCLUSTERED (TypeName)
GO

ALTER TABLE tbAnswer 
    ADD CONSTRAINT FK_Answer_Captcha FOREIGN KEY 
    ( 
     idCaptcha
    ) 
    REFERENCES tbCaptcha 
    ( 
     IdCapcha 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbAttempsCaptcha 
    ADD CONSTRAINT FK_AttempsCaptcha_KeyApp FOREIGN KEY 
    ( 
     KeyApp
    ) 
    REFERENCES tbKeyApp 
    ( 
     "Key" 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbCaptcha 
    ADD CONSTRAINT FK_Capcha_KeyApp FOREIGN KEY 
    ( 
     KeyApp
    ) 
    REFERENCES tbKeyApp 
    ( 
     "Key" 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbKeyApp 
    ADD CONSTRAINT FK_KeyApp_Owner FOREIGN KEY 
    ( 
     Owner
    ) 
    REFERENCES tbOwner 
    ( 
     IdOwner 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbKeyApp 
    ADD CONSTRAINT FK_KeyApp_TypeValue FOREIGN KEY 
    ( 
     TypeApp
    ) 
    REFERENCES tbTypeValue 
    ( 
     idType 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbLockApp 
    ADD CONSTRAINT FK_LockApp_KeyApp FOREIGN KEY 
    ( 
     KeyApp
    ) 
    REFERENCES tbKeyApp 
    ( 
     "Key" 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE tbTimeLife 
    ADD CONSTRAINT FK_TimeLife_KeyApp FOREIGN KEY 
    ( 
     KEYAPP
    ) 
    REFERENCES tbKeyApp 
    ( 
     "Key" 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

CREATE VIEW vwAttemps  
AS
	SELECT 
	  KA.[Key],
	  KA.NameApp,
	  AC.Attemp,
	  AC.TimeStampStart,
	  AC.TimeStampLast,
	  AC.IdAttemp
	FROM tbKeyApp KA
	 WITH(NOLOCK)
	JOIN tbAttempsCaptcha AC WITH(NOLOCK) ON KA.[Key] = AC.KeyApp
	WHERE 
		CAST(AC.TimeStampStart AS DATE)=CAST(GETDATE() AS DATE) 
GO

CREATE VIEW vwCaptcha  AS
SELECT 
  Captcha.IdCapcha,
  Captcha.KeyApp,
  Captcha.Image,
  Captcha.TimeStamp TimeStampCreate,
  Aws.Answer,
  Aws.Result,
  Aws.TimeStamp AS TimeStampResponse
FROM tbCaptcha Captcha
 WITH(NOLOCK)
JOIN tbAnswer Aws WITH(NOLOCK) ON Captcha.IdCapcha = Aws.idCaptcha 
GO

CREATE VIEW vwKeyApp  AS
SELECT KA.[Key],
  KA.NameApp,
  KA.Value,
  TV.TypeName AS Type,
  Own.Name AS [Owner Name]
FROM tbKeyApp KA WITH(NOLOCK)
  JOIN tbOwner Own WITH(NOLOCK) ON Own.IdOwner = KA.Owner
  JOIN tbTypeValue TV WITH(NOLOCK) ON TV.idType = KA.TypeApp 
GO

CREATE VIEW vwKeyAppTime  AS
SELECT 
  KA.[Key],
  KA.NameApp,
  TL.TimeStampInit,
  TL.TimeStampEnd,
  TL.LockoutTime,
  TL.Active
FROM tbKeyApp KA
 WITH(NOLOCK)
JOIN tbTimeLife TL WITH(NOLOCK) ON KA.[Key] = TL.KEYAPP 
GO

CREATE VIEW vwLockApp  AS
SELECT 
  LA.KeyApp,
  KA.NameApp,
  LA.StartDim,
  LA.EndDim,
  KA.URLAPP,
  TV.TypeName
FROM tbLockApp LA WITH(NOLOCK)
JOIN tbKeyApp KA WITH(NOLOCK) ON KA.[Key] = LA.KeyApp
JOIN tbTypeValue TV WITH(NOLOCK) ON TV.idType = KA.TypeApp 
GO
