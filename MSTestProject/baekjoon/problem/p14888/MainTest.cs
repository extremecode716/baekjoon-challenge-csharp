using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p14888.test
{
    using baekjoon.problem.p14888;

    /// <summary>
    /// 연산자 끼워넣기
    /// 브루트포스 알고리즘
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/14888">https://www.acmicpc.net/problem/14888</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "2\n" +
                            "5 6\n" +
                            "0 0 1 0";
            string output = "30\n" +
                            "30";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "3\n" +
                            "3 4 5\n" +
                            "1 0 1 0";
            string output = "35\n" +
                             "17";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase3()
        {
            string input = "6\n" +
                            "1 2 3 4 5 6\n" +
                            "2 1 1 1";
            string output = "54\n" +
                            "-24";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
