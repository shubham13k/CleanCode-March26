namespace TemplateEngine.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Jelly", "Bean")]
    [TestCase("John", "Doe")]
    [TestCase("Jane", "Doe")]
    public void TemplateEngineFirstAndLastNameGenerationTest(string firstName, string lastName)
    {
        var templateEngine = new TemplateEngine();

        templateEngine.SetTemplate("Hello, firstName lastName");
        templateEngine.SetVariable("firstName", firstName);
        templateEngine.SetVariable("lastName", lastName);
        var result = templateEngine.EvaluateTemplate();

        Assert.That($"Hello, {firstName} {lastName}", Is.EqualTo(result));
    }
}