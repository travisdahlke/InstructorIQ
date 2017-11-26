﻿CREATE TABLE [dbo].[Session]
(
    [Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT [DF_Session_Id] DEFAULT (newsequentialid()),
    [Name] NVARCHAR(256) NOT NULL,

    [Note] NVARCHAR(MAX) NULL,

    [StartTime] DATETIMEOFFSET NULL,
    [EndTime] DATETIMEOFFSET NULL,

    [OrganizationId] UNIQUEIDENTIFIER NOT NULL,
    [TopicId] UNIQUEIDENTIFIER NOT NULL,
    [LocationId] UNIQUEIDENTIFIER NULL,
    [LeadInstructorId] UNIQUEIDENTIFIER NULL,

    [Created] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Created] DEFAULT (sysutcdatetime()),
    [CreatedBy] NVARCHAR(100) NULL,
    [Updated] DATETIMEOFFSET NOT NULL CONSTRAINT [DF_Session_Updated] DEFAULT (sysutcdatetime()),
    [UpdatedBy] NVARCHAR(100) NULL,
    [RowVersion] ROWVERSION NOT NULL,

    CONSTRAINT [PK_Session] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_Organization_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organization]([Id]),
    CONSTRAINT [FK_Session_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Topic]([Id]),
    CONSTRAINT [FK_Session_Location_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Location]([Id]),
    CONSTRAINT [FK_Session_Instructor_LeadInstructorId] FOREIGN KEY ([LeadInstructorId]) REFERENCES [Instructor]([Id]),
)

GO
CREATE INDEX [IX_Session_Name]
ON [dbo].[Session] ([Name])

GO
CREATE INDEX [IX_Session_OrganizationId]
ON [dbo].[Session] ([OrganizationId])

GO
CREATE INDEX [IX_Session_TopicId]
ON [dbo].[Session] ([TopicId])
