using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
	private GameObject allets;
	private GameObject twinAllets;
	private GameObject s;
	private GameObject f;
	private Text finScore;
    public AudioSource audio;
    public bool started;

    // Use this for initialization
    void Start()
    {
		twinAllets = GameObject.Find ("Allets");
		f = GameObject.Find ("FinalScore");
		finScore = f.GetComponent<Text> ();
		f.SetActive (false);
		allets = GameObject.Find("AlletsGameOver");
		s = GameObject.FindWithTag("Score");
		allets.SetActive (false);
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            if (!started)
            {
                started = true;
                StartCoroutine("wait");
            }
        }
        
    }

    IEnumerator wait()
    {
		twinAllets.SetActive (false);
		f.SetActive (true);
		finScore.text = s.GetComponent<Score> ().score.ToString ("D6");
		allets.SetActive (true);
		GameObject.Find ("New Arrows").SetActive (false);
		s.SetActive (false);
		GameObject.Find ("Health").SetActive (false);
		GameObject.Find ("Health (1)").SetActive (false);
        yield return new WaitForSeconds(5F);
        SceneManager.LoadSceneAsync("Second Menu");
    }

	public void vidStop()
	{
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Pause();
		audio.Stop ();
	}
}
