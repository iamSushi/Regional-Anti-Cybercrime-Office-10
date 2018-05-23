-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2018 at 08:13 AM
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
  `acc_id` int(11) NOT NULL,
  `officer_id` int(20) NOT NULL,
  `position` varchar(20) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`acc_id`, `officer_id`, `position`, `username`, `password`) VALUES
(1, 1, 'admin', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `agency`
--

CREATE TABLE `agency` (
  `agency_id` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
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
  `nature_of_case` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `destinction`
--

CREATE TABLE `destinction` (
  `destinct_id` bigint(20) NOT NULL,
  `person_id` bigint(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `dfe`
--

CREATE TABLE `dfe` (
  `dfe_id` bigint(20) NOT NULL,
  `lab_case_no` bigint(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `evidence`
--

CREATE TABLE `evidence` (
  `dfe_id` bigint(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  `qty` varchar(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `facts`
--

CREATE TABLE `facts` (
  `fact_no` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `remarks` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `laboratory_case`
--

CREATE TABLE `laboratory_case` (
  `lab_case_no` bigint(20) NOT NULL,
  `lab_case_no_id` varchar(50) NOT NULL,
  `date_received` date NOT NULL,
  `complainant` int(20) DEFAULT NULL,
  `victim` int(20) DEFAULT NULL,
  `suspect` int(20) DEFAULT NULL,
  `requesting_agency` int(20) DEFAULT NULL,
  `examiner` int(20) DEFAULT NULL,
  `investigator` int(20) DEFAULT NULL,
  `date_occur` date NOT NULL,
  `time_occur` time NOT NULL,
  `place_occur` varchar(50) NOT NULL,
  `remarks` varchar(50) DEFAULT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `laboratory_case`
--

INSERT INTO `laboratory_case` (`lab_case_no`, `lab_case_no_id`, `date_received`, `complainant`, `victim`, `suspect`, `requesting_agency`, `examiner`, `investigator`, `date_occur`, `time_occur`, `place_occur`, `remarks`, `date_created`) VALUES
(1, 'daw', '0000-00-00', NULL, NULL, NULL, 0, 0, 0, '0000-00-00', '00:00:00', 'dadw', '', '2018-05-17 14:27:56');

-- --------------------------------------------------------

--
-- Table structure for table `law`
--

CREATE TABLE `law` (
  `law_id` bigint(20) NOT NULL,
  `designation` varchar(50) NOT NULL,
  `date_passed` date NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nature`
--

CREATE TABLE `nature` (
  `nature_no` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `remarks` longtext NOT NULL
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
  `rank` varchar(20) NOT NULL,
  `office` varchar(50) NOT NULL,
  `user` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  `remark` varchar(50) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `officer`
--

INSERT INTO `officer` (`officer_id`, `fname`, `mname`, `sname`, `dob`, `gender`, `contact`, `email`, `rank`, `office`, `user`, `pass`, `remark`, `date_created`) VALUES
(1, 'joshua', NULL, 'perater', '2018-05-10', 'male', '09169947508', 'jbperater15', 'spo1', 'alagar', 'admin', 'admin', 'secret', '2018-05-16 13:33:24'),
(2, 'aw', 'saw', 'daw', '0000-00-00', 'female', 'daw', 'sa', 'dawd', 'awd', 'null', 'null', 'dawdad', '2018-05-17 07:15:17'),
(3, 'dawdaw', 'dwwa', 'aws', '0000-00-00', 'female', 'wda', 'awd', 'dawd', 'ada', 'null', 'null', 'dawdaw', '2018-05-17 07:17:01'),
(4, '', '', '', '0000-00-00', 'female', '', '', '', '', 'null', 'null', '', '2018-05-22 02:15:56'),
(5, 'James', 'Sinadjan', '', '0000-00-00', 'female', '', '', '', '', 'null', 'null', '', '2018-05-22 02:16:05'),
(6, 'Jhon', 'Doe', 'Dee', '0000-00-00', 'male', '', '', '', '', 'null', 'null', '', '2018-05-22 02:16:36'),
(7, 'Uzumaki', 'Secreto', 'Naruto', '0000-00-00', 'female', '', '', 'Police Officer 3', '', 'null', 'null', '', '2018-05-22 08:09:45');

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
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `persons`
--

INSERT INTO `persons` (`person_id`, `fname`, `mname`, `sname`, `nname`, `dob`, `gender`, `status`, `contact`, `email`, `category`, `date_created`) VALUES
(1, 'joshua', 'omagap', 'perater', 'gwapo', '2018-05-22', 'male', 'single', '09169947508', NULL, '', '2018-05-16 12:40:18'),
(2, 'sample', 'lang', 'ni', 'null', '0000-00-00', 'male', 'Single', '09169947508', 'try@gmail.com', 'Complainant', '2018-05-16 16:03:41'),
(3, 'sakura', '', 'Uchiha', 'null', '0000-00-00', 'female', 'Married', '0316495', 'sakura@gmail.com', 'Victim', '2018-05-16 17:17:23'),
(4, 'dawd', 'dawd', 'adwda', 'null', '0000-00-00', 'female', 'Widowed', 'daw', 'awd', 'Victim', '2018-05-17 07:22:25'),
(5, 'Yunnah', 'Chuyy', 'Masaya', 'null', '0000-00-00', 'male', '', '', '', '', '2018-05-22 02:17:17'),
(6, 'fbhdfbj', 'vxdbxd', 'bxdc', 'null', '0000-00-00', 'female', 'Divorced', 'xbxd', 'vxdvxd', 'Complainant', '2018-05-22 08:03:06');

-- --------------------------------------------------------

--
-- Table structure for table `rank`
--

CREATE TABLE `rank` (
  `rank_id` bigint(20) NOT NULL,
  `rank` varchar(50) NOT NULL,
  `date_created` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE `reports` (
  `report_id` bigint(20) NOT NULL,
  `lab_case_no` bigint(20) NOT NULL,
  `date_informed` date NOT NULL,
  `date_released` date NOT NULL,
  `released_by` bigint(20) NOT NULL,
  `claimed_by` bigint(20) NOT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`acc_id`);

--
-- Indexes for table `agency`
--
ALTER TABLE `agency`
  ADD PRIMARY KEY (`agency_id`);

--
-- Indexes for table `case_nature`
--
ALTER TABLE `case_nature`
  ADD KEY `lab_case_no` (`lab_case_no`);

--
-- Indexes for table `destinction`
--
ALTER TABLE `destinction`
  ADD PRIMARY KEY (`destinct_id`),
  ADD KEY `person_id` (`person_id`);

--
-- Indexes for table `dfe`
--
ALTER TABLE `dfe`
  ADD PRIMARY KEY (`dfe_id`),
  ADD KEY `lab_case_no` (`lab_case_no`);

--
-- Indexes for table `evidence`
--
ALTER TABLE `evidence`
  ADD KEY `dfe_id` (`dfe_id`);

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
  ADD KEY `victim` (`victim`),
  ADD KEY `suspect` (`suspect`),
  ADD KEY `requesting_agency` (`requesting_agency`),
  ADD KEY `examiner` (`examiner`),
  ADD KEY `investigator` (`investigator`);

--
-- Indexes for table `law`
--
ALTER TABLE `law`
  ADD PRIMARY KEY (`law_id`);

--
-- Indexes for table `nature`
--
ALTER TABLE `nature`
  ADD PRIMARY KEY (`nature_no`);

--
-- Indexes for table `officer`
--
ALTER TABLE `officer`
  ADD PRIMARY KEY (`officer_id`);

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
-- Indexes for table `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`report_id`),
  ADD KEY `lab_case_no` (`lab_case_no`),
  ADD KEY `released_by` (`released_by`),
  ADD KEY `claimed_by` (`claimed_by`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `acc_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `agency`
--
ALTER TABLE `agency`
  MODIFY `agency_id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `destinction`
--
ALTER TABLE `destinction`
  MODIFY `destinct_id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dfe`
--
ALTER TABLE `dfe`
  MODIFY `dfe_id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `facts`
--
ALTER TABLE `facts`
  MODIFY `fact_no` int(11) NOT NULL AUTO_INCREMENT;

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
-- AUTO_INCREMENT for table `nature`
--
ALTER TABLE `nature`
  MODIFY `nature_no` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `officer`
--
ALTER TABLE `officer`
  MODIFY `officer_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `person_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `rank`
--
ALTER TABLE `rank`
  MODIFY `rank_id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `report_id` bigint(20) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
