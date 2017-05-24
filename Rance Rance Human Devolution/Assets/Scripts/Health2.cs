using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health2 : MonoBehaviour
{
	public int playerHealth;
	public Image bar;
	public bool started;

	// Use this for initialization
	void Start()
	{
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
		if (playerHealth == 0 && !started) 
		{
			started = true;
			StopAllCoroutines ();

		}
	}
}
