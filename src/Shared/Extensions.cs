using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Shared
{
    public static class Extensions
    {
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this List<T> list)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                var result = new List<T>();
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        result.Add(list[j]);
                    }
                }
                yield return result;
            }
        }



        //TODO: Make this better...
        public static List<List<T>> Permutations<T>(this IList<T> items)
        {
            var perm = new T[items.Count];
            var results = new List<List<T>>();
            PermuteItems(items, new bool[items.Count], perm, results, 0);
            return results;
        }

        private static void PermuteItems<T>(IList<T> items, bool[] in_selection, T[] current_permutation, List<List<T>> results, int next_position)
        {
            // See if all of the positions are filled.
            if (next_position == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(current_permutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        // Add this item to the current permutation.
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, in_selection,
                            current_permutation, results,
                            next_position + 1);

                        // Remove the item from the current permutation.
                        in_selection[i] = false;
                    }
                }
            }
        }
    }
}