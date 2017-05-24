using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Notes : MonoBehaviour
{
    private bool hasNote = false;
    private KeyCode[] kc;
    private GameObject lastNote, temp_note, score, health;
    public GameObject n;
    private List<GameObject> notes = new List<GameObject>();
    private SpriteRenderer sr;
    public bool createMode;
    public Color old;

    public string[] controller;
    public Sprite xbox_sprite;
    public Sprite key_sprite;

    private int note_capacity;
    private float missBound = 0.29f, okayBound = 0.2f, goodBound = 0.11f; //Values greater than a certain bound are classified as that type of hit. Ex: outside of goodBound but within okayBound is good.
    private bool noPenalty = false;
    private float freeTimer = 0f;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        score = GameObject.FindWithTag("Score");
        health = GameObject.Find("Health");
        print(health);
        old = sr.color;
        note_capacity = 0;
        kc = new KeyCode[3];
        switch (this.name)
        {
            case "Left":
                kc[0] = KeyCode.A;
                kc[1] = KeyCode.LeftArrow;
                kc[2] = KeyCode.Joystick1Button2;
                break;
            case "Right":
                kc[0] = KeyCode.D;
                kc[1] = KeyCode.RightArrow;
                kc[2] = KeyCode.Joystick1Button1;
                break;
            case "Up":
                kc[0] = KeyCode.W;
                kc[1] = KeyCode.UpArrow;
                kc[2] = KeyCode.Joystick1Button3;
                break;
            case "Down":
                kc[0] = KeyCode.S;
                kc[1] = KeyCode.DownArrow;
                kc[2] = KeyCode.Joystick1Button0;
                break;
        }
        controller = Input.GetJoystickNames(); //Moved this code to start() to reduce lag
        if (controller.Length > 0 && controller[0] == "Controller (Xbox One For Windows)")
        {
            sr.sprite = xbox_sprite;
        }

        else
        {
            sr.sprite = key_sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (noPenalty)
        {
            freeTimer -= Time.deltaTime;
            if(freeTimer <= 0f)
            {
                freeTimer = 0f;
                noPenalty = false;
            }
        }
        if (createMode)
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]) || Input.GetKeyDown(kc[2]))
            {
                Instantiate(n, gameObject.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]) || Input.GetKeyDown(kc[2]))
            {
                StartCoroutine(pressed());
                if (hasNote)
                {
                    StartCoroutine(destructoList());
                }
				else {
					score.SendMessage ("miss");
					health.SendMessage ("esfdlite");
				}
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D o)
    {
        hasNote = true;
        lastNote = o.gameObject;
        notes.Add(lastNote);
        note_capacity++;
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (!noPenalty)
        {
            hasNote = false;
            score.SendMessage("miss");
            health.SendMessage("esfd");
            notes.Remove(o.gameObject);
            notes.TrimExcess();
            note_capacity--;
        }
        if (note_capacity < 0) note_capacity = 0;
    }

    public IEnumerator pressed()
    {
        sr.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }

    public IEnumerator destructoList()
    {
        noPenalty = true;
        freeTimer = 0.05f;
            int n2 = note_capacity;
            note_capacity = 0;
            hasNote = false;
			for (int i = 0; i < n2; i++) {
				temp_note = notes [0];
				float absDiff = Mathf.Abs (temp_note.transform.position.y - this.transform.position.y);
				if (absDiff > okayBound) {
					score.SendMessage ("okay");
					health.GetComponent<Health2> ().addHealth (3);
				} else if (absDiff > goodBound) {
					score.SendMessage ("good");
					health.GetComponent<Health2> ().addHealth (3);
				} else {
					score.SendMessage ("excellent");
					health.GetComponent<Health2> ().addHealth (3);
				}
                notes.Remove(temp_note);
                Destroy (temp_note);
				notes.TrimExcess ();
			}
			yield return new WaitForSeconds (0.01f);
    }

}