using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemList.items.Length - ItemList.currentItem <= 0)
            GetComponent<Animator>().speed = 1;
    }

    public void ButtonClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
