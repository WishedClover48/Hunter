using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    Dictionary<string, MonoBehaviour> servicesByName = new();

    public MonoBehaviour GetService(string serviceName)
    {
        return servicesByName[serviceName];
    }
    public void SetService(string serviceName, MonoBehaviour value)
    {
        servicesByName.Add(serviceName, value);
    }
}
