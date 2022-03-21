using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 좌표 정렬하기 2
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/11651">https://www.acmicpc.net/problem/11651</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p11651
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            int.TryParse(Algorithm.ReadLine(), out int N);

            // Pos 클래스에 x, y를 넣은 후 Comparer를 구현하여 정렬 할 것 이다.
            Position[] positions = new Position[N];
            for(int i = 0; i < positions.Length; ++i)
            {
                int[] xy = Array.ConvertAll<string, int>(Algorithm.ReadLine().Split(' '), int.Parse);
                positions[i] = new Position(xy[0], xy[1]);
            }

            // 기본적으로 Y를 기준으로 정렬하고, 같은 경우는 X를 기준으로 정렬한다. (오름차순)
            Array.Sort(positions, comparison: (pos1, pos2) =>
            {
                if (pos1.Y == pos2.Y)
                {
                    return pos1.X.CompareTo(pos2.X);
                }
                return pos1.Y.CompareTo(pos2.Y);
            });

            StringBuilder output = new StringBuilder();
            foreach (var pos in positions)
            {
                output.Append(pos.ToString()).Append('\n');
            }

           Console.Write(output);
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
