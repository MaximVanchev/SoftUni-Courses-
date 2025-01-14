USE Gringotts

--1. Records� Count
SELECT COUNT(*)
FROM WizzardDeposits

--2. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--3. Longest Magic Wand per Deposit Groups
SELECT DepositGroup , MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--4. Smallest Deposit Group per Magic Wand Size
SELECT TOP (2) S.DepositGroup
FROM
(
SELECT DepositGroup , AVG(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup
) AS S
ORDER BY S.LongestMagicWand

--5. Deposits Sum
SELECT DepositGroup , SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--6. Deposits Sum for Ollivander Family
SELECT DepositGroup , SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7. Deposits Filter
SELECT DepositGroup , SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup , MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family' AND SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC

--8. Deposit Charge
SELECT DepositGroup , MagicWandCreator , MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup , MagicWandCreator
ORDER BY MagicWandCreator , DepositGroup

--9. Age Groups
WITH CTE_AgeCases (AgeGroup)
AS
(
SELECT
CASE 
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END AS AgeGroup
FROM WizzardDeposits
)

SELECT AC.AgeGroup , COUNT(AC.AgeGroup) AS WizardCount
FROM CTE_AgeCases AS AC
GROUP BY AC.AgeGroup

--10. First Letter
SELECT LEFT(FirstName , 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName , 1)

--11. Average Interest
SELECT DepositGroup , IsDepositExpired , AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup , IsDepositExpired
ORDER BY DepositGroup DESC , IsDepositExpired

--12. * Rich Wizard, Poor Wizard


--13. Departments Total Salaries
USE SoftUni

SELECT DepartmentID , SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID , MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2 , 5 , 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT *
INTO E2
FROM Employees
WHERE Salary > 30000

DELETE FROM E2 WHERE ManagerID = 42;

UPDATE E2
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID , AVG(Salary)
FROM E2
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID , MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--18. 3rd Highest Salary
SELECT	S.DepartmentID , S.Salary AS ThirdHighestSalary
FROM
(
SELECT DepartmentID , Salary 
, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
FROM Employees
GROUP BY DepartmentID , Salary
) AS S
WHERE Rank = 3

--19. Salary Challenge
SELECT TOP(10) E.FirstName , E.LastName , E.DepartmentID
FROM Employees AS E
JOIN
(
SELECT DepartmentID , AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentID
) AS S
ON E.DepartmentID = S.DepartmentID
WHERE E.Salary > S.AverageSalary
ORDER BY E.DepartmentID