using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {
    public BoxCollider boxCollision;
    public static bool Input;
    public static string choiceName = ""; 
    void OnMouseUp()
    {
       if(!(Input)) {
            Input = true;
            choiceName = GameObject.Find("Text" + gameObject.name.Replace(" ","")).GetComponent<TextMesh>().text;
            Debug.Log("Game Object is " + choiceName);
        }
    }
}
