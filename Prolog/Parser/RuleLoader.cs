using Microsoft.EntityFrameworkCore;
using Prolog.Context;
using System.Linq;
namespace Prolog.Parser
{
    public class RuleLoader
    {
        public void GetFacts()
        {
            using (var context = new PrologContext())
            {
                System.Console.WriteLine(context.Facts
                .Include(fact => fact.ArgumentPositions)
                .ThenInclude(arg => arg.Argument)
                .ToList()
                .Select(fact => fact.ToString()).First());
            }
        }
        public void GetRules()
        {
            using (var context = new PrologContext())
            {
                var test = context.Facts.Include(fact => fact.Rule);
                foreach (var item in context.Rules
                .Include(rule => rule.Response)
                .ThenInclude(rule  => rule.ArgumentPositions)
                .ThenInclude(arg => arg.Argument)
                .Include(rule => rule.Facts)
                .ThenInclude(arg => arg.ArgumentPositions)
                .ThenInclude(arg => arg.Argument)
                .ToList()
                .Select(rule => rule.ToString()))
                {
                    System.Console.WriteLine(item);
                } 
            }
        }
    }
}