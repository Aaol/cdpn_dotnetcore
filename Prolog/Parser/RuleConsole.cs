using System;
namespace Prolog.Parser
{
    class RuleConsole
    {
        private RuleParser Parser { get; set; }
        private RuleLoader RuleLoader { get; set; }
        public RuleConsole()
        {
            Parser = new RuleParser();
            RuleLoader = new RuleLoader();
        }
        public void MyMagnificientRuleConsole()
        {
            int response = 0;
            do
            {
                this.WriteMenu();
                string input = Console.ReadLine();
                if(int.TryParse(input, out response))
                {
                    switch (response)
                    {
                        case 1:
                            Parser.AddFact();
                            break;
                        case 2:
                            Parser.AddRule();
                            break;
                        case 3:
                            RuleLoader.GetFacts();
                            break;
                        default:
                            RuleLoader.GetRules();
                            break;
                    }
                }
                else
                {
                    response = 5;
                }
            } while (response != 0);
        }
        private void WriteMenu()
        {
            Console.WriteLine("Prolog");
            Console.WriteLine("------");
            Console.WriteLine("1) Ajouter un fait");
            Console.WriteLine("2) Ajouter une règle");
            Console.WriteLine("3) Lister les faits");
            Console.WriteLine("4) Lister les règles");
            Console.WriteLine("5) Réécrire le menu");
            Console.WriteLine("0) Quitter");
        }
    }
}