﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// A PlayerUnit is a unit controlled by a player
// This could be a character in an FPS, a zergling in a RTS
// Or a scout in a TBS

public class PlayerUnit : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // This function runs on ALL PlayerUnits -- not just the ones that I own.

        // How do I verify that I am allowed to mess around with this object?
        if (hasAuthority == false)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        { this.transform.Translate(0, 1, 0); }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        { this.transform.Translate(0, -1, 0); }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        { this.transform.Translate(1, 0, 0); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        { this.transform.Translate(-1, 0, 0); }

    }
}