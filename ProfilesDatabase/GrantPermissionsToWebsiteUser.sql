EXEC sp_change_users_login 'Report'

EXEC sp_change_users_login 'Auto_Fix', 'App_ResNav_People', NULL, 'E29CC$3zya25!B4D53'


-- Grant Permissions for Website User
-- 1 - Variable declarations
SET NOCOUNT ON
DECLARE @user SYSNAME

-- 2 - Set @user variable
SELECT @user='App_ResNav_People'
 
-- 4 - Populate temporary table
SELECT  'GRANT EXEC ON ' + '[' + ROUTINE_SCHEMA + ']' + '.' + '[' +ROUTINE_NAME + ']' + ' TO ' + @user
	   call
  INTO #storedprocedures
  FROM INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_NAME NOT LIKE 'dt_%'
   AND ROUTINE_TYPE = 'PROCEDURE'

-- 6 - WHILE loop
WHILE exists (SELECT TOP 1 * FROM #storedprocedures  )
	BEGIN
	 
		DECLARE @sql varchar(max)
		SELECT TOP 1 @sql=call
		  FROM #storedprocedures
		DELETE	
		  FROM #storedprocedures
		 WHERE call=@sql
		EXEC (@SQL)
	END
DROP TABLE #storedprocedures