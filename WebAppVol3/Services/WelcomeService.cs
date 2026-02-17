namespace WebAppVol3.Services;

public class WelcomeService : IWelcomeService
{
  Date_Time _serviceCreated;
  Guid _serviceId;
  public WelcomeService()
  {
    _serviceCreated = new Date_Time();
    _serviceId = Guid.NewGuid();
  }
  public string GetWelcomeMessage()
  {
    return $"Welcome! This service was created at {_serviceCreated} and has ID {_serviceId}";
  }
};

internal class Date_Time
{
  public override string ToString()
  {
    return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
  }
}

public interface IWelcomeService
{
  string GetWelcomeMessage();
}