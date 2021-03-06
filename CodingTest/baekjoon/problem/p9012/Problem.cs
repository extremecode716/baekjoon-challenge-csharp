using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 괄호
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/9012">https://www.acmicpc.net/problem/9012</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p9012
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            Stack<char> stack = new Stack<char>();

            int T;
            int.TryParse(Algorithm.ReadLine(), out T);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < T; ++i)
            {
                stack.Clear();

                char[] VPS = Algorithm.ReadLine().ToCharArray();

                for (int j = 0; j < VPS.Length; ++j)
                {
                    if (VPS[j].Equals('('))
                    {
                        stack.Push(VPS[j]);
                    }
                    else if (VPS[j].Equals(')'))
                    {
                        if (stack.Count == 0)
                        {
                            stack.Push(VPS[j]);
                        }
                        else
                        {
                            char peek = stack.Peek();
                            if (peek.Equals('('))
                            {
                                stack.Pop();
                            }
                            else
                            {
                                stack.Push(VPS[j]);
                            }
                        }
                    }
                }

                if (stack.Count == 0)
                {
                    output.Append("YES");
                }
                else
                {
                    output.Append("NO");
                }
                output.Append("\n");
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