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

            throw new NotImplementedException();
        }
    }
}