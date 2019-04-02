﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkDiscovery : NetworkDiscovery
{
    private readonly List<BroadcastListener> m_Listeners = new List<BroadcastListener>();

    public void Register(BroadcastListener o)
    {
        m_Listeners.Add(o);
    }

    private void OnEnable()
    {
        Initialize();
        hasRecievedBroadcast = false;
        StartAsClient();
    }

    private bool hasRecievedBroadcast = false;

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        if (hasRecievedBroadcast) return;
        hasRecievedBroadcast = true;

        foreach (var listener in m_Listeners)
        {
            listener.OnReceivedBroadcast(fromAddress, data);
        }

        gameObject.SetActive(false);
    }
}

public interface BroadcastListener
{
    void OnReceivedBroadcast(string fromAddress, string data);
}