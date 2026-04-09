\connect test_db

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Contains Duplicates', 'easy', 'array',
  'Given an integer array nums, return true if any value appears more than once in the array, otherwise return false.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Valid Anagram', 'easy', 'array',
  'Given two strings s and t, return true if the two strings are anagrams of each other, otherwise return false. 
  An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('two sum', 'easy', 'aray',
  'given an array of integers and a target integer, return the indices of the two numbers that add up to the target');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Group Anagrams', 'medium', 'array',
  'Given an array of strings strs, group all anagrams together into sublists. You may return the output in any order.
  An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES (
    'Top K Frequent Elements', 'medium','array',
    'Given an integer array nums and an integer k, return the k most frequent elements within the array.
    The test cases are generated such that the answer is always unique. You may return the output in any order.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Encode And Decode String', 'medium','array',
  'Design an algorithm to encode a list of strings to a string.
  The encoded string is then sent over the network and is decoded back to the original list of strings.
  Implement the Encode and Decode methods.

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
  strs2 in Machine 2 should be the same as strs in Machine 1.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Product Of Array Except Self', 'medium', 'array', 
  'Given an integer array nums, return an array output where output[i] is the product of all the elements of nums except nums[i].
  Each product is guaranteed to fit in a 32-bit integer.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Consecutive Sequence', 'medium', 'array',
  'Given an array of integers nums, return the length of the longest consecutive sequence of elements that can be formed.
  A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than the previous element.
  The elements do not have to be consecutive in the original array.');

-- two pointers
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Valid Palindrome', 'easy', 'two pointers',
  'Given a string s, return true if it is a palindrome, otherwise return false.
  A palindrome is a string that reads the same forward and backward.
  It is also case-insensitive and ignores all non-alphanumeric characters.
  Note: Alphanumeric characters consist of letters (A-Z, a-z) and numbers (0-9).');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('3 Sum', 'medium', 'two pointers',
  'Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] where nums[i] + nums[j] + nums[k] == 0, and the indices i, j and k are all distinct.
  The output should not contain any duplicate triplets. You may return the output and the triplets in any order.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Container With Most Water', 'medium', 'two pointers',
  'You are given an integer array heights where heights[i] represents the height of the ith bar.
  You may choose any two bars to form a container. Return the maximum amount of water a container can store.');

-- sliding window
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Best Time to Buy And Sell Stock', 'easy', 'sliding window', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Substring Without Repeating Characters', 'medium', 'sliding window', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Repeating Character Replacement', 'medium', 'sliding window', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Minimum Window Substring', 'hard', 'sliding window',
  'Given two strings s and t, return the shortest substring of s such that every character in t, including duplicates, is present in the substring.
  If such a substring does not exist, return an empty string. You may assume that the correct output is always unique.');

-- stack
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Valid Parentheses', 'easy', 'stack',
  'You are given a string s consisting of the following characters: ( ) { } [ ].
  The input string s is valid if and only if: Every open bracket is closed by the same type of close bracket.
  Open brackets are closed in the correct order. Every close bracket has a corresponding open bracket of the same type.
  Return true if s is a valid string, and false otherwise.');

-- binary search
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('mock_easy_bs_problem', 'easy', 'binary search', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Find Minimum In Rotated Sorted Array', 'medium', 'binary search', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Search In Rotated Sorted Array', 'medium', 'binary search', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('mock_hard_bs_problem', 'hard', 'binary search', 'description_goes_here');

-- linked list
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Reverse Linked List', 'easy', 'linked list', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Merge Two Sorted Lists', 'easy', 'linked list', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Linked List Cycle', 'easy', 'linked list', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Reorder List', 'medium', 'linked list', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Remove Node From End of Linked List', 'medium', 'linked list', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Merge K Sorted Lists', 'hard', 'linked list', 'description_goes_here');

-- tree
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Invert Binary Tree', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Maximum Depth of Binary Tree', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Same Tree', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Subtree of Another Tree', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Lowest Common Ancestor of a Binary Search Tree', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Binary Tree Level Order Traversal', 'easy', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Validate Binary Search Tree', 'medium', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Kth Smallest Element In a Bst', 'medium', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Construct Binary Tree From Preorder And Inorder Traversal', 'medium', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Binary Tree Maximum Path Sum', 'hard', 'tree', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Serialize And Deserialize Binary Tree', 'hard', 'tree', 'description_goes_here');

-- heap/priority queue
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Find Median From Data Stream', 'hard', 'heap', 'description_goes_here');

-- backtracking
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Combination Sum', 'medium', 'backtracking', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Search', 'medium', 'backtracking', 'description_goes_here');

-- tries
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Implement Trie Prefix Tree', 'medium', 'tries', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Design Add And Search Words Data Structure', 'medium', 'tries', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Search 2', 'hard', 'tries', 'description_goes_here');

-- graphs
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Number Of Islands', 'medium', 'graphs', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Clone Graph', 'medium', 'graphs', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Pacific Atlantic Water Flow', 'medium', 'graphs', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Course Schedule', 'medium', 'graphs', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Graph Valid Tree', 'medium', 'graphs', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Number of Connected Components In An Undirected Graph', 'medium', 'graphs', 'description_goes_here');

-- advanced graphs
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Alien Dictionary', 'hard', 'advanced graphs', 'description_goes_here');

-- 1-D dynamic programming
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Climbing Stairs', 'easy', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('House Robber', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('House Robber 2', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Palindromic Substring', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Palindromic Substrings', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Decode Ways', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Coin Change', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Maximum Product Subarray', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Break', 'medium', '1D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Increasing Subsequence', 'medium', '1D dynamic programming', 'description_goes_here');

-- 2-D dynamic programming
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Unique Paths', 'medium', '2D dynamic programming', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Longest Common Subsequence', 'medium', '2D dynamic programming', 'description_goes_here');

-- greedy
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Maximum Subarray', 'medium', 'greedy', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Jump Game', 'medium', 'greedy', 'description_goes_here');

-- intervals
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Meeting Rooms', 'easy', 'intervals', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Meeting Rooms 2', 'medium', 'intervals', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Insert Interval', 'medium', 'intervals', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Merge Intervals', 'medium', 'intervals', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Non Overlapping Intervals', 'medium', 'intervals', 'description_goes_here');

-- math & geometry
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Rotate Image', 'medium', 'math and geometry', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Spiral Matrix', 'medium', 'math and geometry', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Set Matrix Zones', 'medium', 'math and geometry', 'description_goes_here');

-- bit manipulation
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Number of 1 Bits', 'easy', 'bit manipulation', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Counting Bits', 'easy', 'bit manipulation', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Reverse Bits', 'easy', 'bit manipulation', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Missing Number', 'easy', 'bit manipulation', 'description_goes_here');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Sum of Two Integerss', 'medium', 'bit manipulation', 'description_goes_here');