
using Crypto.Lib;
using System.Numerics;

Console.WriteLine("Gib dein N:");
string input = Console.ReadLine();
RSALogic foo = new();
var bar = foo.Factorize_Slow_TrivialsIncluded(input);
foreach (var item in bar)
{
    Console.WriteLine(item.ToString());
}
foo.Exp_PubKey = 1021;


Console.ReadKey();