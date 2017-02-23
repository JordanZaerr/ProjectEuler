using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public static class Looping
    {
        /// <summary>
        /// Return false to break out of the loop.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <returns>Returns true if the loop was broken out of, otherwise false.</returns>
        public static bool EachBreakable<T>(this IEnumerable<T> list, Func<T, bool> action)
        {
            if (list == null) return false;

            foreach (var t in list)
            {
                if (!action(t))
                    return true;
            }
            return false;
        }

        public static void Each<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null) return;

            foreach (var t in list)
            {
                action(t);
            }
        }

        public static IEnumerable<U> For<T, U>(this IEnumerable<T> list, Func<T, int, U> action)
        {
            return list.ToList().For(action);
        }

        public static IEnumerable<U> For<T, U>(this IList<T> list, Func<T, int, U> action)
        {
            if (list == null) yield break;
            for (int i = 0; i < list.Count; i++)
            {
                yield return action(list[i], i);
            }
        }

        public static T FirstOrderedBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey> order)
        {
            return list.OrderByDescending(order).First();
        }
    }
}