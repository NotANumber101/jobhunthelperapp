\connect test_db

-- create a table
CREATE TABLE application (
  id SERIAL,
  company_id INT,
  current_status VARCHAR(100),
  current_status_date VARCHAR(100),
  job_location VARCHAR(100),
  job_title VARCHAR(100),
  job_description TEXT
);

CREATE TABLE company_information (
  id INT UNIQUE,
  name VARCHAR(100),
  description TEXT,
  job_board_link VARCHAR(300)
);

CREATE TABLE company_contact (
  id INT,
  company_id INT,
  name VARCHAR(100),
  description TEXT
);

CREATE TABLE company_prompt (
  id SERIAL,
  company_id INT,
  prompt TEXT,
  response TEXT
);

CREATE TABLE contact_message (
  id SERIAL,
  contact_id INT,
  title VARCHAR(200),
  body TEXT,
  date_of_message VARCHAR(100),
  platform VARCHAR(100)
);

CREATE TABLE dsa_problem (
  id SERIAL,
  name VARCHAR(100),
  description TEXT,
  difficulty VARCHAR(10),
  topic VARCHAR(40)
);

CREATE TABLE dsa_solution (
  id SERIAL,
  problem_id INT,
  solution TEXT
);

CREATE TABLE dsa_postmortem (
  id SERIAL,
  solution_id INT,
  explanation TEXT
);

-- rubric

INSERT INTO dsa_problem (name, description, difficulty, topic)
  VALUES ('two sum', 'given an array of integers and a target integer, return the indices of the two numbers that add up to the target', 'easy', 'array');



INSERT INTO company_information (id, name, description, job_board_link) VALUES (1, 'spacex', 'an aerospace company', 'www.spacex.com/careers');
INSERT INTO company_information (id, name, description, job_board_link) VALUES (2, 'anduril', 'a defense company', 'https://www.anduril.com/careers');
INSERT INTO company_information (id, name, description, job_board_link) VALUES (3, 'apex', 'a defense company', 'https://www.apex.com/careers');
INSERT INTO company_information (id, name, description, job_board_link) VALUES (4, 'google', 'a technology company', 'https://www.google.com/careers');


INSERT INTO company_contact (id, company_id, name, description) VALUES (1, 1, 'john doe', 'a senior engineer');
INSERT INTO company_contact (id, company_id, name, description) VALUES (2, 3, 'mary jane', 'a senior engineer - apex');
INSERT INTO company_contact (id, company_id, name, description) VALUES (3, 1, 'tucker carlson', 'a software application manager at starbase');


INSERT INTO company_prompt (company_id, prompt, response)
  VALUES (1, 'Tell me about yourself', 'I am a software engineer with a passion for aerospace and space exploration. I have experience working on a variety of projects, including developing software for satellite communication systems and creating algorithms for optimizing rocket trajectories. I am excited about the opportunity to work at SpaceX and contribute to the mission of making life multiplanetary.');
INSERT INTO company_prompt (company_id, prompt, response)
  VALUES (2, 'Tell me about a recent project', 'I recently worked on a project where I developed a new algorithm for optimizing drone flight paths. The algorithm uses machine learning to analyze weather patterns and adjust the flight path in real-time, which has resulted in a 20% increase in efficiency for our drone deliveries.');
INSERT INTO company_prompt (company_id, prompt, response)
  VALUES (1, 'Why do you want to work here?', 'I have always been fascinated by space and the idea of exploring the unknown. SpaceX is at the forefront of space exploration and has a mission that aligns with my passion for making life multiplanetary. I am excited about the opportunity to work with a team of talented individuals who are dedicated to pushing the boundaries of what is possible in space exploration.');


INSERT INTO contact_message (contact_id, title, body, date_of_message, platform)
  VALUES (1, 'greetings', 'Dear john doe, lorem ipsum', '30/3/2026', 'linkedin');
INSERT INTO contact_message (contact_id, title, body, date_of_message, platform)
  VALUES (3, 'follow-up: request a meeting', 'Hey Bob, Its been a while. How have you been? Ive been workin', 'APRIL 1, 2026', 'linkedin');
INSERT INTO contact_message (contact_id, title, body, date_of_message, platform)
  VALUES (2, 'Thank you for the call', 'lorem ipsum asfkghwk lweg skgj w ktwgebf qje gasg', '30/3/2026', 'linkedin');


-- spacex
INSERT INTO application (company_id, current_status, current_status_date, job_location, job_title, job_description) 
  VALUES (1, 'applied', '3/28/2026', 'REMOTE', 'software application engineer', 'please paste the job posting here');


-- anduril
INSERT INTO application (company_id, current_status, current_status_date, job_location, job_title, job_description) 
  VALUES (2, 'not-applied', 'APRIL 1, 2026', 'COLORADO', 'fulls stack software engineer', 'please paste the job posting here');



  -- create test data for alerting (ie application or message that is 2 weeks old)