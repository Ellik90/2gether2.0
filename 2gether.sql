-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 10 jan 2023 kl 17:15
-- Serverversion: 10.4.25-MariaDB
-- PHP-version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `2gether`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `age`
--

CREATE TABLE `age` (
  `id` int(11) NOT NULL,
  `lower_age` int(11) DEFAULT NULL,
  `upper_age` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `age`
--

INSERT INTO `age` (`id`, `lower_age`, `upper_age`) VALUES
(1, 18, 25),
(2, 26, 33),
(3, 34, 41),
(4, 42, 49),
(5, 50, 57),
(6, 58, 65),
(7, 66, 73),
(8, 74, 81),
(9, 82, 90);

-- --------------------------------------------------------

--
-- Tabellstruktur `interests`
--

CREATE TABLE `interests` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `interests`
--

INSERT INTO `interests` (`id`, `name`) VALUES
(1, 'Hemmamysarn'),
(2, 'Resenären'),
(3, 'Friluftslevaren'),
(4, 'Festprissen');

-- --------------------------------------------------------

--
-- Tabellstruktur `landscape`
--

CREATE TABLE `landscape` (
  `id` int(11) NOT NULL,
  `name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `landscape`
--

INSERT INTO `landscape` (`id`, `name`) VALUES
(1, 'Norrbotten'),
(2, 'Västerbotten'),
(3, 'Jämtland'),
(4, 'Västernorrland'),
(5, 'Gävleborg'),
(6, 'Dalarna'),
(7, 'Uppsala'),
(8, 'Västmanland'),
(9, 'Värmland'),
(10, 'Stockholm'),
(11, 'Södermanland'),
(12, 'Örebro'),
(13, 'Östergötland'),
(14, 'Västra Götaland'),
(15, 'Jönköping'),
(16, 'Kalmar'),
(17, 'Kronoberg'),
(18, 'Gotland'),
(19, 'Halland'),
(20, 'Blekinge'),
(21, 'Skåne');

-- --------------------------------------------------------

--
-- Tabellstruktur `matches`
--

CREATE TABLE `matches` (
  `id` int(11) NOT NULL,
  `one_user_account_id` int(11) DEFAULT NULL,
  `two_user_account_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `matches`
--

INSERT INTO `matches` (`id`, `one_user_account_id`, `two_user_account_id`) VALUES
(86, 47, 48),
(87, 48, 47),
(88, 45, 48),
(89, 48, 45),
(90, 43, 45),
(91, 45, 43),
(92, 42, 48),
(93, 48, 42),
(96, 33, 39),
(97, 39, 33),
(98, 33, 48),
(99, 48, 33),
(100, 40, 39),
(101, 39, 40),
(102, 32, 41),
(103, 41, 32),
(106, 48, 32),
(107, 32, 48);

-- --------------------------------------------------------

--
-- Tabellstruktur `message`
--

CREATE TABLE `message` (
  `id` int(11) NOT NULL,
  `content` text DEFAULT NULL,
  `sender_id` int(11) DEFAULT NULL,
  `receiver_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellstruktur `user_account`
--

CREATE TABLE `user_account` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `gender` varchar(50) DEFAULT NULL,
  `age` int(50) DEFAULT NULL,
  `personal_number` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `pass_word` varchar(50) DEFAULT NULL,
  `about_me` text DEFAULT NULL,
  `date_time` datetime NOT NULL DEFAULT current_timestamp(),
  `land_scape_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `user_account`
--

INSERT INTO `user_account` (`id`, `first_name`, `last_name`, `gender`, `age`, `personal_number`, `email`, `pass_word`, `about_me`, `date_time`, `land_scape_id`) VALUES
(32, 'Sofia ', 'Eriksson', 'miss', 25, '970808-1212', 'sofia@live.se', '123', NULL, '2022-12-29 16:30:21', 10),
(33, 'Stefan', 'Mcbean', 'mr', 56, '680101-2323', 'stefan@live.se', '123', NULL, '2022-12-29 16:31:04', 18),
(34, 'Klaes', 'Jansson', 'mr', 70, '501212-0202', 'klaes@live.se', '123', NULL, '2022-12-29 16:31:58', 21),
(35, 'Jennifer', 'Håkansson', 'miss', 20, '20020202-2323', 'jennifer@live.se', '123', NULL, '2022-12-29 16:33:20', 14),
(36, 'Dan', 'Samuel', 'mr', 30, '19620909-1212', 'dan@live.se', '123', NULL, '2022-12-29 16:35:48', 16),
(39, 'Daryl', 'Jacobs', 'mr', 40, '19780101-2323', 'daryl@live.se', '123', NULL, '2022-12-29 16:37:47', 14),
(40, 'Eliza', 'Donald', 'binary', 47, '19800201-1212', 'eliza@live.se', '123', NULL, '2022-12-29 16:39:14', 20),
(41, 'Matt', 'Fraser', 'mr', 42, '19821010-2020', 'matt@live.se', '123', NULL, '2022-12-29 16:39:48', 19),
(42, 'Will', 'Richardsson', 'mr', 39, '19840202-1212', 'will@live.se', '123', NULL, '2022-12-29 16:40:34', 12),
(43, 'Clark', 'Hansen', 'binary', 61, '19563434-0202', 'clark@live.se', '123', NULL, '2022-12-29 16:41:56', 11),
(44, 'Fredrik', 'Pålsson', 'mr', 23, '19990306-2323', 'fredrik@live.se', '123', NULL, '2022-12-29 16:42:47', 7),
(45, 'Alissa', 'Stenmark', 'miss', 50, '19950202-2323', 'alissa@live.se', '123', NULL, '2022-12-29 16:43:17', 14),
(46, 'Kirk', 'Tanning', 'mr', 39, '19920202-2323', 'kirk@live.se', '123', NULL, '2022-12-29 16:44:34', 10),
(47, 'Samuel', 'Johansson', 'mr', 31, '19900202-2323', 'samuel@live.se', '123', NULL, '2022-12-29 16:45:23', 3),
(48, 'Bob', 'Sagon', 'mr', 44, '18872233-9292', 'bob@live.se', '123', NULL, '2022-12-29 16:46:34', 14),
(49, 'Linus', 'Karlsson', 'mr', 35, '198705469864', 'Linus@live.se', '123', NULL, '2023-01-03 12:18:51', 13),
(50, 'Elina', 'Andersson', 'miss', 32, '199103170546', 'Andersson@live.se', '123', NULL, '2023-01-05 10:17:58', 12),
(51, 'Johan', 'Nilsson', 'mr', 45, '199007675432', 'johan@live.se', '123', NULL, '2023-01-05 12:58:12', 3);

-- --------------------------------------------------------

--
-- Tabellstruktur `user_age`
--

CREATE TABLE `user_age` (
  `id` int(11) NOT NULL,
  `age_id` int(11) DEFAULT NULL,
  `user_account_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `user_age`
--

INSERT INTO `user_age` (`id`, `age_id`, `user_account_id`) VALUES
(47, 2, 48),
(48, 4, 48),
(49, 2, 47),
(50, 3, 47),
(51, 4, 47),
(52, 1, 41),
(53, 2, 41),
(54, 3, 41),
(55, 4, 41),
(56, 4, 45),
(57, 4, 45),
(58, 2, 36),
(59, 3, 36),
(60, 7, 36),
(61, 5, 43),
(62, 5, 43),
(63, 7, 43),
(64, 4, 42),
(65, 3, 42),
(66, 6, 42),
(67, 1, 39),
(68, 2, 39),
(69, 3, 39),
(70, 3, 33),
(71, 4, 33),
(72, 3, 40),
(73, 4, 32),
(74, 3, 32),
(75, 7, 32),
(76, 8, 32),
(80, 1, 48);

-- --------------------------------------------------------

--
-- Tabellstruktur `user_interests`
--

CREATE TABLE `user_interests` (
  `id` int(11) NOT NULL,
  `interests_id` int(11) DEFAULT NULL,
  `user_account_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `user_interests`
--

INSERT INTO `user_interests` (`id`, `interests_id`, `user_account_id`) VALUES
(48, 2, 48),
(49, 1, 48),
(50, 2, 47),
(51, 1, 47),
(52, 3, 47),
(53, 1, 41),
(54, 2, 41),
(55, 4, 41),
(56, 1, 41),
(57, 1, 45),
(58, 2, 45),
(59, 1, 36),
(60, 2, 36),
(61, 1, 36),
(62, 1, 43),
(63, 1, 43),
(64, 1, 43),
(65, 1, 42),
(66, 2, 42),
(67, 3, 42),
(68, 1, 39),
(69, 2, 39),
(70, 1, 39),
(71, 1, 33),
(72, 2, 33),
(73, 1, 40),
(74, 1, 32),
(75, 2, 32),
(76, 3, 32),
(77, 2, 32),
(81, 1, 48);

-- --------------------------------------------------------

--
-- Tabellstruktur `user_landscape`
--

CREATE TABLE `user_landscape` (
  `id` int(11) NOT NULL,
  `user_account_id` int(11) DEFAULT NULL,
  `landscape_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumpning av Data i tabell `user_landscape`
--

INSERT INTO `user_landscape` (`id`, `user_account_id`, `landscape_id`) VALUES
(45, 48, 14),
(46, 48, 10),
(47, 47, 8),
(48, 47, 19),
(49, 47, 14),
(50, 41, 21),
(51, 41, 17),
(52, 41, 15),
(53, 41, 10),
(54, 45, 18),
(55, 45, 14),
(56, 36, 15),
(57, 36, 18),
(58, 36, 20),
(59, 43, 17),
(60, 43, 19),
(61, 43, 14),
(62, 42, 17),
(63, 42, 14),
(64, 42, 15),
(65, 39, 21),
(66, 39, 20),
(67, 39, 14),
(68, 33, 14),
(69, 33, 10),
(70, 40, 14),
(71, 32, 19),
(72, 32, 16),
(73, 32, 10),
(74, 32, 16),
(78, 48, 1);

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `age`
--
ALTER TABLE `age`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `interests`
--
ALTER TABLE `interests`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `landscape`
--
ALTER TABLE `landscape`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `matches`
--
ALTER TABLE `matches`
  ADD PRIMARY KEY (`id`),
  ADD KEY `matches_ibfk_3` (`one_user_account_id`),
  ADD KEY `matches_ibfk_4` (`two_user_account_id`);

--
-- Index för tabell `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sender_id` (`sender_id`),
  ADD KEY `receiver_id` (`receiver_id`);

--
-- Index för tabell `user_account`
--
ALTER TABLE `user_account`
  ADD PRIMARY KEY (`id`),
  ADD KEY `land_scape_id` (`land_scape_id`) USING BTREE;

--
-- Index för tabell `user_age`
--
ALTER TABLE `user_age`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_account_id` (`user_account_id`),
  ADD KEY `age_id` (`age_id`);

--
-- Index för tabell `user_interests`
--
ALTER TABLE `user_interests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_interests_ibfk_3` (`interests_id`),
  ADD KEY `user_interests_ibfk_4` (`user_account_id`);

--
-- Index för tabell `user_landscape`
--
ALTER TABLE `user_landscape`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_landscape_ibfk_2` (`landscape_id`),
  ADD KEY `user_landscape_ibfk_3` (`user_account_id`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `matches`
--
ALTER TABLE `matches`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=108;

--
-- AUTO_INCREMENT för tabell `message`
--
ALTER TABLE `message`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT för tabell `user_account`
--
ALTER TABLE `user_account`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT för tabell `user_age`
--
ALTER TABLE `user_age`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;

--
-- AUTO_INCREMENT för tabell `user_interests`
--
ALTER TABLE `user_interests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=82;

--
-- AUTO_INCREMENT för tabell `user_landscape`
--
ALTER TABLE `user_landscape`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;

--
-- Restriktioner för dumpade tabeller
--

--
-- Restriktioner för tabell `matches`
--
ALTER TABLE `matches`
  ADD CONSTRAINT `matches_ibfk_3` FOREIGN KEY (`one_user_account_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `matches_ibfk_4` FOREIGN KEY (`two_user_account_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Restriktioner för tabell `message`
--
ALTER TABLE `message`
  ADD CONSTRAINT `message_ibfk_1` FOREIGN KEY (`sender_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `message_ibfk_2` FOREIGN KEY (`receiver_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE;

--
-- Restriktioner för tabell `user_account`
--
ALTER TABLE `user_account`
  ADD CONSTRAINT `user_account_ibfk_1` FOREIGN KEY (`land_scape_id`) REFERENCES `landscape` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Restriktioner för tabell `user_age`
--
ALTER TABLE `user_age`
  ADD CONSTRAINT `user_age_ibfk_3` FOREIGN KEY (`age_id`) REFERENCES `age` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_age_ibfk_4` FOREIGN KEY (`user_account_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Restriktioner för tabell `user_interests`
--
ALTER TABLE `user_interests`
  ADD CONSTRAINT `user_interests_ibfk_3` FOREIGN KEY (`interests_id`) REFERENCES `interests` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_interests_ibfk_4` FOREIGN KEY (`user_account_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Restriktioner för tabell `user_landscape`
--
ALTER TABLE `user_landscape`
  ADD CONSTRAINT `user_landscape_ibfk_2` FOREIGN KEY (`landscape_id`) REFERENCES `landscape` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_landscape_ibfk_3` FOREIGN KEY (`user_account_id`) REFERENCES `user_account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
