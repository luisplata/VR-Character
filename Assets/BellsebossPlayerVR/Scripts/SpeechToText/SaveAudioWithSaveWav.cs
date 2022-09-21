using System.IO;
using UnityEngine;

public class SaveAudioWithSaveWav : ISaveAudio
{
    private readonly ISpeechToText _speechToTextService;

    public SaveAudioWithSaveWav(ISpeechToText speechToTextService)
    {
        _speechToTextService = speechToTextService;
    }

    public string Save(string name, AudioClip clip)
    {
        var filepath = Path.Combine(Application.dataPath, name);
        SavWav.Save(filepath, clip);
        return filepath;
    }
}