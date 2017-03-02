using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace SpiralPrimes
{
    //26241
    class SpiralPrimes
    {
        static void Main()
        {
            //This takes forever...
            //Timer.Record(FirstAttempt);
      
            //This also takes forever, just a shorter forever.
            //Timer.Record(SecondAttempt);

            //~500ms
            Timer.Record(ThirdAttempt);
            Console.ReadLine();
        }

        private static void ThirdAttempt()
        {
            //Seed values for side length of 3
            var numberCount = 9;
            var primeCount = 3;
            var number = 9;
            var percentage = 1d;

            var sideCount = 5;
            while (percentage > 0.1)
            {
                var nextNumbers = GetNextNumbers(sideCount, number);
                number = nextNumbers.Last();
                numberCount += 4;
                primeCount += nextNumbers.Count(x => x.IsPrime());
                percentage = primeCount * 1d / numberCount;
                sideCount += 2;
            }
            Console.WriteLine(sideCount);
        }

        private static IEnumerable<int> GetNextNumbers(int sideLength, int current)
        {
            yield return current + (sideLength - 1);
            yield return current + (sideLength - 1)*2;
            yield return current + (sideLength - 1)*3;
            yield return current + (sideLength - 1)*4;
        }

        private static void SecondAttempt()
        {
            var sideLength = 26239;
            var percentage = 1d;
            while (percentage > 0.1d)
            {
                sideLength += 2;
                var numbers = CornerNumberGenerator(sideLength);
                percentage =  numbers.Count(x => x.IsPrime()) * 1d / numbers.Count();
            }
            Console.WriteLine(sideLength);
        }

        private static IEnumerable<int> CornerNumberGenerator(int sides)
        {
            var sideLength = 3;
            var number = 1;
            var incrementor = 2;
            var count = 0;
            while (sides >= sideLength)
            {
                number += incrementor;
                yield return number;
                count++;
                if (count == 4)
                {
                    incrementor += 2;
                    sideLength += 2;
                    count=0;
                }
            }
        }

        private static void FirstAttempt()
        {
            double percentage = 100d;
            var primes = new HashSet<int>(Primes.FindPrimesBySieveOfAtkins(214748359));
            var grid = new Grid(26241);
            grid.BuildGrid();

            while (percentage >= 0.1)
            {
                var diagonals = grid.Rows.FlattenLeftDiagonal(grid.Size - 1).First()
                    .Concat(grid.Rows.FlattenRightDiagonal(grid.Size - 1).First()).Distinct().ToList();
                var foundPrimes = diagonals.Where(x => primes.Contains(x)).ToList();
                percentage = foundPrimes.Count * 1d / diagonals.Count;

                if(percentage >= 0.1)
                    grid.IncreaseSize();
            }
            Console.WriteLine(grid.Size);
        }

        public class Grid
        {
            public int Size { get; set; }
            private readonly Position _position = new Position();

            public Grid(int size)
            {
                Size = size;
            }

            public List<List<int>> Rows { get; set; } = new List<List<int>>();

            public void BuildGrid()
            {
                _position.Row = Size / 2;
                _position.Column = Size / 2;
                _position.Current = 1;

                Enumerable.Range(0, Size).Each(_ => Rows.Add(Enumerable.Repeat(0, Size).ToList()));

                Rows[_position.Row][_position.Column] = _position.Current;
                _position.Current++;

                Enumerable.Range(1, Size - 1).Each(_ => Iteration());
            }

            public void IncreaseSize()
            {
                Size += 2;
                Rows.Each(x =>
                {
                    x.Insert(0, 0); 
                    x.Add(0);
                });
                Rows.Insert(0, Enumerable.Repeat(0, Size).ToList());
                Rows.Add(Enumerable.Repeat(0, Size).ToList());
                ExpandIteration();
            }

            private void Iteration()
            {
                MoveRight(Rows);
                if (CheckPosition(Size)) return;
                MoveUp(Rows);
                MoveLeft(Rows);
                MoveDown(Rows);
            }

            private void ExpandIteration()
            {
                _position.Row++;
                _position.Column += 2;
                Rows[_position.Row][_position.Column] = _position.Current++;
                MoveUp(Rows);
                MoveLeft(Rows);
                MoveDown(Rows);
                MoveRight(Rows);
            }

            private void MoveDown(List<List<int>> rows)
            {
                Enumerable.Range(0, _position.StepAmount)
                    .Each(_ =>
                    {
                        _position.Row++;
                        rows[_position.Row][_position.Column] = _position.Current++;
                    });
            }

            private void MoveRight(List<List<int>> rows)
            {
                _position.StepAmount++;
                Enumerable.Range(0, _position.StepAmount)
                    .Each(_ =>
                    {
                        if (CheckPosition(Size)) return;
                        _position.Column++;
                        rows[_position.Row][_position.Column] = _position.Current++;
                    });
            }

            private void MoveUp(List<List<int>> rows)
            {
                Enumerable.Range(0, _position.StepAmount)
                    .Each(_ =>
                    {
                        _position.Row--;
                        rows[_position.Row][_position.Column] = _position.Current++;
                    });
                _position.StepAmount++;
            }

            private void MoveLeft(List<List<int>> rows)
            {
                Enumerable.Range(0, _position.StepAmount)
                    .Each(_ =>
                    {
                        _position.Column--;
                        rows[_position.Row][_position.Column] = _position.Current++;
                    });
            }

            private bool CheckPosition(int size)
            {
                return _position.Column >= size - 1 && _position.Row >= size - 1;
            }

            private class Position
            {
                public int Row { get; set; }
                public int Column { get; set; }

                public int StepAmount { get; set; }
                public int Current { get; set; }
            }
        }
    }
}
