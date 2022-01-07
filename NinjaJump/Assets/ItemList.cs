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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            items = FillGameObjects;//assign to static list
            currentItem=0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
       

        if (Input.GetKeyDown(KeyCode.Backspace))
            Application.Quit();
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10 , 20, 20), UI, ScaleMode.ScaleToFit, true);
   
        GUI.Label(new Rect(0, 0, 100, 100), (items.Length - currentItem).ToString());

        /*for (int i = 0; i < items.Length; i++)
        {
            if(currentItem<=i)//only draw stuff not thrown yet
            GUI.DrawTexture(new Rect(Screen.width / 2 - 150+(125*i), Screen.height / 2 + 325, 50,25), items[i].GetComponent<throwingKC>().icon,ScaleMode.StretchToFill, true,10f);
        }*/
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
