using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public Texture2D activeCursor;
    public Texture2D inActiveCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    public GameObject umbrellaDog;
    public GameObject shhBoss;
    public GameObject coffee;
    public GameObject portait;
    public GameObject gameOverPainting;
    public GameObject Godog;
    public GameObject potion;
    public TextMeshProUGUI textBox;
    public GameObject Title;
    public GameObject Settings;
    public GameObject Mug;
    public GameObject Face;
    public GameObject God;
    public GameObject Umbrella;
    public GameObject canvas;
    public GameObject video;
    public float timer;
    public bool timing;
    public float secTimer;
    public bool secTiming;
    public bool once;
    [TextArea(2,5)]
    public string[] bossSetup;
    int x=0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
        timing = false;
        secTimer = 2f;
        secTiming = false;
        once = true;
        Cursor.SetCursor(inActiveCursor,hotspot, cursorMode);
        Debug.Log(SavedVariables.potion);
        changeText(bossSetup[x]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            x++;
            changeText(bossSetup[x]);
        }
        if(SavedVariables.gameover){
            foreach (GameObject buton in GameObject.FindGameObjectsWithTag("Btn") ){
                buton.SetActive(false);
            }
        }
        string c_Scene = SceneManager.GetActiveScene().name;
        if(c_Scene == "LevelSelect"){
            
            if(SavedVariables.mug){
                Mug.SetActive(true);
            }
            if(SavedVariables.face){
                Face.SetActive(true);
            }
            if(SavedVariables.god){
                God.SetActive(true);
            }
            if(SavedVariables.umbrella){
                Umbrella.SetActive(true);
            }

        }

        if(SavedVariables.gameover && Input.GetKeyDown(KeyCode.Space)){
            // Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("LevelSelect");
        }
        
        if(SavedVariables.potion && !secTiming){
            Instantiate(potion, new Vector3(0,-.13f,-3f), Quaternion.identity);
            secTiming = true;
        }
        if(timing){
            timer -= Time.deltaTime;
            if(timer <= 0){
                GameOver();
                timing = false;
            }
        }
        if(secTiming && once){
            Debug.Log("check one");
            secTimer -= Time.deltaTime;
            if(secTimer<=0){
                Debug.Log("check two");
                Instantiate(Godog, new Vector3(0, 0, -2f), Quaternion.identity);
                Destroy(GameObject.Find("Potion(Clone)"));
                changeText("Boss: There is no greater joy in this life than the relation between human and dog. Join us in holy Wallis Annenberg Petspace...");
                once = false;
                SavedVariables.god = true;
                SavedVariables.gameover = true;
            }
        }
    }
    
    void changeText(string newTxt)
    {
        Debug.Log(newTxt);
        if(!SavedVariables.translate){
            int newNumber = Random.Range(2,20);
            string woof = "Woof ";
            for(int i=0; i<newNumber; i++){
                //meant to make a random number of woofs appear in the textbox
                woof = woof+"woof ";
            }
            textBox.GetComponent<TextMeshProUGUI>().text = woof;
        } else {
            textBox.GetComponent<TextMeshProUGUI>().text = newTxt;
        }
    }
    public void painting(){
        Debug.Log("clicked on painting");
        portait.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,-30, 0));
        portait.GetComponent<Rigidbody2D>().gravityScale = 40;
        Debug.Log(portait.GetComponent<Rigidbody2D>().gravityScale);
        changeText("Boss: HOW DARE YOU KNOW DOWN MY PAINTING! YOUR'RE FIRED!!! \n You: Too bad, push SPACE to try again!");
        timing = true;
    }

    public void GameOver(){
        Debug.Log("game over");
        Instantiate(gameOverPainting, new Vector3(0,0,-2f), Quaternion.identity);
        // Debug.Log(GameObject.FindGameObjectsWithTag("Btn"));
        // GameObject.FindGameObjectsWithTag("Btn").SetActive(false);
        foreach (GameObject buton in GameObject.FindGameObjectsWithTag("Btn") ){
            buton.SetActive(false);
        }
        SavedVariables.gameover =true;
    }

    public void restart(){
        SavedVariables.gameover = false;
        SavedVariables.potion = false;
    }

    public void mug(){
        Debug.Log("clicking on the mug, written by Jason as was painting");
        Instantiate(coffee, new Vector3(0,0,-2f), Quaternion.identity);
        changeText("Boss: Thank you so much, if your dog hadn't knocked over my coffee it would have me on the floor. Damn, that near death experience is making me rethink this whole scnenario. You know what, you're not fired. You're getting a promotion!");
        SavedVariables.mug = true;
        SavedVariables.gameover = true;
    }

    public void face(){
        Debug.Log("Clicked on the bosses face, you know the painting");
        Instantiate(shhBoss, new Vector3(0, 0, -2f), Quaternion.identity);
        changeText("You: Shhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh DON'T FIRE HIM hhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        SavedVariables.face = true;
        SavedVariables.gameover = true;
    }

    public void umbrella(){
        Debug.Log("umbrella dog");
        changeText("Owner: Hey how about you relieve some stress that you clearly have, as you're in the middle of laying off a valueable worker, by checking out some pictures of my dog with an umbrella!");
        Instantiate(umbrellaDog, new Vector3(0, 0, -2f), Quaternion.identity);
        SavedVariables.umbrella = true;
        SavedVariables.gameover = true;
    }
    
    public void facts(){
        Debug.Log("fact about how humans and dogs help each other");
        changeText("FACT: Dogs provide people with companionship to fight stress, and people provide dogs with unlimited happiness (like when you come home from school or work, just like at your dogs tail go!)!");
    }

    public void settingPage(){
        if(Title.activeInHierarchy){
            Title.SetActive(false);
            Settings.SetActive(true);
        } else {
            Title.SetActive(true);
            Settings.SetActive(false);
        }
    }

    public void translate(){
        if(SavedVariables.translate){
            SavedVariables.translate = false;
        } else {
            SavedVariables.translate = true;
        }
    }

    public void changeScene(){
        var scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.buildIndex + "'.");
        // if(scene.buildIndex == 1){
        //     canvas.SetActive(false);
        //     video.GetComponent<VideoPlayer>.Play();
        // }
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
