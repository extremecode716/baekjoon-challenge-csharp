using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 구간 합 구하기
/// 세그먼트 트리 : 구간을 저장하기 위한 트리
/// (원래 데이터의 범위를 반씩 분할하며 그 구간을 저장하는 방식, 루트 인덱스 번호가 1부터 시작)
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/2042">https://www.acmicpc.net/problem/2042</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p2042
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static long[] numbers;
        private static long[] sumSegmentTree;
        private static long sumValue;

        private static void Solution()
        {
            // input 값 세팅
            int[] NMK = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse);
            int N = NMK[0], M = NMK[1], K = NMK[2];
            numbers = new long[N];
            for (int i = 0; i < N; ++i)
            {
                long.TryParse(Algorithm.ReadLine(), out numbers[i]);
            }

            // 트리 사이즈 계산 및 배열 할당
            int depth = (int)Math.Ceiling(Math.Log2(N)) + 1;
            int treeSize = (int)Math.Pow(2, depth);
            sumSegmentTree = new long[treeSize];
            InitSegmentTree(1, 0, N - 1);

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < M + K; ++i)
            {
                sumValue = 0;
                string[] abc = Algorithm.ReadLine().Split(' ');
                int.TryParse(abc[0], out int a);
                int.TryParse(abc[1], out int b);
                long.TryParse(abc[2], out long c);
                switch (a)
                {
                    case 1: // 값 
                        long difValue = c - numbers[b - 1];
                        numbers[b - 1] = c;
                        UpdateSumValueFromSegmentTree(1, 0, N - 1, b - 1, difValue);
                        break;
                    case 2: // 구간 합 출력
                        FindSumValueFromSegmentTree(1, 0, N - 1, b - 1, c - 1);
                        output.Append(sumValue).Append('\n');
                        break;
                }
            }
            Console.Write(output);
        }

        // 매개변수 : 현재 인덱스, 시작 인덱스, 종료 인덱스
        private static void InitSegmentTree(int currentIndex, int startIndex, int endIndex)
        {
            if (startIndex == endIndex) // 세그먼트 트리의 리프 노드에 오리지널 값 저장
            {
                sumSegmentTree[currentIndex] = numbers[startIndex];
                return;
            }
            InitSegmentTree(currentIndex * 2, startIndex, (startIndex + endIndex) / 2);
            InitSegmentTree(currentIndex * 2 + 1, (startIndex + endIndex) / 2 + 1, endIndex);
            // 왼쪽 자식 노드, 오른쪽 자식 노드의 합계를 저장.
            sumSegmentTree[currentIndex] = sumSegmentTree[currentIndex * 2] + sumSegmentTree[currentIndex * 2 + 1];
        }

        // 합계 찾기
        private static void FindSumValueFromSegmentTree(int currentIndex, int startIndex, int endIndex, int leftIndex, long rightIndex)
        {
            if (leftIndex > endIndex || rightIndex < startIndex)
                return;
            if (leftIndex <= startIndex && endIndex <= rightIndex)
            {
                sumValue += sumSegmentTree[currentIndex];
                return;
            }
            FindSumValueFromSegmentTree(currentIndex * 2, startIndex, (startIndex + endIndex) / 2, leftIndex, rightIndex);
            FindSumValueFromSegmentTree(currentIndex * 2 + 1, (startIndex + endIndex) / 2 + 1, endIndex, leftIndex, rightIndex);
        }

        private static void UpdateSumValueFromSegmentTree(int currentIndex, int startIndex, int endIndex, int updateIndex, long difValue)
        {
            if (updateIndex < startIndex || updateIndex > endIndex)
                return;

            sumSegmentTree[currentIndex] += difValue;
            if (startIndex == endIndex)
                return;

            UpdateSumValueFromSegmentTree(currentIndex * 2, startIndex, (startIndex + endIndex) / 2, updateIndex, difValue);
            UpdateSumValueFromSegmentTree(currentIndex * 2 + 1, (startIndex + endIndex) / 2 + 1, endIndex, updateIndex, difValue);
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
