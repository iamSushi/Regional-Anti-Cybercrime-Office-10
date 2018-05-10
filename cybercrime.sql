-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 10, 2018 at 02:22 AM
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
-- Table structure for table `agency`
--

CREATE TABLE `agency` (
  `agency_id` bigint(20) NOT NULL,
  `name` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `mother_unit` varchar(50) NOT NULL,
  `contact_no` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
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
  `type` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `evidence`
--

CREATE TABLE `evidence` (
  `dfe_id` bigint(20) NOT NULL,
  `type` varchar(20) NOT NULL,
  `qty` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `laboratory_case`
--

CREATE TABLE `laboratory_case` (
  `lab_case_no` bigint(20) NOT NULL,
  `lab_case_no_id` varchar(50) NOT NULL,
  `date_received` date NOT NULL,
  `complainant` bigint(20) NOT NULL,
  `victim` bigint(20) NOT NULL,
  `suspect` bigint(20) NOT NULL,
  `requesting_agency` bigint(20) NOT NULL,
  `examiner` bigint(20) NOT NULL,
  `investigator` bigint(20) NOT NULL,
  `remarks` varchar(50) NOT NULL
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
  `office` varchar(50) NOT NULL
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
  `nname` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `gender` varchar(20) NOT NULL,
  `status` varchar(20) NOT NULL,
  `contact` varchar(20) DEFAULT NULL,
  `date_created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
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
  `claimed_by` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

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
-- AUTO_INCREMENT for table `laboratory_case`
--
ALTER TABLE `laboratory_case`
  MODIFY `lab_case_no` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `officer`
--
ALTER TABLE `officer`
  MODIFY `officer_id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `persons`
--
ALTER TABLE `persons`
  MODIFY `person_id` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `report_id` bigint(20) NOT NULL AUTO_INCREMENT;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
