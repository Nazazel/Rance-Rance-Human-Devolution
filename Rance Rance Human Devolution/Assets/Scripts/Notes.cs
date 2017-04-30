using System.Collections;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private bool hasNote = false;
    private GameObject lastNote, un, dn, ln, rn;
    private SpriteRenderer sr;
    private float timer = 10f;
    private float o = 0.125f;
    private KeyCode[] kc;
    private readonly float FLASH_DUR = 0.4f;
    public bool createMode;
    public GameObject n;

    // Use this for initialization
    void Start()
    {
        un = GameObject.Find("NoteY");
        dn = GameObject.Find("NoteA");
        ln = GameObject.Find("NoteX");
        rn = GameObject.Find("NoteB");
        sr = GetComponent<SpriteRenderer>();
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
    void FixedUpdate()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]))
            {
				Instantiate(n,gameObject.transform.position,Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(kc[0]) || Input.GetKeyDown(kc[1]))
            {
                if (hasNote)
                {
                    Destroy(lastNote);
                    timer = 0f;
                }
            }
            if (timer < FLASH_DUR)
            {
                o = Mathf.Lerp(0.1f, 1f, (FLASH_DUR / 2f - Mathf.Abs((FLASH_DUR / 2f) - timer)) / FLASH_DUR);
                if (timer < FLASH_DUR / 2f)
                {
                    o += 0.64f * Mathf.Sqrt(timer);
                    if (o > 1f)
                    {
                        o = 1f;
                    }
                }
                sr.color = new Color(o, o, o, 1f);
                timer += Time.deltaTime;
                if (timer >= FLASH_DUR)
                {
                    o = 0.1f;
                    sr.color = new Color(o, o, o, 1f);
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
}
