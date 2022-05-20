CREATE TABLE tab_positions
(
    id       INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    position TEXT    NOT NULL
);

CREATE TABLE tab_department
(
    id         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    department TEXT    NOT NULL
);

CREATE TABLE tab_persons
(
    id            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    first_name    TEXT    NOT NULL,
    last_name     TEXT    NOT NULL,
    date_of_birth TEXT    NOT NULL
);

CREATE TABLE tab_staffers
(
    id            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    person_id     INTEGER NOT NULL,
    department_id INTEGER NOT NULL,
    position_id   INTEGER NOT NULL,
    FOREIGN KEY (person_id) REFERENCES tab_persons (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (department_id) REFERENCES tab_department (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION,
    FOREIGN KEY (position_id) REFERENCES tab_positions (id)
        ON DELETE NO ACTION
        ON UPDATE NO ACTION
);

INSERT INTO tab_department(department) VALUES ('IT');
INSERT INTO tab_department(department) VALUES ('HR');
INSERT INTO tab_department(department) VALUES ('Design');

INSERT INTO tab_positions(position) VALUES ('programmer');
INSERT INTO tab_positions(position) VALUES ('recruiter');
INSERT INTO tab_positions(position) VALUES ('designer');

INSERT INTO tab_persons(first_name, last_name, date_of_birth) VALUES ('Anonim', 'Anonimus', '2005-08-09');
INSERT INTO tab_persons(first_name, last_name, date_of_birth) VALUES ('Anna', 'Karenina', '1890-08-09');
INSERT INTO tab_persons(first_name, last_name, date_of_birth) VALUES ('Andrey', 'Starinin', '1986-02-18');

INSERT INTO tab_staffers(person_id, department_id, position_id) VALUES (1, 1, 1);
INSERT INTO tab_staffers(person_id, department_id, position_id) VALUES (2, 2, 2);
INSERT INTO tab_staffers(person_id, department_id, position_id) VALUES (3, 3, 3);

SELECT tab_persons.id AS 'id', 
       first_name, last_name, date_of_birth,
       department, position
FROM tab_staffers
    JOIN tab_persons 
        ON tab_staffers.person_id = tab_persons.id
    JOIN tab_department
        ON tab_staffers.department_id = tab_department.id
    JOIN tab_positions
        ON tab_staffers.position_id = tab_positions.id;