using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woofScript : MonoBehaviour
{
    public GameObject woof;
    public float timer;
    public int rand; 
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!SavedVariables.translate){
            if(timer<=0){            
                woof.GetComponent<AudioSource>().Play();
                rand = Random.Range(0,1);
                if(rand == 1){
                    woof.GetComponent<AudioSource>().Play();
                }
                timer = 5f;

            } else {            
                timer -= Time.deltaTime;
            }

        }
        
    }
}
