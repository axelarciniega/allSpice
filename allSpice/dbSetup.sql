CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(200) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(255) NOT NULL,
        category VARCHAR(100) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        "eggs",
        "Cook them bad bois",
        "https://unsplash.com/photos/y2X7JYv019M ",
        "food",
        "6527182f925769ff6f109ae2 "
    )

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        "Bacon",
        "Put them in the micro wave",
        "https://unsplash.com/photos/y2X7JYv019M ",
        "snacks",
        "6527182f925769ff6f109ae2"
    )