﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateWallEvent : textEvent {

    public GreatCrystalWall wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void eventTrigger()
    {
        wall.OpenGate();
    }
}
