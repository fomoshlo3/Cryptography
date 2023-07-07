using System.Numerics;

namespace Crypto.Lib
{
    public class RSALogic
    {
        public BigInteger Exp_PubKey { get; set; } = BigInteger.Zero;
        public BigInteger Prime_One { get; set; } = BigInteger.Zero;
        public BigInteger Prime_Two { get; set; } = BigInteger.Zero;
        public BigInteger Exp_PrivKey { get; set; } = BigInteger.Zero;
        public BigInteger Euler_Totient { get; set; } = BigInteger.Zero;

        public RSALogic() { }
        public RSALogic(string exp_pubKey, string prime_One, string prime_Two)
        {
            Exp_PubKey = BigInteger.Parse(exp_pubKey);
            Prime_One = BigInteger.Parse(prime_One);
            Prime_Two = BigInteger.Parse(prime_Two);
            Euler_Totient = (Exp_PrivKey - 1) * (Exp_PubKey - 1);
        }

        public BigInteger CalculatePrivateKeyExponent()
        {
            //todo: Exponent berechnen
            throw new NotImplementedException();
        }

        public BigInteger[] Encrypt(string value)
        {
            BigInteger[] encryptedValue = new BigInteger[value.Length];
            if (value != string.Empty)
            {
                foreach (char c in value)
                {
                    encryptedValue[value.IndexOf(c)] = BigInteger.ModPow(c, Exp_PubKey, Prime_One * Prime_Two);
                }
            }
            return encryptedValue;
        }

        public string Decrypt(string encryptedValue)
        {
            var str = encryptedValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string decryptedText = string.Empty;
            int decryptedValue = 0;

            for (int i = 0; i < str.Length; i++)
            {
                decryptedValue = (int)BigInteger.ModPow(BigInteger.Parse(str[i]), Exp_PrivKey, Prime_One * Prime_Two);
                decryptedText += (char)decryptedValue;
            }
            return decryptedText;
        }


        public Dictionary<BigInteger, BigInteger> Factorize_Slow_TrivialsIncluded(string productOfPrimes)
        {
            return Factorize_Slow_TrivialsIncluded(BigInteger.Parse(productOfPrimes));
        }
        public Dictionary<BigInteger, BigInteger> Factorize_Slow_TrivialsIncluded(int productOfPrimes)
        {
            return Factorize_Slow_TrivialsIncluded(productOfPrimes.ToString());
        }
        public Dictionary<BigInteger, BigInteger> Factorize_Slow_TrivialsIncluded(BigInteger productOfPrimes)
        {
            Prime primes = new(productOfPrimes);
            Dictionary<BigInteger, BigInteger> PrimeFactorPairsProducingPublicNumber_TrivialsIncluded = new();

            var listOfPrimes = primes.Generate();
            foreach (var prime in listOfPrimes)
            {
                BigInteger remainder;
                var factor = BigInteger.DivRem(productOfPrimes, prime, out remainder);
                if (remainder == 0) PrimeFactorPairsProducingPublicNumber_TrivialsIncluded.Add(prime, factor);
            }
            return PrimeFactorPairsProducingPublicNumber_TrivialsIncluded;
        }



    }
}




