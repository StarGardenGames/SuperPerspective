﻿using UnityEngine;
using System.Collections;

public class Checkpoint : ActiveInteractable {

	public int id;
	public bool triggered = false;	
	
	public override void Triggered(){
		CheckpointManager.instance.showMenu(id);
	}
	
}
