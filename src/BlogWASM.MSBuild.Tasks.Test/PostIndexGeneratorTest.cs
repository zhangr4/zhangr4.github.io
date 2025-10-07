using Microsoft.Build.Framework;
using Moq;

namespace BlogWASM.MSBuild.Tasks.Test;

public class PostIndexGeneratorTest
{
    private readonly Mock<IBuildEngine> buildEngine;
    private readonly List<BuildMessageEventArgs> messages = [];
    private readonly List<BuildErrorEventArgs> errors = [];
    private readonly ITestOutputHelper testOutput;

    public PostIndexGeneratorTest(ITestOutputHelper testOutput)
    {
        this.testOutput = testOutput;
        buildEngine = new Mock<IBuildEngine>();
        buildEngine
            .Setup(x => x.LogMessageEvent(It.IsAny<BuildMessageEventArgs>()))
            .Callback<BuildMessageEventArgs>(msg => messages.Add(msg));
        buildEngine
            .Setup(x => x.LogErrorEvent(It.IsAny<BuildErrorEventArgs>()))
            .Callback<BuildErrorEventArgs>(msg => errors.Add(msg));
    }

    [Fact]
    public void Execute_OK()
    {
        // Arrange
        var item = new Mock<ITaskItem>();
        var generator = new PostIndexGenerator
        {
            PostsDirectory = "Posts",
            BuildEngine = buildEngine.Object,
        };

        // Act
        var result = generator.Execute();

        // Assert
        foreach (var msg in messages)
        {
            testOutput.WriteLine($"[{msg.Importance}] {msg.Message}");
        }
        foreach (var err in errors)
        {
            testOutput.WriteLine($"[ERROR] {err.Message}");
        }
        Assert.True(result);
    }
}
