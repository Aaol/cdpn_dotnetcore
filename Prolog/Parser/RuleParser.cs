using Prolog.Context;
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
        public RuleParser() : this(new char[] { '(', ',', ')' })
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
            (Regex.Split(input, pattern)).Where(temp => !Regex.IsMatch(temp, pattern))
            .ToList().ForEach(factToParse => facts.Add(this.ParseFact(factToParse)));
            using (var context = new PrologContext())
            {
                Rule rule = new Rule();
                facts.ForEach(fact => fact.ArgumentPositions = null);
                facts.Last().RuleResponse = rule;
                facts.Take(facts.Count - 1).ToList().ForEach(fact => fact.Rule = rule);
                context.AttachRange(facts);
                try
                {
                    context.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
        public void AddFact()
        {
            string input = Console.ReadLine();
            ParseFact(input);

        }
        private Fact ParseFact(string s)
        {
            using (PrologContext context = new PrologContext())
            {

                string[] splitted = s.Split(this.FactSplitRules);
                Fact fact = new Fact();
                fact.Name = splitted[0];
                for (int i = 1; i < splitted.Length; i++)
                {
                    string name = splitted[i];
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        Argument argument = context.Arguments.FirstOrDefault(arg => arg.Name == name);
                        if (argument == null)
                        {
                            if (!char.IsUpper(name[0]))
                            {
                                argument = new Atom()
                                {
                                    Name = name
                                };
                            }
                            else
                            {
                                argument = new Variable()
                                {
                                    Name = name
                                };
                            }
                            context.Arguments.Add(argument);
                        }
                        context.ArgumentPositions.Add(new ArgumentPosition()
                        {
                            Argument = argument,
                            Fact = fact
                        });
                    }
                }
                context.Facts.Add(fact);
                context.SaveChanges();
                return fact;
            }
        }

    }
}