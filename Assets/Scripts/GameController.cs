﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    // Use this for initialization
    void Start () {
        
    }
	
	
}
