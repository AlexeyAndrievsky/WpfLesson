CREATE TABLE [dbo].[Employers] (
    [Id_Employee]   INT            IDENTITY (1, 1) NOT NULL,
    [EmpSurname]    NVARCHAR (255) NULL,
    [EmpName]      NVARCHAR (255) NULL,
    [EmpSecondName] NVARCHAR (255) NULL,
    [Birthday]      DATE           NULL,
    [Id_Department] INT            NOT NULL,
    [Salary]        MONEY          NULL,
    PRIMARY KEY CLUSTERED ([Id_Employee] ASC),
    CONSTRAINT [FK_Employers_Id_Department] FOREIGN KEY ([Id_Department]) REFERENCES [dbo].[Departments] ([Id_Department])
);

