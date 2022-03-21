using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p3052.test
{
    using baekjoon.problem.p3052;

    /// <summary>
    /// 나머지
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/3052">https://www.acmicpc.net/problem/3052</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "1\n" +
                "2\n" +
                "3\n" +
                "4\n" +
                "5\n" +
                "6\n" +
                "7\n" +
                "8\n" +
                "9\n" +
                "10";
            string output = "10";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "42\n" +
                "84\n" +
                "252\n" +
                "420\n" +
                "840\n" +
                "126\n" +
                "42\n" +
                "84\n" +
                "420\n" +
                "126";
            string output = "1";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase3()
        {
            string input = "39\n" +
                "40\n" +
                "41\n" +
                "42\n" +
                "43\n" +
                "44\n" +
                "82\n" +
                "83\n" +
                "84\n" +
                "85";
            string output = "6";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
