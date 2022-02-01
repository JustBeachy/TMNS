using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour {

    private GameObject[] search;
    // Use this for initialization
    public Rigidbody2D rb;
    public GameObject feet, poof, clipfix;
    public LayerMask ground;
    public bool isdead=false;

    public AudioClip DeathAudio, ThrowAudio, PoofAudio;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        if (!isdead)
        {
            if (Physics2D.OverlapCircle(feet.transform.position, .13f, ground))
            {
                gameObject.GetComponent<Animator>().SetBool("isIdle", true);
                gameObject.GetComponent<Animator>().SetFloat("flySpeed", 0);

                if (Physics2D.OverlapCircle(clipfix.transform.position, .01f, ground)&&transform.position.y<-2.3f)//clip fix
                    gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + .1f);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("isIdle", false);
                gameObject.GetComponent<Animator>().SetFloat("flySpeed", Mathf.Abs(rb.velocity.x));
            }
        }
        //old way of teleporting
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10)); //get mouse pos
            search = GameObject.FindGameObjectsWithTag("Weapon");//check all weapons

            if (search.Length > 0)//if list isnt empty
            {
                for(int i = 0;i<search.Length;i++)
                {
                    if (Vector2.Distance(search[i].transform.position, mousePosition) < 2)//check if mouse is close to a weapon
                    {
                        transform.position = search[i].transform.position; //jump to knife pos
                        Destroy(search[i]);
                        rb.useGravity = true;
                        
                        // if(search[i].name=="Star(Clone)")
                        // rb.velocity = Vector3.zero; //stop in air
                        if (search[i].name == "Knife(Clone)")
                        {
                            if (search[i].GetComponent<Rigidbody>().velocity == Vector3.zero) //stall
                                rb.useGravity = false;
                            else
                                rb.velocity = search[i].GetComponent<Rigidbody>().velocity / 2;//carry over velocity from knife
                        }
                        break;
                    }
                    else
                    {
                        if (i == search.Length - 1)
                            UseItem();
                    }
                }
            }*/
        if (Input.GetMouseButtonDown(1)&&!isdead)//teleport
        {
            TeleportToAcorn();

        }

        if(Input.GetMouseButtonDown(0))
        {
            UseItem();
           
        }

    }

    public void UseItem()//throw
    {
        if ((ItemList.currentItem < ItemList.items.Length)&&!isdead)
        {
            Vector3 mousePos =Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            gameObject.transform.localScale = new Vector3(Mathf.Sign(mousePos.x-transform.position.x), 1, 1);
            Instantiate(ItemList.items[ItemList.currentItem], transform.position, Quaternion.identity);
            //ItemList.items[ItemList.currentItem].GetComponent<throwingKC>().icon = ItemList.items[ItemList.currentItem].GetComponent<throwingKC>().empty;//set new icon after thrown
            ItemList.currentItem++;
            gameObject.GetComponent<Animator>().Play("aPlayerThrow");
            GetComponent<AudioSource>().clip = ThrowAudio;
            GetComponent<AudioSource>().Play();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="LaserR")
        {
            Die();
        }
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rotator")
        {
            rb.gravityScale = 1; //cannot hang on rotating platforms
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    private void Die()
    {
        if (GetComponent<Animator>().GetBool("isDead") == false)
        {
            GetComponent<AudioSource>().clip = DeathAudio;
            GetComponent<AudioSource>().Play();
            rb.velocity = new Vector2(0, 0);
        }

        GetComponent<Animator>().SetBool("isDead", true);
        isdead = true;
        
    }

    public void TeleportToAcorn()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); //get mouse pos
        search = GameObject.FindGameObjectsWithTag("Weapon");//check all weapons

        if (search.Length > 0)
        {

            GameObject closest = search[0];
            foreach (GameObject g in search)//find closest knife
            {
                if (Vector2.Distance(g.transform.position, mousePosition) < Vector2.Distance(closest.transform.position, mousePosition))
                    closest = g;
            }
            Instantiate(poof, transform);
            Instantiate(poof, transform.position, Quaternion.identity);
            transform.position = closest.transform.position; //jump to knife pos
            rb.velocity = closest.GetComponent<Rigidbody2D>().velocity;
            gameObject.transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);
            Destroy(closest);
            rb.gravityScale = 1f;
            GetComponent<AudioSource>().clip = PoofAudio;
            GetComponent<AudioSource>().Play();

        }
    }

}

