namespace CustomMetricsPOC.Interfaces;

public interface IMessageCustomMetricsPOC
{
    void SendMessage<T>(T message);
}
