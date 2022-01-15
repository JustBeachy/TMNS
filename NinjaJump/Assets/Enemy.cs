using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public GameObject deadDog;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Weapon"|| collision.gameObject.tag == "EnemyWeapon")//next level
        {
            
            GameObject[] endLv = null;
            endLv = GameObject.FindGameObjectsWithTag("Enemy");
            if (endLv.Length <= 1)
            {

                GetComponent<Animator>().SetBool("isDead", true);
                GetComponent<AudioSource>().Play();
                
               
            }

            
        }
    }

    public void killDog()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ItemList.currentItem = 0;
    }

   
}
