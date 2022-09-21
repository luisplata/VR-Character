using System;
using System.Collections.Generic;

[Serializable]
public class ResponseGoogle
{
    public List<Results> results;
    public string totalBilledTime;
    public string requestId;
}