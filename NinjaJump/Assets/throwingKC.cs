using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class throwingKC : MonoBehaviour
{
    public GameObject player;
    public Vector2 mousePosition;
    float ang = 0;
    public bool isMoving = true;
    float direction = 0;
    public Rigidbody2D rb;
    private Vector2 AimVector;
    public int speed = 10;
    public Texture icon;
    public PhysicMaterial isBouncy;
    public bool icy = false;
    public GameObject friedAcorn;
    public bool onStartScreen = false;
    public bool placedOnLevel = false;




    // Use this for initialization
    void Start()
    {
        player= GameObject.Find("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        rb = GetComponent<Rigidbody2D>();
        if (!onStartScreen)
        {
            if (!placedOnLevel)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                //direction = Mathf.Atan2(transform.position.y - mousePosition.y, transform.position.x - mousePosition.x) * Mathf.Rad2Deg;
                AimVector = mousePosition - new Vector2(transform.position.x, transform.position.y);
                AimVector.Normalize();
                AimVector.x *= speed;
                AimVector.y *= speed;
                rb.velocity = new Vector2(AimVector.x, AimVector.y); //* Time.deltaTime*140;
            }
        }
        else
            rb.velocity = new Vector2(4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
       
       // if (isMoving) //angle/rotation
       // {
            //transform.position = Vector2.MoveTowards(transform.position, mousePosition, .5f);



            //transform.rotation = Quaternion.AngleAxis(ang+90, Vector3.up);
            //ang++;
       // }



        //transform.rotation = Quaternion.AngleAxis(direction, Vector3.forward);

        if (isMoving)
        {
            transform.right = rb.velocity+new Vector2(0,0);//angle in direction of flight
            

        }
       // else
          //  rb.velocity = new Vector3(0, 0, 0);

        //gameObject.transform.forward =Vector3.Slerp(gameObject.transform.forward, rb.velocity.normalized, Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       
        

            //if (other.gameObject.tag == "Bounce") //if hitting a bouncy surface
            
               // gameObject.GetComponent<Collider>().material = isBouncy;
            
            if (other.gameObject.tag == "EnemyWeapon")
            {
                Destroy(gameObject);
            }
            else
            {
            GetComponent<AudioSource>().Play();
            // gameObject.GetComponent<Collider>().material = null;

                rb.velocity=new Vector2(0,0);
                rb.freezeRotation = true;
                rb.isKinematic = true;
                if(other.gameObject.tag!="Key") //fixes bug with acorn falling flat from a target hit, resulting in player clipping ground
                isMoving = false;
               
                if(other.transform.childCount>0) //rotate or move with object
                transform.parent = other.transform.GetChild(0).transform;

                if (other.gameObject.tag == "PaperWall")
                    transform.parent = other.transform;

                if (other.gameObject.tag == "Icy")
                    icy = true;


            }
        
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="LaserB")
        {
            Instantiate(friedAcorn, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}