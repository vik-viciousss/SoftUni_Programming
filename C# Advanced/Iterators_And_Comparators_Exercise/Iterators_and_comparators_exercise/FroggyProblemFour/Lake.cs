using System.Collections;
using System.Collections.Generic;

namespace FroggyProblemFour
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            int lastIndex = this.stones.Count - 1;

            if (lastIndex % 2 == 0)
            {
                for (int i = lastIndex - 1; i >= 1; i -= 2)
                {
                    yield return stones[i];
                }
            }
            else
            {
                for (int i = lastIndex; i >= 1; i -= 2)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
