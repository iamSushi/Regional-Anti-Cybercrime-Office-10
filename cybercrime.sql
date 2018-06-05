-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 05, 2018 at 12:27 PM
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
  `agency_name` varchar(255) NOT NULL,
  `street` varchar(255) DEFAULT NULL,
  `barangay` varchar(255) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `province` varchar(255) DEFAULT NULL,
  `mother_unit` varchar(255) NOT NULL,
  `contact_no` varchar(50) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `agency`
--

INSERT INTO `agency` (`agency_id`, `agency_name`, `street`, `barangay`, `city`, `province`, `mother_unit`, `contact_no`, `email`, `date_created`) VALUES
(2, 'El Salvador City Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:05:47'),
(3, 'Gingoog City Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:14:38'),
(4, 'Alubijid Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:14:56'),
(5, 'Balingasag Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:16:07'),
(6, 'Balingoan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:18:33'),
(7, 'Binuangan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:19:00'),
(8, 'Claveria Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:19:14'),
(9, 'Gitagum Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:19:28'),
(10, 'Initao Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:20:00'),
(11, 'Jasaan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:20:44'),
(12, 'Kinoguitan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:21:10'),
(13, 'Lagonglong Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:21:39'),
(14, 'Laguindingan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:22:00'),
(15, 'Libertad Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:22:23'),
(16, 'Lugait Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:22:41'),
(17, 'Magsaysay Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:23:02'),
(18, 'Manticao Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:23:29'),
(19, 'Medina Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:24:37'),
(20, 'Naawan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:25:42'),
(21, 'Opol Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:25:58'),
(22, 'Salay Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:26:17'),
(23, 'Sugbongcogon Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:26:41'),
(24, 'Tagoloan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:27:07'),
(25, 'Talisayan Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:27:20'),
(26, 'Villanueva Municipality Police Station', '', '', '', '', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:27:48'),
(27, 'Misamis Oriental Provincial Police Office', '', 'San Martin', 'Villanueva', 'Misamis Oriental', 'Misamis Oriental Provincial Police Office', '09xx xxx xxxx', '', '2018-06-05 08:30:04');

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

-- --------------------------------------------------------

--
-- Table structure for table `facts`
--

CREATE TABLE `facts` (
  `lab_case_no` bigint(20) NOT NULL,
  `what` text NOT NULL,
  `date_occur` date NOT NULL,
  `time_occur` varchar(255) NOT NULL,
  `place_occur` varchar(255) NOT NULL,
  `why` text NOT NULL,
  `how` longtext NOT NULL,
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
  `date_informed` date DEFAULT NULL,
  `date_released` date NOT NULL,
  `date_examined` date NOT NULL,
  `case_status` varchar(20) NOT NULL,
  `released_by` bigint(20) DEFAULT NULL,
  `claimed_by` bigint(20) DEFAULT NULL,
  `complainant` bigint(20) DEFAULT NULL,
  `requesting_agency` bigint(20) DEFAULT NULL,
  `examiner` bigint(20) DEFAULT NULL,
  `investigator` bigint(20) DEFAULT NULL,
  `type` varchar(50) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `law`
--

CREATE TABLE `law` (
  `law_id` bigint(20) NOT NULL,
  `designation` varchar(255) NOT NULL,
  `date_passed` date DEFAULT NULL,
  `description` longtext NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `law`
--

INSERT INTO `law` (`law_id`, `designation`, `date_passed`, `description`, `date_created`) VALUES
(1, 'Act 1696', '0000-00-00', 'Known as the Flag Law, this law proscribed display of \"any flag, banner, emblem, or device used during the late insurrection in the Philippine Islands to designate or identify those in armed rebellion against the United States, or any flag, banner, emblem, or device used or adopted at any time by the public enemies of the United States in the Philippine Islands for the purposes of public disorder or of rebellion or insurrection against the authority of the United States in the Philippine Islands, or any flag, banner, emblem, or device of the Katipunan Society or which is commonly known as such.[1]\" This law was repealed in 1919.', '2018-06-05 07:05:17'),
(2, 'Act 2871', '0000-00-00', 'Repealed the Flag Law and legalised the use of the National Flag and the National Anthem. Passed on October 24, 1919.[2]', '2018-06-05 07:06:00'),
(3, 'Act 3436', '0000-00-00', 'Established the Philippine Long Distance Telephone Company (PLDT) with the bill granting it a 50-year charter.', '2018-06-05 07:07:20'),
(4, 'Act 3815', '0000-00-00', 'The Revised Penal Code', '2018-06-05 07:12:06'),
(5, 'Act 3827', '0000-00-00', 'Declared the last Sunday of August as National Heroes Day.', '0000-00-00 00:00:00'),
(6, 'CA 1', '0000-00-00', 'The National Defense Act of 1935, which created the Armed Forces of the Philippines.', '0000-00-00 00:00:00');

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
  `profile_image` longblob,
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

--
-- Dumping data for table `rank`
--

INSERT INTO `rank` (`rank_id`, `rank`, `abbreviation`, `date_created`) VALUES
(2, 'Police Officer 1', 'PO1', '2018-06-05 06:57:33'),
(3, 'Police Officer 2', 'PO2', '2018-06-05 06:57:33'),
(4, 'Police Officer 3', 'PO3', '2018-06-05 06:59:02'),
(5, 'Senior Police Officer 1', 'SPO1', '2018-06-05 06:59:02'),
(6, 'Senior Police Officer 2', 'SPO2', '2018-06-05 06:59:02'),
(7, 'Senior Police Officer 3', 'SPO3', '2018-06-05 06:59:02'),
(8, 'Senior Police Officer 4', 'SPO4', '2018-06-05 06:59:02'),
(10, 'Inspector', 'Lieutenant', '2018-06-05 07:01:15'),
(11, 'Senior Inspector', 'Captain', '2018-06-05 07:01:29'),
(12, 'Chief Inspector', 'Major', '2018-06-05 07:01:45'),
(13, 'Superintendent', 'Lieutenant Colonel', '2018-06-05 07:02:11'),
(14, 'Senior Superintendent', 'Colonel', '2018-06-05 07:02:38');

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
  ADD PRIMARY KEY (`lab_case_no`);

--
-- Indexes for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  ADD PRIMARY KEY (`lab_case_no`),
  ADD KEY `complainant` (`complainant`),
  ADD KEY `requesting_agency` (`requesting_agency`),
  ADD KEY `examiner` (`examiner`),
  ADD KEY `investigator` (`investigator`),
  ADD KEY `released_by` (`released_by`),
  ADD KEY `claimed_by` (`claimed_by`);

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
-- AUTO_INCREMENT for table `agency`
--
ALTER TABLE `agency`
  MODIFY `agency_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `facts`
--
ALTER TABLE `facts`
  MODIFY `lab_case_no` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  MODIFY `lab_case_no` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `law`
--
ALTER TABLE `law`
  MODIFY `law_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `officer`
--
ALTER TABLE `officer`
  MODIFY `officer_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `person_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `rank`
--
ALTER TABLE `rank`
  MODIFY `rank_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

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
-- Constraints for table `facts`
--
ALTER TABLE `facts`
  ADD CONSTRAINT `facts_ibfk_1` FOREIGN KEY (`lab_case_no`) REFERENCES `laboratory_case` (`lab_case_no`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  ADD CONSTRAINT `laboratory_case_ibfk_1` FOREIGN KEY (`released_by`) REFERENCES `officer` (`officer_id`),
  ADD CONSTRAINT `laboratory_case_ibfk_2` FOREIGN KEY (`claimed_by`) REFERENCES `officer` (`officer_id`);

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
