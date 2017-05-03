using System.Collections;
using UnityEngine;

public class TestRight: MonoBehaviour
{
	private bool hasNote = false;
	private GameObject lastNote, un, dn, ln, rn;
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
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				Instantiate(n,gameObject.transform.position,Quaternion.identity);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				StartCoroutine (pressed ());
				if (hasNote)
				{
					Destroy(lastNote);
					timer = 0f;
				}
			}

		}
	}


	private void OnTriggerEnter2D(Collider2D o)
	{
		hasNote = true;
		lastNote = o.gameObject;
	}

	private void OnTriggerExit2D(Collider2D o)
	{
		hasNote = false;
	}

	public IEnumerator pressed()
	{
		Color old = sr.color;
		sr.color = new Color(1,1,1);
		yield return new WaitForSeconds (0.1f);
		sr.color = old;
	}
}
