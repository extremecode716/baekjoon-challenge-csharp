using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p2580.test
{
    using baekjoon.problem.p2580;

    /// <summary>
    /// 스도쿠
    /// 백트래킹 알고리즘
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/2580">https://www.acmicpc.net/problem/2580</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "0 3 5 4 6 9 2 7 8\n" +
                            "7 8 2 1 0 5 6 0 9\n" +
                            "0 6 0 2 7 8 1 3 5\n" +
                            "3 2 1 0 4 6 8 9 7\n" +
                            "8 0 4 9 1 3 5 0 6\n" +
                            "5 9 6 8 2 0 4 1 3\n" +
                            "9 1 7 6 5 2 0 8 0\n" +
                            "6 0 3 7 0 1 9 5 2\n" +
                            "2 5 8 3 9 4 7 6 0";

            string output = "1 3 5 4 6 9 2 7 8\n" +
                            "7 8 2 1 3 5 6 4 9\n" +
                            "4 6 9 2 7 8 1 3 5\n" +
                            "3 2 1 5 4 6 8 9 7\n" +
                            "8 7 4 9 1 3 5 2 6\n" +
                            "5 9 6 8 2 7 4 1 3\n" +
                            "9 1 7 6 5 2 3 8 4\n" +
                            "6 4 3 7 8 1 9 5 2\n" +
                            "2 5 8 3 9 4 7 6 1";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
