using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 나머지
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/3052">https://www.acmicpc.net/problem/3052</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p3052
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            const int MAX_COUNT = 10;   // 10개 입력 상수
            const int FORTY_TWO = 42;   // 42로 나누기 위한 상수

            int[] arrayCountModBy42 = new int[FORTY_TWO];   // 42로 나눈 나머지를 인덱스 번호에 카운팅 하기 위한 배열
            int differentCount = 0;     // 서로 다른 개수를 구하기
            for (int i = 0; i < MAX_COUNT; ++i)
            {
                int.TryParse(Algorithm.ReadLine(), out int number);
                int modNumber = number % FORTY_TWO;
                if(arrayCountModBy42[modNumber] == 0)
                {
                    ++differentCount; // 서로 다른 개수 구하기(답)
                }
                ++arrayCountModBy42[modNumber]; // 카운팅
            }
           
           Console.WriteLine(differentCount);
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
