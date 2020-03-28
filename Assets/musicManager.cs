using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource jump;
    public AudioSource pickUp;
    public AudioSource spill;
    public AudioSource fail;
    public AudioSource hit;
    // Start is called before the first frame update
    // void Start()
    // {}

    void Update(){        
        Vector3 playerpos = GameObject.Find("Person").transform.position;
        // Debug.Log(SavedVariables.jumped);
        if(Input.GetKeyDown(KeyCode.W) && !SavedVariables.jumped){
            jumpFX();
        }
        if(Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Magic Dog Muffin") && playerpos.x > GameObject.Find("Magic Dog Muffin").transform.position.x){
            pickUpFX();
        }
    }

    public void pickUpFX(){
        pickUp.Play();
    }

    public void jumpFX(){
        jump.Play();
    }

    public void spillFX(){
        spill.Play();
    }

    public void bumpFX(){
        hit.Play();
    }

    public void failFX(){
        GameObject.Find("GameManager").GetComponent<AudioSource>().Stop();
        fail.Play();
    }
}
