using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04_Froggy
{
    public class Froggy : IEnumerable<int>
    {
        private int[] lake;

        public Froggy(params int[] rocks)
        {
            this.lake = rocks;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lake.Length; i += 2)
            {
                yield return lake[i];
            }

            for (int i = lake.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
