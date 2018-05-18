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
            var random = new Random(1);
            var list = new List<TestModel1>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new TestModel1()
                {
                    thing1int = random.Next(-1000, 1000),
                    thing2float = (float)(random.NextDouble() * random.Next(-1000, 1000)),
                    thing3Double = random.NextDouble() * random.Next(-1000, 1000),
                    thing4bool = random.Next(-1, 1) == 0
                });
            }
            var newList = list.InsertionSortBy(x => x.thing2float, true);
            OutputTestModel1(list);
            Console.WriteLine("--------");
            OutputTestModel1((List<TestModel1>)newList);

            Console.ReadKey();
        }
        private static void OutputTestModel1(List<TestModel1> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.thing1int}, {item.thing2float}, {item.thing3Double}, {item.thing4bool}");
            }
        }
    }
}

