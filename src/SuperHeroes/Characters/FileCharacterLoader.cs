namespace SuperHeroes.Characters
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    internal class FileCharacterLoader : ICharacterLoader
    {
        public Task<IEnumerable<Character>> RetrieveCharacters()
        {
            using var file = File.OpenRead("./characters.json");

            var result = JsonSerializer.Deserialize<IEnumerable<Character>>(file, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            });
            
            return Task.FromResult(result);
        }
    }
}