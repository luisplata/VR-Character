using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

public class ConsumerApiGoogle : IConsumerApiGoogle
{
    private readonly ISpeechToText _speechToTextService;
    private string _result;
    private bool _isAvailable;
    
    public bool IsAvailable => _isAvailable;
    public string Result => _result;

    public ConsumerApiGoogle(ISpeechToText speechToTextService)
    {
        _speechToTextService = speechToTextService;
    }

    public async Task SpeechToText(string key, string audioBuffer)
    {
	    _isAvailable = false;
	    WebRequest request = WebRequest.Create($"https://speech.googleapis.com/v1/speech:recognize?key={key}");
	    request.Method = "POST";
	    string postData = JsonUtility.ToJson(new SpeechToText()
	    {
		    audio = new Audio()
		    {
			    content = audioBuffer
		    },
		    config = new Config()
		    {
			    encoding = "ENCODING_UNSPECIFIED",
			    languageCode = "en-US"
		    }
	    });
	    var byteArray = Encoding.UTF8.GetBytes(postData);
	    Debug.Log(">>>>>>>>>>>>A");
	    request.ContentType = "application/json";
	    request.ContentLength = byteArray.Length;
	    var dataStream = await request.GetRequestStreamAsync();
	    Debug.Log(">>>>>>>>>>>>B");
	    await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
	    Debug.Log(">>>>>>>>>>>>C");
	    dataStream.Close();
	    var response = await request.GetResponseAsync();
	    Debug.Log(">>>>>>>>>>>>D");
	    await using (dataStream = response.GetResponseStream())
	    {
		    Assert.IsNotNull(dataStream);
		    Debug.Log(">>>>>>>>>>>>E");
		    // Open the stream using a StreamReader for easy access.
		    var reader = new StreamReader(dataStream);
		    // Read the content.
		    var responseFromServer = await reader.ReadToEndAsync();
		    Debug.Log(">>>>>>>>>>>>F");
		    // Display the content.
		    Debug.Log(responseFromServer);
		    try
		    {
			    var convertFromGoogle = JsonUtility.FromJson<ResponseGoogle>(responseFromServer);
			    _result = convertFromGoogle.results[0].alternatives[0].transcript;
			    _isAvailable = true;
		    }
		    catch (Exception e)
		    {
			    Debug.Log(e.Message);
		    }
	    }
	    Debug.Log(">>>>>>>>>>>>G");
	    response.Close();
    }
}