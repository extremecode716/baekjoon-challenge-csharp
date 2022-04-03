using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p9012.test
{
    using baekjoon.problem.p9012;

    /// <summary>
    /// 괄호
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/9012">https://www.acmicpc.net/problem/9012</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "6\n" +
                            "(())())\n" +
                            "(((()())()\n" +
                            "(()())((()))\n" +
                            "((()()(()))(((())))()\n" +
                            "()()()()(()()())()\n" +
                            "(()((())()(";
            string output = "NO\n" +
                            "NO\n" +
                            "YES\n" +
                            "NO\n" +
                            "YES\n" +
                            "NO";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "3\n" +
                            "((\n" +
                            "))\n" +
                            "())(()";
            string output = "NO\n" +
                            "NO\n" +
                            "NO";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
