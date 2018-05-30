-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 30, 2018 at 08:05 PM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cybercrime`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `acc_id` bigint(20) NOT NULL,
  `officer_id` bigint(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `agency`
--

CREATE TABLE `agency` (
  `agency_id` bigint(20) NOT NULL,
  `agency_name` varchar(50) NOT NULL,
  `street` varchar(20) DEFAULT NULL,
  `barangay` varchar(20) DEFAULT NULL,
  `city` varchar(20) NOT NULL,
  `province` varchar(20) NOT NULL,
  `mother_unit` varchar(50) NOT NULL,
  `contact_no` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `agency`
--

INSERT INTO `agency` (`agency_id`, `agency_name`, `street`, `barangay`, `city`, `province`, `mother_unit`, `contact_no`, `email`, `date_created`) VALUES
(1, 'alagar', 'w', 'dw', 'Cagayan De Oro', 'mis', 'mo', 'da', 'dwa', '2018-05-30 15:59:21');

-- --------------------------------------------------------

--
-- Table structure for table `case_nature`
--

CREATE TABLE `case_nature` (
  `lab_case_no` bigint(20) NOT NULL,
  `nature_of_case` bigint(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `evidence`
--

CREATE TABLE `evidence` (
  `lab_case_no` bigint(20) NOT NULL,
  `sim` int(20) NOT NULL,
  `tablet` int(20) NOT NULL,
  `loptop` int(20) NOT NULL,
  `desktop` int(20) NOT NULL,
  `cellphone` int(20) NOT NULL,
  `flash_drive` int(20) NOT NULL,
  `optical_drive` int(20) NOT NULL,
  `secure_digital` int(20) NOT NULL,
  `external_drive` int(20) NOT NULL,
  `video_recorder` int(20) NOT NULL,
  `hard_disk_drive` int(20) NOT NULL,
  `dc` int(11) NOT NULL,
  `dvr` int(11) NOT NULL,
  `status` varchar(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `evidence`
--

INSERT INTO `evidence` (`lab_case_no`, `sim`, `tablet`, `loptop`, `desktop`, `cellphone`, `flash_drive`, `optical_drive`, `secure_digital`, `external_drive`, `video_recorder`, `hard_disk_drive`, `dc`, `dvr`, `status`, `date_created`) VALUES
(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 7, 4, 7, 3, 'ok', '2018-05-30 17:56:39');

-- --------------------------------------------------------

--
-- Table structure for table `facts`
--

CREATE TABLE `facts` (
  `fact_no` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `remarks` longtext NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facts`
--

INSERT INTO `facts` (`fact_no`, `name`, `remarks`, `date_created`) VALUES
(1, 'try', 'dadawd', '2018-05-30 16:05:00');

-- --------------------------------------------------------

--
-- Stand-in structure for view `laboratory`
-- (See below for the actual view)
--
CREATE TABLE `laboratory` (
`ID` bigint(20)
,`CaseID` varchar(50)
,`Date_Recieved` date
,`Requesting_Agency` varchar(50)
,`CP` int(20)
,`TAB` int(20)
,`DT` int(20)
,`LT` int(20)
,`SIM` int(20)
,`SD` int(20)
,`USB` int(20)
,`ED` int(20)
,`OD` int(20)
,`HDD` int(20)
,`DC` int(11)
,`DVR` int(11)
,`Evidence_Status` varchar(20)
,`Case_Status` varchar(20)
,`Date_Examined` date
,`Claimed_By` varchar(50)
,`Released_By` varchar(50)
,`Date_Informed` date
,`Fact_Name` varchar(50)
,`Remarks` longtext
);

-- --------------------------------------------------------

--
-- Table structure for table `laboratory_case`
--

CREATE TABLE `laboratory_case` (
  `lab_case_no` bigint(20) NOT NULL,
  `lab_case_no_id` varchar(50) NOT NULL,
  `date_received` date NOT NULL,
  `date_informed` date NOT NULL,
  `date_released` date NOT NULL,
  `date_examined` date NOT NULL,
  `case_status` varchar(20) NOT NULL,
  `released_by` varchar(50) NOT NULL,
  `claimed_by` varchar(50) NOT NULL,
  `complainant` bigint(20) DEFAULT NULL,
  `requesting_agency` bigint(20) DEFAULT NULL,
  `examiner` bigint(20) DEFAULT NULL,
  `investigator` bigint(20) DEFAULT NULL,
  `date_occur` date NOT NULL,
  `time_occur` time NOT NULL,
  `place_occur` varchar(50) NOT NULL,
  `type` varchar(50) NOT NULL,
  `facts` bigint(20) DEFAULT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `laboratory_case`
--

INSERT INTO `laboratory_case` (`lab_case_no`, `lab_case_no_id`, `date_received`, `date_informed`, `date_released`, `date_examined`, `case_status`, `released_by`, `claimed_by`, `complainant`, `requesting_agency`, `examiner`, `investigator`, `date_occur`, `time_occur`, `place_occur`, `type`, `facts`, `date_created`) VALUES
(2, 'try', '2018-05-09', '2018-05-16', '2018-05-09', '2018-05-16', 'ok', '1', '1', 1, 1, 1, 1, '2018-05-08', '05:36:09', '1', 'staff', 1, '2018-05-30 16:05:10');

-- --------------------------------------------------------

--
-- Table structure for table `law`
--

CREATE TABLE `law` (
  `law_id` bigint(20) NOT NULL,
  `designation` varchar(50) NOT NULL,
  `date_passed` date NOT NULL,
  `description` longtext NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `officer`
--

CREATE TABLE `officer` (
  `officer_id` bigint(20) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `mname` varchar(20) DEFAULT NULL,
  `sname` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `gender` varchar(20) NOT NULL,
  `contact` varchar(20) NOT NULL,
  `email` varchar(20) NOT NULL,
  `rank` varchar(50) NOT NULL,
  `position` varchar(50) NOT NULL,
  `agency` varchar(50) NOT NULL,
  `remark` varchar(50) NOT NULL,
  `profile_image` longblob NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `officer`
--

INSERT INTO `officer` (`officer_id`, `fname`, `mname`, `sname`, `dob`, `gender`, `contact`, `email`, `rank`, `position`, `agency`, `remark`, `profile_image`, `date_created`) VALUES
(1, 'Christian', 'Hundinay', 'perater', '2018-05-10', 'male', '09169947508', 'cat-awan@gmail.com', '1', 'admin', '1', 'da', '', '2018-05-30 15:59:29');

-- --------------------------------------------------------

--
-- Table structure for table `persons`
--

CREATE TABLE `persons` (
  `person_id` bigint(20) NOT NULL,
  `fname` varchar(50) NOT NULL,
  `mname` varchar(20) DEFAULT NULL,
  `sname` varchar(20) NOT NULL,
  `nname` varchar(20) DEFAULT NULL,
  `dob` date NOT NULL,
  `gender` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `email` varchar(20) DEFAULT NULL,
  `category` varchar(20) NOT NULL,
  `profile_image` longblob NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `persons`
--

INSERT INTO `persons` (`person_id`, `fname`, `mname`, `sname`, `nname`, `dob`, `gender`, `status`, `contact`, `email`, `category`, `profile_image`, `date_created`) VALUES
(1, 'Christian', 'Hundinay', 'perater', 'da', '2018-05-09', 'male', 'ok', '09169947508', 'cat-awan@gmail.com', 'victim', '', '2018-05-30 16:00:51');

-- --------------------------------------------------------

--
-- Table structure for table `rank`
--

CREATE TABLE `rank` (
  `rank_id` bigint(20) NOT NULL,
  `rank` varchar(50) NOT NULL,
  `abbreviation` varchar(50) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rank`
--

INSERT INTO `rank` (`rank_id`, `rank`, `abbreviation`, `date_created`) VALUES
(1, 'spo1', 's', '2018-05-30 15:57:18');

-- --------------------------------------------------------

--
-- Table structure for table `suspect`
--

CREATE TABLE `suspect` (
  `lab_case_no` bigint(20) NOT NULL,
  `person_id` bigint(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `victim`
--

CREATE TABLE `victim` (
  `lab_case_no` bigint(20) NOT NULL,
  `person_id` bigint(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `victim`
--

INSERT INTO `victim` (`lab_case_no`, `person_id`, `date_created`) VALUES
(2, 1, '2018-05-30 16:05:50');

-- --------------------------------------------------------

--
-- Structure for view `laboratory`
--
DROP TABLE IF EXISTS `laboratory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `laboratory`  AS  select `laboratory_case`.`lab_case_no` AS `ID`,`laboratory_case`.`lab_case_no_id` AS `CaseID`,`laboratory_case`.`date_received` AS `Date_Recieved`,`agency`.`agency_name` AS `Requesting_Agency`,`evidence`.`cellphone` AS `CP`,`evidence`.`tablet` AS `TAB`,`evidence`.`desktop` AS `DT`,`evidence`.`loptop` AS `LT`,`evidence`.`sim` AS `SIM`,`evidence`.`secure_digital` AS `SD`,`evidence`.`flash_drive` AS `USB`,`evidence`.`external_drive` AS `ED`,`evidence`.`optical_drive` AS `OD`,`evidence`.`hard_disk_drive` AS `HDD`,`evidence`.`dc` AS `DC`,`evidence`.`dvr` AS `DVR`,`evidence`.`status` AS `Evidence_Status`,`laboratory_case`.`case_status` AS `Case_Status`,`laboratory_case`.`date_examined` AS `Date_Examined`,`laboratory_case`.`claimed_by` AS `Claimed_By`,`laboratory_case`.`released_by` AS `Released_By`,`laboratory_case`.`date_informed` AS `Date_Informed`,`facts`.`name` AS `Fact_Name`,`facts`.`remarks` AS `Remarks` from (((((`laboratory_case` join `agency` on((`laboratory_case`.`requesting_agency` = `agency`.`agency_id`))) join `officer` on((`laboratory_case`.`investigator` = `officer`.`officer_id`))) join `persons` on((`laboratory_case`.`complainant` = `persons`.`person_id`))) join `evidence` on((`laboratory_case`.`lab_case_no` = `evidence`.`lab_case_no`))) join `facts` on((`laboratory_case`.`facts` = `facts`.`fact_no`))) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`acc_id`),
  ADD KEY `officer_id` (`officer_id`);

--
-- Indexes for table `agency`
--
ALTER TABLE `agency`
  ADD PRIMARY KEY (`agency_id`);

--
-- Indexes for table `case_nature`
--
ALTER TABLE `case_nature`
  ADD KEY `lab_case_no` (`lab_case_no`),
  ADD KEY `nature_of_case` (`nature_of_case`);

--
-- Indexes for table `evidence`
--
ALTER TABLE `evidence`
  ADD KEY `lab_case_no` (`lab_case_no`);

--
-- Indexes for table `facts`
--
ALTER TABLE `facts`
  ADD PRIMARY KEY (`fact_no`);

--
-- Indexes for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  ADD PRIMARY KEY (`lab_case_no`),
  ADD KEY `complainant` (`complainant`),
  ADD KEY `requesting_agency` (`requesting_agency`),
  ADD KEY `examiner` (`examiner`),
  ADD KEY `investigator` (`investigator`),
  ADD KEY `facts` (`facts`);

--
-- Indexes for table `law`
--
ALTER TABLE `law`
  ADD PRIMARY KEY (`law_id`);

--
-- Indexes for table `officer`
--
ALTER TABLE `officer`
  ADD PRIMARY KEY (`officer_id`),
  ADD KEY `rank` (`rank`),
  ADD KEY `agency` (`agency`);

--
-- Indexes for table `persons`
--
ALTER TABLE `persons`
  ADD PRIMARY KEY (`person_id`);

--
-- Indexes for table `rank`
--
ALTER TABLE `rank`
  ADD PRIMARY KEY (`rank_id`);

--
-- Indexes for table `suspect`
--
ALTER TABLE `suspect`
  ADD KEY `lab_case_no` (`lab_case_no`),
  ADD KEY `person_id` (`person_id`);

--
-- Indexes for table `victim`
--
ALTER TABLE `victim`
  ADD KEY `lab_case_no` (`lab_case_no`),
  ADD KEY `person_id` (`person_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `acc_id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `agency`
--
ALTER TABLE `agency`
  MODIFY `agency_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `facts`
--
ALTER TABLE `facts`
  MODIFY `fact_no` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  MODIFY `lab_case_no` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `law`
--
ALTER TABLE `law`
  MODIFY `law_id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `officer`
--
ALTER TABLE `officer`
  MODIFY `officer_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `person_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `rank`
--
ALTER TABLE `rank`
  MODIFY `rank_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `accounts`
--
ALTER TABLE `accounts`
  ADD CONSTRAINT `accounts_ibfk_1` FOREIGN KEY (`officer_id`) REFERENCES `officer` (`officer_id`);

--
-- Constraints for table `case_nature`
--
ALTER TABLE `case_nature`
  ADD CONSTRAINT `case_nature_ibfk_1` FOREIGN KEY (`nature_of_case`) REFERENCES `law` (`law_id`);

--
-- Constraints for table `evidence`
--
ALTER TABLE `evidence`
  ADD CONSTRAINT `evidence_ibfk_1` FOREIGN KEY (`lab_case_no`) REFERENCES `laboratory_case` (`lab_case_no`);

--
-- Constraints for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  ADD CONSTRAINT `laboratory_case_ibfk_1` FOREIGN KEY (`examiner`) REFERENCES `officer` (`officer_id`),
  ADD CONSTRAINT `laboratory_case_ibfk_2` FOREIGN KEY (`investigator`) REFERENCES `officer` (`officer_id`),
  ADD CONSTRAINT `laboratory_case_ibfk_3` FOREIGN KEY (`requesting_agency`) REFERENCES `agency` (`agency_id`),
  ADD CONSTRAINT `laboratory_case_ibfk_4` FOREIGN KEY (`complainant`) REFERENCES `persons` (`person_id`),
  ADD CONSTRAINT `laboratory_case_ibfk_5` FOREIGN KEY (`facts`) REFERENCES `facts` (`fact_no`);

--
-- Constraints for table `suspect`
--
ALTER TABLE `suspect`
  ADD CONSTRAINT `suspect_ibfk_1` FOREIGN KEY (`lab_case_no`) REFERENCES `laboratory_case` (`lab_case_no`),
  ADD CONSTRAINT `suspect_ibfk_2` FOREIGN KEY (`person_id`) REFERENCES `persons` (`person_id`);

--
-- Constraints for table `victim`
--
ALTER TABLE `victim`
  ADD CONSTRAINT `victim_ibfk_1` FOREIGN KEY (`lab_case_no`) REFERENCES `laboratory_case` (`lab_case_no`),
  ADD CONSTRAINT `victim_ibfk_2` FOREIGN KEY (`person_id`) REFERENCES `persons` (`person_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
