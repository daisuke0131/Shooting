﻿using UnityEngine;
using System.Collections;

public class Bom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
}
