

DELIMITER $$

CREATE PROCEDURE insert_employee(
    IN p_name VARCHAR(50),
    IN p_email VARCHAR(100),
    IN p_salary INT,
    IN p_department VARCHAR(50)
)
BEGIN
    INSERT INTO employee(name, email, salary, department)
    VALUES (p_name, p_email, p_salary, p_department);
END $$

DELIMITER ;

/*
CALL insert_employee('Rahul', 'rahul@gmail.com', 30000, 'IT');
*/