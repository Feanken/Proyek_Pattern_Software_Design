-- MsUser Table
CREATE TABLE MsUser (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(100),
    UserPassword VARCHAR(20),
    UserEmail VARCHAR(100),
    UserDOB DATE,
    UserGender VARCHAR(10),
    UserRole VARCHAR(10)
);

-- MsBrand Table
CREATE TABLE MsBrand (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName VARCHAR(50),
    BrandCountry VARCHAR(50),
    BrandClass VARCHAR(20)
);

-- MsCategory Table
CREATE TABLE MsCategory (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(15)
);

-- MsJewel Table
CREATE TABLE MsJewel (
    JewelID INT PRIMARY KEY IDENTITY(1,1),
    BrandID INT,
    CategoryID INT,
    JewelName VARCHAR(100),
    JewelPrice INT,
    JewelReleaseYear INT,
    FOREIGN KEY (BrandID) REFERENCES MsBrand(BrandID),
    FOREIGN KEY (CategoryID) REFERENCES MsCategory(CategoryID)
);

-- Cart Table
CREATE TABLE Cart (
    UserID INT,
    JewelID INT,
    Quantity INT,
    PRIMARY KEY (UserID, JewelID),
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID),
    FOREIGN KEY (JewelID) REFERENCES MsJewel(JewelID)
);

-- TransactionHeader Table
CREATE TABLE TransactionHeader (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    TransactionDate DATE,
    PaymentMethod VARCHAR(15),
    TransactionStatus VARCHAR(30),
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID)
);

-- TransactionDetail Table
CREATE TABLE TransactionDetail (
    TransactionID INT,
    JewelID INT,
    Quantity INT,
    PRIMARY KEY (TransactionID, JewelID),
    FOREIGN KEY (TransactionID) REFERENCES TransactionHeader(TransactionID),
    FOREIGN KEY (JewelID) REFERENCES MsJewel(JewelID)
);
