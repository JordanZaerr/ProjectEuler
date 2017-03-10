using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Shared;

namespace XorDecryption
{
    //107359
    class XorDecryption
    {
        static void Main()
        {
            //~1400ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static List<char> _letters = new List<char>();

        //Lowercase a-z ASCII values 97-122
        private static void FirstAttempt()
        {
            //The most common word in english.
            var matchWord = "the";

            _letters = Enumerable.Range(97, 26).Select(x => (char) x).ToList();

            var encrypted = File.ReadAllLines("cipher.txt")
                .First()
                .Split(',')
                .Select(int.Parse)
                .ToList();

            var keys = _letters.SelectMany(a => _letters.SelectMany(b => _letters.Select(c => new string(new[] {a, b, c})))).ToList();

            var dictionary = new Dictionary<string, string>();
            keys.Each(key =>
            {
                var message = Encoding.ASCII.GetString(encrypted.Zip(BuildLongKey(key), (a, b) => (byte)(a ^ b)).ToArray());
                if (message.IndexOf(matchWord, StringComparison.OrdinalIgnoreCase) > 0)
                    dictionary[key] = message;
            });

            var result =
                dictionary.Select(x => Tuple.Create(FindCount(x.Value, matchWord), x))
                    .OrderByDescending(x => x.Item1)
                    .First().Item2;

            Console.WriteLine(result.Value.Sum(x => x));
        }

        private static int FindCount(string message, string word)
        {
            var count = 0;
            var index = -1;

            do
            {
                if ((index = message.IndexOf(word, index + 1, StringComparison.OrdinalIgnoreCase)) >= 0)
                    count++;
            } while (index >= 0);

            return count;
        }

        private static IEnumerable<byte> BuildLongKey(string key)
        {
            while (true)
            {
                yield return (byte)key[0];
                yield return (byte)key[1];
                yield return (byte)key[2];
            }
        }
    }
}
