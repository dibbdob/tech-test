namespace SuperHeroes.Tests
{
    using System.Threading.Tasks;
    using Characters;
    using Shouldly;
    using Xunit;

    public class SampleTest
    {
        [Fact]
        public void CanBattleWhenCharacterTypesAreDifferent()
        {
            // Arrange
            Character batman = new Character("Batman", 1.0, CharacterType.Hero);
            Character joker = new Character("Joker", 2.3, CharacterType.Villain);

            // Act
            var validCharactertypes = Battle.ValidCharacterTypes(batman, joker);

            // Assert
            Assert.True(validCharactertypes);
        }

        [Fact]
        public void CannotBattleWhenCharacterTypesAreSame()
        {
            // Arrange
            Character batman = new Character("Batman", 1.0, CharacterType.Villain);
            Character joker = new Character("Joker", 2.3, CharacterType.Villain);

            // Act
            var validCharactertypes = Battle.ValidCharacterTypes(batman, joker);

            // Assert
            Assert.False(validCharactertypes);
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
            Assert.Same(winner, "Joker");
        }
    }
}
