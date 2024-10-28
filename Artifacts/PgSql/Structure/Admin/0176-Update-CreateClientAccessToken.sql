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
    active_token_count integer;
    client_is_approved integer;
BEGIN

  	SELECT count(1)
  	INTO client_is_approved
    FROM dbo.apiclients ac
    WHERE ac.apiclientid = createclientaccesstoken.ApiClientId
	    AND ac.isapproved = true;
  
  	IF (client_is_approved = 0) THEN
  		RAISE EXCEPTION USING MESSAGE = 'Client is not approved';
  	END IF;

    IF maxtokencount < 1 THEN
        active_token_count := 0;
    ELSE
        active_token_count := (SELECT COUNT(1)
                               FROM dbo.clientaccesstokens actoken
                               WHERE apiclient_apiclientid = ApiClientId
                                 AND actoken.expiration > current_timestamp at time zone 'utc');
    END IF;

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
