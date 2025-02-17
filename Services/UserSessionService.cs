namespace EventEaseApp.Services;
public class UserSessionService
{
    public string UserName { get; private set; }
    public DateTime SessionStartTime { get; private set; }
    public TimeSpan SessionDuration { get; private set; } = TimeSpan.FromMinutes(30); // Default session duration of 30 minutes
    public event Action? SessionChanged;

    public void StartSession(string userName)
    {
        UserName = userName;
        SessionStartTime = DateTime.Now;
        SessionChanged?.Invoke();
    }

    public void EndSession()
    {
        UserName = null;
        SessionStartTime = DateTime.MinValue;
        SessionChanged?.Invoke();
    }

    public bool IsSessionActive()
    {
        if (string.IsNullOrEmpty(UserName))
        {
            return false;
        }

        return DateTime.Now - SessionStartTime < SessionDuration;
    }
}