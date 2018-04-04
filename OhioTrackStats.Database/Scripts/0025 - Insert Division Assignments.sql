DECLARE @divisionOneId UNIQUEIDENTIFIER;
DECLARE @divisionTwoId UNIQUEIDENTIFIER;
DECLARE @divisionThreeId UNIQUEIDENTIFIER;
DECLARE @year INT = 2018;
DECLARE @male NVARCHAR(10) = 'Male';
DECLARE @female NVARCHAR(10) = 'Female';

SELECT TOP 1 @divisionOneId = d.[Id] FROM [dbo].[Division] d WHERE d.[Name] = '1';
SELECT TOP 1 @divisionTwoId = d.[Id] FROM [dbo].[Division] d WHERE d.[Name] = '2';
SELECT TOP 1 @divisionThreeId = d.[Id] FROM [dbo].[Division] d WHERE d.[Name] = '3';

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionOneId,
	s.[Id],
	@male,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[MaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionOneId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[MaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionOneId AND de.[Year] = @year);

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionTwoId,
	s.[Id],
	@male,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[MaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionTwoId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[MaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionTwoId AND de.[Year] = @year);

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionThreeId,
	s.[Id],
	@male,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[MaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionThreeId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[MaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionThreeId AND de.[Year] = @year);

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionOneId,
	s.[Id],
	@female,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[FemaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionOneId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[FemaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionOneId AND de.[Year] = @year);

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionTwoId,
	s.[Id],
	@female,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[FemaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionTwoId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[FemaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionTwoId AND de.[Year] = @year);

INSERT INTO
	[DivisionAssignment] (
		[DivisionId],
		[SchoolId],
		[Gender],
		[Year])
SELECT
	@divisionThreeId,
	s.[Id],
	@female,
	@year
FROM
	[dbo].[School] s
	INNER JOIN [dbo].[Enrollment] e ON e.[SchoolId] = s.[Id]
WHERE
	e.[Year] = @year AND
	e.[Male] >= (SELECT TOP 1 de.[FemaleMin] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionThreeId AND de.[Year] = @year) AND
	e.[Male] <= (SELECT TOP 1 de.[FemaleMax] FROM [dbo].[DivisionEnrollment] de WHERE de.[DivisionId] = @divisionThreeId AND de.[Year] = @year);