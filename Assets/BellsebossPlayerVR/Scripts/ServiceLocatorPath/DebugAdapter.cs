using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugAdapter : MonoBehaviour, IDebug
{
    [SerializeField] private TextMeshProUGUI textUi;
    private Queue<string> log;

    private void Awake()
    {
        log = new Queue<string>(5);
    }

    public void Log(string text)
    {
        Debug.Log(text);
        log.Enqueue(text);
        if (log.Count > 5)
        {
            log.Dequeue();
        }

        textUi.text = "";
        
        foreach (var l in log)
        {
            textUi.text += $"{l}\n";
        }
    }
}