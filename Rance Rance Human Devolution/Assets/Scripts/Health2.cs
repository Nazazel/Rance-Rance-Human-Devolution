using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour
{
	private GameObject allets;
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
		//allets = GameObject.Find("AlletsGameOver");
		//allets.SetActive (false);
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
		if (playerHealth < 0 && !started) 
		{
			started = true;
			left.SendMessage ("death");
			right.SendMessage ("death");
			up.SendMessage ("death");
			down.SendMessage ("death");
			StopAllCoroutines ();
			StartCoroutine ("endLevel");
		}
	}

	public IEnumerator endLevel()
	{
		//allets.SetActive (true);
		yield return new WaitForSeconds (4.0f);
		SceneManager.LoadSceneAsync ("Game Over");
	}
}
