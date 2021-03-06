﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101Assignment2Navaneeth.Controllers
{
    public class CCC2020Controller : ApiController
    {
        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/2020/ccc/juniorEF.pdf J1
        /// Barley the dog loves treats. At the end of the day he is either happy or sad depending on the
        /// number and size of treats he receives throughout the day.The treats come in three sizes: small,
        /// medium, and large. His happiness score can be measured using the following formula:
        /// 1 × S + 2 × M + 3 × L
        /// where S is the number of small treats, M is the number of medium treats and L is the number of
        /// large treats.
        /// If Barley’s happiness score is 10 or greater then he is happy.Otherwise, he is sad.Determine
        /// whether Barley is happy or sad at the end of the day.
        /// </summary>
        /// <para>Input Specification
        /// There are three lines of input.Each line contains a non-negative integer less than 10. The first line
        /// contains the number of small treats, S, the second line contains the number of medium treats, M,
        /// and the third line contains the number of large treats, L, that Barley receives in a day.
        /// </para>
        /// <para>Output Specification
        /// If Barley’s happiness score is 10 or greater, output happy.Otherwise, output sad.
        /// </para>
        /// <param name="small">Number of small treats</param>
        /// <param name="medium">Number of medium treats</param>
        /// <param name="large">Number of large treats</param>
        /// <returns>["sad","happy"] according to the H formula (1 × S + 2 × M + 3 × L) >= 10 </returns>
        /// <example>
        /// GET /api/CCC/DogTreatsJ1/3/1/0 : sad
        /// GET /api/CCC/DogTreatsJ1/3/2/1 : happy
        /// </example>
        [HttpGet]
        [Route("api/CCC/DogTreatsJ1/{small}/{medium}/{large}")]
        public string DogTreatsJ1(int small, int medium, int large)
        {
            // variables
            string successMessage = "happy";
            string failMessage = "sad";
            
            // input validation
            if ( small < 0 || medium < 0 || large < 0)
            {
                return "Invalid Input : Input should be a non-negative number";
            }
            
            // calculating H = 1 × S + 2 × M + 3 × L
            int happyScore = (1 * small) + (2 * medium) + (3 * large);
            if (happyScore >= 10)
            {
                return successMessage;
            }
            else
            {
                return failMessage;
            }
        }

        /// <summary>
        /// Help page
        /// </summary>
        /// <returns>Strings with sample input</returns>
        [HttpGet]
        [Route("api/CCC/Help/DogTreatsJ1")]
        public IEnumerable<string> DogTreatsJ1()
        {
            string heading = "Help Page";
            string requestFormat = "requestFormat: GET DogTreatsJ1/small/medium/large";
            string responseFormat = "responseFormat: happy|sad";
            string exampleRequest = "exampleRequest: GET /api/CCC/DogTreatsJ1/3/1/0";
            string exampleResponse = "exampleResponse: sad";
            return new string[] { heading, requestFormat, responseFormat, exampleRequest, exampleResponse };
        }

        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/2020/ccc/juniorEF.pdf J2
        /// People who study epidemiology use models to analyze the spread of disease. In this problem, we
        /// use a simple model. When a person has a disease, they infect exactly R other people but only on
        /// the very next day.No person is infected more than once. We want to determine when a total of more
        /// than P people have had the disease.
        /// <para>Input Specification
        /// There are three lines of input.Each line contains one positive integer.The first line contains the
        /// value of P. The second line contains N, the number of people who have the disease on Day 0. The
        /// third line contains the value of R. Assume that P ≤ 107 and N ≤ P and R ≤ 10.
        /// </para>
        /// <para>Output Specification
        /// Output the number of the first day on which the total number of people who have had the disease
        /// is greater than P.
        /// </para>
        /// <para> Solution
        /// We'll use an array/list to hold the total number of affected people on that day with index 0
        /// dailyInfectedList[0] : number of newly infected people on day 0 = n
        /// dailyInfectedList[1] : number of people infected on day 1 ( just newly infected, not the total number)
        ///                        => dailyInfectedList[0] * number of people to which the disease can spread (r))
        /// dailyInfectedList[n] : dailyInfectedList[n-1] * r
        /// totalInfected = SUM(all elements in the list)
        /// if totalInfected > p
        ///     return : index of the last element on whose addition the total became greater than p ( lenght of list - 1 )
        /// </para>
        /// </summary>
        /// <param name="p">Upper limit of the number of people who gets infected</param>
        /// <param name="n">Number of people who have disease on Day 0</param>
        /// <param name="r">Rate at which the infection is spreading, Number of people infected by each infected person</param>
        /// <returns>Integer number which shows how many days it took to cross the limit of P</returns>
        /// <example>
        /// GET api/CCC/EpidemiologyJ2/750/1/5
        /// GET api/CCC/EpidemiologyJ2/10/2/1
        /// </example>
        [HttpGet]
        [Route("api/CCC/EpidemiologyJ2/{p}/{n}/{r}")]
        public int EpidemiologyJ2(int p, int n, int r)
        {
            // input validation
            if (p < 1 || n < 1 || r < 1)
            {
                System.Diagnostics.Debug.WriteLine("Invalid Input : Input should be a positive number");
                return 0;
            }

            // variables
            // totalInfected = n on day 0 : n people are infected as per problem statement
            int totalInfected = n;
            // list to hold the number of new infections on each day
            List<int> dailyInfectedList = new List<int>();
            // first element of the array is 'n'
            dailyInfectedList.Add(n);

            // condition to check whether the total infected is still under p
            while (totalInfected <= p)
            {
                int peopleInfectedToday = (dailyInfectedList[dailyInfectedList.Count - 1] * r);
                dailyInfectedList.Add(peopleInfectedToday);
                totalInfected += dailyInfectedList[dailyInfectedList.Count - 1];
            }
            System.Diagnostics.Debug.WriteLine("----------------------");
            System.Diagnostics.Debug.WriteLine(String.Join("; ", dailyInfectedList));
            return (dailyInfectedList.Count - 1);
        }

        /// <summary>
        /// Help page
        /// </summary>
        /// <returns>Strings with sample input</returns>
        [HttpGet]
        [Route("api/CCC/Help/EpidemiologyJ2")]
        public IEnumerable<string> EpidemiologyJ2()
        {
            string heading = "Help Page";
            string requestFormat = "requestFormat: GET EpidemiologyJ2/p/n/r";
            string responseFormat = "responseFormat: integer";
            string exampleRequest = "exampleRequest: GET api/CCC/EpidemiologyJ2/750/1/5";
            string exampleResponse = "exampleResponse: 4";
            return new string[] { heading, requestFormat, responseFormat, exampleRequest, exampleResponse };
        }

        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/2020/ccc/juniorEF.pdf J3
        /// Mahima has been experimenting with a new style of art. She stands in front of a canvas and, using
        /// her brush, flicks drops of paint onto the canvas.When she thinks she has created a masterpiece,
        /// she uses her 3D printer to print a frame to surround the canvas.
        /// Your job is to help Mahima by determining the coordinates of the smallest possible rectangular
        /// frame such that each drop of paint lies inside the frame.Points on the frame are not considered
        /// <para>Input Specification
        /// The first line of input contains the number of drops of paint, N, where 2  N  100 and N is an
        /// integer.Each of the next N lines contain exactly two positive integers X and Y separated by one
        /// comma (no spaces). Each of these pairs of integers represents the coordinates of a drop of paint on
        /// the canvas.Assume that X< 100 and Y< 100, and that there will be at least two distinct points.
        /// The coordinates (0, 0) represent the bottom-left corner of the canvas.
        /// For 12 of the 15 available marks, X and Y will both be two-digit integers.
        /// </para>
        /// <para>Output Specification
        /// Output two lines.Each line must contain exactly two non-negative integers separated by a single
        /// comma(no spaces). The first line represents the coordinates of the bottom-left corner of the rectangular frame.
        /// The second line represents the coordinates of the top-right corner of the rectangular frame.
        /// </para>
        /// </summary>
        /// <param name="input"> Input has to be given in a string format in the following format
        /// "N-x1_y1-x2_y2-x3_y3-........-xN_yN"
        /// 5(N)
        /// 44,62(x,y)
        /// 34,69(x,y)
        /// 24,78(x,y)
        /// 42,44(x,y)
        /// 64,10(x,y)
        /// The above input will be given as
        /// 5-44_62-34_69-24_78-42_44-64_10
        /// </param>
        /// <returns>two string on two line containing co-ordinates of bottom-left(line#1) and top-right(line#2)</returns>
        /// <example>
        /// GET api/CCC/ArtJ3/5-44_62-34_69-24_78-42_44-64_10
        /// Output
        /// ------------
        /// 23,9
        /// 65,79
        /// </example>
        [HttpGet]
        [Route("api/CCC/ArtJ3/{input}")]
        public IEnumerable<string> ArtJ3(string input)
        {
            // receive the input as a string and extract the data out of it
            //string s = "5-44_62-34_69-24_78-42_44-64_10";
            System.Diagnostics.Debug.WriteLine(input);
            // Initially the input contained ':' seperating lines and ',' seperating coordinates
            // inorder to escape that the urlDecode was mentioned.
            // New input format contains url friendly characters
            input = WebUtility.UrlDecode(input);
            System.Diagnostics.Debug.WriteLine(input);
            // splitting the input string to make processing easier
            string[] subs = input.Split('-');
            List<int> xAxis = new List<int>();
            List<int> yAxis = new List<int>();

            // first element of the list is N, thus we can avoid it in processing
            // so the list is starting from index 1
            for (int i = 1; i < subs.Length; i++)
            {
                // Console.WriteLine(subs[i]);
                string[] axes = subs[i].Split('_');
                // input validation : skipping for now as the document has 
                // mentioned the input will be in that range
                // verify whether the x,y values are in the range of 1-99 : 
                xAxis.Add(int.Parse(axes[0]));
                yAxis.Add(int.Parse(axes[1]));
            }

            int minX = xAxis.Min();
            int minY = yAxis.Min();
            int maxX = xAxis.Max();
            int maxY = yAxis.Max();

            // decrementing the bottom left value by 1 for frame
            // incrementing the top right value by 1 for frame
            int frameMinX = minX - 1;
            int frameMinY = minY - 1;
            int frameMaxX = maxX + 1;
            int frameMaxY = maxY + 1;

            return new string[] { frameMinX + "," + frameMinY, frameMaxX + "," + frameMaxY };
        }

        /// <summary>
        /// Help page
        /// </summary>
        /// <returns>Strings with sample input</returns>
        [HttpGet]
        [Route("api/CCC/Help/ArtJ3")]
        public IEnumerable<string> ArtJ3()
        {
            string heading = "Help Page";
            string requestFormat = "requestFormat: GET api/CCC/ArtJ3/N-x1_y1-x2_y2-x3_y3-........-xN_yN";
            string responseFormat = "responseFormat: x1,y1\nx2,y2";
            string exampleRequest = "exampleRequest: GET api/CCC/ArtJ3/5-44_62-34_69-24_78-42_44-64_10";
            string exampleResponse = "exampleResponse: 23,9\n65,79";
            return new string[] { heading, requestFormat, responseFormat, exampleRequest, exampleResponse };
        }
    

        /// <summary>
        /// Thuc likes finding cyclic shifts of strings. A cyclic shift of a string is obtained by moving characters
        /// from the beginning of the string to the end of the string. We also consider a string to be a cyclic
        /// shift of itself.For example, the cyclic shifts of ABCDE are:
        /// ABCDE, BCDEA, CDEAB, DEABC, and EABCD.
        /// Given some text, T, and a string, S, determine if T contains a cyclic shift of S.
        /// <para>Input Specification
        /// The input will consist of exactly two lines containing only uppercase letters.The first line will be
        /// the text T, and the second line will be the string S. Each line will contain at most 1000 characters.
        /// For 6 of the 15 available marks, S will be exactly 3 characters in length.
        /// </para>
        /// <para>Output Specification
        /// Output yes if the text, T, contains a cyclic shift of the string, S.Otherwise, output no.Output Specification
        /// Output yes if the text, T, contains a cyclic shift of the string, S.Otherwise, output no.
        /// </para>
        /// <param name="textT">Input string : We need to check whether it contains any cyclic shift of inputS</param>
        /// <param name="inputS">Input string : We need to check whether any cyclic shift of S is present in textT</param>
        /// <returns> a string "yes" or "no" according to the condition:(cyclicShift(input) in textT</returns>
        /// <example>
        /// GET api/CCC/CyclicShiftsJ4/ABCCDEABAA/ABCDE : YES
        /// GET api/CCC/CyclicShiftsJ4/batman/abcd : NO
        /// GET api/CCC/CyclicShiftsJ4/ABCDDEBCAB/ABA : NO
        /// </example>
        [HttpGet]
        [Route("api/CCC/CyclicShiftsJ4/{textT}/{inputS}")]
        public string CyclicShiftsJ4(string textT, string inputS)
        {
            // easiest way to generate a list of all possible cyclic shifts is
            // to concatenate the string with itself, and take substrings of original string length
            // but with index offset by one for each iteration
            // abc : abc + abc = abcabc => abc, bca, cab, abc ( last one can be avoided )
            // abcd : abcdabcd => abcd, bcda, cdab, dabc, abcd
            string cyclicStringCheck = inputS + inputS;
            // a list containing all possible cyclic shifts
            List<string> cyclicShiftList = new List<string>();

            // generating all possible cyclic shifts and adding it into a list
            for ( int i = 0; i < cyclicStringCheck.Length / 2 ; i++)
            {
                // shifting the index by one point on every iteration and storing the
                // substring into a list
                string cyclicSubstring = cyclicStringCheck.Substring(i, inputS.Length);
                System.Diagnostics.Debug.WriteLine(cyclicSubstring);
                cyclicShiftList.Add(cyclicSubstring);
            }
            // return value of IndexOf is -1 if no match is found
            int flag = -1;
            foreach (string cyclicShift in cyclicShiftList)
            {
                System.Diagnostics.Debug.WriteLine(textT);
                System.Diagnostics.Debug.WriteLine(cyclicShift);
                // if a match occurs, it returns the index of the match
                flag = textT.IndexOf(cyclicShift);
                if (flag != -1)
                {
                    break;
                }
            }
            
            if (flag == -1)
            {
                return "no";
            } else
            {
                return "yes";
            }
        }

        /// <summary>
        /// Help page
        /// </summary>
        /// <returns>Strings with sample input</returns>
        [HttpGet]
        [Route("api/CCC/Help/CyclicShiftsJ4")]
        public IEnumerable<string> CyclicShiftsJ4()
        {
            string heading = "Help Page";
            string requestFormat = "requestFormat: GET api/CCC/CyclicShiftsJ4/text/string";
            string responseFormat = "responseFormat: yes|no";
            string exampleRequest = "exampleRequest: GET api/CCC/CyclicShiftsJ4/ABCCDEABAA/ABCDE";
            string exampleResponse = "exampleResponse: yes";
            return new string[] { heading, requestFormat, responseFormat, exampleRequest, exampleResponse };
        }

        /*
        Escape Room is a backtracking algorithm problem, and will solve if I get enough time
        You start at (1,1) and you've to reach (m,n)
        When you start at (1,1) you've to find the value of the two dimensional matrix, and find the divisors of that value.
        3
        4
        3 10 8 14
        1 11 12 12
        6 2 3 9

        input_matrix[0,0] => 3
        Divisors of 3 -> (1,3) and (3,1)
        These two co-ordinates are the places to which you can move now
        This has to be written in a fucntion and we'll use recursion to keep on checking

        End Condition
        ------------
        If the divisor of an element is (m,n) then you've existed the maze:
        Else
        ------------
        mark the current value as -1 a[i,j] (to mark it as visited)
        and return false to the calling function

        // pseudo code
        func findDivisors(x)
            i = 1
            while ( i <= sqrt(x)
                if x % i == 0
                    list.add(i, x/i)
                    return list
                i++
            

        func solveMaze(i,j)
            if matrix[i,j] == -1
                return -1 ( making sure we don't reach an infinite loop by solving the same nodes again
            else
                divisorList = findDivisors(matrix[i,j])
                if (m,n) in divisorList
                    return "True" // solved the maze
                else
                    matrix[i,j] = -1 // so that we dont do these operations again 
                                     // you can duplicate the matrix to keep track of visited as well
                    for divisors in divisorList
                        solveMaze(divisor[0],divisor[1])
            

        */
        /*
        [HttpGet]
        [Route("api/CCC/EscapeRoomJ5/{input}")]
        public string EscapeRoomJ5(input)
        {

        }*/
    }
}
