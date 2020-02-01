using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public float timer;
    public bool timing;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
        timing = false;
        Cursor.SetCursor(inActiveCursor,hotspot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        if(timing){
            timer -= Time.deltaTime;
            if(timer <= 0){
                GameOver();
                timing = false;
            }
        }
        // Debug.Log(Input.mousePosition);
    }

    public void painting(){
        Debug.Log("clicked on painting");
        portait.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,-30, 0));
        portait.GetComponent<Rigidbody2D>().gravityScale = 40;
        Debug.Log(portait.GetComponent<Rigidbody2D>().gravityScale);
        timing = true;
    }

    public void GameOver(){
        Debug.Log("game over");
        Instantiate(gameOverPainting, new Vector3(0,0,-2f), Quaternion.identity);
    }

    public void mug(){
        Debug.Log("clicking on the mug, written by Jason as was painting");
        Instantiate(coffee, new Vector3(0,0,-2f), Quaternion.identity);
    }

    public void face(){
        Debug.Log("Clicked on the bosses face, you know the painting");
        Instantiate(shhBoss, new Vector3(0, 0, -2f), Quaternion.identity);
    }

    public void umbrella(){
        Debug.Log("umbrella dog");
        Instantiate(umbrellaDog, new Vector3(0, 0, -2f), Quaternion.identity);
    }
    
    public void facts(){
        Debug.Log("fact about how humans and dogs help each other");
    }

    public void changeScene(){
        var scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.buildIndex + "'.");
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
