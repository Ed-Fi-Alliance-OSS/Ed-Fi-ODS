DO $$
BEGIN
    IF NOT EXISTS(
        SELECT schema_name
          FROM information_schema.schemata
          WHERE schema_name = 'tracked_deletes_samplestudenttransportation'
      )
    THEN
      EXECUTE 'CREATE SCHEMA tracked_deletes_samplestudenttransportation AUTHORIZATION postgres';
    END IF;

END
$$;
