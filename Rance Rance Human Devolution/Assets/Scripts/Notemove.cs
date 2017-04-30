using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notemove : MonoBehaviour {

    private Rigidbody2D rb;
    public float SPEED;
    public bool mobile = true;

    // Use this for initialization
    void Start()
    {
		if (SPEED == 0f && gameObject.tag != "OriginNote") SPEED = 1.5f;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, SPEED);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mobile) rb.velocity = new Vector2(0, SPEED);
        else rb.velocity = new Vector2(0, 0);
    }
}
