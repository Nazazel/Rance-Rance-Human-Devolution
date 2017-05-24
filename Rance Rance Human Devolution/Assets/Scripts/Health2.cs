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
		playerHealth = 10;
	}

	public void esfd() {
		if (playerHealth > 0) {
			playerHealth--;
		}
	}

	public void addHealth(int hpGain)
	{
		playerHealth += hpGain;
		if (playerHealth > 10) playerHealth = 10;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerHealth <= 10) {
			bar.fillAmount = playerHealth * 0.1f;
		}
		if (playerHealth == 0 && !started) 
		{
			started = true;
			StopAllCoroutines ();

		}
	}
}
