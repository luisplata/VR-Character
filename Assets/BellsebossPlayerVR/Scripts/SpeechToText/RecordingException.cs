using System;

public class RecordingException : Exception
{
    public RecordingException(string deviceToGetRecorder): base(deviceToGetRecorder){}
}