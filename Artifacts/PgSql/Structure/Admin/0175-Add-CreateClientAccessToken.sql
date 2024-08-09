-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE PROCEDURE dbo.CreateClientAccessToken (
	Id uuid, 
	Expiration timestamp without time zone, 
	Scope text, 
	ApiClientId integer, 
	MaxTokenCount integer)
AS
$BODY$
DECLARE
    ActiveTokenCount integer DEFAULT 0;
BEGIN
        ActiveTokenCount := (SELECT COUNT(1)
        FROM dbo.clientaccesstokens actoken
        WHERE apiclient_apiclientid = ApiClientId AND actoken.Expiration > current_timestamp at time zone 'utc');
    IF (MaxTokenCount < 1) OR (ActiveTokenCount < MaxTokenCount)  THEN
        INSERT INTO dbo.ClientAccessTokens(id, expiration, scope, apiclient_apiclientid) VALUES (Id, Expiration, Scope, ApiClientId);
    ELSE
        RAISE EXCEPTION 'Token limit reached';
    END IF;
END
$BODY$
LANGUAGE plpgsql;
