-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE PROCEDURE edfi.SetCurrentSchoolYear 
    @schoolYear int
AS
BEGIN
    SET NOCOUNT ON

    IF NOT EXISTS(
        SELECT SchoolYear 
        FROM edfi.SchoolYearType 
        WHERE SchoolYear = @schoolYear)
    BEGIN
        THROW 50000, N'Specified school year does not exist.', 1
    END

    UPDATE [edfi].[SchoolYearType]
       SET [CurrentSchoolYear] = 0
    WHERE SchoolYear <> @schoolYear

    UPDATE [edfi].[SchoolYearType]
       SET [CurrentSchoolYear] = 1
    WHERE SchoolYear = @schoolYear

END
