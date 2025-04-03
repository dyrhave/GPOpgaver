using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.RegularExpressions;

namespace GPOpgaver
{
    public static class Opgaver
    {
        /*
        * Introduktion til Algoritmer
        * Exercise 1. 
        * Make an algorithm that interchanges the values of the variables x and y, using only assignment statements.
        * What is the minimum number of assignment statements needed to do so?
        */
        public static void Interchange(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }
        /*
        * Introduktion til Algoritmer
        * Exercise 2. 
        * Make an algorithm that uses only assignment statements to replace thevalues of the triple(x, y, z) with (z, x, y).
        * What is the minimum number of assignment statements needed?
        */
        public static void InterchangeTriple(ref int x, ref int y, ref int z)
        {
            (x, y, z) = (z, x, y);
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 3.
         * A palindrome is a string that reads the same forward and backward.
         * Make an algorithm for determining whether a string of n characters is a palindrome and output true or false.
         */
        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            
            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.a.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4A
         * The solution should return the number of steps that it goes through to complete the unit test
         */
        public static int StepsInLinearSearch(int searchFor, int[] intergerArray)
        {
            int steps = 0;
            foreach (int num in intergerArray)
            {
                steps++;
                if (num == searchFor)
                    return steps;
            }
            return 0;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.b.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4B
         * The solution should return the number of steps that it goes through complete the unit test
         */
        public static int StepsInBinarySearch(int[] integerArray, int arrayStart, int arrayEnd, int searchFor)
        {
            var steps = 0;
            while (arrayStart < arrayEnd)
            {
                steps++;
                int mid = arrayStart + (arrayEnd - arrayStart) / 2;
                
                if (integerArray[mid] == searchFor)
                    return steps;
                
                if (integerArray[mid] < searchFor)
                    arrayStart = mid + 1;
                else arrayEnd = mid - 1;
            }
            return 0;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 5.
         * Describe an algorithm based on the linear search for de-termining the correct position in which to insert a new element in an already sorted list.
         */
        public static int InsertSortedList(List<int> sortedList, int insert)
        {
            int insertIndex = 0;

            foreach (var item in sortedList)
            {
                if (item >= insert)
                    break;
                
                insertIndex++;
            }
            return insertIndex;
        }
        /*
         * Exercise 6.
         * Arrays
         * Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num up to length.
         * Notice that num is also included in the returned array.
         */
        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] multiples = new int[length];
            for (int i = 0; i < length; i++)
            {
                multiples[i] = num * (i + 1);
            }
            return multiples;
        }
        /*
         * Exercise 7.
         * Create a function that takes in n, a, b and returns the number of values raised to the nth power that lie in the range [a, b], inclusive.
         * Remember that the range is inclusive. a < b will always be true.
         */
        public static int PowerRanger(int power, int min, int max)
        {
            int count = 0;
            for (int i = 1; i <= max; i++)
            {
                double result = Math.Pow(i, power);
                if (result >= min && result <= max)
                    count++;
                if (result > max)
                    break;
            }

            return count;
        }
        /*
         * Exercise 8.
         * Create a Fact method that receives a non-negative integer and returns the factorial of that number.
         * Consider that 0! = 1.
         * You should return a long data type number.
         * https://www.mathsisfun.com/numbers/factorial.html
         */
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        /*
         * Exercise 9.
         * Write a function which increments a string to create a new string.
         * If the string ends with a number, the number should be incremented by 1.
         * If the string doesn't end with a number, 1 should be added to the new string.
         * If the number has leading zeros, the amount of digits should be considered.
         * exampel: 
         * wow0849 -> wow0850
         * test99 -> test100
         */
        public static string IncrementString(string txt)
        {
            int i = txt.Length - 1;
            while (i >= 0 && char.IsDigit(txt[i]))
            {
                i--;
            }

            if (i == txt.Length -1)
            {
                return txt + "1";
            }

            string wordPart = txt.Substring(0, i + 1);
            string numberPart = txt.Substring(i + 1);

            int number = int.Parse(numberPart) + 1;
            string incrementedNumber = number.ToString().PadLeft(numberPart.Length, '0');

            return wordPart + incrementedNumber;
        }
        /*
         * Exercise 10.
         * Write a method to validate a sercure password.
         *     The password must contain at least one uppercase character.
         *     The password must contain at least one lowercase character.
         *     The password must contain at least one number.
         *     The password must contain at least one special character 
         *     The password must not contain other special characters then ! @ # $ % ^ & * ( ) + = - { } [ ] : ; " ' ? < > , . _
         *     The password must be at least 8 characters in length.
         *     The password must not be 25 characters or over in length.
         */
        public static bool ValidatePassword(string password)
        {
            int check = 0;
            
            while (true)
            {
                switch (check)
                {
                    case 0:
                        bool hasUppercase = password.Any(char.IsUpper);
                        if (hasUppercase)
                        {
                            check = 1;
                            continue;
                        }
                        return false;
                    
                    case 1:
                        bool hasLowercase = password.Any(char.IsLower);
                        if (hasLowercase)
                        {
                            check = 2;
                            continue;
                        }
                        return false;
                    
                    case 2:
                        bool hasDigits = Regex.IsMatch(password, @"\d");
                        if (hasDigits)
                        {
                            check = 3;
                            continue;
                        }
                        return false;
                    
                    case 3:
                        bool hasSymbols = password.Any(ch => !char.IsLetterOrDigit(ch));
                        if (hasSymbols)
                        {
                            check = 4;
                            continue;
                        }
                        return false;
                    
                    case 4:
                        string validSymbols = "!@#$%^&*()+=- {}[]:;\"'?<>,./_";

                        bool hasInvalidSymbols = password.Any(ch => !char.IsLetterOrDigit(ch) && !validSymbols.Contains(ch));
                        if (!hasInvalidSymbols)
                        {
                            check = 5;
                            continue;
                        }   
                        return false;
                    
                    case 5:
                        bool validMinLength = password.Length >= 8;
                        if (validMinLength)
                        {
                            check = 6;
                            continue;
                        }
                        return false;
                    
                    case 6:
                        bool validMaxLength = password.Length < 25;
                        if (validMaxLength)
                        {
                            check = 7;
                            continue;
                        }
                        return false;
                    
                    case 7:
                        return true;
                }
            }
        }
    }
}