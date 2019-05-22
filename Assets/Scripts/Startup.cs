using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startup : MonoBehaviour {
    public string objectName;
    public GameObject Camera;
    public Button play, exit;
    void Awake() {
        objectName = gameObject.name;
        Camera = GameObject.Find("MenuCamera");
        Debug.Log("objectName is " + objectName);
    }
    void Start()
    {
    }
	// Use this for initialization
	void listenerCall () {
        if(objectName.Equals("New Game"))
        {
            Debug.Log("Hey Load Scene...");
            SceneManager.LoadScene(1);
        } else if(objectName.Equals("Exit"))
        {
            Application.Quit();
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
[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    Text txt;
    Color baseColor;
    Button btn;
    bool interactableDelay;

    void Start()
    {
        txt = GetComponentInChildren<Text>();
        baseColor = txt.color;
        btn = gameObject.GetComponent<Button>();
        interactableDelay = btn.interactable;
    }

    void Update()
    {
        if (btn.interactable != interactableDelay)
        {
            if (btn.interactable)
            {
                txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
            }
            else
            {
                txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
            }
        }
        interactableDelay = btn.interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.pressedColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

}
