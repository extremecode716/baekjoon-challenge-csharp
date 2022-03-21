using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p11651.test
{
    using baekjoon.problem.p11651;

    /// <summary>
    /// 좌표 정렬하기 2
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/11651">https://www.acmicpc.net/problem/11651</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "5\n" +
                "0 4\n" +
                "1 2\n" +
                "1 -1\n" +
                "2 2\n" +
                "3 3";
            string output = "1 -1\n" +
                "1 2\n" +
                "2 2\n" +
                "3 3\n" +
                "0 4";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
