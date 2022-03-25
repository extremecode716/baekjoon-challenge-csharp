using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace baekjoon.problem.p2357.test
{
    using baekjoon.problem.p2357;

    /// <summary>
    /// 최솟값과 최댓값
    /// 세그먼트 트리 : 구간을 저장하기 위한 트리
    /// (원래 데이터의 범위를 반씩 분할하며 그 구간을 저장하는 방식, 루트 인덱스 번호가 1부터 시작)
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://www.acmicpc.net/problem/2357">https://www.acmicpc.net/problem/2357</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    [TestClass]
    public class MainTest
    {
        private static void main() { Problem.Main(new string[0]); }

        [TestMethod]
        public void TestCase1()
        {
            string input = "10 4\n" +
                            "75\n" +
                            "30\n" +
                            "100\n" +
                            "38\n" +
                            "50\n" +
                            "51\n" +
                            "52\n" +
                            "20\n" +
                            "81\n" +
                            "5\n" +
                            "1 10\n" +
                            "3 5\n" +
                            "6 9\n" +
                            "8 10";
            string output = "5 100\n" +
                            "38 100\n" +
                            "20 81\n" +
                            "5 81";

            BaekjoonTest.MainTest(input, output, MainTest.main);
            BaekjoonTest.PrintRuntime();
        }
    }
}
