using System;
using System.Collections.Generic;

namespace PersonalBudget.Utilities
{
    internal static class DictionaryExtensions
    {
        public static TV GetOrAdd<T, TV>(this Dictionary<T, TV> dictionary, T key, Func<T, TV> valueFactory)
        {
            TV value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = valueFactory(key);
                dictionary.Add(key, value);
            }

            return value;
        }
    }
}