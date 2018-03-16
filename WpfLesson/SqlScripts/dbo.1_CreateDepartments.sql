CREATE TABLE [dbo].[Departments] (
    [Id_Department] INT            IDENTITY (1, 1) NOT NULL,
    [DeptName]      NVARCHAR (255) NULL,
    [DeptInfo]      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_Department] ASC)
);

