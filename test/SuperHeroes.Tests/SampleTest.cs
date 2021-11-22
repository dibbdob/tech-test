namespace SuperHeroes.Tests
{
    using System.Threading.Tasks;
    using Characters;
    using Shouldly;
    using Xunit;

    public class SampleTest
    {
        [Fact]
        public async Task Can_Run_Tests()
        {
            "123".ShouldBe("123");
        }
    }
}