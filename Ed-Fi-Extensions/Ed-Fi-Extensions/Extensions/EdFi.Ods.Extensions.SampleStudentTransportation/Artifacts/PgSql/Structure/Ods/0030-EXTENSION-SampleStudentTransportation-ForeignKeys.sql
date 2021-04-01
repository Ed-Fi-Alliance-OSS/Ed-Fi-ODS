ALTER TABLE samplestudenttransportation.StudentTransportation ADD CONSTRAINT FK_68afad_School FOREIGN KEY (SchoolId)
REFERENCES edfi.School (SchoolId)
;

CREATE INDEX FK_68afad_School
ON samplestudenttransportation.StudentTransportation (SchoolId ASC);

ALTER TABLE samplestudenttransportation.StudentTransportation ADD CONSTRAINT FK_68afad_Student FOREIGN KEY (StudentUSI)
REFERENCES edfi.Student (StudentUSI)
;

CREATE INDEX FK_68afad_Student
ON samplestudenttransportation.StudentTransportation (StudentUSI ASC);

