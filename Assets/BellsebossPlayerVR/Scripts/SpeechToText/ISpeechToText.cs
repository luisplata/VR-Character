using System.Collections.Generic;

public interface ISpeechToText
{
    List<string> GetDeviceToCanRecorder();
    void StartRecording(string deviceSelected);
    void StopRecording(bool autoPlay = false);
    bool IsAvailableRequest();
    string Result { get; }
}