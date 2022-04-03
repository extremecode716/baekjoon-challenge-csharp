using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p4949.test
{
    using baekjoon.problem.p4949;

    /// <summary>
    /// 균형잡힌 세상
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/4949">https://www.acmicpc.net/problem/4949</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "So when I die (the [first] I will see in (heaven) is a score list).\n" +
                            "[ first in ] ( first out ).\n" +
                            "Half Moon tonight (At least it is better than no Moon at all].\n" +
                            "A rope may form )( a trail in a maze.\n" +
                            "Help( I[m being held prisoner in a fortune cookie factory)].\n" +
                            "([ (([( [ ] ) ( ) (( ))] )) ]).\n" +
                            " .\n" +
                            ".";
            string output = "yes\n" +
                            "yes\n" +
                            "no\n" +
                            "no\n" +
                            "no\n" +
                            "yes\n" +
                            "yes";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
