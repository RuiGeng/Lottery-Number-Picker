using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LotteryPicker.Models
{
    public class LottoMax : INotifyPropertyChanged
    {
        public ObservableCollection<int> Numbers
        {
            get { return numbers; }
            set
            {
                if (value == numbers)
                {
                    return;
                }
                numbers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> numbers;

        private const int Min = 1;

        private const int Max = 50;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LottoMax()
        {
            Numbers = new ObservableCollection<int>();
        }

        public void GenerateNumbers()
        {
            var resultInts = Enumerable
                .Range(Min, Max)
                .OrderBy(g => Guid.NewGuid())
                .Take(7)
                .ToArray();

            Numbers = new ObservableCollection<int>(resultInts);
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