using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score;
    private Text t;

	// Use this for initialization
	void Start () {
        score = 0;
        t = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        t.text = "Score: " + score.ToString("D6");
	}

    void excellent()
    {
        score += 1000;
    }

    void good()
    {
        score += 500;
    }

    void okay()
    {
        score += 250;
    }

    void miss()
    {
        score -= 101;
        if (score < 0)
        {
            score = 0;
        }
    }
}
