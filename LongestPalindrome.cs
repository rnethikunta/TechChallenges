			
			
/* method 1 which is brute force /*

    	/*  time complexity: O ( n^3   and Auxiliary complexity : O (1)
	since method1  is not optimized so we need to look for something better than method1.
		   
 /* method 2: dynamoic programming. See below for the solution.
		
		
	    string str = "banana";
            // All substrings of length 1 are palindromes
            int n = str.Length;
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
                if (str[i] == str[i + 1])
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
                    if (table[i + 1, j - 1] && str[i] == str[j])
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
		Console.WriteLine(str.Substring(start, maxLength)) ;
	      	// the output is  anana
            	//MessageBox.Show(str.Substring(start, maxLength));
			
	 //Time complexity: O(n^2)
         ///Auxiliary complexity: O(n^2)
