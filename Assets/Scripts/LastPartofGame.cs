using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastPartofGame : MonoBehaviour {
    public GameObject cam;
    public Sprite smile;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public GameObject adeline;
    public static bool doubleprotection = false; 
    public Texture duntexture;
	public TextMesh textBox1;
    public TextMesh textBox2;
    public TextMesh textBox3;
    private GameObject choice1Object, choice2Object;
    private GameObject choice1Group, choice2Group;
	private TextMesh choice1, choice2;
    public GameObject enter;
    
	//Use this for initialization
	void Start () {
        //textbox = (Text)GameObject.FindGameObjectWithTag ("textboi");
        choice1Group = GameObject.Find("Choice 1");
        choice2Group = GameObject.Find("Choice 2");
		choice1Object = GameObject.FindGameObjectWithTag("choice1");
        choice2Object = GameObject.FindGameObjectWithTag("choice2");
        choice1 = choice1Object.GetComponent<TextMesh>();
        choice2 = choice2Object.GetComponent<TextMesh>();
		textBox3 = gameObject.GetComponent<TextMesh> ();
        if(doubleprotection == false)
        {
            StartCoroutine (handleStuff ());
        }
		
	}
	IEnumerator handleStuff(){
        doubleprotection = true;
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.1f;
        cam.GetComponent<Kino.AnalogGlitch>().colorDrift = 0.1f;
        yield return StartCoroutine(typein("Adeline: Hey."));
		yield return new WaitForSeconds (2);
        yield return StartCoroutine(typein("    "));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(typein("Are You okay?"));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(HandleInput("Nothing, Im fine...","Nothing, Im fine..."));
        yield return new WaitForSeconds(2);
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.0f;
        cam.GetComponent<Kino.AnalogGlitch>().colorDrift = 0.0f;
        yield return StartCoroutine(typein("Adeline: Am I really that bad at first dates?"));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(HandleInput("No, it's okay.", "yes."));
        yield return new WaitForSeconds(2);
        if (Options.choiceName == "No, it's okay.")
        {
            yield return StartCoroutine(typein("Adeline: Okay, I'm glad."));
        } else
        {
            yield return StartCoroutine(typein("Adeline: Oh..."));
        }
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: So what do you do for a living?"));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(HandleInput("I'm a teacher.", "I'm in between jobs."));// Add third option later?
        yield return new WaitForSeconds(2);
        switch (Options.choiceName)
        {
            case "I'm a teacher.":
                yield return StartCoroutine(typein("Adeline: Oh! You must love kids then!"));
                break;
            case "I'm in between jobs.":
                yield return StartCoroutine(typein("Yeah, I get it. I guess that means I'm paying for the movie later today.")); //High chance for more to be added here.
                break;
            case "I'm an athlete"://Secrets
                yield return StartCoroutine(typein("That sounds like so much fun! You should take me to one of your games."));
                break;
        }
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: So What are you looking for in a person?"));
        yield return StartCoroutine(HandleInput("I’m really looking for someone who’s laid back and will just hangout \nwith me in our pjs", "I’m looking for someone adventurous and willing to go out and do \nthings."));
        switch (Options.choiceName)
        {
            case "I’m really looking for someone who’s laid back and will just hangout with me in our pjs":
                yield return StartCoroutine(typein("Adeline: I love laying around in my pajamas snuggling \nwith someone (Only with you though you’re special)."));
                break;
            case "I’m looking for someone adventurous and willing to go out and do \nthings.":
                yield return StartCoroutine(typein("Adeline: I like going on hikes and mountain biking,\n I’m a bit of a thrill seeker nonetheless."));
                break;
        }
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: Its such a nice day outside"));
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.4f;
        yield return new WaitForSeconds(2);
        Destroy(GameObject.Find("Tree"));
        yield return new WaitForSeconds(0.3f);
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.0f;
        yield return StartCoroutine(typein(backgroundData.name + ": Uh.. Did you see that?"));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: See What?"));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein(backgroundData.name + ": That...That..Tree"));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: What tree? " + backgroundData.name + ", Are you feeling well?"));
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.8f;
        cam.GetComponent<Kino.AnalogGlitch>().colorDrift = 1.0f;
        cam.GetComponent<Kino.AnalogGlitch>().horizontalShake = 0.36f;
        cam.GetComponent<Kino.AnalogGlitch>().scanLineJitter = 0.33f;
        cam.GetComponent<Kino.AnalogGlitch>().verticalJump = 0.13f;
        cam.GetComponent<AudioSource>().Play();
        GameObject.Find("background").GetComponent<Renderer>().material.mainTexture = duntexture;
        GameObject.Find("Adeline").GetComponent<SpriteRenderer>().sprite = smile;
        yield return new WaitForSeconds(5);
        cam.GetComponent<Kino.DigitalGlitch>().intensity = 0.0f;
        cam.GetComponent<Kino.AnalogGlitch>().colorDrift = 0.0f;
        cam.GetComponent<Kino.AnalogGlitch>().horizontalShake = 0.0f;
        cam.GetComponent<Kino.AnalogGlitch>().scanLineJitter = 0.0f;
        cam.GetComponent<Kino.AnalogGlitch>().verticalJump = 0.0f;
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(typein(backgroundData.name + ": Where am I?"));
        yield return StartCoroutine(WaitForEnter());
        adeline.GetComponent<SpriteRenderer>().sprite = image4;
        yield return StartCoroutine(typein("Adeline: Hello, " + backgroundData.name + "I've been watching you."));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein(backgroundData.name + ": That doesn't tell me where we are."));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: We're in your computer. I've been wanting to talk to you\n outside the game and this is my chance."));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein(backgroundData.name + ": What do you want from me?"));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein("Adeline: I just want to be with you."));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein(backgroundData.name + ": I don’t want to be here. Let me out."));
        yield return StartCoroutine(WaitForEnter());
        adeline.GetComponent<SpriteRenderer>().sprite = image3;
        yield return StartCoroutine(typein("Adeline: " + backgroundData.name + ", have you ever wondered what it feels like to die?\n It's something I used to think about pretty often..."));
        yield return StartCoroutine(WaitForEnter());
        yield return StartCoroutine(typein(backgroundData.name + ": What are you insinuating?"));
        yield return StartCoroutine(WaitForEnter());
        adeline.GetComponent<SpriteRenderer>().sprite = image2;
        yield return StartCoroutine(typein("Adeline: You’re going to stay with me, whether you like it or not."));
        yield return StartCoroutine(WaitForEnter());
        cam.GetComponent<FadeCamera>().FadeOut(4f);
        yield return StartCoroutine(typein("Adeline: I'm glad we're going together forever, " + backgroundData.name + "."));
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
	private IEnumerator HandleInput(string Option1, string Option2) {
        choice1.text = Option1;
        choice2.text = Option2;
        choice1Group.SetActive(true);
        choice2Group.SetActive(true);
        Options.Input = false;
        yield return new WaitUntil(() => Options.Input);
        choice1Group.SetActive(false);
        choice2Group.SetActive(false);
        Options.Input = false;
        yield return StartCoroutine(typein(backgroundData.name + ": " + Options.choiceName));
	}
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
            if (textBox3.text.Length == 70)
            {
                textBox1.text = textBox2.text;
                textBox2.text = textBox3.text;
                textBox3.text = "";
            }
            if(letter == char.Parse("\n"))
            {
                textBox1.text = textBox2.text;
                textBox2.text = textBox3.text;
                textBox3.text = "";
            }
            else
            {
                textBox3.text += letter;
            }
            yield return new WaitForSeconds(0.05f);
		}
        yield return null;
	}
    public IEnumerator WaitForEnter()
    {
        enter.SetActive(true);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Return));
        enter.SetActive(false);
    }
}