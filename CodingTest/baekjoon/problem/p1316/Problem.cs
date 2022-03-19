using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// 그룹 단어 체커
/// </summary>
/// <author>extremecode716</author>
/// <see href="http://https://www.acmicpc.net/problem/1316">https://www.acmicpc.net/problem/1316</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p1316
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            int testCase = int.Parse(Algorithm.ReadLine());
            int count = 0;
            for (int i = 0; i < testCase; ++i)
            {
                if (IsGroupString(Algorithm.ReadLine()))
                {
                    ++count;
                }
            }

            Console.WriteLine(count);
        }

        private static bool IsGroupString(string str)
        {
            bool[] checkAlphabet = new bool['z' - 'a' + 1];

            char prevAlphabet = (char)0;
            for (int i = 0; i < str.Length; ++i)
            {
                char curAlphabet = str[i];

                if (prevAlphabet != curAlphabet)
                {
                    if (checkAlphabet[curAlphabet - 'a'])
                    { // 기존에 나온 알파벳이면 그룹이 아니다.
                        return false;
                    }
                    else
                    {
                        checkAlphabet[curAlphabet - 'a'] = true;
                        prevAlphabet = curAlphabet;
                    }
                }
            }
            return true;
        }
    }

    /// <summary>
    /// Algorithm 클래스는 백준 문제의 Main 클래스로 복사 - 붙여넣기하여 사용합니다.
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
