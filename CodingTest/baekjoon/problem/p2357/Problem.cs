using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 최솟값과 최댓값
/// 세그먼트 트리 : 구간을 저장하기 위한 트리
/// (원래 데이터의 범위를 반씩 분할하며 그 구간을 저장하는 방식, 루트 인덱스 번호가 1부터 시작)
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/2357">https://www.acmicpc.net/problem/2357</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p2357
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static int[] numbers;
        private static int[] minSegmentTree, maxSegmentTree;
        private static int minValue, maxValue;

        private static void Solution()
        {
            // input 값 세팅
            int[] NM = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse);
            int N = NM[0], M = NM[1];
            numbers = new int[N];
            for (int i = 0; i < N; ++i)
            {
                int.TryParse(Algorithm.ReadLine(), out numbers[i]);
            }

            // 트리 사이즈 계산 및 배열 할당
            int depth = (int)Math.Ceiling(Math.Log(N) / Math.Log(2)) + 1;
            int treeSize = (int)Math.Pow(2, depth);
            minSegmentTree = new int[treeSize];
            maxSegmentTree = new int[treeSize];

            InitSegmentTree(1, 0, N - 1);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < M; ++i)
            {
                minValue = int.MaxValue;
                maxValue = int.MinValue;
                int[] ab = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse);
                int a = ab[0], b = ab[1];
                FindMinMaxValueFromSegmentTree(1, 0, N - 1, a - 1, b - 1);
                output.Append(minValue).Append(' ').Append(maxValue).Append('\n');
            }
            Console.Write(output);
        }

        // 매개변수 : 현재 인덱스, 시작 인덱스, 종료 인덱스
        private static void InitSegmentTree(int currentIndex, int startIndex, int endIndex)
        {
            if (startIndex == endIndex) // 세그먼트 트리의 리프 노드에 값 저장
            {
                minSegmentTree[currentIndex] = maxSegmentTree[currentIndex] = numbers[startIndex];
                return;
            }
            InitSegmentTree(currentIndex * 2, startIndex, (startIndex + endIndex) / 2);
            InitSegmentTree(currentIndex * 2 + 1, (startIndex + endIndex) / 2 + 1, endIndex);
            // 왼쪽 자식 노드, 오른쪽 자식 노드의 최솟값을 저장.
            minSegmentTree[currentIndex] = Math.Min(minSegmentTree[currentIndex * 2], minSegmentTree[currentIndex * 2 + 1]);
            maxSegmentTree[currentIndex] = Math.Max(maxSegmentTree[currentIndex * 2], maxSegmentTree[currentIndex * 2 + 1]);
        }

        // 최솟값, 최댓값 찾기
        private static void FindMinMaxValueFromSegmentTree(int currentIndex, int startIndex, int endIndex, int leftIndex, int rightIndex)
        {
            if (leftIndex > endIndex || rightIndex < startIndex)
                return;
            if (leftIndex <= startIndex && endIndex <= rightIndex)
            {
                minValue = Math.Min(minValue, minSegmentTree[currentIndex]);
                maxValue = Math.Max(maxValue, maxSegmentTree[currentIndex]);
                return;
            }
            FindMinMaxValueFromSegmentTree(currentIndex * 2, startIndex, (startIndex + endIndex) / 2, leftIndex, rightIndex);
            FindMinMaxValueFromSegmentTree(currentIndex * 2 + 1, (startIndex + endIndex) / 2 + 1, endIndex, leftIndex, rightIndex);
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
