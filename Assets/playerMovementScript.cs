using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    public bool hasJumped;
    public Vector3 leftMovement;
    public Vector3 rightMovement;
    public Vector3 jumpForce;
    private Vector3 balconySpawn;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("OfficeBackground") || other.gameObject.name.Contains("Painting"))
        {
            Debug.Log("hitting floor");
                hasJumped= true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //use this position to teleport player to balcony when they interact with the glassdoors
        balconySpawn = new Vector3(-2.04f, -25.47f, -2);
        hasJumped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == -1){
            GetComponent<Rigidbody2D>().AddForce(leftMovement);
        } else if(Input.GetAxisRaw("Horizontal") == 1){
            GetComponent<Rigidbody2D>().AddForce(rightMovement);
        }
        if(Input.GetKeyDown(KeyCode.W) && hasJumped){
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            hasJumped= false;
        }
    }
}