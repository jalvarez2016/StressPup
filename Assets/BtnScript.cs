using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnScript : MonoBehaviour
{
    public GameManagerScript gm;
    
    public void MouseEnter() {
        Debug.Log("Mouse Enter");
        Cursor.SetCursor(gm.activeCursor, gm.hotspot, gm.cursorMode);
    }

    public void MouseLeave() {
        Debug.Log("Mouse Leave");
        Cursor.SetCursor(gm.inActiveCursor, gm.hotspot, gm.cursorMode);
    }
    
}
