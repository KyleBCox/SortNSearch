using App.Models;
using SortNSearch.Sort;
using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(2);
            var list = new List<TestModel1>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new TestModel1()
                {
                    Integer = random.Next(-1000, 1000),
                    FloatingPoint = (float)(random.NextDouble() * random.Next(-1000, 1000)),
                    Double = random.NextDouble() * random.Next(-1000, 1000),
                    Bool = random.Next(-1, 1) == 0
                });
            }
            var newList = list.SelectionSortBy(x => x.FloatingPoint, true);
            OutputTestModel1(list);
            Console.WriteLine("--------");
            OutputTestModel1((List<TestModel1>)newList);

            Console.ReadKey();
        }
        private static void OutputTestModel1(List<TestModel1> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Integer}, {item.FloatingPoint}, {item.Double}, {item.Bool}");
            }
        }
    }
}

