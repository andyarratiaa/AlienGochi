using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnCursor : MonoBehaviour
{
    
void Start()
    {
        Cursor.visible = false;
    }
   
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
    public void MakeCursorVisible()
    {
        
    }
}