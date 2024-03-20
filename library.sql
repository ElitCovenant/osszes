-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2024. Már 20. 08:25
-- Kiszolgáló verziója: 8.0.31
-- PHP verzió: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `library`
--
CREATE DATABASE IF NOT EXISTS `library` DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci;
USE `library`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `account_img`
--

DROP TABLE IF EXISTS `account_img`;
CREATE TABLE IF NOT EXISTS `account_img` (
  `id` int NOT NULL AUTO_INCREMENT,
  `img_name` varchar(100) NOT NULL,
  `img_path` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `account_img`
--

INSERT INTO `account_img` (`id`, `img_name`, `img_path`) VALUES
(1, 'Default', './img/default_prof_picture.png'),
(2, 'Teacher_1', './img/teacher1_prof_picture.png'),
(3, 'Teacher_2', './img/teacher2_prof_picture.png'),
(4, 'Guest_1', './img/quest1_prof_picture.png'),
(5, 'Guest_2', './img/quest2_prof_picture.png');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `author`
--

DROP TABLE IF EXISTS `author`;
CREATE TABLE IF NOT EXISTS `author` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `author`
--

INSERT INTO `author` (`id`, `name`) VALUES
(1, 'No information'),
(2, 'Ady Endre'),
(3, 'Arany János'),
(4, 'Babits Mihály'),
(5, 'Balzac, Honoré de'),
(6, 'Csokonai Vitéz Mihály'),
(7, 'Barabás Tibor'),
(8, 'Brecht, Bertolt'),
(9, 'Bóka László'),
(10, 'Malraux, André'),
(11, 'Romain Rolland'),
(12, 'Goda Gábor'),
(13, 'Fagyejev, Alexandr'),
(14, 'Ibsen, Henrik'),
(15, 'Turgenyev, Ivan Szergejevics'),
(16, 'Reymont, Wladislaw Stanislaw'),
(17, 'Moliere'),
(18, 'Kisfaludy Károly'),
(19, 'Murányi-Kovács Endre'),
(20, 'Dercsényi Dezső - Zádor Anna'),
(21, 'Horváth István'),
(22, 'Teke Zsuzsa'),
(23, 'Gorkij, Maxim'),
(24, 'Fábián Janka'),
(25, 'Fedor Vilmos'),
(26, 'Follett, Ken'),
(27, 'Grecsó Krisztián'),
(28, 'Kun Árpád'),
(29, 'King, Stephen'),
(30, 'Meyer, Stephenie'),
(31, 'Fejős Éva'),
(32, 'Lagercrantz, David'),
(33, 'Sztrugackij, Arkagyij és Borisz'),
(34, 'Cs. Nagy Lajos');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `book`
--

DROP TABLE IF EXISTS `book`;
CREATE TABLE IF NOT EXISTS `book` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `warehouse_num` int UNSIGNED NOT NULL,
  `purchase_date` date DEFAULT NULL,
  `author_id` int UNSIGNED NOT NULL DEFAULT '34',
  `title` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `series_id` int UNSIGNED DEFAULT NULL,
  `isbn_num` decimal(13,0) UNSIGNED DEFAULT NULL,
  `szakkjelzet` decimal(3,0) DEFAULT NULL,
  `cutter_jelzet` varchar(8) DEFAULT NULL,
  `publisher_id` int UNSIGNED DEFAULT NULL,
  `release_date` smallint UNSIGNED DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `comment` varchar(1000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `book_img` varchar(300) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT 'http://img.library.nhely.hu/img/default_book_img.png',
  `user_id` int UNSIGNED DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `raktari_szam_UNIQUE` (`warehouse_num`),
  KEY `fk_szerzo_id_idx` (`author_id`),
  KEY `fk_sorozat_id_idx` (`series_id`),
  KEY `fk_kiado_id_idx` (`publisher_id`),
  KEY `fk_tag_id_idx` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=556 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `book`
--

INSERT INTO `book` (`id`, `warehouse_num`, `purchase_date`, `author_id`, `title`, `series_id`, `isbn_num`, `szakkjelzet`, `cutter_jelzet`, `publisher_id`, `release_date`, `price`, `comment`, `book_img`, `user_id`) VALUES
(1, 1, '1967-01-09', 2, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, 'http://img.library.nhely.hu/img/ady_osszesvers_book_img.png', NULL),
(2, 2, '1967-01-09', 2, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, 'http://img.library.nhely.hu/img/ady_osszesvers_book_img.png', NULL),
(3, 3, '1967-01-09', 2, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, 'http://img.library.nhely.hu/img/ady_osszesvers_book_img.png', NULL),
(4, 4, '1967-01-09', 2, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, 'http://img.library.nhely.hu/img/ady_osszesvers_book_img.png', NULL),
(5, 5, '1967-01-09', 3, 'Összes költeményei', NULL, NULL, NULL, 'A 76', NULL, NULL, '110.00', NULL, 'http://img.library.nhely.hu/img/arany_osszeskolt_book_img.png', NULL),
(6, 6, '1967-01-09', 3, 'Toldi trilógia', NULL, NULL, NULL, 'A 76', NULL, NULL, '6.00', NULL, 'http://img.library.nhely.hu/img/toldi_trilogia_book_img.PNG', NULL),
(7, 8, '1967-01-09', 3, 'Toldi trilógia', NULL, NULL, NULL, 'A 76', NULL, NULL, '6.00', NULL, 'http://img.library.nhely.hu/img/toldi_trilogia_book_img.PNG', NULL),
(8, 12, '1967-01-09', 3, 'Toldi trilógia', NULL, NULL, NULL, 'A 76', NULL, NULL, '6.00', NULL, 'http://img.library.nhely.hu/img/toldi_trilogia_book_img.PNG', NULL),
(9, 13, '1967-01-09', 3, 'Toldi trilógia', NULL, NULL, NULL, 'A 76', NULL, NULL, '6.00', NULL, 'http://img.library.nhely.hu/img/toldi_trilogia_book_img.PNG', NULL),
(10, 17, '1967-01-09', 3, 'Toldi trilógia', NULL, NULL, NULL, 'A 76', NULL, NULL, '6.00', NULL, 'http://img.library.nhely.hu/img/toldi_trilogia_book_img.PNG', NULL),
(11, 28, '1967-01-09', 4, 'Jónás könyve', NULL, NULL, NULL, 'B 11', NULL, NULL, '25.00', NULL, 'http://img.library.nhely.hu/img/jonas_konyve_book_img.PNG', NULL),
(12, 29, '1967-01-09', 4, 'Jónás könyve', NULL, NULL, NULL, 'B 11', NULL, NULL, '25.00', NULL, 'http://img.library.nhely.hu/img/jonas_konyve_book_img.PNG', NULL),
(13, 30, '1967-01-09', 4, 'Jónás könyve', NULL, NULL, NULL, 'B 11', NULL, NULL, '25.00', NULL, 'http://img.library.nhely.hu/img/jonas_konyve_book_img.PNG', NULL),
(14, 38, '1967-01-09', 1, 'A kultúra világa: sport, tánc és ', NULL, NULL, '8', 'K 97', NULL, NULL, '5.00', NULL, 'http://img.library.nhely.hu/img/A_kultura_vilaga_sport_es_tanc_book_img.PNG', NULL),
(15, 39, '1967-01-09', 1, 'A kultúra világa: A technika fejlődése', NULL, NULL, '8', 'K 97', NULL, NULL, '5.00', NULL, 'http://img.library.nhely.hu/img/A_kultura_vilaga_a_technika_fejlodese_book_img.PNG', NULL),
(16, 43, '1967-01-09', 5, 'Goriot apó', NULL, NULL, NULL, 'B 16', NULL, NULL, '5.00', NULL, 'http://img.library.nhely.hu/img/goriot_apo_book_img.PNG', NULL),
(17, 49, '1967-01-09', 6, 'Dorottya, A méla tempefői', NULL, NULL, NULL, 'C 77', NULL, NULL, '5.00', NULL, 'http://img.library.nhely.hu/img/dorottya_a_mela_tempefoi_book_img.PNG', NULL),
(18, 51, '1967-01-09', 7, 'Éjjeli őrjárat-Rembrandt élete', NULL, NULL, NULL, 'B 29', NULL, NULL, '17.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_orjarat_rembrandt_elete_book_img.PNG', NULL),
(19, 52, '1967-01-09', 8, 'Színművek 1-2.', NULL, NULL, NULL, 'B 88', NULL, NULL, '115.00', NULL, 'http://img.library.nhely.hu/img/default_book_img.png', NULL),
(20, 54, '1967-01-09', 9, 'Válogatott tanulmányok', NULL, NULL, '894', 'B 75', NULL, NULL, '67.00', NULL, 'http://img.library.nhely.hu/img/valogatott_tanulmanyok_book_img.PNG', NULL),
(21, 6108, '1973-12-28', 1, 'A kultúra világa-A magyar irodalom-A magyar nép története', NULL, NULL, '8', 'K 97', NULL, NULL, '50.00', NULL, 'http://img.library.nhely.hu/img/A_kultura_vilaga_a_magyar_irodalom_a_magyar_nep_tortenete_book_img.PNG', NULL),
(22, 6109, '1973-12-28', 10, 'A remény', NULL, NULL, NULL, 'M 25', NULL, NULL, '20.00', NULL, 'http://img.library.nhely.hu/img/a_remeny_book_img.PNG', NULL),
(23, 6110, '1973-12-28', 5, 'Huhogók', NULL, NULL, NULL, 'B 26', NULL, NULL, '18.00', NULL, 'http://img.library.nhely.hu/img/huhogok_book_img.PNG', NULL),
(24, 6111, '1973-12-28', 1, 'Rádió és televízió évkönyve 1968/69', NULL, NULL, '790', 'R 16', NULL, NULL, '20.00', NULL, 'http://img.library.nhely.hu/img/radio_es_televizio_evkönyve_1968-69_book_img.PNG', NULL),
(25, 6112, '1973-12-28', 1, 'Rádió és televízió évkönyve 1965', NULL, NULL, '790', 'R 16', NULL, NULL, '18.00', NULL, 'http://img.library.nhely.hu/img/radio_es_televizio_evkonyve_1965_book_img.PNG', NULL),
(26, 6113, '1973-12-28', 11, 'Az elvarázsolt lélek 1-2', NULL, NULL, NULL, 'R 79', NULL, NULL, '80.00', NULL, 'http://img.library.nhely.hu/img/az_elvarazsolt_lelek_1-2_book_img.PNG', NULL),
(27, 6114, '1973-12-28', 12, 'Ördögűzés 1-2-Összegyűjtött elbeszélések', NULL, NULL, NULL, 'G 56', NULL, NULL, '30.00', NULL, 'http://img.library.nhely.hu/img/ordoguzes_1-2_osszegyujtott_elbeszelesek_book_img.PNG', NULL),
(28, 6116, '1973-12-28', 3, 'Válogatott prózai művei', NULL, NULL, NULL, 'A 76', NULL, NULL, '45.00', NULL, 'http://img.library.nhely.hu/img/valogatott_prozai_muvei_book_img.PNG', NULL),
(29, 6117, '1973-12-28', 13, 'Tizenkilencen', NULL, NULL, NULL, 'F 12', NULL, NULL, '16.00', NULL, 'http://img.library.nhely.hu/img/tizenkilencen_book_img.PNG', NULL),
(30, 6118, '1973-12-28', 1, 'Rádió és televízió évkönyve 1967', NULL, NULL, '790', 'R 16', NULL, NULL, '20.00', NULL, 'http://img.library.nhely.hu/img/radio_es_televizio_evkonyve_1967_book_img.PNG', NULL),
(31, 6119, '1973-12-28', 14, 'Válogatott drámái 2.', NULL, NULL, NULL, 'I 11', NULL, NULL, '40.00', NULL, 'http://img.library.nhely.hu/img/valogatott_dramai_2._book_img.PNG', NULL),
(32, 6120, '1973-12-28', 1, 'Szöveggyűjtemény a reformkorszak irodalmáról', NULL, NULL, '894', 'Sz 93', NULL, NULL, '75.00', NULL, 'http://img.library.nhely.hu/img/szoveggyujtemeny_a_reformkorszak_irodalmarol_book_img.PNG', NULL),
(33, 6121, '1973-12-28', 15, 'A küszöbön', NULL, NULL, NULL, 'T 94', NULL, NULL, '8.00', NULL, 'http://img.library.nhely.hu/img/a_kuszobon_book_img.PNG', NULL),
(34, 6122, '1973-12-28', 16, 'Parasztok 1.', NULL, NULL, NULL, 'R 51', NULL, NULL, '32.00', NULL, 'http://img.library.nhely.hu/img/parasztok_1._book_img.PNG', NULL),
(35, 6123, '1973-12-28', 1, 'Klasszikus spanyol drámák 1-2.', NULL, NULL, '860', 'K 58', NULL, NULL, '70.00', NULL, 'http://img.library.nhely.hu/img/klasszikus_spanyol_dramak_1-2_book_img.PNG', NULL),
(36, 6124, '1973-12-28', 17, 'Összes színművei 1-2.', NULL, NULL, NULL, 'M76', NULL, NULL, '120.00', NULL, 'http://img.library.nhely.hu/img/osszes_szinmuvei_1-2._book_img.PNG', NULL),
(37, 6125, '1973-12-28', 8, 'Színművek', NULL, NULL, NULL, 'B 88', NULL, NULL, '28.00', NULL, 'http://img.library.nhely.hu/img/szinmuvek_book_img.PNG', NULL),
(38, 6126, '1973-12-28', 18, 'Válogatott művei', NULL, NULL, NULL, 'K 50', NULL, NULL, '8.00', NULL, 'http://img.library.nhely.hu/img/valogatott_muvei_book_img.PNG', NULL),
(39, 6127, '1973-12-28', 1, 'Sebzett madár-Mai szerb és horvát drámák', NULL, NULL, '886', 'S 48', NULL, NULL, '18.00', NULL, 'http://img.library.nhely.hu/img/sebzett_madar-mai_szerb_es_horvat_dramak_book_img.png', NULL),
(40, 6128, '1973-12-28', 19, 'Anatole France', NULL, NULL, '840', 'M 95', NULL, NULL, '15.00', NULL, 'http://img.library.nhely.hu/img/anatole_france_book_img.png', NULL),
(41, 9412, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(42, 9415, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(43, 9417, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(44, 9418, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(45, 9420, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(46, 9422, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(47, 9423, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(48, 9426, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(49, 9428, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(50, 9429, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(51, 9432, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(52, 9433, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(53, 9435, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(54, 9437, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(55, 9440, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(56, 9441, '1981-03-22', 17, 'Hat színmű', NULL, NULL, NULL, 'M 76', NULL, NULL, '27.00', NULL, 'http://img.library.nhely.hu/img/hat_szinmu_book_img.png', NULL),
(57, 9442, '1981-03-22', 1, 'A második világháború története', NULL, NULL, '940', 'M 39', NULL, NULL, '190.00', NULL, 'http://img.library.nhely.hu/img/A_masodik_vilaghaboru_tortenete_book_img.png', NULL),
(58, 9443, '1981-03-22', 20, 'Kis magyar művészettörténet', NULL, NULL, '700', 'D 51', NULL, NULL, '111.00', NULL, 'http://img.library.nhely.hu/img/kis_magyar_muveszettortenet_book_img.png', NULL),
(59, 9444, '1981-03-22', 21, 'Magyarózdi toronyalja', NULL, NULL, '390', 'H 87', NULL, NULL, '138.00', NULL, 'http://img.library.nhely.hu/img/magyarozdi_toronyalja_book_img.png', NULL),
(60, 9447, '1981-03-22', 22, 'Hunyadi János és kora', NULL, NULL, '943', 'T 38', NULL, NULL, '19.00', NULL, 'http://img.library.nhely.hu/img/hunyadi_janos_es_kora_book_img.png', NULL),
(61, 12372, '1988-11-03', 1, 'Görög drámák', NULL, '9630742047', NULL, 'G 58', NULL, NULL, '15.00', NULL, 'http://img.library.nhely.hu/img/gorog_dramak_book_img.png', NULL),
(62, 12378, '1988-11-03', 1, 'Görög drámák', NULL, '9630742047', NULL, 'G 58', NULL, NULL, '15.00', NULL, 'http://img.library.nhely.hu/img/gorog_dramak_book_img.png', NULL),
(63, 12392, '1988-11-03', 5, 'Goriot apó', NULL, '9630740559', NULL, 'B 26', NULL, NULL, '17.00', NULL, 'http://img.library.nhely.hu/img/goriot_apo_book_img.PNG', NULL),
(64, 12396, '1988-11-03', 5, 'Goriot apó', NULL, '9630740559', NULL, 'B 26', NULL, NULL, '17.00', NULL, 'http://img.library.nhely.hu/img/goriot_apo_book_img.PNG', NULL),
(65, 12399, '1988-11-03', 5, 'Goriot apó', NULL, '9630740559', NULL, 'B 26', NULL, NULL, '17.00', NULL, 'http://img.library.nhely.hu/img/goriot_apo_book_img.PNG', NULL),
(66, 12401, '1988-11-03', 5, 'Goriot apó', NULL, '9630740559', NULL, 'B 26', NULL, NULL, '17.00', NULL, 'http://img.library.nhely.hu/img/goriot_apo_book_img.PNG', NULL),
(67, 12405, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(68, 12406, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(69, 12407, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(70, 12409, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(71, 12410, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(72, 12411, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(73, 12416, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(74, 12417, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(75, 12419, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(76, 12420, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(77, 12421, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(78, 12423, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(79, 12424, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(80, 12425, '1988-11-03', 23, 'Éjjeli menedékhely', NULL, '9630737574', NULL, 'G 53', NULL, NULL, '9.00', NULL, 'http://img.library.nhely.hu/img/ejjeli_menedekhely_book_img.png', NULL),
(81, 16367, '2017-02-16', 24, 'Búzavirág', NULL, '9789633106372', NULL, 'F 10', NULL, NULL, '3192.00', NULL, 'http://img.library.nhely.hu/img/buzavirag_book_img.png', NULL),
(82, 16368, '2017-02-16', 24, 'Koszorúfonat', NULL, '9789634330004', NULL, 'F 10', NULL, NULL, '3199.00', NULL, 'http://img.library.nhely.hu/img/koszorufonat_book_img.png', NULL),
(83, 16369, '2017-02-17', 25, 'Miskolc legendái', NULL, '9786155536250', NULL, 'F 31', NULL, NULL, '2184.00', NULL, 'http://img.library.nhely.hu/img/miskolc_legendai_book_img.png', NULL),
(84, 16370, '2017-02-20', 26, 'Veszélyes gazdagság', NULL, '9789634061762', NULL, 'F 69', NULL, NULL, '2392.00', NULL, 'http://img.library.nhely.hu/img/veszelyes_gazdagsag_book_img.png', NULL),
(85, 16371, '2017-02-20', 27, 'Jelmezbál', NULL, '9789631433708', NULL, 'G 62', NULL, NULL, '2792.00', NULL, 'http://img.library.nhely.hu/img/jelmezbal_book_img.png', NULL),
(86, 16372, '2017-02-20', 28, 'Megint hazavárunk', NULL, '9789631434149', NULL, 'K 98', NULL, NULL, '3192.00', NULL, 'http://img.library.nhely.hu/img/megint_hazavarunk_book_img.png', NULL),
(87, 16373, '2017-02-20', 29, 'Agykontroll', NULL, '9789634055679', NULL, 'K 46', NULL, NULL, '3432.00', NULL, 'http://img.library.nhely.hu/img/agykontroll_book_img.png', NULL),
(88, 16374, '2017-02-20', 30, 'A vegyész', NULL, '9789634192114', NULL, 'M 62', NULL, NULL, '3184.00', NULL, 'http://img.library.nhely.hu/img/a_vegyesz_book_img.png', NULL),
(89, 16376, '2017-02-20', 1, 'Isten hozta őrnagy úr (DVD)', NULL, NULL, NULL, 'NULL', NULL, NULL, '990.00', NULL, 'http://img.library.nhely.hu/img/Isten_hozta_ornagy_ur_dvd_book_img.png', NULL),
(90, 16377, '2017-02-22', 31, 'Nápolyi vakáció', NULL, '9789638982742', NULL, 'F 36', NULL, NULL, '2799.00', NULL, 'http://img.library.nhely.hu/img/napolyi_vakacio_book_img.png', NULL),
(91, 16378, '2017-02-22', 31, 'November lánya', NULL, '9786155469084', NULL, 'F 36', NULL, NULL, '2799.00', NULL, 'http://img.library.nhely.hu/img/november_lanya_book_img.png', NULL),
(92, 16379, '2017-02-22', 32, 'Ami nem öl meg', NULL, '9789633243336', NULL, 'L 14', NULL, NULL, '3184.00', NULL, 'http://img.library.nhely.hu/img/ami_nem_ol_meg_book_img.png', NULL),
(93, 16380, '2017-02-22', 24, 'Az utolsó boszorkány', NULL, '9789633105726', NULL, 'F 10', NULL, NULL, '2799.00', NULL, 'http://img.library.nhely.hu/img/az_utolso_boszorkany_book_img.png', NULL),
(94, 16381, '2017-02-22', 33, 'Hazatérés', NULL, '9786155508806', NULL, 'Sz 95', NULL, NULL, '2792.00', NULL, 'http://img.library.nhely.hu/img/hazateres_book_img.png', NULL),
(95, 16382, '2017-03-10', 34, 'Helyesírási gyakorlókönyv', NULL, '9638144492', '400', 'N 24', NULL, NULL, '1890.00', NULL, 'http://img.library.nhely.hu/img/helyesirasi_gyakorlokonyv_book_img.png', NULL),
(96, 16383, '2017-05-03', 1, 'Magyar helyesírási szótár', NULL, '9789630598231', '400', 'M 14', NULL, NULL, '0.00', NULL, 'http://img.library.nhely.hu/img/magyar_helyesirasi_szotar_book_img.png', NULL),
(97, 16384, '2017-05-03', 1, 'Magyar helyesírási szótár', NULL, '9789630598231', '400', 'M 14', NULL, NULL, '0.00', NULL, 'http://img.library.nhely.hu/img/magyar_helyesirasi_szotar_book_img.png', NULL),
(98, 16385, '2017-05-03', 1, 'Magyar helyesírási szótár', NULL, '9789630598231', '400', 'M 14', NULL, NULL, '0.00', NULL, 'http://img.library.nhely.hu/img/magyar_helyesirasi_szotar_book_img.png', NULL),
(99, 16386, '2017-05-03', 1, 'Magyar helyesírási szótár', NULL, '9789630598231', '400', 'M 14', NULL, NULL, '0.00', NULL, 'http://img.library.nhely.hu/img/magyar_helyesirasi_szotar_book_img.png', NULL),
(100, 16387, '2017-05-03', 1, 'Magyar helyesírási szótár', NULL, '9789630598231', '400', 'M 14', NULL, NULL, '0.00', NULL, 'http://img.library.nhely.hu/img/magyar_helyesirasi_szotar_book_img.png', NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `loan_history`
--

DROP TABLE IF EXISTS `loan_history`;
CREATE TABLE IF NOT EXISTS `loan_history` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `book_id` int UNSIGNED NOT NULL,
  `user_id` int UNSIGNED DEFAULT NULL,
  `date` date DEFAULT NULL,
  `date_end` date DEFAULT NULL,
  `returned` tinyint(1) NOT NULL DEFAULT '0',
  `comment` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_konyv_id_idx` (`book_id`),
  KEY `fk_tag_id_idx` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `publisher`
--

DROP TABLE IF EXISTS `publisher`;
CREATE TABLE IF NOT EXISTS `publisher` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `publisher`
--

INSERT INTO `publisher` (`id`, `name`) VALUES
(1, 'Gyakorlas');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rules`
--

DROP TABLE IF EXISTS `rules`;
CREATE TABLE IF NOT EXISTS `rules` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `rules`
--

INSERT INTO `rules` (`id`, `name`) VALUES
(1, 'Admin'),
(2, 'Guest');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `series`
--

DROP TABLE IF EXISTS `series`;
CREATE TABLE IF NOT EXISTS `series` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `membership_start` date DEFAULT NULL,
  `membership_end` date DEFAULT NULL,
  `usarname` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `HASH` varchar(65) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `token` varchar(1000) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `id_rule` int NOT NULL DEFAULT '2',
  `id_account_img` int NOT NULL DEFAULT '4',
  PRIMARY KEY (`id`),
  KEY `id_rule` (`id_rule`),
  KEY `id_account_img` (`id_account_img`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`id`, `membership_start`, `membership_end`, `usarname`, `HASH`, `token`, `id_rule`, `id_account_img`) VALUES
(1, '2024-02-19', '2028-02-19', 'string@kkszki.hu', '$2a$11$O9CC4SduJTI3IP9FRx5qSeuBfwDTdqMCgypF2yDR3mbmLJOrG.rIa', 'eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InN0cmluZ0Bra3N6a2kuaHUiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9kbnMiOiIxIiwiZXhwIjoxNzA5NzIxNDQxLCJpc3MiOiJkb3RuZXQtdXNlci1qd3RzIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDozMDAwIn0.BwCalv-Hk8ogu3mly519rzGIGdbKtQzvBxAmGTP0zc6Wp5H6H0tIIdimd6N3dOI9svV-H7zFTOaj53i10d4URA', 1, 2),
(2, '2024-02-19', '2028-02-19', 'string2@kkszki.hu', '$2a$11$Zi8gAeq3mkpQqLShqZbs5etvHKQw5aH5waZ//RrxU0rpwveCzRzH6', 'eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJHdWVzdCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InN0cmluZzJAa2tzemtpLmh1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZG5zIjoiMiIsImV4cCI6MTcwOTYyNjAyOSwiaXNzIjoiZG90bmV0LXVzZXItand0cyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6MzAwMCJ9.9lnwxYry0MLX7EDPxwtSnFI0kC_olgVP_Iqv0MdB_cH0-MuKOqqUNpmryhYq90x_BK6lGw1pLe4IoukCXj2Dcw', 2, 4);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `book`
--
ALTER TABLE `book`
  ADD CONSTRAINT `book_ibfk_1` FOREIGN KEY (`author_id`) REFERENCES `author` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_konyv_kiado_id` FOREIGN KEY (`publisher_id`) REFERENCES `publisher` (`id`),
  ADD CONSTRAINT `fk_konyv_sorozat_id` FOREIGN KEY (`series_id`) REFERENCES `series` (`id`),
  ADD CONSTRAINT `fk_konyv_tag_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Megkötések a táblához `loan_history`
--
ALTER TABLE `loan_history`
  ADD CONSTRAINT `fk_kolcsonzes_tortenet_konyv_id` FOREIGN KEY (`book_id`) REFERENCES `book` (`id`),
  ADD CONSTRAINT `fk_kolcsonzes_tortenet_tag_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Megkötések a táblához `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`id_rule`) REFERENCES `rules` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_ibfk_2` FOREIGN KEY (`id_account_img`) REFERENCES `account_img` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
