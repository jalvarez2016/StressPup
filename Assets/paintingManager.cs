using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        GameObject.Find("GameManager").GetComponent<musicManager>().bumpFX();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
