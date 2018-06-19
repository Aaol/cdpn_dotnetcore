using Prolog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Prolog.Parser
{
    public class RuleParser
    {
        private char[] FactSplitRules { get; set; }
        public RuleParser() : this(new char[] {'(',',',')'})
        {
            
        }
        public RuleParser(char[] factSplitRules)
        {
            this.FactSplitRules = factSplitRules;
        }
        public void AddRule()
        {
            string pattern = @"(&)|(->)";
            string input = Console.ReadLine();
            List<Fact> facts = new List<Fact>();
            (Regex.Split(input,pattern)).Where(temp => !Regex.IsMatch(temp,pattern))
            .ToList().ForEach(factToParse => facts.Add(this.ParseFact(factToParse)));
            facts.ForEach(fact => fact.Arguments.ToList().ForEach(arg => Console.WriteLine(arg.Name)));
        }

        private Fact ParseFact(string s)
        {
            System.Console.WriteLine(s);
            string[] splitted = s.Split(this.FactSplitRules);
            Fact fact = new Fact();
            fact.Name = splitted[0];
            for (int i = 1; i < splitted.Length; i++)
            {
                fact.Arguments.Add( new Atom() {
                    Rank = i + 1,
                    Name = splitted[i] 
                });
            } 
            return fact;
        }

    }
}