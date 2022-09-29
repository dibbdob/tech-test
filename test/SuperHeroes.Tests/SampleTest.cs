namespace SuperHeroes.Tests
{
    using System.Threading.Tasks;
    using Characters;
    using Shouldly;
    using Xunit;

    public class SampleTest
    {
        [Fact]
        public void CanFightWhenCharacterTypesAreDifferent()
        {
            // Arrange
            Character batman = new Character("Batman", 1.0, CharacterType.Hero);
            Character joker = new Character("Joker", 2.3, CharacterType.Villain);

            // Act
            var validCharacterTypes = Battle.ValidCharacterTypes(batman, joker);

            // Assert
            validCharacterTypes.ShouldBeTrue();
        }

        [Fact]
        public void CannotFightWhenCharacterTypesAreSame()
        {
            // Arrange
            Character batman = new Character("Batman", 1.0, CharacterType.Villain);
            Character joker = new Character("Joker", 2.3, CharacterType.Villain);

            // Act
            var validCharacterTypes = Battle.ValidCharacterTypes(batman, joker);

            // Assert
            validCharacterTypes.ShouldBeFalse();
        }

        [Fact]
        public void CharacterWithHighestScoreWins()
        {
            // Arrange
            Character batman = new Character("Batman", 1.0, CharacterType.Hero);
            Character joker = new Character("Joker", 2.3, CharacterType.Villain);

            // Act
            var winner = Battle.GetWinner(batman, joker);

            // Assert
            winner.ShouldMatch("Joker");
        }

        [Fact]
        public async void FightOutcomeIndicatesWinnerName()
        {
            // Arrange
            var battle = new Battle(new MockFileCharacterLoader());

            // Act
            var winner = await battle.Fight("Batman", "Lex Luther");

            // Assert
            winner.ShouldMatch("Lex Luther");
        }

        [Fact]
        public async void CharacterLoaderReturnsExpectedCountOfCharacters()
        {
            // Arrange
            var loader =  new MockFileCharacterLoader();

            // Act
            var count = (await loader.RetrieveCharacters()).Count();

            // Assert
            count.ShouldBe(2);
        }
    }
}
