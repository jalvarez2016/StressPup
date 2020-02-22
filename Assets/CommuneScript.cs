using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<GameObject> Employees;
    public List<int> crtDialogue;
    public bool talking;
    // Start is called before the first frame update
    void Start()
    {
        //use this position to teleport player to balcony when they interact with the glassdoors
        balconySpawn = new Vector3(-2.04f, -25.47f, -2);
        paintingPos = GameObject.Find("Painting").transform.position;
        changeText(dogFacts[0]);
        Employees = GameObject.FindGameObjectsWithTag("Employee").ToList();
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        talking = false;
    }

    // Update is called once per frame
    void Update()
    {    
        for(int i = 0; i< Employees.Count; i++){
            Vector3 playerpos = GameObject.Find("Person").transform.position;
            if(playerpos.x >= Employees[i].transform.position.x -2 && playerpos.x <= Employees[i].transform.position.x + 2){
                if(i==0){
                    changeText(emply4Dialogue[crtDialogue[2]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[2]+1 < 3 && playerpos.y> -20){
                        crtDialogue[2]++;
                    }
                } else if(i==1)
                {
                    changeText(emply3Dialogue[crtDialogue[3]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[3]+1 < 3 && playerpos.y> -10){
                        crtDialogue[3]++;
                    }
                } else if(i==2)
                {
                    changeText(emply2Dialogue[crtDialogue[1]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[1]+1 < 2 && playerpos.y> -10){
                        crtDialogue[1]++;
                    }
                } else if(i==3)
                {
                    changeText(emply1Dialogue[crtDialogue[0]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[0]+1 < 5 && playerpos.y> -10){
                        crtDialogue[0]++;
                    }
                }
            } else 
            {
                talking = true;
            } 
        }

        if(GameObject.Find("Person").transform.position.x > (GameObject.Find("Glassdoors").transform.position.x - 6) && GameObject.Find("Person").transform.position.y > -20)
        {
            changeText("Press E to go outside");
            if(Input.GetKeyDown(KeyCode.E)){
                teleport(balconySpawn);
            }
        } else if(GameObject.Find("Person").transform.position.x < (GameObject.Find("Glassdoors (1)").transform.position.x + 10) && GameObject.Find("Person").transform.position.y < -20) 
        {
            changeText("Press E to go inside");
            if(Input.GetKeyDown(KeyCode.E)){
                GameObject.Find("Painting").transform.position = paintingPos;
                Vector3 insideLoc = GameObject.Find("Glassdoors").transform.position;
                insideLoc.z = -2;
                teleport(insideLoc);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[4]+1 < 6 && talking){
            Debug.Log(crtDialogue[4]);
            changeText(dogFacts[crtDialogue[4]]);
            crtDialogue[4]+=1;
        } 
        // else {
        //     Debug.Log(crtDialogue[4]);
        //     crtDialogue[4] = 0;
        // }
    }

    void changeText(string newTxt)
    {
        Debug.Log(newTxt);
        textBox.GetComponent<TextMeshProUGUI>().text = newTxt;
    }

    void teleport(Vector3 newPos)
    {
        Debug.Log("teleporting");
        GameObject.Find("Person").transform.position = newPos;
        Debug.Log(GameObject.Find("Person").transform.position.z);
    }

}
