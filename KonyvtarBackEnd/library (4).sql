-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2024. Feb 06. 08:44
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
(1, 'Default', 'Valami/valami'),
(2, 'Teacher_1', 'Valami/valami'),
(3, 'Teacher_2', 'Valami/valami'),
(4, 'Guest_1', 'Valami/valami'),
(5, 'Guest_2', 'Valami/valami');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `author`
--

DROP TABLE IF EXISTS `author`;
CREATE TABLE IF NOT EXISTS `author` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `author`
--

INSERT INTO `author` (`id`, `name`) VALUES
(1, 'Ady Endre'),
(2, 'Arany János'),
(3, 'Babits Mihály'),
(4, 'Balzac, Honoré de'),
(5, 'Csokonai Vitéz Mihály'),
(6, 'Barabás Tibor'),
(7, 'Brecht, Bertolt'),
(8, 'Bóka László');

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
  `user_id` int UNSIGNED DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `raktari_szam_UNIQUE` (`warehouse_num`),
  KEY `fk_szerzo_id_idx` (`author_id`),
  KEY `fk_sorozat_id_idx` (`series_id`),
  KEY `fk_kiado_id_idx` (`publisher_id`),
  KEY `fk_tag_id_idx` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `book`
--

INSERT INTO `book` (`id`, `warehouse_num`, `purchase_date`, `author_id`, `title`, `series_id`, `isbn_num`, `szakkjelzet`, `cutter_jelzet`, `publisher_id`, `release_date`, `price`, `comment`, `user_id`) VALUES
(1, 1, '1967-01-09', 1, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, NULL),
(2, 2, '1967-01-09', 1, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, NULL),
(3, 3, '1967-01-09', 1, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, NULL),
(4, 4, '1967-01-09', 1, 'Összes versei 1-2', NULL, NULL, NULL, 'A 25', NULL, NULL, '75.00', NULL, NULL),
(5, 5, '1967-01-09', 2, 'Összes költeményei', NULL, NULL, NULL, 'A 76', NULL, NULL, '110.00', NULL, NULL);

--
-- Tábla szerkezet ehhez a táblához `loan_history`
--

DROP TABLE IF EXISTS `loan_history`;
CREATE TABLE IF NOT EXISTS `loan_history` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `book_id` int UNSIGNED NOT NULL,
  `user_id` int UNSIGNED DEFAULT NULL,
  `date` datetime DEFAULT NULL,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

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
  `membership_start_time` varchar(100) NOT NULL,
  `membership_end` date DEFAULT NULL,
  `usarname` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `HASH` varchar(65) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `id_rule` int NOT NULL DEFAULT '2',
  `id_account_img` int NOT NULL DEFAULT '4',
  PRIMARY KEY (`id`),
  KEY `id_rule` (`id_rule`),
  KEY `id_account_img` (`id_account_img`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`id`, `membership_start`, `membership_start_time`, `membership_end`, `usarname`, `HASH`, `id_rule`, `id_account_img`) VALUES
(1, '2024-01-18', '08:26:24', '2034-01-01', 'ambrusk@kkszki.hu', 'admin1', 1, 1),
(2, '2023-09-01', '08:28:33', '2024-06-16', 'valami@kkszki.hu', 'proba', 2, 4);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `book`
--
ALTER TABLE `book`
  ADD CONSTRAINT `fk_konyv_kiado_id` FOREIGN KEY (`publisher_id`) REFERENCES `publisher` (`id`),
  ADD CONSTRAINT `fk_konyv_sorozat_id` FOREIGN KEY (`series_id`) REFERENCES `series` (`id`),
  ADD CONSTRAINT `fk_konyv_szerzo_id` FOREIGN KEY (`author_id`) REFERENCES `author` (`id`),
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
