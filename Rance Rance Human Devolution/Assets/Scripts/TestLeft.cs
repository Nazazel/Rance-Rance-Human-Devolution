using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class TestLeft: MonoBehaviour
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
    public GameObject xn;
	public Color old;
    public string[] controller;
    public Sprite xbox_sprite;

    // Use this for initialization
    void Start()
    {

        controller = Input.GetJoystickNames();
        sr = GetComponent<SpriteRenderer>();

        if (controller[0] == "Controller (Xbox One For Windows)")
        {
            sr.sprite = xbox_sprite;
        }

        old = sr.color;
        print(sr.color);
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(n, gameObject.transform.position, Quaternion.identity);
            }

            else if (Input.GetKeyDown("joystick button 2"))
            {
                Instantiate(xn, gameObject.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(pressed());
                if (hasNote)
                {
                    StartCoroutine(destructoList());
                    timer = 0f;
                }
            }

            else if (Input.GetKeyDown("joystick button 2"))
            {
                StartCoroutine(pressed());
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
