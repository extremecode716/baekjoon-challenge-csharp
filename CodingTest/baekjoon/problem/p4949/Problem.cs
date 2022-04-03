using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 균형잡힌 세상
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/4949">https://www.acmicpc.net/problem/4949</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p4949
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

            StringBuilder output = new StringBuilder();
            do
            {
                stack.Clear();

                char[] VPS = Algorithm.ReadLine().ToCharArray();
                if (VPS.Length == 1 && VPS[0] == '.')
                    break;

                for (int j = 0; j < VPS.Length; ++j)
                {
                    switch (VPS[j])
                    {
                        case '(':
                            stack.Push(VPS[j]);
                            break;
                        case ')':
                            if (stack.Count == 0)
                            {
                                stack.Push(VPS[j]);
                            }
                            else
                            {
                                char peek = stack.Peek();
                                if (peek == '(')
                                {
                                    stack.Pop();
                                }
                                else
                                {
                                    stack.Push(VPS[j]);
                                }
                            }
                            break;
                        case '[':
                            stack.Push(VPS[j]);
                            break;
                        case ']':
                            if (stack.Count == 0)
                            {
                                stack.Push(VPS[j]);
                            }
                            else
                            {
                                char peek = stack.Peek();
                                if (peek == '[')
                                {
                                    stack.Pop();
                                }
                                else
                                {
                                    stack.Push(VPS[j]);
                                }
                            }
                            break;
                    }
                }

                if (stack.Count == 0)
                {
                    output.Append("yes");
                }
                else
                {
                    output.Append("no");
                }
                output.Append("\n");
            } while (true);

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