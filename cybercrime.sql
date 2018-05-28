-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 28, 2018 at 11:13 PM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.2

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
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `rank` bigint(20) NOT NULL,
  `position` varchar(50) NOT NULL,
  `agency` bigint(20) NOT NULL,
  `remark` varchar(50) NOT NULL,
  `profile_image` longblob NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  MODIFY `acc_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `agency`
--
ALTER TABLE `agency`
  MODIFY `agency_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `facts`
--
ALTER TABLE `facts`
  MODIFY `fact_no` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  MODIFY `lab_case_no` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `law`
--
ALTER TABLE `law`
  MODIFY `law_id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `officer`
--
ALTER TABLE `officer`
  MODIFY `officer_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `person_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

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
-- Constraints for table `officer`
--
ALTER TABLE `officer`
  ADD CONSTRAINT `officer_ibfk_2` FOREIGN KEY (`rank`) REFERENCES `rank` (`rank_id`),
  ADD CONSTRAINT `officer_ibfk_3` FOREIGN KEY (`agency`) REFERENCES `agency` (`agency_id`);

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
