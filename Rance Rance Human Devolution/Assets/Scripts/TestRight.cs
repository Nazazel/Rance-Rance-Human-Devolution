using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TestRight: MonoBehaviour
{
	private bool hasNote = false;
	private GameObject lastNote;
	private GameObject temp_note;
	private List<GameObject> notes = new List<GameObject>();
	private SpriteRenderer sr;
	public bool createMode;
	public GameObject n, score;
//    public GameObject xn;
    public Color old;
    public string[] controller;
    public Sprite xbox_sprite;
    public Sprite key_sprite;
    private float missBound = 0.28f, okayBound = 0.2f, goodBound = 0.11f; //Values greater than a certain bound are classified as that type of hit. Ex: outside of goodBound but within okayBound is good.


    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        old = sr.color;
        print(sr.color);
    }

    // Update is called once per frame
    void Update()
	{
        controller = Input.GetJoystickNames();
		if (controller.Length > 0 && controller[0] == "Controller (Xbox One For Windows)")
        {
            sr.sprite = xbox_sprite;
        }

        else
        {
            sr.sprite = key_sprite;
        }

        if (createMode)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown("joystick button 1"))
			{
				Instantiate(n,gameObject.transform.position,Quaternion.identity);
			}

//            else if (Input.GetKeyDown("joystick button 1"))
//            {
//                Instantiate(xn, gameObject.transform.position, Quaternion.identity);
//            }
        }
		else
		{
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				StartCoroutine (pressed ());
				if (hasNote)
				{
					StartCoroutine(destructoList());
				}
			}

            else if (Input.GetKeyDown("joystick button 1"))
            {
                StartCoroutine(pressed());
                if (hasNote)
                {
                    StartCoroutine(destructoList());
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
        float absDiff = Mathf.Abs(o.gameObject.transform.position.y - this.transform.position.y);
        if (absDiff > missBound)
        {
            score.SendMessage("miss");
        }
        else if (absDiff > okayBound)
        {
            score.SendMessage("okay");
        }
        else if (absDiff > goodBound)
        {
            score.SendMessage("good");
        }
        else
        {
            score.SendMessage("excellent");
        }
        notes.Remove (o.gameObject);
		notes.TrimExcess ();
	}

	public IEnumerator pressed()
	{
		sr.color = new Color(1,1,1);
		yield return new WaitForSeconds (0.1f);
		sr.color = old;
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
