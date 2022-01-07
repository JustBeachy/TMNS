using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {
    LineRenderer line;
    Vector3 playerPos;
    float timer = 0;
    public float time = 1;
    public GameObject bullet;
    
	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        line.SetPosition(0, transform.position);
        
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,playerPos-transform.position,out hit)) //cast a ray to detect a collision
        {
            if (hit.collider)
            {
                line.SetPosition(1, hit.point); //draw laser to point of hit

                if (hit.collider.gameObject.tag == "Player")//only shoot if hoved over the player for a certain amount of time
                {
                    timer += Time.deltaTime;
                    if (timer > time)
                    {
                        timer = 0;
                        GameObject createWeapon = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                        Physics.IgnoreCollision(createWeapon.GetComponent<Collider>(), GetComponent<Collider>());
                    }
                }
                else
                    timer = 0;

                
            }
            else
            {
                line.SetPosition(1, playerPos);//draw laser to player

               

            }
            
        }
	}
}
