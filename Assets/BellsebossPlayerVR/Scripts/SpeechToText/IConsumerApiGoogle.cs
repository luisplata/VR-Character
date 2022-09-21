using System.Threading.Tasks;

public interface IConsumerApiGoogle
{
    Task SpeechToText(string key, string audioInBase64);
    bool IsAvailable { get; }
    string Result { get; }
}