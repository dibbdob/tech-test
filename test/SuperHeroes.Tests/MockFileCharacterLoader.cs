namespace SuperHeroes.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using SuperHeroes.Characters;

    internal class MockFileCharacterLoader : ICharacterLoader
    {
        public Task<IEnumerable<Character>> RetrieveCharacters()
        {
            return Task.FromResult<IEnumerable<Character>>(
                new List<Character>() {
                    new Character("Batman", 1.0, CharacterType.Hero),
                    new Character("Lex Luther", 2.0, CharacterType.Villain)
                }.AsEnumerable<Character>());
         }
    }
}