using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// 연산자 끼워넣기
/// 브루트포스 알고리즘
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/14888">https://www.acmicpc.net/problem/14888</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p14888
{
    class OperatorChar
    {
        public char Command { get; private set; }
        public int Count { get; set; }

        public OperatorChar(char command, int count)
        {
            this.Command = command;
            this.Count = count;
        }
    }

    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static int max;
        private static int min;
        private static int[] numbers;
        private static OperatorChar[] operatorChars;
        private static void Solution()
        {
            // 초기 셋팅
            max = int.MinValue;
            min = int.MaxValue;
            numbers = new int[int.Parse(Algorithm.ReadLine())];
            operatorChars = new OperatorChar[4];
            numbers = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse);
            string[] opers = Algorithm.ReadLine().Split(' ');
            for (int i = 0; i < opers.Length; ++i)
            {
                switch (i)
                {
                    case 0:
                        operatorChars[i] = new OperatorChar('+', int.Parse(opers[i]));
                        break;
                    case 1:
                        operatorChars[i] = new OperatorChar('-', int.Parse(opers[i]));
                        break;
                    case 2:
                        operatorChars[i] = new OperatorChar('*', int.Parse(opers[i]));
                        break;
                    case 3:
                        operatorChars[i] = new OperatorChar('/', int.Parse(opers[i]));
                        break;
                }
            }

            // 브루트포스 알고리즘
            dfs(numbers[0], 1);

            Console.WriteLine(max);
            Console.WriteLine(min);
        }

        private static void dfs(int sum, int depth)
        {
            if (depth == numbers.Length)
            {
                max = Math.Max(max, sum);
                min = Math.Min(min, sum);
                return;
            }

            for (int i = 0; i < 4; ++i)
            {
                if (operatorChars[i].Count > 0)
                {
                    --operatorChars[i].Count;

                    switch (operatorChars[i].Command)
                    {
                        case '+':
                            dfs(sum + numbers[depth], depth + 1);
                            break;
                        case '-':
                            dfs(sum - numbers[depth], depth + 1);
                            break;
                        case '*':
                            dfs(sum * numbers[depth], depth + 1);
                            break;
                        case '/':
                            dfs(sum / numbers[depth], depth + 1);
                            break;
                        default:
                            break;
                    }
                    ++operatorChars[i].Count;
                }
            }
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