using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAnimation()
    {
        Destroy(gameObject);
    }
}
