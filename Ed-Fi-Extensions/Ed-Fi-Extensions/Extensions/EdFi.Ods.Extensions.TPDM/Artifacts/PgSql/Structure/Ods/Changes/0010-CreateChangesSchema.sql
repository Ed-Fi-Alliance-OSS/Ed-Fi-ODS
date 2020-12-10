DO $$
BEGIN
    IF NOT EXISTS(
        SELECT schema_name
          FROM information_schema.schemata
          WHERE schema_name = 'changes'
      )
    THEN
      EXECUTE 'CREATE SCHEMA changes AUTHORIZATION postgres';
    END IF;

END
$$;