using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemList : MonoBehaviour {
    public GameObject[] FillGameObjects;
    public static GameObject[] items;
    public Texture UI;
    public static int currentItem = 0;
    public Material material;
    // Use this for initialization
    private void Awake()
    {
        items = FillGameObjects;//assign to static list
        currentItem = 0;
    }
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
      

        items = FillGameObjects;


       

    
    }

 

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hazard"|| other.gameObject.tag == "EnemyWeapon")
        {
            currentItem = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
