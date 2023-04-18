WITH RECURSIVE ManagerHierarchy AS (
  SELECT id, CHIEF_ID, 1 AS Depth
  FROM EMPLOYEE
  WHERE CHIEF_ID IS NULL
  UNION ALL
  SELECT EMPLOYEE.id, EMPLOYEE.CHIEF_ID, ManagerHierarchy.Depth + 1
  FROM EMPLOYEE
  INNER JOIN ManagerHierarchy ON EMPLOYEE.CHIEF_ID = ManagerHierarchy.id
)
SELECT MAX(Depth) AS MaxDepth
FROM ManagerHierarchy;