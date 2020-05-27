-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO 
$$ 
BEGIN
   IF NOT EXISTS (SELECT 1
                  FROM information_schema.table_constraints 
                  WHERE table_schema='edfi' 
                  AND table_name = 'student'
                  AND constraint_name = 'uk_student_person')
   THEN
      ALTER TABLE edfi.student 
      ADD CONSTRAINT uk_student_person UNIQUE (personid, sourcesystemdescriptorid);
   END IF;

   IF NOT EXISTS (SELECT 1
                  FROM information_schema.table_constraints 
                  WHERE table_schema='edfi' 
                  AND table_name = 'parent'
                  AND constraint_name = 'uk_parent_person')
   THEN
      ALTER TABLE edfi.parent 
      ADD CONSTRAINT uk_parent_person UNIQUE (personid, sourcesystemdescriptorid);
   END IF;

   IF NOT EXISTS (SELECT 1
                  FROM information_schema.table_constraints 
                  WHERE table_schema='edfi' 
                  AND table_name = 'staff'
                  AND constraint_name = 'uk_staff_person')
   THEN
      ALTER TABLE edfi.staff 
      ADD CONSTRAINT uk_staff_person UNIQUE (personid, sourcesystemdescriptorid);
   END IF;
END
$$;