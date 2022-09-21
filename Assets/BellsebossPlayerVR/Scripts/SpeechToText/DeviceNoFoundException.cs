using System;

public class DeviceNoFoundException : Exception
{
    public DeviceNoFoundException(string deviceNotFoundInDevices) : base(deviceNotFoundInDevices){}
}