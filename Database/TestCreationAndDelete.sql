--CREATE SCHEMA TEST

CREATE TABLE TEST.Users
(
   UserID         int NOT NULL IDENTITY PRIMARY KEY
 , FName          nvarchar(30) NOT NULL
 , LName          nvarchar(30) NOT NULL
 , Email          nvarchar(60)
   UNIQUE NOT NULL
 , AreaOfInterest nvarchar(250) NULL
 , Background     nvarchar(250) NULL
 , Location       nvarchar(100) NULL
)

CREATE TABLE TEST.UserPasswords
(
   UserID   int
   UNIQUE
   FOREIGN KEY REFERENCES TEST.Users(UserID) NOT NULL
 , HashPass nchar(33) NOT NULL
				  CHECK(LEN(HashPass) = 32)
)

CREATE TABLE TEST.UserSalts
(
   UserID int
   UNIQUE
   FOREIGN KEY REFERENCES TEST.Users(UserID) NOT NULL
 , Salt   nchar(33) NOT NULL
				CHECK(LEN(Salt) = 32)
)

CREATE TABLE TEST.Supervisors
(
   SupervisorID             int IDENTITY PRIMARY KEY NOT NULL
 , UserID                   int
   UNIQUE
   FOREIGN KEY REFERENCES TEST.Users(UserID) NOT NULL
 , CertificationNumber      nvarchar(30) NOT NULL
 , DateCertified            date NOT NULL
 , DateCompletedSupervision date NOT NULL
 , DistanceSupervision      bit DEFAULT 1
)

CREATE TABLE TEST.Relationships
(
   RelationshipID int IDENTITY PRIMARY KEY NOT NULL
 , SupervisorID   int FOREIGN KEY REFERENCES TEST.Supervisors(SupervisorID) NOT NULL
 , SuperviseeID   int FOREIGN KEY REFERENCES TEST.Users(UserID) NOT NULL
 , StartDate      date NOT NULL
 , EndDate        date DEFAULT NULL
)

CREATE TABLE TEST.GradeCategories
(
   GradeID           int IDENTITY PRIMARY KEY NOT NULL
 , GradeAbbreviation nvarchar(8) NOT NULL
						   DEFAULT 'NO_ABRV'
 , GradeTitle        nvarchar(30) NOT NULL
)

CREATE TABLE TEST.Forms
(
   FormID                int IDENTITY PRIMARY KEY NOT NULL
 , RelationshipID        int FOREIGN KEY REFERENCES TEST.Relationships(RelationshipID) NOT NULL
 , StartDate             date NOT NULL
 , EndDate               date NULL
 , SupervisonMeetingDate date NULL
 , SupervisionDuration   time(3) NULL
 , Comments              nvarchar(350) NULL
 , FormGrade             int FOREIGN KEY REFERENCES TEST.GradeCategories(GradeID) NULL
 , ValidFlag             bit NULL
)

CREATE TABLE TEST.SkillCategories
(
   SkillID          int IDENTITY PRIMARY KEY NOT NULL
 , SkillDescription nvarchar(120) NOT NULL
)

CREATE TABLE TEST.FormSkills
(
   FormID  int REFERENCES TEST.Forms(FormID) NOT NULL
 , SkillID int FOREIGN KEY REFERENCES TEST.SkillCategories(SkillID) NOT NULL
 , GradeID int FOREIGN KEY REFERENCES TEST.GradeCategories(GradeID) NOT NULL
)

CREATE TABLE TEST.CompetencyCategories
(
   CompetencyID           int IDENTITY PRIMARY KEY NOT NULL
 , CompetencyAbbreviation nvarchar(15) NOT NULL
 , CompetencyDescription  nvarchar(250) NULL
)

CREATE TABLE TEST.FormCompetencies
(
   FormID       int FOREIGN KEY REFERENCES TEST.Forms(FormID) NOT NULL
 , CompetencyID int FOREIGN KEY REFERENCES TEST.CompetencyCategories(CompetencyID) NOT NULL
)

CREATE TABLE TEST.ActivityCategories
(
   ActivityID          int IDENTITY PRIMARY KEY NOT NULL
 , ActivityName        nvarchar(30) NOT NULL
 , ActivityDescription nvarchar(250) NULL
)

CREATE TABLE TEST.FormActivities
(
   FormID           int FOREIGN KEY REFERENCES TEST.Forms(FormID) NOT NULL
 , ActivityID       int FOREIGN KEY REFERENCES TEST.ActivityCategories(ActivityID) NOT NULL
 , ActivityDuration time(3) NOT NULL
)


--DROP TABLE TEST.FormCompetencies
--DROP TABLE TEST.FormSkills
--DROP TABLE TEST.FormActivities

--DROP TABLE TEST.ActivityCategories
--DROP TABLE TEST.SkillCategories
--DROP TABLE TEST.CompetencyCategories
--DROP TABLE TEST.GradeCategories

--DROP TABLE TEST.Forms
--DROP TABLE TEST.Relationships
--DROP TABLE TEST.Supervisors
--DROP TABLE TEST.UserPasswords
--DROP TABLE TEST.UserSalts
--DROP TABLE TEST.Users