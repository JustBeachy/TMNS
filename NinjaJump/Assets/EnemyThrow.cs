using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour {

    Rigidbody rb;
    Vector2 AimVector;
    public int speed=6;
	// Use this for initialization
	void Start () {
        

        rb = GetComponent<Rigidbody>();
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        AimVector = playerPos - new Vector2(transform.position.x, transform.position.y);
        AimVector.Normalize();
        AimVector.x *= speed;
        AimVector.y *= speed;
        rb.velocity = new Vector3(AimVector.x, AimVector.y, 0)*Time.deltaTime*140;
    }
	
	// Update is called once per frame
	void Update () {
        transform.up = rb.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    }
