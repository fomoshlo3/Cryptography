using Crypto.Lib;
using System.Numerics;

int exp = 67;
BigInteger P1 = 139;
BigInteger P2 = 113;
//string encryptedText = string.Empty;

Console.WriteLine("Gib den zu verschlüsselnden Text ein:");
string input = Console.ReadLine().TrimEnd('\r');
BigInteger[] encryptedText = new BigInteger[input.Length];
if (input != string.Empty && input != null)
{
    Console.WriteLine("Entschlüsselter Text:");
    foreach (char c in input)
    {
        BigInteger hashedValue = BigInteger.Pow(c, exp) % (P1 * P2);
        encryptedText[input.IndexOf(c)] = hashedValue;
        Console.Write(encryptedText[input.IndexOf(c)] + " ");
    }
}
else
{
    Console.WriteLine("That's not a valid input");
}

Console.WriteLine("Gib den zu entschlüsselnden Text ein");
string encoded = Console.ReadLine();
string[] encryptedValues = encoded.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int dexp = 3691;
string decryptedText = string.Empty;

foreach (string encryptedValue in encryptedValues)
{
    BigInteger i = BigInteger.Parse(encryptedValue);
    BigInteger decryptedValue = BigInteger.ModPow(i, dexp, P1 * P2);
    char decryptedChar = (char)decryptedValue;
    decryptedText += decryptedChar.ToString();

}

Console.WriteLine(decryptedText);


Console.WriteLine("Please give the first Part of the Public Key(N or Product of Primes):");


int N = Int32.Parse(Console.ReadLine());
Prime primes = new(N);
var list =  primes.Generate();

Dictionary<BigInteger, BigInteger> PrimeFactorPairsProducingPublicNumber = new();

foreach (var prime in list)
{
    BigInteger remainder;
    var factor = BigInteger.DivRem(N,prime, out remainder);
    if (prime > 3  && factor > 3 && remainder == 0) PrimeFactorPairsProducingPublicNumber.Add(prime,factor);
}



Console.ReadKey();