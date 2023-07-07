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

        #region Classic
        public static bool IsPrime(int value)
        {
            return IsPrime(value.ToString());
        }

        public static bool IsPrime(string value)
        {
            return IsPrime(BigInteger.Parse(value));
        }
        /// <summary>
        /// Checks a number for primality, slow but 100%
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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

        #region Fermat
        public static bool IsComposite_Fermat(int value)
        {
            return IsComposite_Fermat(value.ToString());
        }

        public static bool IsComposite_Fermat(string value)
        {
            return IsComposite_Fermat(BigInteger.Parse(value));
        }

        public static bool IsComposite_Fermat(BigInteger value)
        /* NOTE: a ^ (n - 1) mod n = 1
         * I went with IsPrime Fermat first until i read that it also returns true on Fake Primes,
         * so now we just sieve out composite numbers, idea is to make the PrimeCheck faster by using this first.
         */
        {
            return BigInteger.ModPow(2, value - 1, value) != 1; 
        }
        #endregion

        #region Miller-Rabin
        public static bool IsComposite_MillerRabin(int value, int iterations = 20)
        {
            return IsComposite_MillerRabin(value.ToString(), iterations); 
        }

        public static bool IsComposite_MillerRabin(string value, int iterations = 20)
        {
            return IsComposite_MillerRabin(BigInteger.Parse(value), iterations);
        }

        public static bool IsComposite_MillerRabin(BigInteger value, int iterations = 20)
        {
            //TODO: Biginteger as byte array conversion
            for (int i = 0; i < iterations; i++)
            {

            }
            throw new NotImplementedException();
        }
        public static bool IsComposite_Witness(int value, int witness)
        {
            return IsComposite_Witness(value.ToString(), witness.ToString());
        }
        public static bool IsComposite_Witness(string value, string witness)
        {
            return IsComposite_Witness(BigInteger.Parse(value), BigInteger.Parse(witness));
        }
        public static bool IsComposite_Witness(BigInteger value, BigInteger witness)
        {
            try
            {
                return ModPow_withCeckForWitness(value, value - 1, witness) != 1;
            }
            catch(Exception) 
            {
                return true;
            }
        }

        private static BigInteger ModPow_withCeckForWitness(BigInteger value, BigInteger exponent, BigInteger modulus)
        {
            if (exponent == 0) return 1;
            if (exponent % 2 == 1) return modulus * ModPow_withCeckForWitness(value, exponent - 1, modulus) % value;
            else
            {
                BigInteger x, q;
                x = ModPow_withCeckForWitness(value, BigInteger.Divide(exponent, 2), modulus);
                q = BigInteger.ModPow(x, 2, value);
                /* Note: Looks a bit sketchy since i transferred it from a python code example
                 * 
                 * *****python code:
                 * if q == 1 :
                 *      assert x == 1 or x == value - 1
                 * return q
                 * *****
                 */
                if ((q == 1 && x == 1) || (q == 1 && x == value - 1))
                {
                    return q;
                }
                else
                {
                    throw new Exception($"ModPow2 found witness for value being composite: {x}");
                }
            }
        }
        #endregion
    }
}
