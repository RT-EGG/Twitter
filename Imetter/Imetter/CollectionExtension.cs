using System.Collections.Generic;

namespace Imetter
{
    public static class CollectionExtension
    {
        public static int CountTrue(this IEnumerable<bool> inConditions)
        {
            int result = 0;
            foreach (bool condition in inConditions) {
                if (condition)
                    ++result;
            }
            return result;
        }
    }
}
