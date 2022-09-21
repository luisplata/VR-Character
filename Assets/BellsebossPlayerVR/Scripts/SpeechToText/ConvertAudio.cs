using System;
using System.IO;

public class ConvertAudio : IConvertAudio
{
    private readonly ISpeechToText _speechToTextService;

    public ConvertAudio(ISpeechToText speechToTextService)
    {
        _speechToTextService = speechToTextService;
    }

    public string ConvertAudioToBase64(string filepath)
    {
        var bytes = File.ReadAllBytes(filepath);
        
        var encoded = Convert.ToBase64String(bytes);
        
        return encoded;
    }
}