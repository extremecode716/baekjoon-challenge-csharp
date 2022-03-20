using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p10926.test
{
    using baekjoon.problem.p10926;

    /// <summary>
    /// ??!
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/10926">https://www.acmicpc.net/problem/10926</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "joonas";
            string output = "joonas??!";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
