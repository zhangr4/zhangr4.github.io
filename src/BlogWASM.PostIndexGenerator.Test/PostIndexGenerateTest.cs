namespace BlogWASM.PostIndexGenerator.Test;

public class PostIndexGenerateTest
{
    [Fact]
    public void Execute_OK()
    {
        var generator = new PostIndexGenerate()
        {
            PostsDirectory = "Posts",
        };

        var result = generator.Execute();
        Assert.True(result);

        
    }
}
