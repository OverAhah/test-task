SELECT * FROM EPMLOYEE
WHERE SALARY - (SELECT MAX(SELERY) FROM EPMLOYEE)