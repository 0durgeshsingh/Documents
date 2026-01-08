CREATE TABLE employee_full (
    -- Numeric Types
    id INT NOT NULL AUTO_INCREMENT,
    age TINYINT DEFAULT 18,
    experience SMALLINT NULL,
    salary INT NOT NULL DEFAULT 0,
    bonus BIGINT NULL,
    rating DECIMAL(5,2) DEFAULT 0.00,
    tax FLOAT NULL,
    commission DOUBLE DEFAULT 0.0,

    -- String Types
    emp_code CHAR(10) NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NULL,
    email VARCHAR(100) UNIQUE,
    phone VARCHAR(15) DEFAULT 'N/A',
    address TEXT NULL,
    bio MEDIUMTEXT NULL,
    notes LONGTEXT NULL,

    -- Date & Time Types
    birth_date DATE NULL,
    joining_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    login_time TIME NULL,
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    work_year YEAR DEFAULT 2025,

    -- Boolean / Bit
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    is_verified BIT(1) DEFAULT b'0',

    -- Enum & Set
    gender ENUM('Male','Female','Other') NOT NULL,
    skills SET('C','C++','Java','Python','MySQL') NULL,

    -- Binary Types
    profile_pic BLOB NULL,
    document MEDIUMBLOB NULL,

    -- JSON (MySQL 5.7+)
    extra_info JSON NULL,

    -- Constraints
    PRIMARY KEY (id)
);