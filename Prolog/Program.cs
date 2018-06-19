using System;
using Prolog.Parser;

namespace Prolog
{
    class Program
    {
        static void Main(string[] args)
        {
            RuleParser parser = new RuleParser();
            parser.AddRule();
            Console.Read();
        }
    }
}
