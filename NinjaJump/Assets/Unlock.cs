using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject lockedBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)//target key
    {
        if(collision.gameObject.tag=="Weapon")
        {
            lockedBox.GetComponent<Animator>().SetBool("Unlock", true);
            GetComponent<Animator>().SetBool("Broken", true);

            GetComponent<AudioSource>().Play();

            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = .5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//key
    {
        if (collision.gameObject.tag == "Player")
        {
            lockedBox.GetComponent<Animator>().SetBool("Unlock", true);
            transform.parent.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
