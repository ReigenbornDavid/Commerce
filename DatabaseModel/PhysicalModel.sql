--------------------------------------------------------
DROP DATABASE IF EXISTS commerce;
-- -----------------------------------------------------
CREATE DATABASE IF NOT EXISTS commerce;
USE commerce;

CREATE TABLE IF NOT EXISTS category(
  idCategory INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(30) UNIQUE NOT NULL,
  PRIMARY KEY (idCategory))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS client(
  dniClient BIGINT NOT NULL,
  firstName VARCHAR(30) NOT NULL,
  lastName VARCHAR(30) NOT NULL,
  address VARCHAR(45) NULL DEFAULT NULL,
  tel VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (dniClient))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS employee(
  dniEmployee INT NOT NULL,
  firstName VARCHAR(30) NOT NULL,
  lastName VARCHAR(30) NOT NULL,
  user VARCHAR(30) NOT NULL,
  pass VARCHAR(16) NOT NULL,
  email VARCHAR(45) NULL DEFAULT NULL,
  position VARCHAR(20) NOT NULL,
  active TINYINT NOT NULL,
  PRIMARY KEY (dniEmployee))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS supplier(
  idSupplier INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(30) UNIQUE NOT NULL,
  needInvoice TINYINT NOT NULL,
  PRIMARY KEY (idSupplier))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS purchase(
  idPurchase INT NOT NULL AUTO_INCREMENT,
  dniEmployee INT NOT NULL,
  idSupplier INT NOT NULL,
  date DATETIME NOT NULL,
  total DOUBLE NOT NULL,
  PRIMARY KEY (idPurchase),
  INDEX fk_Purchase_Supplier1_idx (idSupplier ASC) VISIBLE,
  FOREIGN KEY (dniEmployee) REFERENCES employee(dniEmployee)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idSupplier) REFERENCES supplier(idSupplier)
	ON UPDATE CASCADE
    ON DELETE RESTRICT)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS product(
  idProduct INT NOT NULL AUTO_INCREMENT,
  code VARCHAR(30) UNIQUE NOT NULL,
  description VARCHAR(50) UNIQUE NOT NULL,
  cost DOUBLE NOT NULL,
  price DOUBLE NOT NULL,
  quantity DOUBLE NOT NULL,
  idCategory INT NOT NULL,
  idSupplier INT NOT NULL,
  PRIMARY KEY (idProduct),
  INDEX fk_Product_Category1_idx(idCategory ASC) VISIBLE,
  INDEX fk_Product_Supplier1_idx(idSupplier ASC) VISIBLE,
  FOREIGN KEY (idCategory) REFERENCES category(idCategory)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY (idSupplier) REFERENCES supplier(idSupplier)
	ON UPDATE CASCADE
    ON DELETE RESTRICT)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS detailpurchase(
  idDetailPurchase INT NOT NULL AUTO_INCREMENT,
  idPurchase INT NOT NULL,
  price DOUBLE NOT NULL,
  quantity DOUBLE NOT NULL,
  idProduct INT NOT NULL,
  PRIMARY KEY (idDetailPurchase),
  FOREIGN KEY (idPurchase) REFERENCES purchase(idPurchase)
    ON UPDATE CASCADE
    ON DELETE CASCADE,
  FOREIGN KEY(idProduct) REFERENCES product(idProduct)
    ON UPDATE CASCADE
    ON DELETE RESTRICT)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS sale(
  idSale INT NOT NULL AUTO_INCREMENT,
  dniClient BIGINT NOT NULL,
  dniEmployee INT NOT NULL,
  date DATETIME NOT NULL,
  total DOUBLE NOT NULL,
  PRIMARY KEY(idSale),
  INDEX fk_Sale_Client1_idx (dniClient ASC) VISIBLE,
  FOREIGN KEY(dniClient) REFERENCES client(dniClient)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY(dniEmployee) REFERENCES employee(dniEmployee)
    ON UPDATE CASCADE
    ON DELETE RESTRICT)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS detailsale(
  idDetailSale INT NOT NULL AUTO_INCREMENT,
  idSale INT NOT NULL,
  price DOUBLE NOT NULL,
  quantity DOUBLE NOT NULL,
  idProduct INT NOT NULL,
  PRIMARY KEY(idDetailSale),
  FOREIGN KEY(idProduct) REFERENCES product(idProduct)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY(idSale) REFERENCES sale(idSale)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS expense(
  idExpense INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(50) NOT NULL,
  date DATETIME NOT NULL,
  price DOUBLE NOT NULL,
  PRIMARY KEY (idExpense))
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS service(
  idService INT NOT NULL AUTO_INCREMENT,
  description VARCHAR(50) NOT NULL,
  price DOUBLE NOT NULL,
  date DATETIME NOT NULL,
  state VARCHAR(20) NOT NULL,
  dniClient BIGINT NOT NULL,
  dniEmployee INT NOT NULL,
  PRIMARY KEY(idService),
  FOREIGN KEY(dniClient) REFERENCES client(dniClient)
    ON UPDATE CASCADE
    ON DELETE RESTRICT,
  FOREIGN KEY(dniEmployee) REFERENCES employee(dniEmployee)
    ON UPDATE CASCADE
    ON DELETE RESTRICT)
ENGINE = InnoDB;
