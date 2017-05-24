using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour
{
	private GameObject failure;
	private GameObject twinAllets;
	private GameObject left;
	private GameObject right;
	private GameObject up;
	private GameObject down;
	public int playerHealth;
	public Image bar;
	public bool started;

	// Use this for initialization
	void Start()
	{
		failure = GameObject.Find ("Failed");
		failure.SetActive(false);
		twinAllets = GameObject.Find ("Allets");
		left = GameObject.Find ("Left");
		right = GameObject.Find ("Right");
		up = GameObject.Find ("Up");
		down = GameObject.Find ("Down");
		bar.fillAmount = 1;
		playerHealth = 100;
	}

	public void esfd() { //Stands for Ergonomically Scintillating Floccinaucinihilipilification Disruptor
		if (playerHealth > 0) {
            playerHealth -= 9;
		}
	}

    public void esfdlite()
    { ////
        if (playerHealth > 0)
        {
            playerHealth -= 5;
        }
    }

    public void addHealth(int hpGain)
	{
		playerHealth += hpGain;
		if (playerHealth > 100) playerHealth = 100;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerHealth <= 100) {
			bar.fillAmount = playerHealth * 0.01f;
		}
		if (playerHealth <= 0 && !started) 
		{
			started = true;
			left.SendMessage ("death");
			right.SendMessage ("death");
			up.SendMessage ("death");
			down.SendMessage ("death");
			StopAllCoroutines ();
			GameObject.Find ("VideoPlane").SendMessage ("vidStop");
			StartCoroutine ("endLevel");
		}
	}

	public IEnumerator endLevel()
	{
		twinAllets.SetActive (false);
		Destroy (GameObject.Find ("Notes"));
		GameObject.Find ("VideoPlane").SetActive (false);
		failure.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadSceneAsync ("Game Over");
	}
}
