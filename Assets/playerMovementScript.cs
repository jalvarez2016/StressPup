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
    public Animator Owner;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("OfficeBackground") || other.gameObject.name.Contains("Painting") || other.gameObject.name.Contains("Desk"))
        {
            Debug.Log("hitting floor");
                hasJumped= true;
                SavedVariables.jumped = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {        
        Owner = gameObject.GetComponent<Animator>();
        //use this position to teleport player to balcony when they interact with the glassdoors
        balconySpawn = new Vector3(-2.04f, -25.47f, -2);
        hasJumped = true;
        SavedVariables.jumped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == -1){
            GetComponent<Rigidbody2D>().AddForce(leftMovement);
            Owner.SetBool("Right", false);
            Owner.SetBool("Left",true);
            Owner.SetBool("Moving", true);
        } else if(Input.GetAxisRaw("Horizontal") == 1){
            GetComponent<Rigidbody2D>().AddForce(rightMovement);
            Owner.SetBool("Right",true);
            Owner.SetBool("Left", false);
            Owner.SetBool("Moving", true);
        } else {
            Owner.SetBool("Moving", false);
        }
        if(Input.GetKeyDown(KeyCode.W) && hasJumped){
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            hasJumped= false;
            SavedVariables.jumped = false;
            Owner.SetBool("Jump",true);
        } else if(Input.GetKeyUp(KeyCode.W)){
            Owner.SetBool("Jump", false);
        }
    }
}