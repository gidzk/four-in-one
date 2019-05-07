﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// Simple behaviour used to spawn the player as soon as the scene is loaded
public class PlayerSpawner : MonoBehaviour
{
    private void Start()
    {
        Spawner.Instance.SpawnPlayer();
    }
}