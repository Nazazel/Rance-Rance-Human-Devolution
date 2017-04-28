using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public bool started = false;
    public Text theText;

    // Use this for initialization
    void Start()
    {

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
        yield return new WaitForSeconds(3.0f);
		GameObject.Find ("Audio Source").GetComponent<AudioSource> ().Play ();
        theText.text = "Project Leads:\n\nNazely  Hartoonian\n\nUlises Perez";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Artist:\n\nVictoria Barinova";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Programmers:\n\nUlises Perez\n\nYixuan (Angela) Li\n\nChristopher Dipalma";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Audio/Video Gathering:\n\nNazely  Hartoonian";
        yield return new WaitForSeconds(3.0f);
        theText.text = "Design:\n\nUlises Perez\n\n Nazely  Hartoonian";
        yield return new WaitForSeconds(3.0f);
        theText.text = " ";
        //StartCoroutine(AudioFadeOut.FadeOut(GameObject.Find("Music").GetComponent<AudioSource>(), 2.5f));
        //yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Menu");
    }
}