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
    public GameObject potion;
    public TextMeshProUGUI textBox;
    public GameObject Title;
    public GameObject Settings;
    public float timer;
    public bool timing;
    [TextArea(2,5)]
    public string[] bossSetup;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
        timing = false;
        Cursor.SetCursor(inActiveCursor,hotspot, cursorMode);
        Debug.Log(SavedVariables.potion);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SavedVariables.potion){
            Instantiate(potion, new Vector3(0,-.13f,-3f), Quaternion.identity);
            Color color = GameObject.Find("potion").GetComponent<MeshRenderer>().material.color ;
            color.a -= Time.deltaTime * .01f;
            this.GetComponent<MeshRenderer>().material.color = color ;
        }
        if(timing){
            timer -= Time.deltaTime;
            if(timer <= 0){
                GameOver();
                timing = false;
            }
        }
    }
    
    void changeText(string newTxt)
    {
        Debug.Log(newTxt);
        textBox.GetComponent<TextMeshProUGUI>().text = newTxt;
    }
    public void painting(){
        Debug.Log("clicked on painting");
        portait.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,-30, 0));
        portait.GetComponent<Rigidbody2D>().gravityScale = 40;
        Debug.Log(portait.GetComponent<Rigidbody2D>().gravityScale);
        changeText("Boss: HOW DARE YOU KNOW DOWN MY PAINTING! yOUR'RE FIRED!!!");
        timing = true;
    }

    public void GameOver(){
        Debug.Log("game over");
        Instantiate(gameOverPainting, new Vector3(0,0,-2f), Quaternion.identity);
    }

    public void mug(){
        Debug.Log("clicking on the mug, written by Jason as was painting");
        Instantiate(coffee, new Vector3(0,0,-2f), Quaternion.identity);
        changeText("Boss: Thank you so much, if your dog hadn't nocked over my coffee I would've made the seconf worst mistake in my life. The first one would have been firing you. :) ");
    }

    public void face(){
        Debug.Log("Clicked on the bosses face, you know the painting");
        Instantiate(shhBoss, new Vector3(0, 0, -2f), Quaternion.identity);
        changeText("You: Shhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh DON'T FIRE HIM hhhhhhhhhhhhhhhhhhhhhhhhhhhh");
    }

    public void umbrella(){
        Debug.Log("umbrella dog");
        changeText("Owner: Hey how about you relieve some stress that you clearly have, as you're in the middle of laying off a valueable worker, by checking out some pictures of my dog with an umbrella!");
        Instantiate(umbrellaDog, new Vector3(0, 0, -2f), Quaternion.identity);
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
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
