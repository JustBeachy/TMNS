using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour {
    public bool GlassVsKnife = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player"&&!GlassVsKnife)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Weapon"&&GlassVsKnife)
        {
            Destroy(this.gameObject);
        }
    }
}
