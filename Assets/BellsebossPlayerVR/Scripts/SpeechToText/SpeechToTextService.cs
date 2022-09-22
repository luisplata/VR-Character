using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpeechToTextService : MonoBehaviour, ISpeechToText
{
    [SerializeField] private AudioSource source;
    [SerializeField] private int audioSampleRate = 44100;
    private List<string> devices;
    private string deviceToGetRecorder;
    private AudioClip _clip;
    private string _filepath;
    private ISaveAudio saveAudio;
    private IConvertAudio convertAudio;
    private IConsumerApiGoogle consumerApiGoogle;
    private bool _isBlocked;
    private bool _isAvailable;
    private bool _stopRecord;

    public string Result
    {
        get
        {
            if (_isBlocked) throw new RecordingException("Recording has not finished");
            return consumerApiGoogle.Result;
        }
    }

    public void StartRecording()
    {
        SetDeviceToGetRecorder(GetDeviceToCanRecorder()[0]);
    }

    private void Start()
    {
	    saveAudio = new SaveAudioWithSaveWav(this);
	    convertAudio = new ConvertAudio(this);
	    consumerApiGoogle = new ConsumerApiGoogle(this);
        _isBlocked = false;
        _stopRecord = false;
    }

    public void StartRecording(string device)
    {
        if (_isBlocked) throw new RecordingException("Recording in progress");
        _isBlocked = true;
        _isAvailable = false;
        _stopRecord = false;
	    SetDeviceToGetRecorder(device);
	    Preparing();
	    StartRecord();
    }

    public async void StopRecording(bool autoPlay = false)
    {
        if (!_isBlocked || _stopRecord) throw new RecordingException("Recording has not started");
        _stopRecord = true;
	    Stop();
        _filepath = saveAudio.Save("s", _clip);
        var key = "";//send into params for delegate
        var audioBuffer = convertAudio.ConvertAudioToBase64(_filepath + ".wav");
        await consumerApiGoogle.SpeechToText(key, audioBuffer);
	    if (autoPlay)
	    {
		    PlayRecord();
	    }
        _isBlocked = false;
        _isAvailable = true;
    }

    public List<string> GetDeviceToCanRecorder()
    {
        devices = Microphone.devices.ToList();
        return devices;
    }

    private void SetDeviceToGetRecorder(string device)
    {
        if (!devices.Contains(device))
        {
            throw new DeviceNoFoundException("device not found in devices");
        }
        deviceToGetRecorder = device;
    }

    private void Preparing()
    {
        source.Stop();
    }

    private void StartRecord()
    {
        _clip = Microphone.Start(deviceToGetRecorder, true, 15, audioSampleRate);
        Debug.Log(Microphone.IsRecording(deviceToGetRecorder).ToString());
        if (Microphone.IsRecording (deviceToGetRecorder)) {
            while (!(Microphone.GetPosition (deviceToGetRecorder) > 0)) {} 
        } else {
            throw new RecordingException(deviceToGetRecorder + " doesn't work!");
        }
    }

    private void Stop()
    {
        Microphone.End(deviceToGetRecorder);
    }

    private void PlayRecord()
    {
        source.clip = _clip;
        source.Play();
    }

    public bool IsAvailableRequest()
    {
        return _isAvailable;
    }
}