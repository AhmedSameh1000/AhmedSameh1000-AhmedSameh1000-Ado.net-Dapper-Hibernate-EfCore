USE [EF016]
GO

/****** Object: SqlProcedure [dbo].[sp_GetSectionDetails] Script Date: 10/28/2023 9:34:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE or alter  PROCEDURE [dbo].[sp_GetSectionDetails]
    @SectionId INT
AS
BEGIN
    SELECT
        S.Id,
        C.CourseName,
        C.HoursToComplete TotalHours,
        S.SectionName,
        (I.FName + ' ' + I.LName) As Instructor,
        FORMAT(S.[StartDate], 'yyyy-MM-dd') + ' - ' + FORMAT(S.[EndDate], 'yyyy-MM-dd') As Period,
           COALESCE(CONVERT(VARCHAR, S.[StartTime], 108), 'N/A') 
            + ' - ' + 
            COALESCE(CONVERT(VARCHAR, S.[EndTime], 108), 'N/A') 
            + ' (' + 
            CAST(DATEDIFF(HOUR, S.[StartTime], S.[EndTime]) AS VARCHAR(2)) + ' hrs)' As Timeslot,
        SC.SUN,
        SC.MON,
        SC.Tue,
        SC.WED,
        SC.THU,
        SC.FRI,
        SC.SAT,
            CAST((DATEDIFF(MINUTE, S.StartTime, S.EndTime)/60.0) * 
                CASE 
                    WHEN SC.ScheduleType = 'Daily' THEN 7
                    WHEN SC.ScheduleType = 'DayAfterDay' THEN 3
                    WHEN SC.ScheduleType = 'TwiceAWeek' THEN 2
                    WHEN SC.ScheduleType = 'Weekend' THEN 2
                    WHEN SC.ScheduleType = 'Compact' THEN 7
                    ELSE 0
                END AS INT) AS HoursPerWeek
    FROM Sections S
    JOIN Courses C ON S.CourseId = C.Id
    JOIN Schedules SC ON S.ScheduleId = SC.Id
    JOIN Instructors I ON S.InstructorId = I.Id
    WHERE S.Id = @SectionId
END;

exec  [sp_GetSectionDetails] 1;