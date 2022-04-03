using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p2042.test
{
    using baekjoon.problem.p2042;

    /// <summary>
    /// 구간 합 구하기
    /// 세그먼트 트리 : 구간을 저장하기 위한 트리
    /// (원래 데이터의 범위를 반씩 분할하며 그 구간을 저장하는 방식, 루트 인덱스 번호가 1부터 시작)
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/2042">https://www.acmicpc.net/problem/2042</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "5 2 2\n" +
                            "1\n" +
                            "2\n" +
                            "3\n" +
                            "4\n" +
                            "5\n" +
                            "1 3 6\n" +
                            "2 2 5\n" +
                            "1 5 2\n" +
                            "2 3 5";
            string output = "17\n" +
                            "12";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "5 0 1\n" +
                            "1\n" +
                            "2\n" +
                            "6\n" +
                            "4\n" +
                            "2\n" +
                            "2 1 4";
            string output = "13";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
