using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording;

	// Use this for initialization
	void Start () {
        recording = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1") )
        {
            recording = false;
        }
        else
        {
            recording = true;
        }
	}
}
