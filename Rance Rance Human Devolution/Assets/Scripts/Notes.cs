using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Notes : MonoBehaviour
{
    private bool hasNote = false;
    private KeyCode[] kc;
    private GameObject lastNote, temp_note, score;
    public GameObject n, xn;
    private List<GameObject> notes = new List<GameObject>();
    private SpriteRenderer sr;
    public bool createMode;
    public Color old;
    private float missBound = 0.28f, okayBound = 0.2f, goodBound = 0.11f; //Values greater than a certain bound are classified as that type of hit. Ex: outside of goodBound but within okayBound is good.

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        score = GameObject.FindWithTag("Score");
        print(score);
        old = sr.color;
        print(sr.color);
        kc = new KeyCode[2];
        switch (this.name)
        {
            case "Left":
                kc[0] = KeyCode.A;
                kc[1] = KeyCode.LeftArrow;
                break;
            case "Right":
                kc[0] = KeyCode.D;
                kc[1] = KeyCode.RightArrow;
                break;
            case "Up":
                kc[0] = KeyCode.W;
                kc[1] = KeyCode.UpArrow;
                break;
            case "Down":
                kc[0] = KeyCode.S;
                kc[1] = KeyCode.DownArrow;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]))
            {
                Instantiate(n, gameObject.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]))
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
        notes.Add(lastNote);
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        hasNote = false;
        float absDiff = Mathf.Abs(o.gameObject.transform.position.y - this.transform.position.y);
        if (absDiff > missBound)
        {
            score.SendMessage("miss");
        }
        else if(absDiff > okayBound)
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
        notes.Remove(o.gameObject);
        notes.TrimExcess();
    }

    public IEnumerator pressed()
    {
        sr.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }

    public IEnumerator destructoList()
    {
        for (int i = 0; i < notes.Capacity; i++)
        {
            temp_note = notes[i];
            Destroy(temp_note);
            notes.Remove(temp_note);
        }
        yield return new WaitForSeconds(0.1f);
    }

}