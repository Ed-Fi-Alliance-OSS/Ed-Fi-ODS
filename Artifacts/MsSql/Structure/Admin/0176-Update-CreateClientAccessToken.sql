 -- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR ALTER PROCEDURE dbo.CreateClientAccessToken(
    @Id UNIQUEIDENTIFIER = NULL,
    @Expiration DATETIME = NULL,
    @Scope NVARCHAR(max) = NULL,
    @ApiClientId INT = NULL,
    @MaxTokenCount INT = NULL
)
AS
BEGIN
  SET NOCOUNT ON

  DECLARE @ActiveTokenCount INT
  DECLARE @ClientIsApproved INT
  
  SET @ClientIsApproved = (SELECT COUNT(1)
                                     FROM dbo.ApiClients ac
                                     WHERE ac.ApiClientId = @ApiClientId
                                       AND ac.IsApproved = 1)
                                       
  IF (@ClientIsApproved = 0)
  BEGIN
    THROW 50000, 'Client is not approved', 1;
  END
	
	IF @MaxTokenCount < 1
		SET @ActiveTokenCount = 0
	ELSE
	BEGIN                                 
    SET @ActiveTokenCount = (SELECT COUNT(1)
                                     FROM dbo.ClientAccessTokens actoken
                                     WHERE ApiClient_ApiClientId = @ApiClientId
                                       AND actoken.Expiration > GETUTCDATE())
	END
	
  IF (@MaxTokenCount < 1) OR (@ActiveTokenCount < @MaxTokenCount)
	BEGIN
        INSERT INTO dbo.ClientAccessTokens(Id, Expiration, Scope, ApiClient_ApiClientId)
        VALUES (@Id, @Expiration, @Scope, @ApiClientId)
	END
    ELSE
		THROW 50000, 'Token limit reached', 1;
END
GO
