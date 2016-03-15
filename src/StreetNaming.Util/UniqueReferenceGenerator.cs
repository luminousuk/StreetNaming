using System;

namespace StreetNaming.Util
{
    public static class UniqueReferenceGenerator
    {
        private static readonly Random Rand = new Random(DateTime.Now.Millisecond);

        public static string GetCaseReference(string prefix, long sequence)
        {
            var year = DateTime.Now.Year - 2000;
            var rand = Rand.Next(99);
            var chk = GetParity(sequence + year + rand);

            return $"{prefix}-{year}{sequence:000}-{rand:00}{chk}";
        }

        public static int GetParity(long val)
        {
            var p = 1;
            do
            {
                p ^= (int) (val & 0x1);
                val = val >> 1;
            } while (val > 0);

            return p;
        }
    }
}