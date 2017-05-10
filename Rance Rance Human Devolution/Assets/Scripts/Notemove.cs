using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notemove : MonoBehaviour {

    private Rigidbody2D rb;
    public float SPEED;
    public bool mobile = true;
	private SpriteRenderer sr;
	public string[] controller;
	public Sprite xbox_sprite;
	public Sprite key_sprite;

    // Use this for initialization
    void Start()
    {
		sr = GetComponent<SpriteRenderer>();
		if (SPEED == 0f && gameObject.tag != "OriginNote") SPEED = 1.5f;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, SPEED);
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if (mobile) rb.velocity = new Vector2(0, SPEED);
        else rb.velocity = new Vector2(0, 0);
    }
}
