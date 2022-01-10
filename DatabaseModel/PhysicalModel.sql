-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema commerce
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema commerce
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `commerce` DEFAULT CHARACTER SET utf8 ;
USE `commerce` ;

-- -----------------------------------------------------
-- Table `commerce`.`category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`category` (
  `idCategory` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`client` (
  `dniClient` BIGINT NOT NULL,
  `fisrtName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `address` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`dniClient`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`employee` (
  `dniEmployee` INT NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NULL DEFAULT NULL,
  `position` VARCHAR(45) NOT NULL,
  `active` TINYINT NOT NULL,
  PRIMARY KEY (`dniEmployee`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`supplier` (
  `idSupplier` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `needInvoice` TINYINT NOT NULL,
  PRIMARY KEY (`idSupplier`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`purchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`purchase` (
  `idPurchase` INT NOT NULL AUTO_INCREMENT,
  `dniEmployee` INT NOT NULL,
  `idSupplier` INT NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`idPurchase`),
  INDEX `fk_Purchase_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  INDEX `fk_Purchase_Supplier1_idx` (`idSupplier` ASC) VISIBLE,
  CONSTRAINT `fk_Purchase_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `commerce`.`employee` (`dniEmployee`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Purchase_Supplier1`
    FOREIGN KEY (`idSupplier`)
    REFERENCES `commerce`.`supplier` (`idSupplier`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`product` (
  `idProduct` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `price` DOUBLE NOT NULL,
  `quantity` VARCHAR(45) NOT NULL,
  `idCategory` INT NOT NULL,
  `idSupplier` INT NOT NULL,
  PRIMARY KEY (`idProduct`),
  INDEX `fk_Product_Category1_idx` (`idCategory` ASC) VISIBLE,
  INDEX `fk_Product_Supplier1_idx` (`idSupplier` ASC) VISIBLE,
  CONSTRAINT `fk_Product_Category1`
    FOREIGN KEY (`idCategory`)
    REFERENCES `commerce`.`category` (`idCategory`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Product_Supplier1`
    FOREIGN KEY (`idSupplier`)
    REFERENCES `commerce`.`supplier` (`idSupplier`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`detailpurchase`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`detailpurchase` (
  `idDetailPurchase` INT NOT NULL AUTO_INCREMENT,
  `idPurchase` INT NOT NULL,
  `price` DOUBLE NOT NULL,
  `quantity` INT NOT NULL,
  `idProduct` INT NOT NULL,
  PRIMARY KEY (`idDetailPurchase`),
  INDEX `fk_DetailSale_Product1_idx` (`idProduct` ASC) VISIBLE,
  INDEX `fk_DetailPurchase_Purchase1_idx` (`idPurchase` ASC) VISIBLE,
  CONSTRAINT `fk_DetailPurchase_Purchase1`
    FOREIGN KEY (`idPurchase`)
    REFERENCES `commerce`.`purchase` (`idPurchase`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_DetailSale_Product10`
    FOREIGN KEY (`idProduct`)
    REFERENCES `commerce`.`product` (`idProduct`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`sale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`sale` (
  `idSale` INT NOT NULL AUTO_INCREMENT,
  `dniClient` BIGINT NOT NULL,
  `dniEmployee` INT NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`idSale`),
  INDEX `fk_Sale_Client1_idx` (`dniClient` ASC) VISIBLE,
  INDEX `fk_Sale_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Sale_Client1`
    FOREIGN KEY (`dniClient`)
    REFERENCES `commerce`.`client` (`dniClient`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Sale_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `commerce`.`employee` (`dniEmployee`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`detailsale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`detailsale` (
  `idDetailSale` INT NOT NULL AUTO_INCREMENT,
  `idSale` INT NOT NULL,
  `price` DOUBLE NOT NULL,
  `quantity` INT NOT NULL,
  `idProduct` INT NOT NULL,
  PRIMARY KEY (`idDetailSale`),
  INDEX `fk_DetailSale_Product1_idx` (`idProduct` ASC) VISIBLE,
  INDEX `fk_DetailSale_Sale1_idx` (`idSale` ASC) VISIBLE,
  CONSTRAINT `fk_DetailSale_Product1`
    FOREIGN KEY (`idProduct`)
    REFERENCES `commerce`.`product` (`idProduct`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_DetailSale_Sale1`
    FOREIGN KEY (`idSale`)
    REFERENCES `commerce`.`sale` (`idSale`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`expense`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`expense` (
  `idExpense` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `idPurchase` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idExpense`),
  INDEX `fk_Expense_Purchase1_idx` (`idPurchase` ASC) VISIBLE,
  CONSTRAINT `fk_Expense_Purchase1`
    FOREIGN KEY (`idPurchase`)
    REFERENCES `commerce`.`purchase` (`idPurchase`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `commerce`.`service`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`service` (
  `idService` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(45) NOT NULL,
  `price` DOUBLE NOT NULL,
  `date` DATETIME NOT NULL,
  `state` VARCHAR(45) NOT NULL,
  `dniClient` BIGINT NOT NULL,
  `dniEmployee` INT NOT NULL,
  `idSale` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idService`),
  INDEX `fk_Service_Employee1_idx` (`dniEmployee` ASC) VISIBLE,
  INDEX `fk_Service_Client1_idx` (`dniClient` ASC) VISIBLE,
  INDEX `fk_Service_Sale1_idx` (`idSale` ASC) VISIBLE,
  CONSTRAINT `fk_Service_Client1`
    FOREIGN KEY (`dniClient`)
    REFERENCES `commerce`.`client` (`dniClient`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Service_Employee1`
    FOREIGN KEY (`dniEmployee`)
    REFERENCES `commerce`.`employee` (`dniEmployee`)
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Service_Sale1`
    FOREIGN KEY (`idSale`)
    REFERENCES `commerce`.`sale` (`idSale`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
