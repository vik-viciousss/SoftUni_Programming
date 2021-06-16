using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = CreateHero(heroName, heroType);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossHealth = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossHealth -= hero.Power;
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
