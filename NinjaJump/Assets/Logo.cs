using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public GameObject pressToStart;
    bool canStart=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canStart)
            NextLevel();
        
    }

    public void PlayerTeleportIntro()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Throw>().TeleportToAcorn();
    }

    public void EnablePressToStart()
    {
        pressToStart.SetActive(true);
        canStart = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ItemList.currentItem = 0;
    }

    public void PlayMusic()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
