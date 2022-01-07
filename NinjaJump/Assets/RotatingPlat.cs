using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlat : MonoBehaviour {

    public int dir = 1;
    public int speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        gameObject.transform.Rotate(new Vector3(0, 0, .5f*dir *speed* Time.deltaTime));
	}
}
