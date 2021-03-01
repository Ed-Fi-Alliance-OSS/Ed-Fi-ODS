DO $$
BEGIN
    IF NOT EXISTS(
        SELECT schema_name
          FROM information_schema.schemata
          WHERE schema_name = 'tracked_deletes_homograph'
      )
    THEN
      EXECUTE 'CREATE SCHEMA tracked_deletes_homograph AUTHORIZATION postgres';
    END IF;

END
$$;
