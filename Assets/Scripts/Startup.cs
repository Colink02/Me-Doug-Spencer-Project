using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour {
    public string objectName;
    public GameObject Camera;
    void Awake() {
        objectName = gameObject.name;
        Camera = GameObject.Find("MenuCamera");
        Debug.Log("objectName is " + objectName);
    }
	// Use this for initialization
	void OnMouseUp () {
        if(objectName.Equals("Play"))
        {
            Debug.Log("Hey Load Scene...");
            SceneManager.LoadScene(1);
        } else if(objectName.Equals("Settings"))
        {
            Camera.transform.Rotate(new Vector3(0, 180, 0)); 
        } else if(objectName.Equals("SavedFiles"))
        {

        }
	}
    void OnMouseEnter () {
        gameObject.GetComponent<TextMesh>().color = Color.red;
    }
    void OnMouseExit () {
        gameObject.GetComponent<TextMesh>().color = Color.white;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
