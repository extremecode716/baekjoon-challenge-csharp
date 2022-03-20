using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p2346.test
{
    using baekjoon.problem.p2346;

    /// <summary>
    /// 풍선 터뜨리기
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/2346">https://www.acmicpc.net/problem/2346</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "5\n" +
                "3 2 1 -3 -1";
            string output = "1 4 5 3 2";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "4\n" +
                "3 2 3 -1";
            string output = "1 4 3 2";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase3()
        {
            string input = "5\n" +
                "-5 -5 -5 -5 -5";
            string output = "1 5 3 2 4";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
