-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: cinema
-- ------------------------------------------------------
-- Server version	5.7.15-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `mobile_number` varchar(20) NOT NULL,
  `email_address` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (5,'Novy John','Albancia','09461353335','iflickstarzz@gmail.com');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movies`
--

DROP TABLE IF EXISTS `movies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movies` (
  `idmovies` int(11) NOT NULL AUTO_INCREMENT,
  `movie_title` varchar(45) NOT NULL,
  `number_in_stock` int(11) NOT NULL,
  `rental_daily_rate` double NOT NULL,
  `release_year` int(11) NOT NULL,
  `image` varchar(45) NOT NULL,
  PRIMARY KEY (`idmovies`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movies`
--

LOCK TABLES `movies` WRITE;
/*!40000 ALTER TABLE `movies` DISABLE KEYS */;
INSERT INTO `movies` VALUES (1,'Assasins Creed',2,250,2015,'assasinsCreed.jpg'),(2,'Beauty and the Beast',1,500,2017,'beautyAndTheBeast.jpg'),(3,'Before I Fall',3,400,2017,'beforeIFall.jpg'),(4,'The BFG',1,400,2016,'bfg.jpg'),(5,'Doctor Strange',7,500,2016,'doctorStrange.jpg'),(6,'Fantastic Beasts',1,250,2016,'fantasticBeasts.jpg'),(7,'Fifty Shades Darker',5,500,2017,'fiftyShadesDarker.jpg'),(8,'The Fate of the Furious',6,500,2017,'fnf7.jpg'),(9,'Ghost in the Shell',4,300,2017,'ghostInTheShell.jpg'),(10,'Guardians of the Galaxy',2,400,2014,'guardiansOfTheGalaxy.jpg'),(11,'Ice Age: Collision Course',3,350,2016,'iceAgeCollisionCourse.jpg'),(12,'John Wick: Chapter 2',5,500,2017,'johnWick2.jpg'),(13,'Kong: Skull Island',4,400,2017,'kongSkullIland.jpg'),(14,'Logan',8,500,2017,'logan.jpg'),(15,'Paterson',4,250,2016,'paterson.jpg'),(16,'Power Rangers',6,400,2017,'powerRangers.jpg'),(17,'Rogue One',7,500,2016,'rogueOne.jpg'),(18,'Sing',4,350,2016,'sing.jpg'),(19,'The Notebook',6,300,2004,'theNotebook.jpg'),(20,'Trolls',4,300,2016,'trolls.jpg'),(21,'The Magnificent Seven',2,400,2016,'magnificentSeven.jpg'),(22,'Moana',3,400,2016,'moana.jpg'),(23,'The Shack',4,250,2016,'theShack.jpg'),(24,'The Passengers',1,400,2016,'passengers.jpg'),(25,'Finding Dory',4,300,2016,'findingDory.jpg'),(26,'Underworld Bloody War',3,200,2017,'underworldBloodyWar.jpg');
/*!40000 ALTER TABLE `movies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rental_status`
--

DROP TABLE IF EXISTS `rental_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rental_status` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idmovies` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `status` varchar(45) NOT NULL,
  `due_date` datetime NOT NULL,
  `rent_date` datetime NOT NULL,
  `is_overdue` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rental_status`
--

LOCK TABLES `rental_status` WRITE;
/*!40000 ALTER TABLE `rental_status` DISABLE KEYS */;
INSERT INTO `rental_status` VALUES (6,3,5,1,'returned','2017-08-01 00:00:00','2017-07-27 00:00:00',0),(7,12,5,1,'on rent','2017-08-01 00:00:00','2017-07-27 00:00:00',0);
/*!40000 ALTER TABLE `rental_status` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-08-01 11:44:24
