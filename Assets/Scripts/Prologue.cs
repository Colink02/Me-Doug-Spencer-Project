using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour {
    static string SelectedOption;
    public TextMesh text;
    private Animator textAnimator;
    private bool waitingForKeyEvents = true;
	private bool next = false;
	private List<Vector3> textPos = new List<Vector3>() {new Vector3(-5.57f, 9.70f,24.27f), new Vector3(-5.60f, 9.70f, 22.60f)};
	private List<string> prologueText = new List<string> () {
		"We’re going on a picnic,\nand afterwards,\n we’re going to see a horror movie. ",
		"Sadly, I have to leave my Dog, Dakota."
	};
	// Use this for initialization
	void Start () {
        TextMesh text = GetComponent<TextMesh>();
        Animator textAnimator = GetComponent<Animator>();
        Color originalColor = text.color;
        text.text = "I'm pretty excited this is my first date in years,\nMy date's name is Adeline; \nWe met on Cupid.com.";
		StartCoroutine (MainLoop ());
	}
	public float fadeOutTime = 15.0f;
	private void FadeOut()
    {
        if (textAnimator != null)
        {
            textAnimator.Play("FadeOutText");
        } else
        {
            textAnimator = GetComponent<Animator>();
            textAnimator.Play("FadeOutText");
        }
        return;
    }
	private void FadeIn()
    {
        if (textAnimator != null)
        {
            textAnimator.Play("FadeInText");
        } else
        {
            textAnimator = GetComponent<Animator>();
            textAnimator.Play("FadeInText");
        }
        return;
    }
	private IEnumerator SleepDelay(int delay) {
		yield return new WaitForSeconds(delay);
		next = true;
	}
    private IEnumerator MainLoop()
    {
        FadeIn();
        yield return new WaitForSeconds(5);
        FadeOut();
        yield return new WaitForSeconds(1);
        int index = 0;
        foreach (string textString in prologueText)
        {
			gameObject.transform.position = textPos[index]; 
            text.text = textString;
            FadeIn();
            yield return new WaitForSeconds(1);
            /*if (text.text == prologueText[1])
            {
                //Typewrite?
                while(!(Input.GetKeyDown(KeyCode.Escape))) {
					StartCoroutine(Keys());
                    yield return new WaitForSeconds(0.1f);
                }
                waitingForKeyEvents = false;
                if (option == 0)
                {
                //    SelectedOption = "Dog";
                //} else if(option == 1)
                //{
                //    SelectedOption = "Cat";
                //}
            }*/
			if (textString == prologueText [1])
				FadeOut ();
				yield return new WaitForSeconds (5);
				SceneManager.LoadScene ("Park_Scene",LoadSceneMode.Additive);
            yield return new WaitForSeconds(5);
            FadeOut();
            yield return new WaitForSeconds(1);
            index++;
        }
    }
    /*IEnumerator Keys ()
    {
		while (waitingForKeyEvents)
        {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    StartCoroutine(handleSwitch());
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    StartCoroutine(handleSwitch());
                }
            yield return null;
        }
    }
    void DeleteUntil(string TextToReach)
    {
        while(text.text != TextToReach) {
			text.text = text.text.Substring(0,text.text.Length-1);
        }
        return;
    }
    IEnumerator handleSwitch()
    {
		if (option == 1)
        {
            DeleteUntil("Sadly, I have to leave my ");
			foreach (char letter in dogWord)
            {
				text.text = text.text.ToString() + letter.ToString();
                yield return new WaitForSeconds(0.125f);
            }
            option = 0;
        }
        else
        {
            DeleteUntil("Sadly, I have to leave my ");
			foreach (char letter in catWord)
            {
				text.text = text.text.ToString() + letter.ToString();
				Debug.Log ("Text is now..." + text.text);
                yield return new WaitForSeconds(0.125f);
            }
            option = 1;
        }
    }*/
}
