SELECT DEPARTMENT.NAME AS Отдел, SUM(EMPLOYEE.SALARY) AS СуммарнаяЗарплата
FROM EMPLOYEE
JOIN DEPARTMENT ON EMPLOYEE.DEPARTMENT_ID = DEPARTMENT.id
GROUP BY DEPARTMENT.NAME
ORDER BY СуммарнаяЗарплата DESC
LIMIT 1;