using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Linq;

namespace Question_1_WompRatThread
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var dictionary = new SortedDictionary<int, string>();
            var semaphore = new Semaphore(1, 1);
            var taskList = new List<Task>();
            
            for (int i = 1; i <= 500; i += 100)
            {
                var range = new Range(i, i + 99);
                taskList.Add(
                    Task.Run(
                        () => ProcessAsync(
                            range, 
                            (i, v) =>
                            {
                                semaphore.WaitOne();
                                dictionary[i] = v;
                                semaphore.Release(1);
                            }
                        )
                    )
                );
            }

            await Task.WhenAll(taskList);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Value);
            }

            void ProcessAsync(Range range, Action<int, string> callback)
            {
                for (int i = range.Start.Value; i <= range.End.Value; i++)
                {
                    string output = i switch
                    {
                        var x when x % 5 == 0 && x % 7 == 0 => "WompRat",
                        var x when x % 5 == 0 => "Womp",
                        var x when x % 7 == 0 => "Rat",
                        _ => $"{i}"
                    };

                    callback(i, output);
                }
            }
        }
    }
}
