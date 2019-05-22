using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPartofGame : MonoBehaviour {
	public TextMesh textBox1;
    public TextMesh textBox2;
    public TextMesh textBox3;
	private TextMesh choice1;
	private TextMesh choice2;
	private GameObject box1;
	private GameObject box2;
	//Use this for initialization
	void Start () {
		//textbox = (Text)GameObject.FindGameObjectWithTag ("textboi");
		choice1 = GameObject.FindGameObjectWithTag("choice1").GetComponent<TextMesh>();
        choice2 = GameObject.FindGameObjectWithTag("choice2").GetComponent<TextMesh>();
		box1 = GameObject.Find ("Choice 1");
		box2 = GameObject.Find ("Choice 2");
		textBox3 = GetComponent<TextMesh> ();
		StartCoroutine (handleStuff ());
	}
	IEnumerator handleStuff(){
		StartCoroutine(typein("Adeline: What’s bothering you?"));
		yield return new WaitForSeconds (2);
        StartCoroutine(typein("Adeline: Am I really that bad at first dates?"));
        yield return new WaitForSeconds(2);
        StartCoroutine(typein("Adeline: Okay, i’m glad."));
        yield return new WaitForSeconds(2);
        StartCoroutine(typein("Adeline: So, what do you do for a living?"));
        yield return new WaitForSeconds(2);
        Debug.Log("done");
		//rewrite for buttons
	}
	//IEnumerator handleInput() {
		//while (Input == false) {
		//	
		//	yield return new WaitForSeconds (0.6f);
		//}
	//}
	public IEnumerator typein(string data) {
        if(textBox1.text != "" && textBox2.text != "" && textBox3.text != "")
        {
            textBox1.text = textBox2.text;
            textBox2.text = textBox3.text;
            textBox3.text = "";
        } else if(textBox3.text != "" && textBox2.text == "" && textBox1.text == "")
        {
            textBox2.text = textBox3.text;
            textBox3.text = "";
        } else if(textBox2.text != "" && textBox3.text != "" && textBox1.text == "")
        {
            textBox1.text = textBox2.text;
            textBox2.text = textBox3.text;
            textBox3.text = "";
        }
		foreach(char letter in data) {
			textBox3.text += letter;
            yield return new WaitForSeconds(0.025f);
		}
        yield return null;
	}
	public IEnumerator choice() {
        box1.SetActive(true);
        box2.SetActive(true);
        yield return null;
	}
    //public IEnumerator SwapText(string text)
    //{
    //    textBox1.text = textBox2.text;
    //    textBox2.text = textBox3.text;
    //    textBox3.text = "";
    //    StartCoroutine(typein(text));
    //    yield return null;
    //}
}