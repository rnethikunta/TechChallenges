
/* Approach1: BruteForce Method
 	
	This approach is to check each substring whether the substring is a palindrome or not and this can be done with three loops.
	Time complexity: O ( n^3 )
	Auxiliary complexity: O ( 1 )
	Hence, its not an optimized solution. We need something better than O(n^3). See Approach2 below.
*/

/* Approach2: Dynamic Programming



For example: 
The input string is abcbk so the output is here   bcb:  Draw a table with rows and columns like below and designate 
true/false based on the length 1, 2 and 3, 4.. unitl max length.
				

        A	B	C	B	k
A	T	F	F	F	
B		T	F	T	
C			T	F	
B				T	F
k					T



      //Time complexity: O(n^2)
      //Auxiliary complexity: O(n^2) 
*/
    public class LongestPal
    {
        public LongestPal()
        {
        }
        public string GetLongestPalInaGivenString(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // All substrings of length 1 are palindromes

            int n = input.Length;
            bool[,] table = new bool[n, n];
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
            {
                table[i, i] = true;
            }
            // check for sub-string of length 2.
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (input[i] == input[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }
            // Check for lengths greater than 2. k is length
            // of substring
            for (int k = 3; k <= n; ++k)
            {
                // Fix the starting index
                for (int i = 0; i < n - k + 1; ++i)
                {
                    // Get the ending index of substring from
                    // starting index i and length k
                    int j = i + k - 1;
                    // checking for sub-string from ith index to
                    // jth index iff str[i+1] to str[j-1] is a
                    // palindrome
                    if (table[i + 1, j - 1] && input[i] == input[j])
                    {
                        table[i, j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            return input.Substring(start, maxLength);
        }
    }
