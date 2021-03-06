using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 수 찾기
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/1920">https://www.acmicpc.net/problem/1920</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p1920
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            HashSet<int> hashSet = new HashSet<int>();

            int N, M;
            int.TryParse(Algorithm.ReadLine(), out N);
            int[] arrayA = Array.ConvertAll<string, int>(Algorithm.ReadLine().Split(' '), int.Parse);
            foreach (int number in arrayA)
            {
                hashSet.Add(number);
            }
            int.TryParse(Algorithm.ReadLine(), out M);
            int[] arrayM = Array.ConvertAll<string, int>(Algorithm.ReadLine().Split(' '), int.Parse); ;

            StringBuilder output = new StringBuilder();
            foreach (int number in arrayM)
            {
                if (hashSet.Contains(number))
                {
                    output.Append(1);
                }
                else
                {
                    output.Append(0);
                }

                output.Append('\n');
            }

            Console.Write(output);
        }


        /// <summary>
        /// Algorithm 클래스는 백준 문제 번호를 이름으로하는 네임스페이스로 복사 - 붙여넣기하여 사용합니다.
        /// </summary>
        /// <author>extremecode716</author>
        /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
        class Algorithm
        {
            public delegate void Solution();
            private static TextReader inputStream;

            public static string ReadLine()
            {
                inputStream = inputStream == null ? Console.In : inputStream;
                string line = null;
                try
                {
                    line = inputStream.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return line;
            }

            public static List<string> ReadLines(int readCount)
            {
                inputStream = inputStream == null ? Console.In : inputStream;
                List<string> lines = new List<string>();
                try
                {
                    int count = 0;
                    String line;
                    while ((line = inputStream.ReadLine()) != null)
                    {
                        lines.Add(line);
                        ++count;
                        if (count == readCount)
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return lines;
            }

            public static void Close()
            {
                if (null == inputStream)
                    return;
                try
                {
                    inputStream.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    inputStream = null;
                }
            }

            public static void Solve(Solution solution)
            {
                solution.Invoke();
                Close();
            }
        }
    }
}