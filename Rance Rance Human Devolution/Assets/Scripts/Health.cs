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
        frac_pos = Mathf.Lerp(-859.5f, -853.9f, (maxPlayerHealth - currPlayerHealth) / maxPlayerHealth);
        sr.transform.localScale = new Vector3(frac_scale, 10f, 0);
        sr.transform.localPosition = new Vector3(frac_pos, -606.08f, 0);
    }

    public void esfd() //Stands for Ergonomically Scintillating Floccinaucinihilipilification Disruptor
    {
        currPlayerHealth -= 10f;
    }

    public void addHealth(int hpGain)
    {
        currPlayerHealth += hpGain;
        if (currPlayerHealth > maxPlayerHealth) currPlayerHealth = maxPlayerHealth;
    }
}
