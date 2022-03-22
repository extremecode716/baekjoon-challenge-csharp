using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 스도쿠
/// 백트래킹 알고리즘
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/2580">https://www.acmicpc.net/problem/2580</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p2580
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static List<Position> emptySpots;
        private static int[,] sudoku;
        private static void Solution()
        {

            // 스도쿠 초기 셋팅
            emptySpots = new List<Position>();
            sudoku = new int[9, 9];
            for (int y = 0; y < 9; ++y)
            {
                int[] arrLine = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse); // 한줄 배열
                for (int x = 0; x < 9; ++x)
                {
                    sudoku[y, x] = arrLine[x];
                    if (sudoku[y, x] == 0)
                        emptySpots.Add(new Position(x, y));
                }
            }

            // 스도쿠 시작
            Sudoku(0);

            // 출력
            StringBuilder output = new StringBuilder();
            for(int y = 0; y < 9; ++y)
            {
                for(int x = 0; x < 9; ++x)
                {
                    output.Append(sudoku[y, x]).Append(' ');
                }
                output.Length = output.Length - 1;
                output.Append('\n');
            }

            Console.Write(output);
        }

        // DFS, 백트래킹
        private static bool Sudoku(int count)
        {
            // 재귀 종료 조건
            if (count == emptySpots.Count)
            {
                return true;
            }

            Position position = emptySpots[count];
            int col = position.X;
            int row = position.Y;
            for (int i = 1; i < 10; i++)
            {
                if (IsSudokuCheck(row, col, i))
                {
                    sudoku[row, col] = i;
                    // 백트래킹
                    if (Sudoku(count + 1)) 
                        return true;
                    else 
                        sudoku[row, col] = 0;
                }
            }

            return false;
        }

        // 행 검사 -> 열 검사 -> 3*3 구역 검사
        private static bool IsSudokuCheck(int row, int col, int num)
        {
            int xZone = col / 3; // 현재 구역의 위치 x
            int yZone = row / 3; // 현재 구역의 위치 y

            // 행, 열 블록 조건 판단
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[row, i] == num) return false;
                if (sudoku[i, col] == num) return false;
            }

            // 3x3 구역 블록 조건 판단
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (sudoku[yZone * 3 + y, xZone * 3 + x] == num)
                        return false;
                }
            }

            return true;
        }
    }

    class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        public bool Equals(Position other)
        {
            return other != null && X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
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
