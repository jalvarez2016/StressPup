using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommuneScript : MonoBehaviour
{
    

    public Vector3 paintingPos;
    public GameObject glassdoorsInside;
    public GameObject glassdoorsOutside;
    public TextMeshProUGUI textBox;
    private Vector3 balconySpawn;
    [TextArea(2,3)]
    public string[] emply1Dialogue;
    [TextArea(2,3)]
    public string[] emply2Dialogue;
    [TextArea(2,3)]
    public string[] emply3Dialogue;
    [TextArea(2,3)]
    public string[] emply4Dialogue;
    [TextArea(2,3)]
    public string[] dogFacts;
    // Start is called before the first frame update
    void Start()
    {
        //use this position to teleport player to balcony when they interact with the glassdoors
        balconySpawn = new Vector3(-2.04f, -25.47f, -2);
        paintingPos = GameObject.Find("Painting").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Person").transform.position.x > (GameObject.Find("Glassdoors").transform.position.x - 6) && GameObject.Find("Person").transform.position.y > -20){
            changeText("Press E to go outside");
            if(Input.GetKeyDown(KeyCode.E)){
                teleport(balconySpawn);
            }
        } else if(GameObject.Find("Person").transform.position.x < (GameObject.Find("Glassdoors (1)").transform.position.x + 10) && GameObject.Find("Person").transform.position.y < -20) {
            changeText("Press E to go inside");
            if(Input.GetKeyDown(KeyCode.E)){
                GameObject.Find("Painting").transform.position = paintingPos;
                teleport(GameObject.Find("Glassdoors").transform.position);
            }
        } else
        {
            changeText("Dog: Woof Woof Woof");
        }
    }

    void changeText(string newTxt)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = newTxt;
    }

    void teleport(Vector3 newPos)
    {
        Debug.Log("teleporting");
        GameObject.Find("Person").transform.position = newPos;
    }

}
