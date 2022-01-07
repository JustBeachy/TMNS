using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDown : MonoBehaviour {
    public float timer = 1;
    float ctime = 0;
    public float delay = 0;
    bool retracted = false;
    public Vector3 retractDir;
    Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        ctime = delay;
	}
	
	// Update is called once per frame
	void Update () {
        ctime+=Time.deltaTime;
        if(ctime>timer)
        {
            ctime = 0;
            

            if (!retracted)
                gameObject.transform.position += retractDir;
            else
                gameObject.transform.position = startPos;

            retracted = !retracted;
        }
	}
}
