using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 500;   //NB Const is needed to define array at compile time
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];   // Define an array of keyframes
    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.recording)
        {
            Record();
        } else
        {
            PlayBack();
        }
        
    }

    private void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;  // returns index to use to handle wrapping around
        Debug.Log("Reading Frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;  // returns index to use to handle wrapping around
        Debug.Log("Writing Frame " + frame);
        keyFrames[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }
}
/// <summary>
/// A structure for storing rotation and position
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (float time, Vector3 pos, Quaternion rot)   // Constructor
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}
