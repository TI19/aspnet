-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Dec 07, 2019 at 07:28 PM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `mahasiswaglobal`
--

-- --------------------------------------------------------

--
-- Table structure for table `biodata`
--

CREATE TABLE IF NOT EXISTS `biodata` (
  `MhsId` int(11) NOT NULL AUTO_INCREMENT,
  `Nim` varchar(20) NOT NULL,
  `Nama` varchar(100) NOT NULL,
  `Kelas` varchar(50) NOT NULL,
  `Kota` varchar(50) NOT NULL,
  `Alamat` text NOT NULL,
  `TempatLahir` varchar(100) NOT NULL,
  `TglLahir` Datetime NOT NULL,
  `TipeKelas` varchar(50) NOT NULL,
  `foto` text NOT NULL,
  PRIMARY KEY (`MhsId`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `biodata`
--


--
-- Table structure for table `dosen`
--

CREATE TABLE IF NOT EXISTS `dosen` (
  `nidn` int(25) NOT NULL AUTO_INCREMENT,
  `iddsn` varchar(30) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  PRIMARY KEY (`nidn`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=54 ;

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`nidn`, `iddsn`, `nama`, `alamat`) VALUES
(1, 'DS0001', 'Ramaddan Julianti', 'Jl. Merdeka Utama No. 2'),
(2, 'DS0002', 'Achmad Sidik', 'Jl. Pegangsaan Timur No. 2'),
(3, 'DS0003', 'Iswahyudi', 'Jl. Tiada yang abadi');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal`
--

CREATE TABLE IF NOT EXISTS `jadwal` (
  `id_jadwal` int(11) NOT NULL AUTO_INCREMENT,
  `nidn` int(11) NOT NULL,
  `matakuliah` varchar(30) NOT NULL,
  `semester` int(1) NOT NULL,
  `kelas` varchar(30) NOT NULL,
  `tahunajaran` varchar(10) NOT NULL,
  PRIMARY KEY (`id_jadwal`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `level` enum('0','1') NOT NULL,
  `status` enum('0','1') NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `user`, `pass`, `nama`, `level`, `status`) VALUES
(5, 'admin', '123', 'administrator', '1', '1');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
