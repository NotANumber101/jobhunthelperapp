\connect test_db
-- This list is 75 problems.
---------------------------------------------------
-- problem.topic: array
---------------------------------------------------
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
  VALUES ('Top K Frequent Elements', 'medium','array',
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
---------------------------------------------------
-- problem.topic: two pointers
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Valid Palindrome', 'easy', 'two pointers',
  'Given a string s, return true if it is a palindrome, otherwise return false.
  A palindrome is a string that reads the same forward and backward.
  It is also case-insensitive and ignores all non-alphanumeric characters.
  Note: Alphanumeric characters consist of letters (A-Z, a-z) and numbers (0-9).');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('3 Sum', 'medium', 'two pointers',
  'Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
  where nums[i] + nums[j] + nums[k] == 0, and the indices i, j and k are all distinct.
  The output should not contain any duplicate triplets. You may return the output and the triplets in any order.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Container With Most Water', 'medium', 'two pointers',
  'You are given an integer array heights where heights[i] represents the height of the ith bar.
  You may choose any two bars to form a container. Return the maximum amount of water a container can store.');
---------------------------------------------------
-- problem.topic: sliding window
--------------------------------------------------- 
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Best Time to Buy And Sell Stock', 'easy', 'sliding window',
  'You are given an integer array prices where prices[i] is the price of NeetCoin on the ith day.
You may choose a single day to buy one NeetCoin and choose a different day in the future to sell it.
Return the maximum profit you can achieve. You may choose to not make any transactions, in which case the profit would be 0.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Substring Without Repeating Characters', 'medium', 'sliding window',
  'Given a string s, find the length of the longest substring without duplicate characters.
A substring is a contiguous sequence of characters within a string.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Repeating Character Replacement', 'medium', 'sliding window',
  'You are given a string s consisting of only uppercase english characters and an integer k. You can choose up to k characters of the string and replace them with any other uppercase English character.
After performing at most k replacements, return the length of the longest substring which contains only one distinct character.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Minimum Window Substring', 'hard', 'sliding window',
  'Given two strings s and t, return the shortest substring of s such that every character in t, including duplicates, is present in the substring.
  If such a substring does not exist, return an empty string. You may assume that the correct output is always unique.');
---------------------------------------------------
-- problem.topic: stack
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Valid Parentheses', 'easy', 'stack',
  'You are given a string s consisting of the following characters: ( ) { } [ ].
  The input string s is valid if and only if: Every open bracket is closed by the same type of close bracket.
  Open brackets are closed in the correct order. Every close bracket has a corresponding open bracket of the same type.
  Return true if s is a valid string, and false otherwise.');
---------------------------------------------------
-- problem.topic: binary search
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Find Minimum In Rotated Sorted Array', 'medium', 'binary search',
  'You are given an array of length n which was originally sorted in ascending order. It has now been rotated between 1 and n times. For example, the array nums = [1,2,3,4,5,6] might become:
[3,4,5,6,1,2] if it was rotated 4 times.
[1,2,3,4,5,6] if it was rotated 6 times.
Notice that rotating the array 4 times moves the last four elements of the array to the beginning. Rotating the array 6 times produces the original array.
Assuming all elements in the rotated sorted array nums are unique, return the minimum element of this array.
A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Search In Rotated Sorted Array', 'medium', 'binary search',
  'You are given an array of length n which was originally sorted in ascending order. It has now been rotated between 1 and n times. For example, the array nums = [1,2,3,4,5,6] might become:
[3,4,5,6,1,2] if it was rotated 4 times.
[1,2,3,4,5,6] if it was rotated 6 times.
Given the rotated sorted array nums and an integer target, return the index of target within nums, or -1 if it is not present.
You may assume all elements in the sorted rotated array nums are unique,
A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?');
---------------------------------------------------
-- problem.topic: linked list
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Reverse Linked List', 'easy', 'linked list',
'Given the beginning of a singly linked list head, reverse the list, and return the new beginning of the list.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Merge Two Sorted Lists', 'easy', 'linked list',
'You are given the heads of two sorted linked lists list1 and list2.
Merge the two lists into one sorted linked list and return the head of the new sorted linked list.
The new list should be made up of nodes from list1 and list2.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Linked List Cycle', 'easy', 'linked list',
  'Given the beginning of a linked list head, return true if there is a cycle in the linked list. Otherwise, return false.
There is a cycle in a linked list if at least one node in the list can be visited again by following the next pointer.
Internally, index determines the index of the beginning of the cycle, if it exists. The tail node of the list will set its next pointer to the index-th node. If index = -1, then the tail node points to null and no cycle exists.
Note: index is not given to you as a parameter.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Reorder List', 'medium', 'linked list',
  'You are given the head of a singly linked-list.
The positions of a linked list of length = 7 for example, can intially be represented as:
[0, 1, 2, 3, 4, 5, 6]
Reorder the nodes of the linked list to be in the following order:
[0, 6, 1, 5, 2, 4, 3]
Notice that in the general case for a list of length = n the nodes are reordered to be in the following order:
[0, n-1, 1, n-2, 2, n-3, ...]
You may not modify the values in the lists nodes, but instead you must reorder the nodes themselves.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Remove Node From End of Linked List', 'medium', 'linked list',
  'You are given the beginning of a linked list head, and an integer n.
Remove the nth node from the end of the list and return the beginning of the list.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Merge K Sorted Lists', 'hard', 'linked list',
  'You are given an array of k linked lists lists, where each list is sorted in ascending order.
Return the sorted linked list that is the result of merging all of the individual linked lists.');
---------------------------------------------------
-- problem.topic: tree
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Invert Binary Tree', 'easy', 'tree',
  'You are given the root of a binary tree root. Invert the binary tree and return its root.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Maximum Depth of Binary Tree', 'easy', 'tree',
  'Given the root of a binary tree, return its depth.
The depth of a binary tree is defined as the number of nodes along the longest path from the root node down to the farthest leaf node.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Same Tree', 'easy', 'tree',
  'Given the roots of two binary trees p and q, return true if the trees are equivalent, otherwise return false.
Two binary trees are considered equivalent if they share the exact same structure and the nodes have the same values.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Subtree of Another Tree', 'easy', 'tree',
  'Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.
A subtree of a binary tree tree is a tree that consists of a node in tree and all of this nodes descendants. The tree tree could also be considered as a subtree of itself.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Lowest Common Ancestor of a Binary Search Tree', 'easy', 'tree',
  'Given a binary search tree (BST) where all node values are unique, and two nodes from the tree p and q, return the lowest common ancestor (LCA) of the two nodes.
The lowest common ancestor between two nodes p and q is the lowest node in a tree T such that both p and q as descendants. The ancestor is allowed to be a descendant of itself.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Binary Tree Level Order Traversal', 'easy', 'tree',
  'Given a binary tree root, return the level order traversal of it as a nested list, where each sublist contains the values of nodes at a particular level in the tree, from left to right.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Validate Binary Search Tree', 'medium', 'tree',
  'Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.
A valid binary search tree satisfies the following constraints:
The left subtree of every node contains only nodes with keys less than the nodes key.
The right subtree of every node contains only nodes with keys greater than the nodes key.
Both the left and right subtrees are also binary search trees.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Kth Smallest Element In a Bst', 'medium', 'tree',
  'Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) in the tree.
A binary search tree satisfies the following constraints:
The left subtree of every node contains only nodes with keys less than the nodes key.
The right subtree of every node contains only nodes with keys greater than the nodes key.
Both the left and right subtrees are also binary search trees.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Construct Binary Tree From Preorder And Inorder Traversal', 'medium', 'tree',
  'You are given two integer arrays preorder and inorder.
preorder is the preorder traversal of a binary tree
inorder is the inorder traversal of the same tree
Both arrays are of the same size and consist of unique values.
Rebuild the binary tree from the preorder and inorder traversals and return its root.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Binary Tree Maximum Path Sum', 'hard', 'tree',
  'Given the root of a non-empty binary tree, return the maximum path sum of any non-empty path.
A path in a binary tree is a sequence of nodes where each pair of adjacent nodes has an edge connecting them. A node can not appear in the sequence more than once. The path does not necessarily need to include the root.
The path sum of a path is the sum of the nodes values in the path.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Serialize And Deserialize Binary Tree', 'hard', 'tree',
  'Implement an algorithm to serialize and deserialize a binary tree.
Serialization is the process of converting an in-memory structure into a sequence of bits so that it can be stored or sent across a network to be reconstructed later in another computer environment.
You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure. There is no additional restriction on how your serialization/deserialization algorithm should work.
Note: The input/output format in the examples is the same as how NeetCode serializes a binary tree. You do not necessarily need to follow this format.');
---------------------------------------------------
-- problem.topic: heap/priority queue
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Find Median From Data Stream', 'hard', 'heap',
'The median is the middle value in a sorted list of integers.
For lists of even length, there is no middle value, so the median is the mean of the two middle values.
For example:
For arr = [1,2,3], the median is 2.
For arr = [1,2], the median is (1 + 2) / 2 = 1.5
Implement the MedianFinder class:
MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far.');
---------------------------------------------------
-- problem.topic: backtracking
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Combination Sum', 'medium', 'backtracking',
'You are given an array of distinct integers nums and a target integer target. Your task is to return a list of all unique combinations of nums where the chosen numbers sum to target.
The same number may be chosen from nums an unlimited number of times. Two combinations are the same if the frequency of each of the chosen numbers is the same, otherwise they are different.
You may return the combinations in any order and the order of the numbers in each combination can be in any order.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Search', 'medium', 'backtracking',
'Given a 2-D grid of characters board and a string word, return true if the word is present in the grid, otherwise return false.
For the word to be present it must be possible to form it with a path in the board with horizontally or vertically neighboring cells. The same cell may not be used more than once in a word.');
---------------------------------------------------
-- problem.topic: tries
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Implement Trie Prefix Tree', 'medium', 'tries',
'A prefix tree (also known as a trie) is a tree data structure used to efficiently store and retrieve keys in a set of strings. Some applications of this data structure include auto-complete and spell checker systems.
Implement the PrefixTree class:
PrefixTree() Initializes the prefix tree object.
void insert(String word) Inserts the string word into the prefix tree.
boolean search(String word) Returns true if the string word is in the prefix tree (i.e., was inserted before), and false otherwise.
boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Design Add And Search Words Data Structure', 'medium', 'tries',
'Design a data structure that supports adding new words and searching for existing words.
Implement the WordDictionary class:
void addWord(word) Adds word to the data structure.
bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots . where dots can be matched with any letter.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Search 2', 'hard', 'tries',
'Given a 2-D grid of characters board and a list of strings words, return all words that are present in the grid.
For a word to be present it must be possible to form the word with a path in the board with horizontally or vertically neighboring cells. The same cell may not be used more than once in a word.');
---------------------------------------------------
-- problem.topic: graphs
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Number Of Islands', 'medium', 'graphs',
  'Given a 2D grid grid where 1 represents land and 0 represents water, count and return the number of islands.
An island is formed by connecting adjacent lands horizontally or vertically and is surrounded by water. You may assume water is surrounding the grid (i.e., all the edges are water).');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Clone Graph', 'medium', 'graphs',
  'Given a node in a connected undirected graph, return a deep copy of the graph.
Each node in the graph contains an integer value and a list of its neighbors.
class Node {
    public int val;
    public List<Node> neighbors;
}
The graph is shown in the test cases as an adjacency list. An adjacency list is a mapping of nodes to lists, used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.
For simplicity, nodes values are numbered from 1 to n, where n is the total number of nodes in the graph. The index of each node within the adjacency list is the same as the nodes value (1-indexed).
The input node will always be the first node in the graph and have 1 as the value.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Pacific Atlantic Water Flow', 'medium', 'graphs',
  'You are given a rectangular island heights where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).
The islands borders the Pacific Ocean from the top and left sides, and borders the Atlantic Ocean from the bottom and right sides.
Water can flow in four directions (up, down, left, or right) from a cell to a neighboring cell with height equal or lower. Water can also flow into the ocean from cells adjacent to the ocean.
Find all cells where water can flow from that cell to both the Pacific and Atlantic oceans. Return it as a 2D list where each element is a list [r, c] representing the row and column of the cell. You may return the answer in any order.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Course Schedule', 'medium', 'graphs',
  'You are given an array prerequisites where prerequisites[i] = [a, b] indicates that you must take course b first if you want to take course a.
The pair [0, 1], indicates that must take course 1 before taking course 0.
There are a total of numCourses courses you are required to take, labeled from 0 to numCourses - 1.
Return true if it is possible to finish all courses, otherwise return false.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Graph Valid Tree', 'medium', 'graphs',
'Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes),
write a function to check whether these edges make up a valid tree.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Number of Connected Components In An Undirected Graph', 'medium', 'graphs',
'You have a graph of n nodes. You are given an integer n and an array edges where edges[i] = [aᵢ, bᵢ] indicates that there is an edge between aᵢ and bᵢ in the graph.
Return the number of connected components in the graph.');
---------------------------------------------------
-- problem.topic: advanced graphs
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Alien Dictionary', 'hard', 'advanced graphs',
  'There is a foreign language which uses the latin alphabet, but the order among letters is not "a", "b", "c" ... "z" as in English.
You receive a list of non-empty strings words from the dictionary, where the words are sorted lexicographically based on the rules of this new language.
Derive the order of letters in this language. If the order is invalid, return an empty string. If there are multiple valid order of letters, return any of them.
A string a is lexicographically smaller than a string b if either of the following is true:
The first letter where they differ is smaller in a than in b.
a is a prefix of b and a.length < b.length.');
---------------------------------------------------
-- problem.topic: 1-D dynamic programming
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Climbing Stairs', 'easy', '1D dynamic programming',
  'You are given an integer n representing the number of steps to reach the top of a staircase. You can climb with either 1 or 2 steps at a time.
Return the number of distinct ways to climb to the top of the staircase.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('House Robber', 'medium', '1D dynamic programming',
  'You are given an integer array nums where nums[i] represents the amount of money the ith house has. The houses are arranged in a straight line, i.e. the ith house is the neighbor of the (i-1)th and (i+1)th house.
You are planning to rob money from the houses, but you cannot rob two adjacent houses because the security system will automatically alert the police if two adjacent houses were both broken into.\
Return the maximum amount of money you can rob without alerting the police.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('House Robber 2', 'medium', '1D dynamic programming',
  'You are given an integer array nums where nums[i] represents the amount of money the ith house has. The houses are arranged in a circle, i.e. the first house and the last house are neighbors.
You are planning to rob money from the houses, but you cannot rob two adjacent houses because the security system will automatically alert the police if two adjacent houses were both broken into.
Return the maximum amount of money you can rob without alerting the police.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Palindromic Substring', 'medium', '1D dynamic programming',
  'Given a string s, return the longest substring of s that is a palindrome.
A palindrome is a string that reads the same forward and backward.
If there are multiple palindromic substrings that have the same length, return any one of them.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Palindromic Substrings', 'medium', '1D dynamic programming',
  'Given a string s, return the number of substrings within s that are palindromes.
A palindrome is a string that reads the same forward and backward.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Decode Ways', 'medium', '1D dynamic programming',
  'A string consisting of uppercase english characters can be encoded to a number using the following mapping:

A -> "1"
B -> "2"
...
Z -> "26"
To decode a message, digits must be grouped and then mapped back into letters using the reverse of the mapping above.
There may be multiple ways to decode a message. For example, "1012" can be mapped into:
"JAB" with the grouping (10 1 2)
"JL" with the grouping (10 12)
The grouping (1 01 2) is invalid because 01 cannot be mapped into a letter since it contains a leading zero.
Given a string s containing only digits, return the number of ways to decode it. You can assume that the answer fits in a 32-bit integer.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Coin Change', 'medium', '1D dynamic programming',
  'You are given an integer array coins representing coins of different denominations (e.g. 1 dollar, 5 dollars, etc) and an integer amount representing a target amount of money.
Return the fewest number of coins that you need to make up the exact target amount. If it is impossible to make up the amount, return -1.
You may assume that you have an unlimited number of each coin.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Maximum Product Subarray', 'medium', '1D dynamic programming',
  'Given an integer array nums, find a subarray that has the largest product within the array and return it.
A subarray is a contiguous non-empty sequence of elements within an array.
You can assume the output will fit into a 32-bit integer.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Word Break', 'medium', '1D dynamic programming',
  'Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of dictionary words.
You are allowed to reuse words in the dictionary an unlimited number of times. You may assume all dictionary words are unique.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('Longest Increasing Subsequence', 'medium', '1D dynamic programming',
  'Given an integer array nums, return the length of the longest strictly increasing subsequence.
A subsequence is a sequence that can be derived from the given sequence by deleting some or no elements without changing the relative order of the remaining characters.');
---------------------------------------------------
-- problem.topic: 2-D dynamic programming
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Unique Paths', 'medium', '2D dynamic programming',
'There is an m x n grid where you are allowed to move either down or to the right at any point in time.
Given the two integers m and n, return the number of possible unique paths that can be taken from the top-left corner of the grid (grid[0][0]) to the bottom-right corner (grid[m - 1][n - 1]).
You may assume the output will fit in a 32-bit integer.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Longest Common Subsequence', 'medium', '2D dynamic programming',
'Given two strings text1 and text2, return the length of the longest common subsequence between the two strings if one exists, otherwise return 0.
A subsequence is a sequence that can be derived from the given sequence by deleting some or no elements without changing the relative order of the remaining characters.
For example, "cat" is a subsequence of "crabt".
A common subsequence of two strings is a subsequence that exists in both strings.');
---------------------------------------------------
-- problem.topic: greedy
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Maximum Subarray', 'medium', 'greedy',
'Given an array of integers nums, find the subarray with the largest sum and return the sum.
A subarray is a contiguous non-empty sequence of elements within an array.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Jump Game', 'medium', 'greedy',
'You are given an integer array nums where each element nums[i] indicates your maximum jump length at that position.
Return true if you can reach the last index starting from index 0, or false otherwise.');
---------------------------------------------------
-- problem.topic: intervals
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Meeting Rooms', 'easy', 'intervals',
'Given an array of meeting time interval objects consisting of start and end times [[start_1,end_1],[start_2,end_2],...] (start_i < end_i),
determine if a person could add all meetings to their schedule without any conflicts.
Note: (0,8),(8,10) is not considered a conflict at 8');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Meeting Rooms 2', 'medium', 'intervals',
'Given an array of meeting time interval objects consisting of start and end times
[[start_1,end_1],[start_2,end_2],...] (start_i < end_i), find the minimum number of rooms required to schedule all meetings without any conflicts.
Note: (0,8),(8,10) is NOT considered a conflict at 8.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Insert Interval', 'medium', 'intervals',
'You are given an array of non-overlapping intervals intervals 
where intervals[i] = [start_i, end_i] represents the start and the end time of the ith interval. intervals is initially sorted in ascending order by start_i.
You are given another interval newInterval = [start, end].
Insert newInterval into intervals such that intervals is still sorted in ascending order by start_i and also intervals still does not have any overlapping intervals.
You may merge the overlapping intervals if needed.
Return intervals after adding newInterval.
Note: Intervals are non-overlapping if they have no common point. For example, [1,2] and [3,4] are non-overlapping, but [1,2] and [2,3] are overlapping.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Merge Intervals', 'medium', 'intervals',
'Given an array of intervals where intervals[i] = [start_i, end_i], merge all overlapping intervals,
and return an array of the non-overlapping intervals that cover all the intervals in the input.
You may return the answer in any order.
Note: Intervals are non-overlapping if they have no common point.
For example, [1, 2] and [3, 4] are non-overlapping, but [1, 2] and [2, 3] are overlapping.');
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Non Overlapping Intervals', 'medium', 'intervals',
'Given an array of intervals intervals where intervals[i] = [start_i, end_i],
return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.
Note: Intervals are non-overlapping even if they have a common point.
For example, [1, 3] and [2, 4] are overlapping, but [1, 2] and [2, 3] are non-overlapping.');
---------------------------------------------------
-- problem.topic: math & geometry
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Rotate Image', 'medium', 'math and geometry',
'Given a square n x n matrix of integers matrix, rotate it by 90 degrees clockwise.
You must rotate the matrix in-place. Do not allocate another 2D matrix and do the rotation.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Spiral Matrix', 'medium', 'math and geometry',
'Given an m x n matrix of integers matrix, return a list of all elements within the matrix in spiral order.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Set Matrix Zones', 'medium', 'math and geometry',
'Given an m x n matrix of integers matrix, if an element is 0, set its entire row and column to 0s.
You must update the matrix in-place.
Follow up: Could you solve it using O(1) space?');
---------------------------------------------------
-- problem.topic: bit manipulation 
---------------------------------------------------
INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Number of 1 Bits', 'easy', 'bit manipulation',
'You are given an unsigned integer n. Return the number of 1 bits in its binary representation.
You may assume n is a non-negative integer which fits within 32-bits.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Counting Bits', 'easy', 'bit manipulation',
'Given an integer n, count the number of 1s in the binary representation of every number in the range [0, n].
Return an array output where output[i] is the number of 1s in the binary representation of i.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Reverse Bits', 'easy', 'bit manipulation',
'Given a 32-bit unsigned integer n, reverse the bits of the binary representation of n and return the result.');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Missing Number', 'easy', 'bit manipulation',
'Given an array nums containing n integers in the range [0, n] without any duplicates, return the single number in the range that is missing from nums.
Follow-up: Could you implement a solution using only O(1) extra space complexity and O(n) runtime complexity?');

INSERT INTO dsa_problem (name, difficulty, topic, description)
VALUES ('Sum of Two Integerss', 'medium', 'bit manipulation',
'Given two integers a and b, return the sum of the two integers without using the + and - operators.');




-- MOCKS
-- INSERT INTO dsa_problem (name, difficulty, topic, description)
--  VALUES ('mock_easy_bs_problem', 'easy', 'binary search', 'description_goes_here');


-- mock
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('mock_easy_bs_problem', 'easy', 'binary search',
  'description_goes_here');
-- move these mock to own script file
INSERT INTO dsa_problem (name, difficulty, topic, description)
  VALUES ('mock_hard_bs_problem', 'hard', 'binary search',
  'description_goes_here');