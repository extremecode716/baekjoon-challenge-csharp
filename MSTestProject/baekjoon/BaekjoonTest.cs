using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Diagnostics;
using NLog;

namespace baekjoon
{
    using CodingTest.utils;

    /// <summary>
    /// 테스트용 클래스
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="http://https://www.acmicpc.net/problem/1316">https://www.acmicpc.net/problem/1316</see>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    public class BaekjoonTest
    {
        public delegate void Main();

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly DecimalFormat DECIMAL_FORMAT = new DecimalFormat("0.####");
        private static readonly String lineSeparator = Environment.NewLine;

        private static DateTime startTime = DateTime.Now, endTime = DateTime.Now;
        private static TextReader originStreamInput;
        private static TextWriter originStreamOutput;

        public static StringWriter GetOutputStringWriter(String input)
        {
            Console.SetIn(new StringReader(input));
            StringWriter outputStringWriter = new StringWriter();
            Console.SetOut(outputStringWriter);

            return outputStringWriter;
        }

        public static void MainTest(String input, String output, Main main)
        {
            SaveOriginInputAndOutputStream();
            StringWriter outputStringWriter = GetOutputStringWriter(input);

            startTime = DateTime.Now;
            main.Invoke();
            endTime = DateTime.Now;

            Assert.AreEqual(output + "\n", outputStringWriter.ToString().Replace(lineSeparator, "\n"));
            LoadOriginInoutAndPrintStream();
        }

        public static void PrintRuntime()
        {
            StackFrame stackFrame = new StackFrame(1, true);
            string[] fileNameSplits = stackFrame.GetFileName()?.Split("\\");
            string problemName = "";
            if (fileNameSplits?.Length > 2)
            {
                problemName = fileNameSplits[fileNameSplits.Length - 2];
            }
            Logger.Debug("{0} {1} | runtime: {2} ms", problemName, stackFrame.GetMethod()?.Name, DECIMAL_FORMAT.format(((TimeSpan)(endTime - startTime)).TotalMilliseconds));
        }

        private static void SaveOriginInputAndOutputStream()
        {
            originStreamInput = Console.In;
            originStreamOutput = Console.Out;
        }

        private static void LoadOriginInoutAndPrintStream()
        {
            Console.SetIn(originStreamInput);
            Console.SetOut(originStreamOutput);
        }
    }
}
