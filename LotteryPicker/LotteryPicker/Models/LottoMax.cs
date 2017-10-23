using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryPicker.Models
{
    public class LottoMax
    {
        public IReadOnlyList<int> Numbers;

        private const int Min = 1;

        private const int Max = 50;

        public LottoMax()
        {
            Numbers = new List<int>();
        }

        public void GenerateNumbers()
        {
            Numbers = Enumerable
                .Range(Min, Max)
                .OrderBy(g => Guid.NewGuid())
                .Take(7)
                .ToArray();
        }

        public void PrintNumbers()
        {
            foreach (var number in Numbers)
            {
                Console.WriteLine($@"{number}");
            }
        }
    }
}