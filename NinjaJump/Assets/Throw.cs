using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour {

    private GameObject[] search;
    // Use this for initialization
    public Rigidbody2D rb;
    public GameObject feet, poof;
    public LayerMask ground;
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        if (Physics2D.OverlapCircle(feet.transform.position, .11f, ground))
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle", true);
            gameObject.GetComponent<Animator>().SetFloat("flySpeed", 0);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle", false);
            gameObject.GetComponent<Animator>().SetFloat("flySpeed", Mathf.Abs(rb.velocity.x));
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
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)); //get mouse pos
            search = GameObject.FindGameObjectsWithTag("Weapon");//check all weapons

            if (search != null)
            {
                GameObject closest = search[0];
                foreach (GameObject g in search)//find closest knife
                {
                    if (Vector2.Distance(g.transform.position, mousePosition) < Vector2.Distance(closest.transform.position, mousePosition))
                        closest = g;
                }
                Instantiate(poof, transform);
                Instantiate(poof, transform.position,Quaternion.identity);
                transform.position = closest.transform.position; //jump to knife pos
                rb.velocity = closest.GetComponent<Rigidbody2D>().velocity;
                gameObject.transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1, 1);
                Destroy(closest);
                rb.gravityScale = 1f;

            }

        }

        if(Input.GetMouseButtonDown(0))
        {
            UseItem();
           
        }

    }

    public void UseItem()
    {
        if (ItemList.currentItem < ItemList.items.Length)
        {
            Vector3 mousePos =Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            gameObject.transform.localScale = new Vector3(Mathf.Sign(mousePos.x-transform.position.x), 1, 1);
            Instantiate(ItemList.items[ItemList.currentItem], transform.position, Quaternion.identity);
            //ItemList.items[ItemList.currentItem].GetComponent<throwingKC>().icon = ItemList.items[ItemList.currentItem].GetComponent<throwingKC>().empty;//set new icon after thrown
            ItemList.currentItem++;
            gameObject.GetComponent<Animator>().Play("aPlayerThrow");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rotator")
        {
            rb.gravityScale = 1; //cannot hang on rotating platforms
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="LaserR")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}

