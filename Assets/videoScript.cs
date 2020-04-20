using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoScript : MonoBehaviour
{
    public float timer;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10.0f;
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <=0){
            canvas.SetActive(true);

        } else {
            timer -= Time.deltaTime;
        }
        
    }
}
