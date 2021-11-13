# .Net API Assessment

This assessment is to address the story [here](https://gist.github.com/d3hiring/4d1415d445033d316c36a56f0953f4ef) and it is developed in .Net Framework (MVC.Net, API) instead of NodeJS.

## Requirements

- Visual Studio 2019
- .Net Framework 4.8
- MySQL Server ([v.8](https://dev.mysql.com/downloads/mysql/))
- MySQL Workbench (Optional [v.8](https://dev.mysql.com/downloads/workbench/))
- MySQL For Visual Studio ([v.1.2.10](https://dev.mysql.com/downloads/windows/visualstudio/))
- Connector/Net ([v.8](https://dev.mysql.com/downloads/connector/net/))

## Installation

1. Open the solution with visual studio (Run As Administrator).
2. In Visual Studio, restore the nuget packages. (Right click on the solution &#10132; Restore Nuget Packages)
3. After the packages are completely installed, rebuild the solution. (Right click on the solution &#10132; Rebuild Solution)
4. In MySQL server, run the following script to create 3 empty tables.


```sql
CREATE TABLE `teacher` (
  `idteacher` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `active` int DEFAULT '1',
  PRIMARY KEY (`idteacher`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `student` (
  `idstudent` int NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `active` int DEFAULT '1',
  PRIMARY KEY (`idstudent`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `lesson` (
  `idlesson` int NOT NULL AUTO_INCREMENT,
  `idteacher` int NOT NULL,
  `idstudent` int NOT NULL,
  PRIMARY KEY (`idlesson`),
  KEY `fk_student_idx` (`idstudent`),
  KEY `fk_teacher_idx` (`idteacher`),
  CONSTRAINT `fk_student` FOREIGN KEY (`idstudent`) REFERENCES `student` (`idstudent`),
  CONSTRAINT `fk_teacher` FOREIGN KEY (`idteacher`) REFERENCES `teacher` (`idteacher`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

```

4. You need to update the connection string of following files, pointing to your own MySQL server.
 - d3hiring.Data &#10132; App.config &#10132; Look for keyword **`d3hiringDb`**
 - d3hiring.MVC &#10132; web.config &#10132; Look for keyword **`d3hiringDb`**
 - d3hiring.MVC.Test &#10132; App.config &#10132; Look for keyword **`d3hiringDb`**

5. The project `d3hiring.MVC` is configure debug in `IIS Express`, pointing to URL: `http://localhost:666`. You may need to change the port if it's in used.

6. Set `d3hiring.MVC` as `Startup Project` (If it's not)


You are ready to go. F5 to run the application.


## Solution Structure
There are 4 projects in the solution:
1. d3hiring.Data  &#10132; `This is data layer. using EF6.`
2. d3hiring.Biz  &#10132; `This is business layer. Contain CRUD logic.`
3. d3hiring.MVC  &#10132; `This is web layer. Contain Web API.`
4. d3hiring.MVC.Test &#10132;  `This is UnitTest.`

## Contact Me
Jackson Quan, [csquan.jackson@gmail.com](mailto:csquan.jackson@gmail.com), (+65-81953013)
