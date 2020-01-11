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
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(inActiveCursor,hotspot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.mousePosition);
    }

    public void painting(){
        Debug.Log("clicked on painting");
    }

    public void mug(){
        Debug.Log("clicking on the mug, written by Jason as was painting");
    }

    public void face(){
        Debug.Log("Clicked on the bosses face, you know the painting");
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
