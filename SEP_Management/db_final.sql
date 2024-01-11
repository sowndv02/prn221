-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: swp391-spp
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `assign_setting`
--

DROP TABLE IF EXISTS `assign_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assign_setting` (
  `setting_id` int NOT NULL AUTO_INCREMENT,
  `setting_group` tinyint DEFAULT NULL,
  `assign_id` int DEFAULT NULL,
  `setting_name` varchar(45) DEFAULT NULL,
  `setting_value` varchar(50) DEFAULT NULL,
  `display_order` tinyint DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`setting_id`),
  KEY `assign_id_fk2_idx` (`assign_id`),
  CONSTRAINT `assign_id_fk2` FOREIGN KEY (`assign_id`) REFERENCES `assignment` (`assign_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assign_setting`
--

LOCK TABLES `assign_setting` WRITE;
/*!40000 ALTER TABLE `assign_setting` DISABLE KEYS */;
/*!40000 ALTER TABLE `assign_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assignment`
--

DROP TABLE IF EXISTS `assignment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assignment` (
  `assign_id` int NOT NULL AUTO_INCREMENT,
  `subject_id` int NOT NULL,
  `assign_name` varchar(100) DEFAULT NULL,
  `assign_descript` text,
  `is_active` tinyint(1) DEFAULT NULL,
  `created_by` smallint DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` smallint DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `part` varchar(45) DEFAULT NULL,
  `weight` varchar(45) DEFAULT NULL,
  `due_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`assign_id`),
  KEY `assignment_ibfk_1` (`subject_id`),
  CONSTRAINT `assignment_ibfk_1` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assignment`
--

LOCK TABLES `assignment` WRITE;
/*!40000 ALTER TABLE `assignment` DISABLE KEYS */;
INSERT INTO `assignment` VALUES (3,1,'iter3','Description for iter3',1,1,NULL,NULL,NULL,'1','30','2023-10-22'),(4,2,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(5,2,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(6,2,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(7,3,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(8,3,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(9,3,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(10,4,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(11,4,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(12,4,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(13,5,'iter1','Description for iter1',0,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(14,5,'iter2','Description for iter2',0,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(15,5,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(16,6,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(17,6,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(18,6,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(19,7,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(20,7,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(21,7,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(22,8,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(23,8,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(24,8,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(25,9,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(26,9,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(27,9,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(28,10,'iter1','Description for iter1',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','30','2023-15-11'),(29,10,'iter2','Description for iter2',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(30,10,'iter3','Description for iter3',1,1,'2023-10-08 02:55:31',NULL,NULL,'1','35','2023-15-11'),(42,1,'iter','description',NULL,NULL,NULL,NULL,NULL,'1','30','2023-10-19');
/*!40000 ALTER TABLE `assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class` (
  `class_id` int NOT NULL AUTO_INCREMENT,
  `class_code` varchar(25) DEFAULT NULL,
  `class_details` text,
  `semester_id` int DEFAULT NULL,
  `subject_id` int DEFAULT NULL,
  `manager_id` int DEFAULT NULL,
  `status` tinyint(1) DEFAULT NULL,
  `created_by` smallint DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` smallint DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `gitlab_id` varchar(150) DEFAULT NULL,
  `access_token` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`class_id`),
  KEY `semester_id` (`semester_id`),
  KEY `subject_id` (`subject_id`),
  KEY `manager_id` (`manager_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (1,'SE1741-NJ','detail 1',17,2,49,1,1,'2023-10-07 16:06:20',NULL,NULL,'https://gitlab.com/fuhn/fall23/swp391-demo/se1741-check','glpat-5z8n-99pzhgWm6VNQbzo'),(2,'SE1742-NJ','Detail2',17,3,48,1,1,'2023-10-07 16:10:00',NULL,NULL,'https://gitlab.com/fptu1/fall23/swp391/se1742-nj',NULL),(3,'SE1743-NJ','Detail3',20,8,48,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(4,'SE1742-JS','Detail4',20,2,48,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(5,'SE1592-JS','Detail5',20,4,1,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(6,'SE1422-IA','Detail6',17,5,1,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(7,'SE1701-AI','Detail7',17,6,1,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(8,'SE1732-NT','Detail8',17,2,1,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(9,'SE1432-BS','Detail9',17,7,8,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(10,'SE1232-KS','Detail10',17,7,8,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(11,'SE1525-JS','Detail11',17,1,8,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(12,'SE1526-JS','Detail12',17,9,21,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(13,'SE1523-JS','Detail13',17,10,21,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(14,'SE1525-JS','Detail14',17,6,49,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(15,'SE1902-HA','Detail15',17,5,8,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(16,'SE1903-HA','Detail16',17,5,8,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(17,'SE1904-HA','Detail17',17,1,48,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(18,'SE1956-HA','Detail18',17,4,49,1,1,'2023-10-07 16:10:00',NULL,NULL,NULL,NULL),(19,'SE1957-HA','Detail19',17,9,8,1,1,'2023-10-07 16:13:00',NULL,NULL,NULL,NULL),(20,'SE1502-HA','Detail20',17,10,21,0,1,'2023-10-07 16:13:00',NULL,NULL,'null',NULL);
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_student`
--

DROP TABLE IF EXISTS `class_student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_student` (
  `class_st_id` int NOT NULL AUTO_INCREMENT,
  `class_id` int DEFAULT NULL,
  `student_id` int NOT NULL,
  `is_active` tinyint(1) DEFAULT NULL,
  `note` text,
  `created_by` smallint DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` smallint DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `project_id` int DEFAULT NULL,
  `is_leader` tinyint DEFAULT NULL,
  PRIMARY KEY (`class_st_id`),
  KEY `class_student_ibfk_1` (`class_id`),
  KEY `class_student_ibfk_2` (`student_id`),
  CONSTRAINT `class_student_ibfk_1` FOREIGN KEY (`class_id`) REFERENCES `class` (`class_id`) ON DELETE CASCADE,
  CONSTRAINT `class_student_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `user` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_student`
--

LOCK TABLES `class_student` WRITE;
/*!40000 ALTER TABLE `class_student` DISABLE KEYS */;
INSERT INTO `class_student` VALUES (1,1,54,1,'des studfenyt cacadcacdddac',NULL,'2023-10-12 10:20:00',NULL,'2023-10-23 09:15:19',0,0),(2,1,55,1,'Student 2',NULL,'2023-10-12 10:21:00',NULL,'2023-10-22 18:14:31',4,1),(3,1,56,1,'Student 3',NULL,'2023-10-12 10:23:39',NULL,'2023-10-22 18:09:44',4,0),(4,1,57,1,'Student 4',NULL,'2023-10-12 10:24:43',NULL,'2023-10-22 18:25:45',1,0),(5,1,58,1,'Student 5',NULL,'2023-10-12 10:24:57',NULL,'2023-10-22 18:25:24',1,1),(6,1,59,1,'Student 6',NULL,'2023-10-12 10:29:43',NULL,'2023-10-16 23:20:43',1,0),(7,1,60,1,'Student 7',NULL,'2023-10-12 10:30:29',NULL,'2023-10-17 07:17:20',42,0),(8,2,61,1,'Student 8',NULL,'2023-10-12 10:30:29',NULL,'2023-10-16 22:54:41',41,0),(9,2,62,1,'Student 9',NULL,'2023-10-12 10:30:29',NULL,'2023-10-17 07:17:21',42,1),(10,2,63,1,'Student 10',NULL,'2023-10-12 18:31:31',NULL,'2023-10-16 22:53:46',41,1),(11,2,64,1,'Student 11',NULL,'2023-10-14 11:56:35',NULL,'2023-10-16 21:12:36',41,0),(12,2,65,1,'Student 12',NULL,'2023-10-14 11:56:50',NULL,'2023-10-16 22:52:39',42,0),(20,2,54,1,NULL,NULL,NULL,NULL,NULL,0,0);
/*!40000 ALTER TABLE `class_student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issue`
--

DROP TABLE IF EXISTS `issue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `issue` (
  `issue_id` int NOT NULL,
  `project_id` int DEFAULT NULL,
  `milestone_id` int DEFAULT NULL,
  `type_id` int DEFAULT NULL,
  `status_id` int DEFAULT NULL,
  `process_id` int DEFAULT NULL,
  `create_by` int DEFAULT NULL,
  `create_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `update_by` int DEFAULT NULL,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`issue_id`),
  KEY `project_issue_fk_idx` (`project_id`),
  KEY `milestone_issue_fk_idx` (`milestone_id`),
  KEY `issue_type_fk_idx` (`type_id`),
  KEY `issue_status_idx` (`status_id`),
  KEY `issue_process_idx` (`process_id`),
  CONSTRAINT `issue_process` FOREIGN KEY (`process_id`) REFERENCES `issue_setting` (`setting_id`) ON DELETE CASCADE,
  CONSTRAINT `issue_status` FOREIGN KEY (`status_id`) REFERENCES `issue_setting` (`setting_id`) ON DELETE CASCADE,
  CONSTRAINT `issue_type_fk` FOREIGN KEY (`type_id`) REFERENCES `issue_setting` (`setting_id`) ON DELETE CASCADE,
  CONSTRAINT `milestone_issue_fk` FOREIGN KEY (`milestone_id`) REFERENCES `milestone` (`milestone_id`) ON DELETE CASCADE,
  CONSTRAINT `project_issue_fk` FOREIGN KEY (`project_id`) REFERENCES `project` (`project_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issue`
--

LOCK TABLES `issue` WRITE;
/*!40000 ALTER TABLE `issue` DISABLE KEYS */;
/*!40000 ALTER TABLE `issue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issue_setting`
--

DROP TABLE IF EXISTS `issue_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `issue_setting` (
  `setting_id` int NOT NULL AUTO_INCREMENT,
  `subject_id` int DEFAULT NULL,
  `class_id` int DEFAULT NULL,
  `project_id` int DEFAULT NULL,
  `title` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `description` text,
  `create_by` int DEFAULT NULL,
  `create_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `is_active` tinyint(1) DEFAULT '1',
  `update_by` int DEFAULT NULL,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`setting_id`),
  KEY `subject_lable_fk_idx` (`subject_id`),
  KEY `project_label_fk_idx` (`project_id`),
  KEY `class_label_idx` (`class_id`),
  CONSTRAINT `class_label` FOREIGN KEY (`class_id`) REFERENCES `class` (`class_id`),
  CONSTRAINT `project_label_fk` FOREIGN KEY (`project_id`) REFERENCES `project` (`project_id`),
  CONSTRAINT `subject_lable_fk` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issue_setting`
--

LOCK TABLES `issue_setting` WRITE;
/*!40000 ALTER TABLE `issue_setting` DISABLE KEYS */;
INSERT INTO `issue_setting` VALUES (21,1,11,NULL,'status1','todo1','description 1',NULL,'2023-11-01 15:37:53',0,NULL,'2023-11-02 08:59:50'),(38,1,17,NULL,'status2','todo2','description 2',NULL,'2023-11-02 08:59:50',1,NULL,'2023-11-02 09:00:03'),(39,2,1,1,'status3','todo3','description 3',NULL,'2023-11-02 08:59:50',1,NULL,'2023-11-02 09:00:03'),(40,2,4,NULL,'status4','todo4','description 4',NULL,'2023-11-02 08:59:50',0,NULL,'2023-11-02 09:00:03'),(41,2,8,NULL,'status5','todo5','description 5',NULL,'2023-11-02 08:59:50',0,NULL,'2023-11-02 09:00:03'),(42,3,2,41,'status6','todo6','description 6',NULL,'2023-11-02 08:59:50',1,NULL,'2023-11-02 09:00:03'),(43,2,1,NULL,'status7','todo7','description 7',NULL,'2023-11-02 09:04:18',1,NULL,'2023-11-02 09:04:18'),(44,2,1,NULL,'status8','todo8','description 8',NULL,'2023-11-02 09:04:18',1,NULL,'2023-11-02 09:04:18'),(45,2,1,NULL,'status9','todo9','description 9',NULL,'2023-11-02 09:04:18',1,NULL,'2023-11-02 09:04:18');
/*!40000 ALTER TABLE `issue_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issue_update`
--

DROP TABLE IF EXISTS `issue_update`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `issue_update` (
  `update_id` int NOT NULL,
  `issue_id` int DEFAULT NULL,
  `milestone_id` int DEFAULT NULL,
  `description` text,
  `created_by` int DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` int DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`update_id`),
  KEY `fk_issue_001_idx` (`issue_id`),
  CONSTRAINT `fk_issue_001` FOREIGN KEY (`issue_id`) REFERENCES `issue` (`issue_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issue_update`
--

LOCK TABLES `issue_update` WRITE;
/*!40000 ALTER TABLE `issue_update` DISABLE KEYS */;
/*!40000 ALTER TABLE `issue_update` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `milestone`
--

DROP TABLE IF EXISTS `milestone`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `milestone` (
  `milestone_id` int NOT NULL AUTO_INCREMENT,
  `milestone_name` varchar(100) DEFAULT NULL,
  `description` text,
  `due_date` date DEFAULT NULL,
  `is_active` smallint DEFAULT NULL,
  `class_id` int DEFAULT NULL,
  `created_by` smallint DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` smallint DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `project_id` int DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `gitlab_id` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`milestone_id`),
  UNIQUE KEY `milestone_name_UNIQUE` (`milestone_name`),
  KEY `assign_id_idx` (`class_id`),
  KEY `project_id_fk1_idx` (`project_id`),
  CONSTRAINT `class_id_fk1` FOREIGN KEY (`class_id`) REFERENCES `class` (`class_id`) ON DELETE CASCADE,
  CONSTRAINT `project_id_fk1` FOREIGN KEY (`project_id`) REFERENCES `project` (`project_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=147 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `milestone`
--

LOCK TABLES `milestone` WRITE;
/*!40000 ALTER TABLE `milestone` DISABLE KEYS */;
INSERT INTO `milestone` VALUES (10,'milestone1','test change','2023-12-23',1,1,1,'2023-10-08 03:17:57',NULL,'2023-10-30 15:00:04',1,'2023-09-26','4320721'),(11,'milestone4','Description','2023-10-24',1,1,1,'2023-10-10 03:17:57',NULL,'2023-10-30 15:00:04',1,'2023-09-21','4320722'),(12,'milestone7','Description for milestone3','2023-10-29',1,1,1,'2023-10-12 03:17:57',NULL,NULL,4,'2023-10-12','4320723'),(13,'milestone2','Description for milestone1','2023-10-15',1,2,1,'2023-10-14 03:17:57',NULL,NULL,41,'2023-10-14',NULL),(14,'milestone5','Description for milestone2','2023-10-22',1,2,1,'2023-10-16 03:17:57',NULL,NULL,41,'2023-10-16',NULL),(15,'milestone8','Description for milestone3','2023-10-29',1,2,1,'2023-10-18 03:17:57',NULL,NULL,42,'2023-10-18',NULL),(16,'milestone32','change to update','2023-12-15',0,1,1,'2023-11-15 03:17:57',NULL,'2023-11-11 15:00:12',NULL,'2023-10-30','4338792'),(17,'milestone6','Description for milestone2','2023-10-18',0,1,1,'2023-11-17 03:17:57',NULL,'2023-11-11 15:00:11',NULL,'2023-06-12','4338793'),(18,'milestone9','Description for milestone3','2023-10-25',1,1,1,'2023-11-19 03:17:57',NULL,'2023-11-11 15:00:12',NULL,'2023-06-15','4338794'),(26,'milestone change on db','test change','2023-10-16',1,1,1,'2023-10-09 22:46:41',NULL,'2023-10-30 15:00:04',1,'2023-10-08','4320724'),(27,'test update 10/10','test 1','2023-10-08',0,1,1,'2023-10-09 22:46:41',NULL,'2023-10-30 13:22:18',4,'2023-10-04','4320725'),(28,'New Milestone from gitlab','add 10/10','2023-10-02',0,1,1,'2023-10-09 22:46:41',NULL,'2023-10-30 15:00:04',4,'2023-09-28','4320726'),(66,'milstone check','change check status','2023-10-23',1,1,1,'2023-10-10 06:40:03',NULL,'2023-10-30 15:00:04',4,'2023-10-08','4320727'),(138,'milestone112','','2023-11-22',1,1,1,'2023-11-06 19:17:55',NULL,NULL,NULL,'2023-11-10','4339102'),(146,'gbgbg','','2023-11-15',2,1,1,'2023-11-06 21:25:35',NULL,NULL,NULL,'2023-11-01','');
/*!40000 ALTER TABLE `milestone` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `project` (
  `project_id` int NOT NULL AUTO_INCREMENT,
  `project_code` varchar(25) DEFAULT NULL,
  `project_en_name` varchar(200) DEFAULT NULL,
  `project_vi_name` varchar(200) DEFAULT NULL,
  `project_descript` text,
  `status` tinyint(1) DEFAULT NULL,
  `created_by` smallint DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` smallint DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `class_id` int DEFAULT NULL,
  `group_name` varchar(45) DEFAULT NULL,
  `mentor_id` int DEFAULT NULL,
  `co_mentor_id` int DEFAULT NULL,
  PRIMARY KEY (`project_id`),
  KEY `class_id_fk_idx` (`class_id`),
  CONSTRAINT `class_id_fk` FOREIGN KEY (`class_id`) REFERENCES `class` (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
INSERT INTO `project` VALUES (1,'SPP-1','Student Project Portal 1','Quan ly du an sinh vien','',0,NULL,'2023-10-12 10:15:55',NULL,'2023-10-16 23:22:06',1,'G1',88,51),(4,'LMS-1','Learning Material System 1','He thong hoc lieu','',0,NULL,'2023-10-12 10:16:41',NULL,'2023-10-16 23:22:06',1,'G3',88,89),(41,'FS-1','Flower Shop','Ban hoa online','',0,NULL,'2023-10-16 21:12:02',NULL,'2023-10-16 22:57:38',2,'G1',88,90),(42,'FR-1','Review Film','Danh gia phim','',0,NULL,'2023-10-16 22:52:25',NULL,'2023-10-16 22:57:38',2,'G4',88,91);
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject` (
  `subject_id` int NOT NULL AUTO_INCREMENT,
  `subject_code` varchar(20) DEFAULT NULL,
  `subject_name` varchar(255) DEFAULT NULL,
  `manager_id` int DEFAULT NULL,
  `is_active` tinyint(1) DEFAULT NULL,
  `create_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` int DEFAULT NULL,
  `update_by` int DEFAULT NULL,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `description` varchar(1000) DEFAULT NULL,
  `time_allocation` varchar(45) DEFAULT NULL,
  `pass_grade` tinyint DEFAULT NULL,
  PRIMARY KEY (`subject_id`),
  UNIQUE KEY `subject_code` (`subject_code`),
  KEY `manager_id` (`manager_id`),
  CONSTRAINT `subject_ibfk_1` FOREIGN KEY (`manager_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (1,'MATH101','Mathematics 101',5,1,'2023-09-17 03:28:55',1001,1001,'2023-11-01 15:25:42','The course focuses on data summaries and descriptive statistics; introduction to a statistical computer package; probability: distributions, expectation, variance, covariance, portfolios, central limit theorem; statistical inference of univariance data; Statistical inference for bivariate data: inference for intrinsically linear simple regression models. This course will have a business focus. Teaching method is flexible. Lecturers and tutors can mix between traditional teaching method with project-based learning, problem-based learning and flipped classroom.','Study hour (150h) = 120h online + 7.5h off',7),(2,'ENG101','English 101',8,1,'2023-09-17 03:28:55',1002,1002,'2023-10-15 08:53:35','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(3,'PHY101','Physics 101',22,1,'2023-09-17 03:28:55',1003,1003,'2023-10-16 18:37:40','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(4,'CHEM101','Chemistry 101',25,1,'2023-09-17 03:28:55',1004,1004,'2023-10-16 18:34:19','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(5,'BIO101','Biology 101',27,1,'2023-09-17 03:28:55',1005,1005,'2023-10-16 18:34:25','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(6,'HIS101','History 101',52,1,'2023-09-17 03:28:55',1006,1006,'2023-10-16 18:37:16','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(7,'GEO101','Geography 101',53,1,'2023-09-17 03:28:55',1007,1007,'2023-10-16 18:37:23','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(8,'CS101','Computer Science 101',8,1,'2023-09-17 03:28:55',1008,1008,'2023-10-14 15:50:13','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(9,'MUS101','Music 101',8,1,'2023-09-17 03:28:55',1009,1009,'2023-10-14 15:50:13','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(10,'ART101','Art 101',8,1,'2023-09-17 03:28:55',1010,1010,'2023-10-14 15:50:13','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(22,'demo2','demo2',8,NULL,'2023-09-26 06:11:49',NULL,NULL,'2023-10-14 15:50:13','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5),(23,'demo1','demo1',22,NULL,'2023-10-10 11:30:24',NULL,NULL,'2023-10-14 15:50:13','dentify sample spaces and events, and use basic rules to calculate the probability of an event LO2.1 Describe the sample space and events of an experiment; distinguish continuous and discrete sample spaces; perform operations on events. LO2.2 Calculate th','Study hour (150h) = 50h online + 7.5h offline',5);
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject_setting`
--

DROP TABLE IF EXISTS `subject_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject_setting` (
  `setting_id` int NOT NULL,
  `setting_name` varchar(45) DEFAULT NULL,
  `setting_type` int DEFAULT NULL,
  `setting_value` int DEFAULT NULL,
  `subject_id` int DEFAULT NULL,
  `created_by` int DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_by` int DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`setting_id`),
  KEY `subject_fk_002_idx` (`subject_id`),
  CONSTRAINT `subject_fk_002` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject_setting`
--

LOCK TABLES `subject_setting` WRITE;
/*!40000 ALTER TABLE `subject_setting` DISABLE KEYS */;
/*!40000 ALTER TABLE `subject_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_setting`
--

DROP TABLE IF EXISTS `system_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `system_setting` (
  `setting_id` int NOT NULL AUTO_INCREMENT,
  `setting_group` smallint DEFAULT NULL,
  `setting_name` varchar(255) DEFAULT NULL,
  `display_order` int DEFAULT NULL,
  `description` text,
  `is_active` tinyint(1) DEFAULT NULL,
  `create_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` int DEFAULT NULL,
  `update_by` int DEFAULT NULL,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`setting_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_setting`
--

LOCK TABLES `system_setting` WRITE;
/*!40000 ALTER TABLE `system_setting` DISABLE KEYS */;
INSERT INTO `system_setting` VALUES (12,3,'fpt.edu.vn',1,'',1,'2023-09-21 16:10:21',NULL,NULL,'2023-10-17 14:46:10'),(13,3,'fe.edu.vn',2,'account for tcher',1,'2023-09-21 10:50:58',NULL,NULL,'2023-10-17 14:46:17'),(14,2,'Admin',3,'admin',1,'2023-09-21 10:50:58',NULL,NULL,'2023-09-22 09:59:33'),(15,2,'Subject Manager',4,'suject manager',1,'2023-09-21 10:50:58',NULL,NULL,'2023-10-23 15:25:00'),(16,2,'Class Manager',5,'class_manager',1,'2023-09-21 10:50:58',NULL,NULL,'2023-09-24 12:05:12'),(17,1,'FAll23',6,NULL,1,'2023-09-21 10:50:58',NULL,NULL,'2023-09-21 10:50:58'),(18,2,'Project Mentor',7,NULL,1,'2023-10-06 08:29:30',NULL,NULL,'2023-10-06 08:29:30'),(19,2,'Student',8,NULL,1,'2023-10-06 08:29:30',NULL,NULL,'2023-10-06 08:30:26'),(20,1,'SU23',NULL,'',NULL,'2023-10-10 11:07:58',NULL,NULL,'2023-10-10 11:07:58');
/*!40000 ALTER TABLE `system_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `full_name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `mobile` varchar(20) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `avatar_url` varchar(255) DEFAULT NULL,
  `role_id` int DEFAULT NULL,
  `note` text,
  `create_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` int DEFAULT NULL,
  `update_by` int DEFAULT NULL,
  `update_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `is_active` tinyint(1) DEFAULT '1',
  `access_token` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `email` (`email`),
  KEY `role_id` (`role_id`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`role_id`) REFERENCES `system_setting` (`setting_id`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Dam Quang Chien','chiendqhe170223@fpt.edu.vn','0359601009','$2a$10$TDQ68M02ZheXmm0XHDs.o./3p.f/kYv2QpkSbnpHXcfZuA3y24wti','',14,'','2023-09-21 12:10:07',NULL,NULL,'2023-11-11 00:27:45',1,NULL),(2,'Dinh Thanh Hung','hung123@fpt.edu.vn','098181829','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC',NULL,14,'','2023-09-21 12:10:07',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(5,'Chien Dam Quang ','chiendam120203@fpt.edu.vn','0359601003','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC',NULL,15,'','2023-09-22 02:34:24',NULL,NULL,'2023-11-01 15:25:59',1,NULL),(8,'Luong Gia Han','luonggiahan.050@fpt.edu.vn','0917625732','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,16,'','2023-09-24 13:01:20',NULL,NULL,'2023-11-02 06:55:57',1,NULL),(21,'Domingos Chica','chiendqhe1223@fpt.edu.vn','0359601022','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC',NULL,16,'','2023-09-24 11:41:04',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(22,'Julek Oscar','ch70223@fpt.edu.vn','0359601111','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC','6259117.png',15,'','2023-09-24 11:43:10',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(23,'Chien Dam Quang','quanchien3@fpt.edu.vn','0359601234','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC','6259117.png',15,'','2023-09-24 11:45:35',NULL,NULL,'2023-11-01 15:25:07',0,NULL),(25,'Nguyen Nam','namnhhe17650@fpt.edu.vn','0941120016','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC','5928164.png',15,'','2023-09-25 07:27:17',NULL,NULL,'2023-11-01 15:25:07',0,NULL),(26,'Onangwatgo Zyanya','namnhhe176500@fpt.edu.vn','0941120015','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC','5928164.png',15,'','2023-10-02 02:00:50',NULL,NULL,'2023-11-02 06:30:10',0,NULL),(27,'Newen Anangikwe','chiendam103@gmail.com','0359601012','$2a$10$4fk3tj7ZybtwqOIJtO.xpuMv1VoW06/pguzyeFdl3P.5zDgoZ9uQC','228263726_963326834456542_7633590877298581726_n (2).jpg',15,'','2023-09-29 06:36:31',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(40,'Amaruq Ahtahkakoop','Chien@fpt.edu.vn','0030303022','$2a$10$vnCQeKewEh5FQSj6d3qoeOxg6VSXlfgbYYHq/ypT5jeahhj9Fn2ra','',15,'','2023-10-02 09:36:40',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(48,'Nayeli Rayen','kasha@fpt.edu.vn','0123456789','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG','',16,'','2023-10-02 04:58:40',NULL,NULL,'2023-11-02 06:55:57',1,NULL),(49,'Aucaman Ehecatl','chiend20203@fpt.edu.vn','0963476584','$2a$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG','226114996_209679911103867_1614158259341742874_n.jpg',16,'','2023-10-03 06:35:57',NULL,NULL,'2023-11-02 06:55:57',1,NULL),(50,'Muscowequan Citlali','chien1@fpt.edu.vn','0123456433','$2a$10$6N.nMy/CQ.MzTPWeI/JzZebrighBvbXGbYva3zGZJYhXlj2YrOg.2',NULL,14,NULL,'2023-10-06 08:48:29',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(51,'Rayen Ailen','hoainampt2003@fpt.edu.vn','0963476565','$2a$10$D2Eg/j0etaaCwksfsCGMtubKIL6ZtL.75lQNhCOOLrFRjthMfcuUW','225903764_880463649541049_7826560316216419537_n (2).jpg',18,'','2023-10-06 09:02:16',NULL,NULL,'2023-11-02 06:30:10',1,NULL),(52,'Dinh Hung','hungdbthe176753@fpt.edu.vn','0981818239','$2a$10$QmFINHY9e9aLW3A7xj00SOxd.4PDmYvZ1XuK6.A4E8FdTfZ/g3iO2','',15,'','2023-10-16 18:35:41',NULL,NULL,'2023-10-16 18:35:41',1,NULL),(53,'Dinh Bui Thanh Hung','hungdbthe171753@fpt.edu.vn','0981818219','$2a$10$SMgO7.RIha4rBBkGSFME4OE2HgZAquT6uHZbiuL9wh3o53neMk0WC','',15,'','2023-10-16 18:36:35',NULL,NULL,'2023-10-16 18:36:35',1,NULL),(54,'Adsila Wapasha','AdsilaWapasha@fpt.edu.vn','0123456789','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:00:18',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(55,'Agnes Moran','AgnesMoran@fpt.edu.vn','0123456780','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:02:13',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(56,'Stephen Archer','StephenArcher@fpt.edu.vn','0123456781','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:02:13',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(57,'Khadija Noble','KhadijaNoble@fpt.edu.vn','0123456782','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:03:30',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(58,'Spencer Douglas','SpencerDouglas@fpt.edu.vn','0123456783','$2a$10$dhYgt/OE3/BPCMjEDqQgBeEPmixY3ItBy2cMapqdidjsPfRwJ71Ze',NULL,19,NULL,'2023-10-12 10:04:12',NULL,NULL,'2023-11-02 06:35:23',1,NULL),(59,'Bryn Trujillo','BrynTrujillo@fpt.edu.vn','0123456784','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:05:24',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(60,'George Stanley','GeorgeStanley@fpt.edu.vn','0123456785','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:06:01',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(61,'Bessie Wells','BessieWells@fpt.edu.vn','0123456786','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:08:43',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(62,'Vinnie Blaese','VinnieBlaese@fpt.edu.vn','0123456787','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 10:09:25',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(63,'Marion Farley','MarionFarley@fpt.edu.vn','0123456788','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-12 18:29:50',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(64,'Niall Daniel','NiallDaniel@fpt.edu.vn','0123456789','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-14 11:55:00',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(65,'Summer George','SummerGeorge@fpt.edu.vn','0123456790','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-14 11:55:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(78,'Kelsie Buck','KelsieBuck@fpt.edu.vn','0123456791','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(79,'Safiya Woodward','SafiyaWoodward@fpt.edu.vn','0123456792','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(80,'Norma Wilkins','NormaWilkins@fpt.edu.vn','0123456793','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(81,'Antony Rodgers','AntonyRodgers@fpt.edu.vn','0123456794','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(82,'Awais Long','AwaisLong@fpt.edu.vn','0123456795','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(83,'Kacie Knight','KacieKnight@fpt.edu.vn','0123456796','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(84,'Katrina Mcclain','KatrinMcclain@fpt.edu.vn','0123456797','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(85,'Kathryn Owens','KathrynOwens@fpt.edu.vn','0123456798','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(86,'Ann Garza','AnnGarza@fpt.edu.vn','0123456799','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(87,'Ria Donaldson','RiaDonaldson@fpt.edu.vn','0123456800','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,19,NULL,'2023-10-18 15:05:34',NULL,NULL,'2023-11-02 06:37:26',1,NULL),(88,'Le Quoc Khanh','khanhlqhe172534@fpt.edu.vn','0969565203','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,18,NULL,'2023-11-01 16:40:21',NULL,NULL,'2023-11-02 06:33:41',1,NULL),(89,'Casey Rollins','CaseyRollins@fpt.edu.vn','0123456801','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,18,NULL,'2023-11-02 06:38:51',NULL,NULL,'2023-11-02 06:38:51',1,NULL),(90,'Yuvraj Winters','YuvrajWinters@fpt.edu.vn','0123456802','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,18,NULL,'2023-11-02 06:39:25',NULL,NULL,'2023-11-02 06:39:25',1,NULL),(91,'Jamal Ballard','JamalBallard@fpt.edu.vn','0123456803','$2a$10$IFwBEoqu1RcSqENS1QBhkucQsiIyrB7qkz9SRgiO2WYtoCaEOS0kG',NULL,18,NULL,'2023-11-02 06:39:56',NULL,NULL,'2023-11-02 06:39:56',1,NULL),(92,'chein','chiendqhe17022323423@fpt.edu.vn','','$2a$10$OgfIOF.kFOnDQRTVRH0Bt.Kpn5f1p5JTPj1WiDDmnfvTGfChfFFNO',NULL,19,NULL,'2023-11-06 14:51:40',NULL,NULL,'2023-11-06 14:51:40',1,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-15 19:42:52
