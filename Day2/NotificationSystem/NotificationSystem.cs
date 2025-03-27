#region Notification System
public class NotificationSystem
{
    private INotification _notification;
    private ISourceChannel _source;

    public NotificationSystem(INotification notification, ISourceChannel source)
    {
        _notification = notification;
        _source = source;
    }

    public void Notify()
    {
        if (_source != null)
        {
            string message = _source.GetMessage();
            _notification.Send(message);
        }
    }
}

#endregion

#region Notification Implementation
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        if (message.Length > 160)
        {
            message = message.Substring(0, 160); // Truncate message to fit SMS limit
        }
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}
#endregion

#region Source Channel
public interface ISourceChannel
{
    string GetMessage();
}

public class Email : ISourceChannel
{
    public string GetMessage()
    {
        return "<html><body><h1>Email Notification</h1></body></html>";
    }
}

public class SMS : ISourceChannel
{
    public string GetMessage()
    {
        return "SMS Notification: Short and precise!";
    }
}

public class PushNotificationSource : ISourceChannel
{
    public string GetMessage()
    {
        return "Push Notification: Quick Alert!";
    }
}
#endregion