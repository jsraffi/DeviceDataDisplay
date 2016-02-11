CREATE DATABASE  IF NOT EXISTS `datalogger` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `datalogger`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: datalogger
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `channels`
--

DROP TABLE IF EXISTS `channels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `channels` (
  `channel_no` int(11) NOT NULL AUTO_INCREMENT,
  `status` text CHARACTER SET latin1 NOT NULL,
  `channel_name` text CHARACTER SET latin1 NOT NULL,
  `display_name` text CHARACTER SET latin1 NOT NULL,
  `units` int(11) NOT NULL,
  `value` float NOT NULL DEFAULT '200',
  `minlevel` float NOT NULL DEFAULT '0',
  `maxlevel` float NOT NULL DEFAULT '0',
  `onlyminlevel` tinyint(1) NOT NULL DEFAULT '0',
  `onlymaxlevel` tinyint(1) NOT NULL DEFAULT '0',
  `alarmswitch` tinyint(1) NOT NULL DEFAULT '0',
  `DeviceRefID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`channel_no`),
  KEY `UnitofmesureRefID_idx` (`units`),
  KEY `DeviceRefID_idx` (`DeviceRefID`),
  CONSTRAINT `UnitofmesureRefID` FOREIGN KEY (`units`) REFERENCES `unitsofmesurement` (`UnitID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `channels`
--

LOCK TABLES `channels` WRITE;
/*!40000 ALTER TABLE `channels` DISABLE KEYS */;
INSERT INTO `channels` VALUES (1,'enabled','Pressure flow','Temperature',17,1000000000,200,400,0,1,0,1),(2,'enabled','Flow Control','pH',2,1000000000,500,600,0,0,1,2),(3,'enabled','Volume Control','Flow',3,1000000000,700,800,0,1,0,0),(4,'enabled','Power Control','pH',2,200,900,1000,0,1,0,0),(5,'enabled','Home audio','Flow',9,200,700,850,0,1,0,0),(6,'enabled','Camera System','Air',8,200,980,799,1,1,0,0),(7,'enabled','Audio systems','Pressure',16,200,900,499,1,1,0,0),(8,'enabled','Water System','Fahrenheit',19,200,6000,98000,0,1,0,0),(9,'enabled','Channel 9','Kelvin',1,200,0,0,1,1,0,0),(10,'enabled','Channel 10','Joule',1,200,0,0,1,1,0,0),(11,'enabled','Channel 11','meter',20,200,0,0,1,1,0,0),(12,'enabled','Channel 12','Km/hr',16,200,0,0,1,1,0,0),(13,'enabled','Channel 13','pH',18,200,0,0,1,1,0,0),(14,'enabled','Channel 14','Flow',1,200,0,0,1,1,0,0),(15,'enabled','Channel 15','Air',15,200,0,0,1,1,0,0),(16,'enabled','Channel 16','Pressure',13,200,0,0,1,1,0,0),(17,'enabled','Channel 17','Fahrenheit',15,200,0,0,1,1,0,0),(18,'enabled','Channel 18','Kelvin',18,200,0,0,1,1,0,0),(19,'enabled','Channel 19','Joule',1,200,0,0,1,1,0,0),(20,'enabled','Channel 20','meter',1,200,0,0,1,1,0,0),(21,'enabled','Channel 21','Km/hr',1,200,0,0,1,1,0,0),(22,'enabled','Channel 22','pH',1,200,0,0,1,1,0,0),(23,'enabled','Channel 23','Flow',1,200,0,0,1,1,0,0),(24,'enabled','Channel 24','Air',1,200,0,0,1,1,0,0),(25,'enabled','Channel 25','Pressure',1,200,0,0,1,1,0,0),(26,'enabled','Channel 26','Fahrenheit',1,200,0,0,1,1,0,0),(27,'enabled','Channel 27','Kelvin',1,200,0,0,1,1,0,0),(28,'enabled','Channel 28','Joule',1,200,0,0,1,1,0,0),(29,'enabled','Channel 29','meter',1,200,0,0,1,1,0,0),(30,'disabled','Channel 30','Km/hr',1,200,0,0,1,1,0,0),(31,'enabled','Channel 31','pH',1,200,0,0,1,1,0,0),(32,'disabled','Channel 32','Flow',19,200,0,0,0,0,0,0);
/*!40000 ALTER TABLE `channels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device_alarm`
--

DROP TABLE IF EXISTS `device_alarm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_alarm` (
  `alarmID` int(11) NOT NULL AUTO_INCREMENT,
  `deviceID` int(11) NOT NULL,
  `alarm_index` int(11) NOT NULL,
  `alarm_value` varchar(100) NOT NULL,
  PRIMARY KEY (`alarmID`),
  KEY `device_ref_alarm_idx` (`deviceID`),
  CONSTRAINT `device_ref_alarm` FOREIGN KEY (`deviceID`) REFERENCES `devices` (`deviceID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_alarm`
--

LOCK TABLES `device_alarm` WRITE;
/*!40000 ALTER TABLE `device_alarm` DISABLE KEYS */;
INSERT INTO `device_alarm` VALUES (5,2,0,'High'),(6,2,1,'Low'),(7,2,2,'High Low'),(8,2,3,'Band'),(9,2,4,'Off');
/*!40000 ALTER TABLE `device_alarm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device_resolution`
--

DROP TABLE IF EXISTS `device_resolution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_resolution` (
  `resolutionID` int(11) NOT NULL AUTO_INCREMENT,
  `deviceID` int(11) NOT NULL,
  `resolution_index` tinyint(10) NOT NULL,
  `resolution_value` int(11) NOT NULL,
  PRIMARY KEY (`resolutionID`),
  KEY `ref_device_idx` (`deviceID`),
  CONSTRAINT `ref_device_resolution` FOREIGN KEY (`deviceID`) REFERENCES `devices` (`deviceID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COMMENT='Adjusting precison and scale to an exisitng value read from meter as meter can display only long integer vaue no decimal vlaue		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_resolution`
--

LOCK TABLES `device_resolution` WRITE;
/*!40000 ALTER TABLE `device_resolution` DISABLE KEYS */;
INSERT INTO `device_resolution` VALUES (2,1,0,1000),(3,1,1,100),(4,1,2,10),(5,1,3,1);
/*!40000 ALTER TABLE `device_resolution` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device_units`
--

DROP TABLE IF EXISTS `device_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_units` (
  `device_unitsID` int(11) NOT NULL AUTO_INCREMENT,
  `deviceID` int(11) NOT NULL,
  `units_index` int(11) NOT NULL,
  `units_value` varchar(45) NOT NULL,
  PRIMARY KEY (`device_unitsID`),
  KEY `ref_device_units_idx` (`deviceID`),
  CONSTRAINT `ref_device_units` FOREIGN KEY (`deviceID`) REFERENCES `devices` (`deviceID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='defines units to be read devices based on index value';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_units`
--

LOCK TABLES `device_units` WRITE;
/*!40000 ALTER TABLE `device_units` DISABLE KEYS */;
INSERT INTO `device_units` VALUES (1,1,0,'m³'),(2,1,1,'lt'),(3,1,2,'gl'),(4,1,3,'kg');
/*!40000 ALTER TABLE `device_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices`
--

DROP TABLE IF EXISTS `devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `devices` (
  `deviceID` int(11) NOT NULL AUTO_INCREMENT,
  `slaveID` int(11) NOT NULL,
  `value_start_address` int(11) NOT NULL,
  `value_return_datatype` int(11) NOT NULL,
  `unit_start_address` int(11) DEFAULT NULL,
  `unit_return_datatype` int(11) DEFAULT NULL,
  `alarm_start_address` int(11) DEFAULT NULL,
  `alarm_return_datatype` int(11) DEFAULT NULL,
  `resolution_start_address` int(11) DEFAULT NULL,
  `resolution_return_datatype` int(11) DEFAULT NULL,
  `device_name` varchar(100) NOT NULL,
  `Endianess` int(11) NOT NULL,
  `alarm_status_start_address` int(11) DEFAULT NULL,
  `alarm_status_return_datatype` int(11) DEFAULT NULL,
  PRIMARY KEY (`deviceID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices`
--

LOCK TABLES `devices` WRITE;
/*!40000 ALTER TABLE `devices` DISABLE KEYS */;
INSERT INTO `devices` VALUES (1,5,2,2,6,1,NULL,NULL,9,1,'pulse meter',0,NULL,NULL),(2,2,0,1,NULL,50000,1,1,NULL,50000,'TDS',0,9,1),(3,8,205,2,NULL,50000,NULL,NULL,NULL,NULL,'pressure meter',0,NULL,NULL),(4,8,206,2,NULL,NULL,NULL,NULL,NULL,NULL,'water flow',0,NULL,NULL),(5,8,101,2,NULL,NULL,NULL,NULL,9,1,'air meter',0,NULL,NULL),(6,65,101,2,7,1,NULL,NULL,9,1,'ph meter',0,NULL,NULL),(7,45,101,2,7,1,NULL,NULL,9,1,'fuse meter',0,NULL,NULL),(8,56,101,2,7,1,NULL,NULL,9,1,'data meter',0,NULL,NULL),(9,57,101,2,7,1,NULL,NULL,9,1,'current meter',0,NULL,NULL),(10,91,101,2,7,1,NULL,NULL,9,1,'power meter',0,NULL,NULL),(11,140,101,2,8,1,NULL,NULL,9,1,'System meter',0,NULL,NULL),(12,125,101,2,8,1,NULL,NULL,9,1,'Cooling meter',0,NULL,NULL),(13,26,101,1,8,1,NULL,NULL,9,1,'Temprature meter',0,NULL,NULL),(14,28,101,1,8,1,NULL,NULL,9,1,'A/c meter',0,NULL,NULL);
/*!40000 ALTER TABLE `devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devices_to_channels`
--

DROP TABLE IF EXISTS `devices_to_channels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `devices_to_channels` (
  `device_channelID` int(11) NOT NULL AUTO_INCREMENT,
  `deviceID` int(11) NOT NULL,
  `channelID` int(11) NOT NULL,
  PRIMARY KEY (`device_channelID`),
  KEY `device_ref_idx` (`deviceID`),
  KEY `channel_ref_idx` (`channelID`),
  CONSTRAINT `channel_ref` FOREIGN KEY (`channelID`) REFERENCES `channels` (`channel_no`) ON UPDATE CASCADE,
  CONSTRAINT `device_ref` FOREIGN KEY (`deviceID`) REFERENCES `devices` (`deviceID`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='Connection devices to channels';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devices_to_channels`
--

LOCK TABLES `devices_to_channels` WRITE;
/*!40000 ALTER TABLE `devices_to_channels` DISABLE KEYS */;
INSERT INTO `devices_to_channels` VALUES (1,2,1);
/*!40000 ALTER TABLE `devices_to_channels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `poll_setting`
--

DROP TABLE IF EXISTS `poll_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `poll_setting` (
  `pollID` int(11) NOT NULL AUTO_INCREMENT,
  `com_port` varchar(10) NOT NULL,
  `baud_rate` int(11) NOT NULL,
  `no_channels` int(11) NOT NULL,
  `poll_interval` int(11) NOT NULL,
  PRIMARY KEY (`pollID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `poll_setting`
--

LOCK TABLES `poll_setting` WRITE;
/*!40000 ALTER TABLE `poll_setting` DISABLE KEYS */;
INSERT INTO `poll_setting` VALUES (1,'COM5',19200,17,50000);
/*!40000 ALTER TABLE `poll_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `port_settings`
--

DROP TABLE IF EXISTS `port_settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `port_settings` (
  `serial_no` int(11) NOT NULL AUTO_INCREMENT,
  `port_name` varchar(20) DEFAULT NULL,
  `baud_rate` varchar(20) DEFAULT NULL,
  `data_bits` varchar(20) DEFAULT NULL,
  `parity` varchar(20) DEFAULT NULL,
  `stop_bits` varchar(20) DEFAULT NULL,
  `DTS` varchar(10) NOT NULL,
  `RTS` varchar(10) NOT NULL,
  `poll_frequency` text NOT NULL,
  PRIMARY KEY (`serial_no`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `port_settings`
--

LOCK TABLES `port_settings` WRITE;
/*!40000 ALTER TABLE `port_settings` DISABLE KEYS */;
INSERT INTO `port_settings` VALUES (1,'COM10','9600','8','NONE','1','TRUE','TRUE','10'),(2,'COM11','9600','1','0','1','','',''),(3,'COM12','9600','1','0','1','','','');
/*!40000 ALTER TABLE `port_settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request` (
  `s_no` int(11) NOT NULL AUTO_INCREMENT,
  `slave_id` int(11) NOT NULL,
  `function` varchar(30) NOT NULL,
  `length` int(11) NOT NULL,
  `poll_frequency` int(11) NOT NULL,
  PRIMARY KEY (`s_no`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
INSERT INTO `request` VALUES (1,1,'01',10,10),(2,1,'01',21,1),(3,1,'01',299,90),(4,3,'02',20,50),(5,3,'02',20,50),(6,3,'04',80,1000),(7,1,'03',1000,999),(8,3,'01',222,4444),(9,245,'03',10,10),(10,245,'02',10,20),(11,245,'03',1000,10),(12,3,'03',111,123),(13,3,'03',10,13),(14,245,'02',10,1000),(15,1,'03',10,234),(16,245,'03',234,432),(17,3,'03',13,23),(18,3,'01',123,321),(19,245,'01',12,12),(20,245,'04',1000,100),(21,245,'03',1000,500),(22,245,'02',1000,34),(23,245,'02',1000,100),(24,245,'02',1000,100),(25,245,'02',1000,1000),(26,245,'02',12,123),(27,3,'02',10,18),(28,3,'02',1233,765),(29,1,'01',1,1),(30,1,'01',10,10),(31,1,'02',12,12),(32,245,'02',10,10),(33,245,'02',13,12),(34,1,'01',1,10),(35,3,'03',10,16),(36,1,'02',10,111),(37,3,'02',100,11),(38,3,'01',12,123),(39,245,'03',1234,2),(40,1,'03',1,1),(41,1,'01',11,123),(42,1,'02',123,2),(43,3,'02',10,100),(44,3,'02',1000,500),(45,245,'02',1000,10),(46,3,'01',1000,111),(47,245,'02',1000,100),(48,245,'03',1000,19),(49,3,'02',100,20);
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serialdata`
--

DROP TABLE IF EXISTS `serialdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `serialdata` (
  `serial_no` int(11) NOT NULL AUTO_INCREMENT,
  `serial_data` text NOT NULL,
  `date` varchar(15) NOT NULL,
  `time` varchar(10) NOT NULL,
  PRIMARY KEY (`serial_no`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serialdata`
--

LOCK TABLES `serialdata` WRITE;
/*!40000 ALTER TABLE `serialdata` DISABLE KEYS */;
INSERT INTO `serialdata` VALUES (1,'8989','07-11-15','12:39:07'),(2,'8989','07-11-15','12:39:17'),(3,'4567','20-11-15','16:35:45');
/*!40000 ALTER TABLE `serialdata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `slaves`
--

DROP TABLE IF EXISTS `slaves`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `slaves` (
  `s_no` int(11) NOT NULL AUTO_INCREMENT,
  `slave_id` int(11) NOT NULL,
  `status` varchar(10) NOT NULL,
  PRIMARY KEY (`s_no`)
) ENGINE=InnoDB AUTO_INCREMENT=249 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `slaves`
--

LOCK TABLES `slaves` WRITE;
/*!40000 ALTER TABLE `slaves` DISABLE KEYS */;
INSERT INTO `slaves` VALUES (1,0,'inactive'),(2,1,'active'),(3,2,'inactive'),(4,3,'active'),(5,4,'inactive'),(6,5,'inactive'),(7,6,'inactive'),(8,7,'inactive'),(9,8,'inactive'),(10,9,'inactive'),(11,10,'inactive'),(12,11,'inactive'),(13,12,'inactive'),(14,13,'inactive'),(15,14,'inactive'),(16,15,'inactive'),(17,16,'inactive'),(18,17,'inactive'),(19,18,'inactive'),(20,19,'inactive'),(21,20,'inactive'),(22,21,'inactive'),(23,22,'inactive'),(24,23,'inactive'),(25,24,'inactive'),(26,25,'inactive'),(27,26,'inactive'),(28,27,'inactive'),(29,28,'inactive'),(30,29,'inactive'),(31,30,'inactive'),(32,31,'inactive'),(33,32,'inactive'),(34,33,'inactive'),(35,34,'inactive'),(36,35,'inactive'),(37,36,'inactive'),(38,37,'inactive'),(39,38,'inactive'),(40,39,'inactive'),(41,40,'inactive'),(42,41,'inactive'),(43,42,'inactive'),(44,43,'inactive'),(45,44,'inactive'),(46,45,'inactive'),(47,46,'inactive'),(48,47,'inactive'),(49,48,'inactive'),(50,49,'inactive'),(51,50,'inactive'),(52,51,'inactive'),(53,52,'inactive'),(54,53,'inactive'),(55,54,'inactive'),(56,55,'inactive'),(57,56,'inactive'),(58,57,'inactive'),(59,58,'inactive'),(60,59,'inactive'),(61,60,'inactive'),(62,61,'inactive'),(63,62,'inactive'),(64,63,'inactive'),(65,64,'inactive'),(66,65,'inactive'),(67,66,'inactive'),(68,67,'inactive'),(69,68,'inactive'),(70,69,'inactive'),(71,70,'inactive'),(72,71,'inactive'),(73,72,'inactive'),(74,73,'inactive'),(75,74,'inactive'),(76,75,'inactive'),(77,76,'inactive'),(78,77,'inactive'),(79,78,'inactive'),(80,79,'inactive'),(81,80,'inactive'),(82,81,'inactive'),(83,82,'inactive'),(84,83,'inactive'),(85,84,'inactive'),(86,85,'inactive'),(87,86,'inactive'),(88,87,'inactive'),(89,88,'inactive'),(90,89,'inactive'),(91,90,'inactive'),(92,91,'inactive'),(93,92,'inactive'),(94,93,'inactive'),(95,94,'inactive'),(96,95,'inactive'),(97,96,'inactive'),(98,97,'inactive'),(99,98,'inactive'),(100,99,'inactive'),(101,100,'inactive'),(102,101,'inactive'),(103,102,'inactive'),(104,103,'inactive'),(105,104,'inactive'),(106,105,'inactive'),(107,106,'inactive'),(108,107,'inactive'),(109,108,'inactive'),(110,109,'inactive'),(111,110,'inactive'),(112,111,'inactive'),(113,112,'inactive'),(114,113,'inactive'),(115,114,'inactive'),(116,115,'inactive'),(117,116,'inactive'),(118,117,'inactive'),(119,118,'inactive'),(120,119,'inactive'),(121,120,'inactive'),(122,121,'inactive'),(123,122,'inactive'),(124,123,'inactive'),(125,124,'inactive'),(126,125,'inactive'),(127,126,'inactive'),(128,127,'inactive'),(129,128,'inactive'),(130,129,'inactive'),(131,130,'inactive'),(132,131,'inactive'),(133,132,'inactive'),(134,133,'inactive'),(135,134,'inactive'),(136,135,'inactive'),(137,136,'inactive'),(138,137,'inactive'),(139,138,'inactive'),(140,139,'inactive'),(141,140,'inactive'),(142,141,'inactive'),(143,142,'inactive'),(144,143,'inactive'),(145,144,'inactive'),(146,145,'inactive'),(147,146,'inactive'),(148,147,'inactive'),(149,148,'inactive'),(150,149,'inactive'),(151,150,'inactive'),(152,151,'inactive'),(153,152,'inactive'),(154,153,'inactive'),(155,154,'inactive'),(156,155,'inactive'),(157,156,'inactive'),(158,157,'inactive'),(159,158,'inactive'),(160,159,'inactive'),(161,160,'inactive'),(162,161,'inactive'),(163,162,'inactive'),(164,163,'inactive'),(165,164,'inactive'),(166,165,'inactive'),(167,166,'inactive'),(168,167,'inactive'),(169,168,'inactive'),(170,169,'inactive'),(171,170,'inactive'),(172,171,'inactive'),(173,172,'inactive'),(174,173,'inactive'),(175,174,'inactive'),(176,175,'inactive'),(177,176,'inactive'),(178,177,'inactive'),(179,178,'inactive'),(180,179,'inactive'),(181,180,'inactive'),(182,181,'inactive'),(183,182,'inactive'),(184,183,'inactive'),(185,184,'inactive'),(186,185,'inactive'),(187,186,'inactive'),(188,187,'inactive'),(189,188,'inactive'),(190,189,'inactive'),(191,190,'inactive'),(192,191,'inactive'),(193,192,'inactive'),(194,193,'inactive'),(195,194,'inactive'),(196,195,'inactive'),(197,196,'inactive'),(198,197,'inactive'),(199,198,'inactive'),(200,199,'inactive'),(201,200,'inactive'),(202,201,'inactive'),(203,202,'inactive'),(204,203,'inactive'),(205,204,'inactive'),(206,205,'inactive'),(207,206,'inactive'),(208,207,'inactive'),(209,208,'inactive'),(210,209,'inactive'),(211,210,'inactive'),(212,211,'inactive'),(213,212,'inactive'),(214,213,'inactive'),(215,214,'inactive'),(216,215,'inactive'),(217,216,'inactive'),(218,217,'inactive'),(219,218,'inactive'),(220,219,'inactive'),(221,220,'inactive'),(222,221,'inactive'),(223,222,'inactive'),(224,223,'inactive'),(225,224,'inactive'),(226,225,'inactive'),(227,226,'inactive'),(228,227,'inactive'),(229,228,'inactive'),(230,229,'inactive'),(231,230,'inactive'),(232,231,'inactive'),(233,232,'inactive'),(234,233,'inactive'),(235,234,'inactive'),(236,235,'inactive'),(237,236,'inactive'),(238,237,'inactive'),(239,238,'inactive'),(240,239,'inactive'),(241,240,'inactive'),(242,241,'inactive'),(243,242,'inactive'),(244,243,'inactive'),(245,244,'inactive'),(246,245,'active'),(247,246,'inactive'),(248,247,'inactive');
/*!40000 ALTER TABLE `slaves` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unitsofmesurement`
--

DROP TABLE IF EXISTS `unitsofmesurement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unitsofmesurement` (
  `UnitID` int(11) NOT NULL AUTO_INCREMENT,
  `Units` varchar(100) NOT NULL,
  PRIMARY KEY (`UnitID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unitsofmesurement`
--

LOCK TABLES `unitsofmesurement` WRITE;
/*!40000 ALTER TABLE `unitsofmesurement` DISABLE KEYS */;
INSERT INTO `unitsofmesurement` VALUES (1,'kg'),(2,'° C'),(3,'° F'),(4,'m'),(5,'m²'),(6,'m³'),(7,'m/s²'),(8,'kg/m³'),(9,'m³/kg'),(10,'A/m²'),(11,'A/m'),(12,'km/hr'),(13,'Pa(N/m²)'),(14,'N'),(15,'J(N-M)'),(16,'W'),(17,'V'),(18,'Ω'),(19,'pH'),(20,'K'),(21,'km/sec'),(22,'meters'),(23,'millimeters');
/*!40000 ALTER TABLE `unitsofmesurement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `sno` int(11) NOT NULL AUTO_INCREMENT,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `user_type` text NOT NULL,
  PRIMARY KEY (`sno`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'sudo','sudopass','administrator'),(2,'vinoth','welcome','administrator'),(3,'ajay','iop','administrator'),(4,'','','administrator'),(5,'vino','vino','administrator');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-02-11 21:43:22
