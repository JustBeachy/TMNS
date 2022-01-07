using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Weapon"|| collision.gameObject.tag == "EnemyWeapon")//next level
        {
            
            GameObject[] endLv = null;
            endLv = GameObject.FindGameObjectsWithTag("Enemy");
            if (endLv.Length <= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                ItemList.currentItem = 0;
            }

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
