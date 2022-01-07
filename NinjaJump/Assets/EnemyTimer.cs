using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimer : MonoBehaviour {
    public GameObject weapon;
    public float timer = 120;
    float currentTime=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime+=Time.deltaTime;

        if(currentTime>timer)
        {
            
            GameObject createWeapon = Instantiate(weapon,gameObject.transform.position,Quaternion.identity);
            Physics.IgnoreCollision(createWeapon.GetComponent<Collider>(), GetComponent<Collider>());

            currentTime = 0;
        }
	}
}
