-- Creating primary key on [DRInvestigationDRDR_REPORT_NUM] in table 'DRHearings'
ALTER TABLE [dbo].[DRHEARING]
ADD CONSTRAINT [PK_DRHEARING]
    PRIMARY KEY CLUSTERED ([DRInvestigationDRDR_REPORT_NUM] ASC);
GO

-- Creating primary key on [DRDR_REPORT_NUM] in table 'DRINVESTIGATION'
ALTER TABLE [dbo].[DRINVESTIGATION]
ADD CONSTRAINT [PK_DRINVESTIGATION]
    PRIMARY KEY CLUSTERED ([DRDR_REPORT_NUM] ASC);
GO

-- Creating primary key on [DR_REPORT_NUM] in table 'DR'
ALTER TABLE [dbo].[DR]
ADD CONSTRAINT [PK_DR]
    PRIMARY KEY CLUSTERED ([DR_REPORT_NUM] ASC);
GO

-- Creating primary key on [LOC_CODE] in table 'LOCATION'
ALTER TABLE [dbo].[LOCATION]
ADD CONSTRAINT [PK_LOCATION]
    PRIMARY KEY CLUSTERED ([LOC_CODE] ASC);
GO

-- Creating primary key on [VIO_CODE] in table 'VIOLATION'
ALTER TABLE [dbo].[VIOLATION]
ADD CONSTRAINT [PK_VIOLATION]
    PRIMARY KEY CLUSTERED ([VIO_CODE] ASC);
GO

-- Creating primary key on [EMP_ID] in table 'EMPLOYEE'
ALTER TABLE [dbo].[EMPLOYEE]
ADD CONSTRAINT [PK_EMPLOYEE]
    PRIMARY KEY CLUSTERED ([EMP_ID] ASC);
GO

-- Creating primary key on [HOUSE_LOC_CODE] in table 'HOUSINGLOCATION'
ALTER TABLE [dbo].[HOUSINGLOCATION]
ADD CONSTRAINT [PK_HOUSINGLOCATION]
    PRIMARY KEY CLUSTERED ([HOUSE_LOC_CODE] ASC);
GO

-- Creating primary key on [INC_LOC_CODE] in table 'INCIDENTLOCATION'
ALTER TABLE [dbo].[INCIDENTLOCATION]
ADD CONSTRAINT [PK_INCIDENTLOCATION]
    PRIMARY KEY CLUSTERED ([INC_LOC_CODE] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------
-- Creating foreign key on [RoleROLE_ID] in table 'EMPLOYEE'
ALTER TABLE [dbo].[EMPLOYEE]
ADD CONSTRAINT [FK_ROLEEMPLOYEE] FOREIGN KEY ([RoleROLE_ID])
    REFERENCES [dbo].[ROLE]([ROLE_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating foreign key on [EmployeeEMP_ID] in table 'DR'
ALTER TABLE [dbo].[DR]
ADD CONSTRAINT [FK_EmployeeDR]
    FOREIGN KEY ([EmployeeEMP_ID])
    REFERENCES [dbo].[Employee]
        ([EMP_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeDR'
CREATE INDEX [IX_FK_EmployeeDR]
ON [dbo].[DR]
    ([EmployeeEMP_ID]);
GO

-- Creating foreign key on [ViolationVIO_CODE] in table 'DR'
ALTER TABLE [dbo].[DR]
ADD CONSTRAINT [FK_ViolationDR]
    FOREIGN KEY ([ViolationVIO_CODE])
    REFERENCES [dbo].[Violation]
        ([VIO_CODE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ViolationDR'
CREATE INDEX [IX_FK_ViolationDR]
ON [dbo].[DR]
    ([ViolationVIO_CODE]);
GO

-- Creating foreign key on [DRDR_REPORT_NUM] in table 'DRInvestigation'
ALTER TABLE [dbo].[DRInvestigation]
ADD CONSTRAINT [FK_DRDRInvestigation]
    FOREIGN KEY ([DRDR_REPORT_NUM])
    REFERENCES [dbo].[DR]
        ([DR_REPORT_NUM])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DRInvestigationDRDR_REPORT_NUM] in table 'DRHearing'
ALTER TABLE [dbo].[DRHearing]
ADD CONSTRAINT [FK_DRInvestigationDRHearing]
    FOREIGN KEY ([DRInvestigationDRDR_REPORT_NUM])
    REFERENCES [dbo].[DRInvestigation]
        ([DRDR_REPORT_NUM])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO