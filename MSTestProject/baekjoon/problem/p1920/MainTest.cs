using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p1920.test
{
    using baekjoon.problem.p1920;

    /// <summary>
    /// 수 찾기
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/1920">https://www.acmicpc.net/problem/1920</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "5\n" +
                            "4 1 5 2 3\n" +
                            "5\n" +
                            "1 3 7 9 5";
            string output = "1\n" +
                            "1\n" +
                            "0\n" +
                            "0\n" +
                            "1";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
