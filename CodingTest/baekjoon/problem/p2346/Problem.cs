using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 풍선 터뜨리기
/// </summary>
/// <author>extremecode716</author>
/// <see href="https://www.acmicpc.net/problem/2346">https://www.acmicpc.net/problem/2346</see>
/// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
namespace baekjoon.problem.p2346
{
    public class Problem
    {
        public static void Main(string[] args)
        {
            Algorithm.Solve(Problem.Solution);
        }

        private static void Solution()
        {
            int N = int.Parse(Algorithm.ReadLine()); // 풍선 개수

            int[] balloonNumberArray = Array.ConvertAll(Algorithm.ReadLine().Split(' '), int.Parse);
            var balloonNumbers = new CircularDoublyLinkedList<int>();
            foreach (var number in balloonNumberArray)
            {
                balloonNumbers.Add(number);
            }


            StringBuilder output = new StringBuilder(); // 결과를 담을 변수

            Item<int> item = balloonNumbers.Get(0); // 1번째 풍선을 찾는다.
            int nextBalloonNumber = item.Data; // 다음 터칠 풍선 번호
            balloonNumbers.RemoveItem(item); // 빵!

            output.Append(item.Index + 1).Append(' '); // 터진 풍선의 번호를 출력값에 Write
            for (int i = 1; i < N; ++i)
            {
                item = balloonNumbers.Get(nextBalloonNumber, item); // 다음 터칠 풍선을 찾는다.
                nextBalloonNumber = item.Data; // 다음 터칠 풍선 번호
                balloonNumbers.RemoveItem(item); // 빵!

                output.Append(item.Index + 1).Append(' '); // 터진 풍선의 번호를 출력값에 Write
            }

            output.Length = output.Length - 1; // 마지막 ' '공백 삭제

            Console.WriteLine(output);
        }
    }

    public class Item<T>
    {
        public T Data { get; set; }
        public int Index { get; set; }

        public Item<T> Previous { get; set; }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
        }
        public override string ToString() => Data.ToString();
    }
    /// <summary>
    /// Circular Doubly Linked List.
    /// </summary>
    public class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        private Item<T> Head;
        private int count;
        public int Count => count;
        public CircularDoublyLinkedList() => Clear();

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (count == 0)
            {
                SetHeadItem(data);

                return;
            }

            Item<T> item = new Item<T>(data)
            {
                Next = Head,
                Previous = Head.Previous
            };

            Head.Previous.Next = item;
            Head.Previous = item;
            item.Index = count;
            count++;
        }

        public Item<T> Get(int index, Item<T> current = null)
        {
            current ??= Head;

            bool isRight = index > -1 ? true : false;

            int i = 0;
            while (true)
            {
                if (i == index)
                {
                    return current;
                }

                if (isRight)
                {
                    ++i;
                    current = current.Next;
                }
                else
                {
                    --i;
                    current = current.Previous;
                }
            }

            return null;
        }

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (Head.Data.Equals(data))
            {
                RemoveItem(Head);
                Head = Head.Next;

                return;
            }

            Item<T> current = Head;

            for (int i = count; i > 0; i--)
            {
                if (current?.Data.Equals(data) == true)
                {
                    RemoveItem(current);
                }

                current = current.Next;
            }
        }

        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                Item<T> current = Head;

                for (int i = count; i > 0; i--)
                {
                    if (current?.Data.Equals(target) == true)
                    {
                        Item<T> item = new Item<T>(data);

                        current.Next.Previous = item;
                        item.Previous = current;
                        item.Next = current.Next;
                        current.Next = item;

                        count++;

                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

        public string Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            while (current != Head)
            {
                if (current.Data.Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Element {data} is not in the list.";
        }

        public void Clear()
        {
            Head = null;
            count = 0;
        }

        public void RemoveItem(Item<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            count--;
        }

        private void SetHeadItem(T data)
        {
            Head = new Item<T>(data);

            Head.Next = Head;
            Head.Previous = Head;
            Head.Index = count;
            count = 1;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            for (int i = 0; i < count * 2; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }

    /// <summary>
    /// Algorithm 클래스는 백준 문제 번호를 이름으로하는 네임스페이스로 복사 - 붙여넣기하여 사용합니다.
    /// </summary>
    /// <author>extremecode716</author>
    /// <see href="https://github.com/extremecode716/baekjoon-challenge-csharp">https://github.com/extremecode716/baekjoon-challenge-csharp</see>
    class Algorithm
    {
        public delegate void Solution();
        private static TextReader inputStream;

        public static string ReadLine()
        {
            inputStream = inputStream == null ? Console.In : inputStream;
            string line = null;
            try
            {
                line = inputStream.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return line;
        }

        public static List<string> ReadLines(int readCount)
        {
            inputStream = inputStream == null ? Console.In : inputStream;
            List<string> lines = new List<string>();
            try
            {
                int count = 0;
                String line;
                while ((line = inputStream.ReadLine()) != null)
                {
                    lines.Add(line);
                    ++count;
                    if (count == readCount)
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return lines;
        }

        public static void Close()
        {
            if (null == inputStream)
                return;
            try
            {
                inputStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                inputStream = null;
            }
        }

        public static void Solve(Solution solution)
        {
            solution.Invoke();
            Close();
        }
    }
}
