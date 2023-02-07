using Demo1;
namespace Demo1.UnitTest;

public class SongTests
{
    [Fact]
    public void CanCreateASong()
    {
        var song = new Song("Fire it up", "Modest Mouse");

        Assert.Equal("Fire it up", song.Title);
        Assert.Equal("Modest Mouse", song.Artist);
    }
}

