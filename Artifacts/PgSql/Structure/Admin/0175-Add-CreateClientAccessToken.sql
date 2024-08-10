-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE OR REPLACE PROCEDURE dbo.CreateClientAccessToken(
    id uuid,
    expiration timestamp without time zone,
    scope text,
    apiclientid integer,
    maxtokencount integer)
AS
$BODY$
DECLARE
    active_token_count integer = 0;
BEGIN
    active_token_count := (SELECT COUNT(1)
                           FROM dbo.clientaccesstokens actoken
                           WHERE apiclient_apiclientid = ApiClientId
                             AND actoken.expiration > current_timestamp at time zone 'utc');
    IF (maxtokencount < 1) OR (active_token_count < maxtokencount) THEN
        INSERT INTO dbo.ClientAccessTokens(id, expiration, scope, apiclient_apiclientid)
        VALUES (CreateClientAccessToken.id, CreateClientAccessToken.expiration, CreateClientAccessToken.scope,
                apiclientid);
    ELSE
        RAISE EXCEPTION USING MESSAGE = 'Token limit reached';
    END IF;
END
$BODY$
    LANGUAGE plpgsql;
