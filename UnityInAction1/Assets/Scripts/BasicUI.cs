using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,40,20),"TEST"))
        {
            Debug.Log("TESTED");
        }
    }
}
