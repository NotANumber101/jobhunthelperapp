\connect test_db

-- create a table
CREATE TABLE application (
  id SERIAL,
  company_name VARCHAR(100),
  current_status VARCHAR(100),
  current_status_date DATE NOT NULL DEFAULT '1-11-2026',
  job_description TEXT
);

CREATE TABLE company_information (
  id SERIAL,
  name VARCHAR(100) UNIQUE,
  job_board_link VARCHAR(300),
  company_description TEXT
);

CREATE TABLE company_contact (
  id SERIAL,
  name VARCHAR(100),
  company_name VARCHAR(100)
);

CREATE TABLE contact_message (
  id SERIAL,
  contact_id INT,
  date_of_message DATE NOT NULL,
  platform VARCHAR(100),
  title VARCHAR(200),
  body TEXT
);

-- permanent companies
INSERT INTO company_information (name, job_board_link, company_description)
  VALUES ('spacex', 'www.spacex.com/careers', 'an aerospace company');
INSERT INTO company_information (name, job_board_link, company_description)
  VALUES ('anduril', 'https://www.anduril.com/careers', 'a defense company');
INSERT INTO company_information (name, job_board_link, company_description)
  VALUES ('apex', 'https://www.apexspace.com/careers#opportunities', 'a space company');

-- mock company contact 
INSERT INTO company_contact (name, company_name)
  VALUES ('mock_company_contact_name', 'mock_company_contact_company_name');
-- mock application
INSERT INTO application (company_name, current_status, job_description) 
  VALUES ('mock_application', 'applied', 'please paste the job posting here');