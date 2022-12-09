namespace sendgrid_poc;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var client = new SendgridWrapper();
        var sendMail = await client.SendMail();
        Assert.True(sendMail.IsSuccessStatusCode);
    }
}