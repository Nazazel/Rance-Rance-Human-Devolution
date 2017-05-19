using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public bool started = false;
	public float fadeSpeed = 1.5f;
    public Text theText;
	public Image FadeScreen;

    // Use this for initialization
    void Start()
    {
		FadeScreen = GameObject.Find ("Fade").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine("waitThreeSeconds");
        }
    }

    IEnumerator waitThreeSeconds()
    {
		InvokeRepeating ("FadeToClear", 0.0f, 0.1f);
        yield return new WaitForSeconds(3.0f);
		GameObject.Find ("Audio Source").GetComponent<AudioSource> ().Play ();
        theText.text = "Project Leads:\n\nNazely  Hartoonian\n\nUlises Perez";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Artist:\n\nVictoria Barinova";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 70;
        theText.text = "Programmers:\n\nUlises Perez\n\nYixuan (Angela) Li\n\nChristopher Dipalma";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 80;
        theText.text = "Audio/Video Gathering:\n\nNazely  Hartoonian";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 70;
        theText.text = "Design:\n\nUlises Perez\n\n Nazely  Hartoonian\n\nYixuan (Angela) Li";
        yield return new WaitForSeconds(3.0f);
        theText.fontSize = 80;
        theText.text = " ";
        StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Audio Source").GetComponent<AudioSource>(), 2.5f));
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("NewMenu");
    }

	public void FadeToBlack()
	{
		FadeScreen.color = Color.Lerp (FadeScreen.color, Color.black, fadeSpeed * Time.deltaTime);
		if (FadeScreen.color.a == 1.0f) {
			CancelInvoke ("FadeToBlack");
		}
	}

	public void FadeToClear()
	{
		if (SceneManager.GetActiveScene ().name == "Lose") {
			GameObject.Find ("Button").GetComponent<Image> ().enabled = false;
		}
		FadeScreen.color = Color.Lerp (FadeScreen.color, Color.clear, fadeSpeed * Time.deltaTime);
		if (FadeScreen.color.a < 0.1f) {
			CancelInvoke ("FadeToClear");
			FadeScreen.color = Color.clear;
			Debug.Log (FadeScreen.color.a);
			if (SceneManager.GetActiveScene ().name == "Lose") {
				GameObject.Find ("Button").GetComponent<Image> ().enabled = true;
				DestroyImmediate (GameObject.Find ("Fade"));
				DestroyImmediate(GameObject.Find("leveltransition"));
			}
		}
	}
}