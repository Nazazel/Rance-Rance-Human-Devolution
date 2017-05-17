using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    private SpriteRenderer sr;
    private float maxPlayerHealth = 100f;
    private float currPlayerHealth;
    private float frac_scale, frac_pos;

	// Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        currPlayerHealth = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {
        frac_scale = Mathf.Lerp(80f, 0f, (maxPlayerHealth - currPlayerHealth) / maxPlayerHealth);
        frac_pos = Mathf.Lerp(-861.5f, -855.9f, (maxPlayerHealth - currPlayerHealth) / maxPlayerHealth);
        sr.transform.localScale = new Vector3(frac_scale, 10f, 0);
        sr.transform.localPosition = new Vector3(frac_pos, -604f, 0);
    }

    public void esfd()
    {
        currPlayerHealth -= 10f;
    }
}
