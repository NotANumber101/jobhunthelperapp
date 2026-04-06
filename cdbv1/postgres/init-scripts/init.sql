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
  topic VARCHAR(40),
  date_completed DATE NOT NULL DEFAULT CURRENT_DATE
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

-- todo:rubric

-- array

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Contains Duplicates', 'Given an integer array nums, return true if any value appears more than once in the array, otherwise return false.',
  'easy', 'array', '3-20-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Valid Anagram', 'Given two strings s and t, return true if the two strings are anagrams of each other, otherwise return false. An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.',
  'easy', 'array', '3-20-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('two sum', 'given an array of integers and a target integer, return the indices of the two numbers that add up to the target',
  'easy', 'array', '4-10-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Group Anagrams', 'Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order. An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.',
  'medium', 'array', '3-20-2026'
);

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Top K Frequent Elements', 'Given an integer array nums and an integer k, return the k most frequent elements within the array. The test cases are generated such that the answer is always unique. You may return the output in any order.',
  'medium', 'array', '3-20-2026');


INSERT INTO dsa_problem (name, description, difficulty, topic)
  VALUES ('Encode And Decode String', 'Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.

Machine 1 (sender) has the function:

string encode(vector<string> strs) {
    // ... your code
    return encoded_string;
}
Machine 2 (receiver) has the function:

vector<string> decode(string s) {
    //... your code
    return strs;
}
So Machine 1 does:

string encoded_string = encode(strs);
and Machine 2 does:

vector<string> strs2 = decode(encoded_string);
strs2 in Machine 2 should be the same as strs in Machine 1.

Implement the encode and decode methods.', 'medium', 'array');


INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Product Of Array Except Self',
  'Given an integer array nums, return an array output where output[i] is the product of all the elements of nums except nums[i]. 
  Each product is guaranteed to fit in a 32-bit integer.', 'medium', 'array', '3-20-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Longest Consecutive Sequence', 'Given an array of integers nums, return the length of the longest consecutive sequence of elements that can be formed. 
A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than the previous element. The elements do not have to be consecutive in the original array.',
'medium', 'array', '3-20-2026');

-- two pointers

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Valid Palindrome', 'Given a string s, return true if it is a palindrome, otherwise return false. A palindrome is a string that reads the same forward and backward. It is also case-insensitive and ignores all non-alphanumeric characters. Note: Alphanumeric characters consist of letters (A-Z, a-z) and numbers (0-9).',
  'easy', 'two pointers', '3-20-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('3 Sum', 'Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] where nums[i] + nums[j] + nums[k] == 0, and the indices i, j and k are all distinct. The output should not contain any duplicate triplets. You may return the output and the triplets in any order.',
'medium', 'two pointers', '3-20-2026');

INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Container With Most Water', 'You are given an integer array heights where heights[i] represents the height of the ith bar. You may choose any two bars to form a container. Return the maximum amount of water a container can store.',
  'medium', 'two pointers', '3-20-2026');

-- sliding window
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Best Time to Buy And Sell Stock', 'test', 'easy', 'sliding window', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Longest Substring Without Repeating Characters', 'test', 'medium', 'sliding window', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Longest Repeating Character Replacement', 'test', 'medium', 'sliding window', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Minimum Window Substring', 'Given two strings s and t, return the shortest substring of s such that every character in t, including duplicates, is present in the substring. If such a substring does not exist, return an empty string. You may assume that the correct output is always unique.',
  'hard', 'sliding window', '3-20-2026');

-- stack

INSERT INTO dsa_problem (name, description, difficulty, topic)
  VALUES ('Valid Parentheses', 'You are given a string s consisting of the following characters: ( ) { } [ ].

The input string s is valid if and only if:

Every open bracket is closed by the same type of close bracket.
Open brackets are closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
Return true if s is a valid string, and false otherwise.', 'easy', 'stack');

-- binary search

INSERT INTO dsa_problem (name, description, difficulty, topic)
  VALUES ('Find Minimum In Rotated Sorted Array', 'test', 'medium', 'binary search');
INSERT INTO dsa_problem (name, description, difficulty, topic)
  VALUES ('Search In Rotated Sorted Array', 'test', 'medium', 'binary search');

-- linked list
 
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Reverse Linked List', 'test', 'easy', 'linked list', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Merge Two Sorted Lists', 'test', 'easy', 'linked list', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Linked List Cycle', 'test', 'easy', 'linked list', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Reorder List', 'test', 'medium', 'linked list', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Remove Node From End of Linked List', 'test', 'medium', 'linked list', '3-20-2026');
INSERT INTO dsa_problem (name, description, difficulty, topic, date_completed)
  VALUES ('Merge K Sorted Lists', 'test', 'hard', 'linked list', '3-20-2026');

-- tree
-- INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('test', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Invert Binary Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Maximum Depth of Binary Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Same Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Subtree of Another Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Lowest Common Ancestor of a Binary Search Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Binary Tree Level Order Traversal', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Validate Binary Search Tree', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Kth Smallest Element In a Bst', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Construct Binary Tree From Preorder And Inorder Traversal', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Binary Tree Maximum Path Sum', 'test', 'easy', 'tree');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Serialize And Deserialize Binary Tree', 'test', 'easy', 'tree');

-- heap/priority queue
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Find Median From Data Stream', 'test', 'hard', 'heap');

-- backtracking
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Combination Sum', 'test', 'medium', 'backtracking');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Word Search', 'test', 'medium', 'backtracking');

-- tries
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Implement Trie Prefix Tree', 'test', 'medium', 'tries');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Design Add And Search Words Data Structure', 'test', 'medium', 'tries');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Word Search 2', 'test', 'hard', 'tries');

-- graphs
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Number Of Islands', 'test', 'medium', 'graphs');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Clone Graph', 'test', 'medium', 'graphs');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Pacific Atlantic Water Flow', 'test', 'medium', 'graphs');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Course Schedule', 'test', 'medium', 'graphs');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Graph Valid Tree', 'test', 'medium', 'graphs');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Number of Connected Components In An Undirected Graph', 'test', 'medium', 'graphs');

-- advanced graphs
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Alien Dictionary', 'test', 'hard', 'advanced graphs');

-- 1-D dynamic programming
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Climbing Stairs', 'test', 'easy', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('House Robber', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('House Robber 2', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Longest Palindromic Substring', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Palindromic Substrings', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Decode Ways', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Coin Change', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Maximum Product Subarray', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Word Break', 'test', 'medium', '1D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Longest Increasing Subsequence', 'test', 'medium', '1D dynamic programming');

-- todo

-- 2-D dynamic programming
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Unique Paths', 'test', 'medium', '2D dynamic programming');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Longest Common Subsequence', 'test', 'medium', '2D dynamic programming');

-- greedy
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Maximum Subarray', 'test', 'medium', 'greedy');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Jump Game', 'test', 'medium', 'greedy');

-- intervals
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Meeting Rooms', 'test', 'easy', 'intervals');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Meeting Rooms 2', 'test', 'medium', 'intervals');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Insert Interval', 'test', 'medium', 'intervals');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Merge Intervals', 'test', 'medium', 'intervals');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Non Overlapping Intervals', 'test', 'medium', 'intervals');

-- math & geometry
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Rotate Image', 'test', 'medium', 'math and geometry');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Spiral Matrix', 'test', 'medium', 'math and geometry');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Set Matrix Zones', 'test', 'medium', 'math and geometry');

-- bit manipulation
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Number of 1 Bits', 'test', 'easy', 'bit manipulation');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Counting Bits', 'test', 'easy', 'bit manipulation');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Reverse Bits', 'test', 'easy', 'bit manipulation');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Missing Number', 'test', 'easy', 'bit manipulation');
INSERT INTO dsa_problem (name, description, difficulty, topic) VALUES ('Sum of Two Integerss', 'test', 'medium', 'bit manipulation');





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