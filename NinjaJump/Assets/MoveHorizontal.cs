using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour {
    private Vector3 startPos;
    public float dir = 1;
    public float speed = .03f;
    public bool horizontal = true;
    public float timer=1;
    private float ctime=0;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(horizontal)
        {
            
            transform.position += new Vector3(speed*dir, 0, 0)*Time.deltaTime;
            
        }
        else//vertical platform
        {
            transform.position += new Vector3(0, speed*dir, 0)*Time.deltaTime;
            
        }

        ctime+=Time.deltaTime;
        if (ctime>timer)
        {
            ctime = 0;
            dir *= -1f;
        }
	}

}
