\connect test_db

CREATE TABLE dsa_problem (
  id SERIAL,
  name VARCHAR(100),
  difficulty VARCHAR(10),
  topic VARCHAR(40),
  description TEXT,
  date_completed DATE NOT NULL DEFAULT '11-11-2011'
);

CREATE TABLE dsa_solution (
  id SERIAL,
  problem_id INT,
  solution VARCHAR(1000),
  date_completed DATE NOT NULL DEFAULT '11-11-2011'
);

CREATE TABLE dsa_postmortem (
  id SERIAL,
  solution_id INT,
  design_time_ms INT,
  code_time_ms INT,
  mistakes TEXT,
  analysis TEXT,
  rubric_problem_solving_score INT,
  rubric_coding_score INT,
  rubric_verification_score INT,
  rubric_communication_score INT
);