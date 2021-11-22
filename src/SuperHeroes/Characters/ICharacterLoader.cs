namespace SuperHeroes.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICharacterLoader
    {
        Task<IEnumerable<Character>> RetrieveCharacters();
    }
}