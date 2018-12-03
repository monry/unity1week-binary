using System;
using System.Linq;

namespace Monry.Unity1Weeks.Binary.Utility
{
    public static class EnumUtility
    {
        private static readonly Random Random = new Random();

        public static TEnum GetRandom<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .OrderBy(x => Random.Next())
                .FirstOrDefault();
        }
    }
}