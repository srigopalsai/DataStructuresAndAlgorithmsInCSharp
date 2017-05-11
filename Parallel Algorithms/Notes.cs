/*
Parallel Algorithms 

http://www.catonmat.net/blog/mit-introduction-to-algorithms-part-thirteen/
http://www.ibm.com/developerworks/java/library/j-jtp11137/index.html

1. Fibonacci 
2. Parallel Matrix Multiplication
3. Greedy Scheduling
4. Parallel Merge Sort      https://courses.engr.illinois.edu/cs241/fa2012/assignments/mergesort/
                            https://codingrush.wordpress.com/2012/10/31/multithreaded-merge-sort/
5. Matrix Multiplication    https://codingrush.wordpress.com/2012/10/31/multi-threaded-matrix-multiplication/


Exercise 2-1. Give an efficient and highly parallel multithreaded algorithm for multiplying an n×n matrix A by a length-n vector x that achieves work Θ(n2)and critical path Θ(lgn). 
                Analyze the work and critical-path length of your implementation, and give the parallelism.
Exercise 2-2. Describe a multithreaded algorithm for matrix multiplication that achieves work Θ(n3)and critical path Θ(lgn). 
                Comment informally on the locality displayed by your algorithm in the ideal cache model as compared with the two algorithms from this section.
Exercise 2-3. Write a Cilk program to multiply an n1 ×n2 matrix by an n2 ×n3 matrix in parallel. Analyze the work, critical-path length, and parallelism of your implementation. 
                Your algorithm should be efficient even if any of n1, n2, and n3 are 1.
Exercise 2-4. Write a Cilk program to implement Strassen’s matrix multiplication algorithm in parallel as efficiently as you can. Analyze the work, critical-path length, and parallelism of your implementation.
Exercise 2-5. Write a Cilk program to invert a symmetric and positive-definite matrix in parallel. (Hint: Use a divide-and-conquer approach based on the ideas of Theorem 31.12 from [7].)
Exercise 2-6. Akl and Santoro [1] have proposed a merging algorithm in which the first step is to find the median of all the elements in the two sorted input arrays (as opposed to the median of the elements in the larger subarray, as is done in P-MERGE). 
                Show that if the total number of elements in the two arrays is n, this median can be found using Θ(lgn)time on one processor in the worst case. 
                Describe a linear-work multithreaded merging algorithm based on this subroutine that has a parallelism of Θ(n/lg 2 n). 
                Give and solve the recurrences for work and critical-path length, and determine the parallelism. Implement your algorithm as a Cilk program.
  !
Handout 29: Dynamic Multithreaded Algorithms 13

Exercise 2-7. Generalize the algorithm from Exercise 2-6 to find arbitrary order statistics. Describe a merge-sorting algorithm with Θ(nlgn) work that achieves a parallelism of Θ(n/lgn). (Hint: Merge many subarrays in parallel.)
Exercise 2-8. The length of a longest-common subsequence of two length-n sequences x and y can be computed in parallel using a divide-and-conquer multithreaded algorithm. Denote by c[i,j] the length of a longest common subsequence of x[1. .i] and y[1. .j]. 
                First, the multithreaded algorithm recursively computes c[i,j] for all i in the range 1 ≤ i ≤ n/2 and all j in the range 1 ≤ j ≤ n/2. 
                Then, it recursively computes c[i,j] for 1 ≤ i ≤ n/2 and n/2 < j ≤ n, while in parallel recursively computing c[i,j] for n/2 < i ≤ n and 1 ≤ j ≤ n/2. Finally, it recursively computes c[i,j] for n/2 < i ≤ n and n/2 < j ≤ n. 
                For the base case, the algorithm computes c[i,j] in terms of c[i− 1,j− 1], c[i− 1,j], and c[i,j− 1] in the ordinary way, since the logic of the algorithm guarantees that these three values have already been computed.

That is, if the dynamic programming tableau is broken into four pieces
I II III IV , 
then the recursive multithreaded code would look something like this:
I 
spawn II 
spawn III 
sync
IV 
return
Analyze the work, critical-path length, and parallelism of this algorithm. 
Describe and analyze an algorithm that is asymptotically as efficient (same work) but more parallel. Make whatever interesting observations you can. Write an efficient Cilk program for the problem.

*/