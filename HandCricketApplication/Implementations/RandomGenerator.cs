using System;
using System.Collections.Generic;
using System.Linq;

namespace HandCricketApplication.Implementations
{
    public class RandomGenerator
    {
        private Random Random { get; set; }
        public RandomGenerator()
        {
            Random = new Random();
        }
        public int RandomNumbers(int minValue, int maxValue)
        {
            SortedList<int, int> sorterd = new SortedList<int, int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                if (i != 5)
                    sorterd.Add(Random.Next(), i);
            }
            return sorterd.Values.First();
        }
    }
}
