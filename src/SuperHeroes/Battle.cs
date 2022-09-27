namespace SuperHeroes
{
    using System;
    using System.Threading.Tasks;
    using Characters;

    public class Battle
    {
        private readonly ICharacterLoader characterLoader;

        public Battle(ICharacterLoader characterLoader)
        {
            this.characterLoader = characterLoader;
        }

        public async Task<string> Fight(string heroName, string villainName)
        {
            var characters = await this.characterLoader.RetrieveCharacters();

            // Get the characters
            Character hero = characters.Single(m => m.Name == heroName);
            Character villain = characters.Single(m => m.Name == villainName);

            // Check the types are not the same
            if (!ValidCharacterTypes(hero, villain))
            {
                throw new ApplicationException("A fight cannot take place between identical character types");
            }

            // Return the name of the winner
            return GetWinner(hero, villain);
        }

        public static bool ValidCharacterTypes(Character hero, Character villian)
        {
            return !(hero.Type == villian.Type);
        }

        public static string GetWinner(Character hero, Character villian)
        {
            return (hero.Score > villian.Score ? hero.Name : villian.Name);
        }
    }
}