using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allets : MonoBehaviour {

	private bool started;
	private Animator allets;
	// Use this for initialization
	void Start () {
		started = false;
		allets = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator AlletsGreat()
	{
		if (!started) {
			started = true;
			allets.Play ("Great");
			yield return new WaitForSeconds (1.5f);
			allets.Play ("Idle");
			started = false;
		}
	}

	public IEnumerator AlletsOK()
	{
		if (!started) {
			started = true;
			allets.Play ("OK");
			yield return new WaitForSeconds (1.5f);
			allets.Play ("Idle");
			started = false;
		}
	}

	public IEnumerator AlletsMiss()
	{
		if (!started) {
			started = true;
			allets.Play ("Miss");
			yield return new WaitForSeconds (1.5f);
			allets.Play ("Idle");
			started = false;
		}
	}
		
}
