using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credsAnim : MonoBehaviour {
    public GameObject LogoCaption;
    public Animator textAnimator;
    public GameObject cam;
    public void exit()
    {
        GetComponent<AudioSource>().Play();
        FadeIn();
        StartCoroutine(restart());
    }
    private void FadeIn()
    {
        if (textAnimator != null)
        {
            textAnimator.Play("FadeInCaption");
        }
        else
        {
            textAnimator = GetComponent<Animator>();
            textAnimator.Play("FadeInCaption");
        }
        return;
    }
    private IEnumerator restart()
    {
        yield return new WaitForSeconds(5f);
        cam.GetComponent<FadeCamera>().FadeOut(3f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
