using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class backgroundData : MonoBehaviour {
	
	private int maxPerLine = 90;
	public static TextMesh backgroundText;
	public float random;
    private bool blinkOk = true;
	private float blinkRandom;
	private SpriteRenderer adeline;
    private int blinkCooldown = 0;
	public Sprite blink;
	public Sprite smile;
	public int lines;
    public string name;
	void Awake() {
		backgroundText = gameObject.GetComponent<TextMesh> ();
		adeline = (SpriteRenderer)GameObject.Find("adeline").GetComponent<SpriteRenderer>();
        name = System.Environment.UserName;
		Debug.Log ("Hi " + name);
	}
	void Update () {
		random = Random.Range(1,4);
		if (backgroundText.text.Length <= maxPerLine * 20) {
			if (random >= 1 && random < 2 ) { 
				backgroundText.text += "0";
			} else {
				backgroundText.text += "1";
			}
		}
		lines = backgroundText.text.Split ("\n".ToCharArray ()).Length;
		if (backgroundText.text.Length >= (maxPerLine * lines)) {
			backgroundText.text += "\n";
		}
		if (lines == 14) {
            //backgroundText.text = "";
            int index = backgroundText.text.IndexOf(System.Environment.NewLine);
            string newText = backgroundText.text.Substring(index + System.Environment.NewLine.Length);
            backgroundText.text = newText;
            lines = 13;
        }
		blinkRandom = Random.Range (0, 400);
		if ((blinkCooldown >= 0) && (blinkRandom == 28) && blinkOk)
        {
            StartCoroutine(revert());
        }
        if(blinkCooldown > 0)
        {
            blinkCooldown -= (int) Mathf.Ceil(Time.deltaTime);
        }
	}
	IEnumerator revert() {
        blinkOk = false;
        blinkCooldown += 15;
        yield return new WaitForSeconds(1);
        adeline.sprite = blink;
        yield return new WaitForSeconds (0.2f);
		adeline.sprite = smile;
        blinkOk = true;
	}
}
