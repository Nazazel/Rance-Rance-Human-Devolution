using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		audio = gameObject.GetComponent<AudioSource> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
