using System.Numerics;

namespace Crypto.Lib
{
    public class Prime
    {
        public BigInteger RangeStart { get; set; } = BigInteger.Zero;

        public BigInteger RangeEnd { get; set; } = BigInteger.Zero;

        #region Ctors
        public Prime(int value)
        {
            RangeEnd = BigInteger.Parse(value.ToString());
        }
        public Prime(BigInteger value)
        {
            RangeEnd = value;
        }

        public Prime(string value)
        {
            RangeEnd = BigInteger.Parse(value);
        }

        public Prime(int start, int end)
        {
            RangeStart = BigInteger.Parse(start.ToString());
            RangeEnd = BigInteger.Parse(end.ToString());
        }
        public Prime(BigInteger start, BigInteger end)
        {
            RangeStart = start;
            RangeEnd = end;
        }

        public Prime(string start, string end)
        {
            RangeStart = BigInteger.Parse(start);
            RangeEnd = BigInteger.Parse(end);
        }
        #endregion


        /// <summary>
        /// Simplest approach
        /// </summary>
        /// <returns></returns>
        public List<BigInteger> Generate()
        {
            List<BigInteger> list_of_primes = new();
            for (BigInteger i = 0; i < RangeEnd; i++)
            {
                if (i < RangeStart) continue;
                if (IsPrime(i)) list_of_primes.Add(i);
            }
            return list_of_primes;
        }

        #region PrimeCheck
        public static bool IsPrime(int value)
        {
            return IsPrime(value.ToString());
        }

        public static bool IsPrime(string value)
        {
            return IsPrime(BigInteger.Parse(value));
        }

        public static bool IsPrime(BigInteger number)
        {
            if (number == 0) return false;
            if (number == 1 || number == 2) return true;
            for (BigInteger i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        #endregion

        public static bool IsCoprime()
        {
            return true; //TODO: think about implementation of euler's totient or Fermat's little theorem.
        }
    }
}
