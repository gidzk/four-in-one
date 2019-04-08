﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public Camera[] cams;

    public int CurrentCamera;
    private int m_lastCamera;

    private void Update()
    {
        if (m_lastCamera == CurrentCamera) return;
        if (CurrentCamera < 0 || CurrentCamera > 3)
            CurrentCamera = CurrentCamera % 4;
        SetCamera(CurrentCamera);
    }

    private void Awake()
    {
        var nc = FindObjectOfType(typeof(NetworkController)) as NetworkController;
        if (nc == null)
        {
            Debug.Log("No network manager");
            SetCamera(0);
            return;
        }

        Debug.Log($"Set camera {nc.NetworkId}");
        SetCamera(nc.NetworkId);
    }

    public void SetCamera(int n)
    {
        if (n < 0 || n > 3)
        {
            Debug.Log($"Bad camera index ({n})");
            return;
        }

        Debug.Log($"Set camera to {n}");

        m_lastCamera = n;
        foreach (var cam in cams)
        {
            cam.enabled = false;
        }

        cams[n].enabled = true;
    }

    public void SetCamera(Cam cam)
    {
        SetCamera((int) cam);
    }
}

public enum Cam
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}