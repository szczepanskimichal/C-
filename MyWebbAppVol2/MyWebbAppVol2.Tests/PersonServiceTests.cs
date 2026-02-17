using Xunit;
using Moq;
using MyWebbAppVol2;

public class Consumer
{
  private readonly IPersonService _personService;
  public Consumer(IPersonService personService)
  {
    _personService = personService;
  }
  public string GetName() => _personService.GetPersonName();
}

public class ConsumerTests
{
  [Fact]
  public void GetName_ReturnsMockedName()
  {
    var mock = new Mock<IPersonService>();
    mock.Setup(x => x.GetPersonName()).Returns("Mocked Name");

    var consumer = new Consumer(mock.Object);
    var result = consumer.GetName();

    Assert.Equal("Mocked Name", result);
  }
}
