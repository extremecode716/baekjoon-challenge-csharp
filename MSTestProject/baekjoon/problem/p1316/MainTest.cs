using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.test
{
    using baekjoon.problem.p1316;

    /// <summary>
    /// 그룹 단어 체커
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="http://https://www.acmicpc.net/problem/1316">https://www.acmicpc.net/problem/1316</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "3\n" +
                  "happy\n" +
                  "new\n" +
                  "year";
            string output = "3";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "4\n" +
                "aba\n" +
                "abab\n" +
                "abcabc\n" +
                "a";
            string output = "1";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase3()
        {
            string input = "5\n" +
               "ab\n" +
               "aa\n" +
               "aca\n" +
               "ba\n" +
               "bb";
            string output = "4";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
