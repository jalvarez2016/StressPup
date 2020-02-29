using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CommuneScript : MonoBehaviour
{
    

    public Vector3 paintingPos;
    public Vector3 BossDoor;
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
    public bool magic;
    // Start is called before the first frame update
    void Start()
    {
        //use this position to teleport player to balcony when they interact with the glassdoors
        balconySpawn = new Vector3(-2.04f, -25.47f, -2);
        paintingPos = GameObject.Find("Painting").transform.position;
        BossDoor = GameObject.Find("Door").transform.position;
        Employees = GameObject.FindGameObjectsWithTag("Employee").ToList();
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        crtDialogue.Add(0);
        talking = false;
        magic = false;
    }

    // Update is called once per frame
    void Update()
    {    
        Vector3 playerpos = GameObject.Find("Person").transform.position;
        for(int i = 0; i< Employees.Count; i++){
            if(playerpos.x >= Employees[i].transform.position.x -2 && playerpos.x <= Employees[i].transform.position.x + 2 && playerpos.y > -10){
                if(i==0){
                    changeText(emply4Dialogue[crtDialogue[2]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[2]+1 < 3){
                        crtDialogue[2]++;
                    }
                } else if(i==1 && magic)
                {
                    changeText(emply3Dialogue[crtDialogue[3]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[3]+1 < 3){
                        crtDialogue[3]++;
                        if(crtDialogue[3] >= 2){
                            SavedVariables.potion = true;
                            Debug.Log(SavedVariables.potion);
                        }
                    }
                } else if(i==2)
                {
                    changeText(emply2Dialogue[crtDialogue[1]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[1]+1 < 2){
                        crtDialogue[1]++;
                    }
                } else if(i==3)
                {
                    changeText(emply1Dialogue[crtDialogue[0]]);
                    if(Input.GetKeyDown(KeyCode.Space) && crtDialogue[0]+1 < 5){
                        crtDialogue[0]++;
                    }
                }
            } else 
            {
                if(crtDialogue[4]+1 < 7 && playerpos.y < -10){            
                    Debug.Log(crtDialogue[4]);
                    changeText(dogFacts[crtDialogue[4]]);
                    if(Input.GetKeyDown(KeyCode.Space) && !talking){
                        crtDialogue[4]+=1;
                        talking = true;
                    }
                    if(Input.GetKeyUp(KeyCode.Space)){
                        talking = false;
                    }
                } 
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
        } else if(GameObject.Find("Person").transform.position.x > BossDoor.x +4 && GameObject.Find("Person").transform.position.x < BossDoor.x+7)
        {
            changeText("Press Space to go to Boss Room");
            if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("Boos Door");
                SceneManager.LoadScene("Office Scene");
            }
        } else if(GameObject.Find("Magic Dog Muffin") && playerpos.x > GameObject.Find("Magic Dog Muffin").transform.position.x){
            changeText("Press Space to Eat the Magic Dog Muffin");
            if(Input.GetKeyDown(KeyCode.Space)){
                Destroy(GameObject.Find("Magic Dog Muffin"));
                magic = true;
            }
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
