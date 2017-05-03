using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TestDown: MonoBehaviour
{
	private bool hasNote = false;
	private GameObject lastNote, un, dn, ln, rn;
	private GameObject temp_note;
	private List<GameObject> notes = new List<GameObject>();
	private SpriteRenderer sr;
	private float timer = 10f;
	private float o = 0.125f;
	private readonly float FLASH_DUR = 0.4f;
	public bool createMode;
	public GameObject n;

	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		print(sr.color);
	}

	// Update is called once per frame
	void Update()
	{
		if (createMode)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				Instantiate(n,gameObject.transform.position,Quaternion.identity);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
			{
				StopCoroutine (pressed ());
				StartCoroutine (pressed ());
				if (hasNote)
				{
					StartCoroutine(destructoList());
					timer = 0f;
				}
			}
		}
	}


	private void OnTriggerEnter2D(Collider2D o)
	{
		hasNote = true;
		lastNote = o.gameObject;
		notes.Add (lastNote);
	}

	private void OnTriggerExit2D(Collider2D o)
	{
		hasNote = false;
		notes.Remove (o.gameObject);
		notes.TrimExcess ();
	}

	public IEnumerator pressed()
	{
		Color old = sr.color;
		sr.color = new Color(1,1,1);
		yield return new WaitForSeconds (0.1f);
		sr.color = old;
		StopCoroutine (pressed ());
	}
		
	public IEnumerator destructoList()
	{
		for (int i = 0; i < notes.Capacity; i++) {
			temp_note = notes [i];
			Destroy (temp_note);
			notes.Remove (temp_note);
		}
		yield return new WaitForSeconds (0.1f);
	}
}
