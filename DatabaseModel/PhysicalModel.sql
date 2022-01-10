-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Commerce
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Commerce
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Commerce` DEFAULT CHARACTER SET utf8 ;
USE `Commerce` ;

-- -----------------------------------------------------
-- Table `Commerce`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Category` (
  `idCategory` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Product` (
  `idProduct` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `price` REAL NOT NULL,
  `quantity` VARCHAR(45) NOT NULL,
  `idCategory` INT NOT NULL,
  PRIMARY KEY (`idProduct`),
  INDEX `fk_Product_Category1_idx` (`idCategory` ASC) VISIBLE,
  CONSTRAINT `fk_Product_Category1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `Commerce`.`Category` (`idCategory`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Commerce`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Client` (
  `dniClient` BIGINT NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NULL,
  PRIMARY KEY (`dniClient`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Employee` (
  `dniEmployee` INT NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `user` VARCHAR(20) NOT NULL,
  `pass`VARCHAR(20) NOT NULL,
  `email` VARCHAR(45) NULL,
  `position` VARCHAR(45) NOT NULL,
  `active` TINYINT NOT NULL,
  PRIMARY KEY (`dniEmployee`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Sale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Sale` (
  `idSale` INT NOT NULL AUTO_INCREMENT,
  `dniClient` BIGINT NOT NULL,
  `dniEmployee` INT NOT NULL,
  `date` DATETIME NOT NULL,
  `total` REAL NOT NULL,
  PRIMARY KEY (`idSale`),
  INDEX `fk_Sale_Client1_idx` (`dniClient` ASC) VISIBLE,
  INDEX `fk_Sale_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Sale_Client1`
    FOREIGN KEY (`dniClient`)
    REFERENCES `Commerce`.`Client` (`dniClient`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Sale_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `Commerce`.`Employee` (`dniEmployee`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`DetailSale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`DetailSale` (
  `idDetailSale` INT NOT NULL AUTO_INCREMENT,
  `idSale` INT NOT NULL,
  `price` REAL NOT NULL,
  `quantity` INT NOT NULL,
  `idProduct` INT NOT NULL,
  PRIMARY KEY (`idDetailSale`),
  INDEX `fk_DetailSale_Product1_idx` (`idProduct` ASC) VISIBLE,
  INDEX `fk_DetailSale_Sale1_idx` (`idSale` ASC) VISIBLE,
  CONSTRAINT `fk_DetailSale_Product1`
    FOREIGN KEY (`idProduct`)
    REFERENCES `Commerce`.`Product` (`idProduct`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_DetailSale_Sale1`
    FOREIGN KEY (`idSale`)
    REFERENCES `Commerce`.`Sale` (`idSale`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Service`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Service` (
  `idService` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `price` REAL NOT NULL,
  `date` DATETIME NOT NULL,
  `dniClient` BIGINT NOT NULL,
  `dniEmployee` INT NOT NULL,
  `idSale` INT NULL,
  PRIMARY KEY (`idService`),
  INDEX `fk_Service_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  INDEX `fk_Service_Client1_idx` (`dniClient` ASC) VISIBLE,
  INDEX `fk_Service_Sale1_idx` (`idSale` ASC) VISIBLE,
  CONSTRAINT `fk_Service_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `Commerce`.`Employee` (`dniEmployee`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Service_Client1`
    FOREIGN KEY (`dniClient`)
    REFERENCES `Commerce`.`Client` (`dniClient`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Service_Sale1`
    FOREIGN KEY (`idSale`)
    REFERENCES `Commerce`.`Sale` (`idSale`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Purchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Purchase` (
  `idPurchase` INT NOT NULL AUTO_INCREMENT,
  `dniEmployee` INT NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`idPurchase`),
  INDEX `fk_Purchase_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Purchase_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `Commerce`.`Employee` (`dniEmployee`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`DetailPurchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`DetailPurchase` (
  `idDetailPurchase` INT NOT NULL AUTO_INCREMENT,
  `idPurchase` INT NOT NULL,
  `price` REAL NOT NULL,
  `quantity` INT NOT NULL,
  `idProduct` INT NOT NULL,
  PRIMARY KEY (`idDetailPurchase`),
  INDEX `fk_DetailSale_Product1_idx` (`idProduct` ASC) VISIBLE,
  INDEX `fk_DetailPurchase_Purchase1_idx` (`idPurchase` ASC) VISIBLE,
  CONSTRAINT `fk_DetailSale_Product10`
    FOREIGN KEY (`idProduct`)
    REFERENCES `Commerce`.`Product` (`idProduct`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `fk_DetailPurchase_Purchase1`
    FOREIGN KEY (`idPurchase`)
    REFERENCES `Commerce`.`Purchase` (`idPurchase`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Commerce`.`Expense`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Commerce`.`Expense` (
  `idExpense` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `price` REAL NOT NULL,
  `idPurchase` INT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`idExpense`),
  INDEX `fk_Expense_Purchase1_idx` (`idPurchase` ASC) VISIBLE,
  CONSTRAINT `fk_Expense_Purchase1`
    FOREIGN KEY (`idPurchase`)
    REFERENCES `Commerce`.`Purchase` (`idPurchase`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
