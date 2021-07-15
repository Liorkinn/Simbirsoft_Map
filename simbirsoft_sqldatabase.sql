-- --------------------------------------------------------
-- Хост:                         95.104.192.212
-- Версия сервера:               5.7.26-0ubuntu0.18.10.1 - (Ubuntu)
-- Операционная система:         Linux
-- HeidiSQL Версия:              11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных Liorkin
CREATE DATABASE IF NOT EXISTS `Liorkin` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `Liorkin`;

-- Дамп структуры для представление Liorkin.a
-- Создание временной таблицы для обработки ошибок зависимостей представлений
CREATE TABLE `a` (
	`id` INT(11) NOT NULL,
	`Place_id` INT(11) NULL,
	`X` DOUBLE NULL,
	`Y` DOUBLE NULL,
	`User_id` INT(11) NULL,
	`City_id` INT(11) NULL,
	`Name` VARCHAR(50) NULL COLLATE 'utf8mb4_general_ci',
	`Adress` VARCHAR(500) NULL COLLATE 'utf8mb4_general_ci',
	`Information` VARCHAR(1000) NULL COLLATE 'utf8mb4_general_ci'
) ENGINE=MyISAM;

-- Дамп структуры для таблица Liorkin.Attractions
CREATE TABLE IF NOT EXISTS `Attractions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `User_id` int(11) DEFAULT NULL,
  `Place_id` int(11) DEFAULT NULL,
  `City_id` int(11) DEFAULT NULL,
  `Coordinats_Place_id` int(11) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Adress` varchar(500) DEFAULT NULL,
  `Information` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Coordinats_Place_id` (`Coordinats_Place_id`),
  KEY `FK_Attractions_City` (`City_id`),
  KEY `FK_Attractions_Place` (`Place_id`),
  KEY `FK_Attractions_Users` (`User_id`),
  CONSTRAINT `FK_Attractions_City` FOREIGN KEY (`City_id`) REFERENCES `City` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Attractions_Coordinats_Place` FOREIGN KEY (`Coordinats_Place_id`) REFERENCES `Coordinats_Place` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Attractions_Place` FOREIGN KEY (`Place_id`) REFERENCES `Place` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Attractions_Users` FOREIGN KEY (`User_id`) REFERENCES `Users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.City
CREATE TABLE IF NOT EXISTS `City` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Coordinates_City
CREATE TABLE IF NOT EXISTS `Coordinates_City` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `City_id` int(11) DEFAULT NULL,
  `X` double DEFAULT NULL,
  `Y` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Coordinates_City` (`City_id`),
  CONSTRAINT `FK_Coordinates_City` FOREIGN KEY (`City_id`) REFERENCES `City` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Coordinats_Place
CREATE TABLE IF NOT EXISTS `Coordinats_Place` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Place_id` int(11) DEFAULT NULL,
  `X` double DEFAULT NULL,
  `Y` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Coordinats_Attractions_Place` (`Place_id`),
  CONSTRAINT `FK_Coordinats_Attractions_Place` FOREIGN KEY (`Place_id`) REFERENCES `Place` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Gender
CREATE TABLE IF NOT EXISTS `Gender` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Place
CREATE TABLE IF NOT EXISTS `Place` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Rate_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Place_Rate` (`Rate_id`),
  CONSTRAINT `FK_Place_Rate` FOREIGN KEY (`Rate_id`) REFERENCES `Rate` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Rate
CREATE TABLE IF NOT EXISTS `Rate` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Users
CREATE TABLE IF NOT EXISTS `Users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Surname` varchar(50) DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `flag` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`),
  KEY `FK_Users_Rate` (`flag`),
  CONSTRAINT `FK_Users_Rate` FOREIGN KEY (`flag`) REFERENCES `Rate` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=124 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Users_Info
CREATE TABLE IF NOT EXISTS `Users_Info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Users_id` int(11) DEFAULT NULL,
  `secname` varchar(50) DEFAULT NULL,
  `age` int(3) DEFAULT NULL,
  `about_me` varchar(250) DEFAULT NULL,
  `gender_id` int(11) DEFAULT NULL,
  `city_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Users_Info_Users` (`Users_id`),
  KEY `FK_Users_Info_Gender` (`gender_id`),
  KEY `FK_Users_Info_City` (`city_id`),
  CONSTRAINT `FK_Users_Info_City` FOREIGN KEY (`city_id`) REFERENCES `City` (`id`),
  CONSTRAINT `FK_Users_Info_Gender` FOREIGN KEY (`gender_id`) REFERENCES `Gender` (`id`),
  CONSTRAINT `FK_Users_Info_Users` FOREIGN KEY (`Users_id`) REFERENCES `Users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Visited
CREATE TABLE IF NOT EXISTS `Visited` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `User_id` int(11) DEFAULT NULL,
  `Attraction_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visited_Attractions` (`Attraction_id`),
  KEY `FK__Users` (`User_id`),
  CONSTRAINT `FK_Visited_Attractions` FOREIGN KEY (`Attraction_id`) REFERENCES `Attractions` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK__Users` FOREIGN KEY (`User_id`) REFERENCES `Users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для таблица Liorkin.Visited_City
CREATE TABLE IF NOT EXISTS `Visited_City` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `User_id` int(11) DEFAULT NULL,
  `City_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visited_City_City` (`City_id`),
  KEY `FK_Visited_City_Users` (`User_id`),
  CONSTRAINT `FK_Visited_City_City` FOREIGN KEY (`City_id`) REFERENCES `City` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Visited_City_Users` FOREIGN KEY (`User_id`) REFERENCES `Users` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;

-- Экспортируемые данные не выделены.

-- Дамп структуры для представление Liorkin.a
-- Удаление временной таблицы и создание окончательной структуры представления
DROP TABLE IF EXISTS `a`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `a` AS select `C`.`id` AS `id`,`C`.`Place_id` AS `Place_id`,`C`.`X` AS `X`,`C`.`Y` AS `Y`,`A`.`User_id` AS `User_id`,`A`.`City_id` AS `City_id`,`A`.`Name` AS `Name`,`A`.`Adress` AS `Adress`,`A`.`Information` AS `Information` from (`Coordinats_Place` `C` join `Attractions` `A` on((`C`.`id` = `A`.`Coordinats_Place_id`)));

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
