using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public bool started;
    public Sprite[] backgrounds;

    // Use this for initialization
    void Start()
    {
		started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            StartCoroutine("waitThreeSeconds");
        }
    }

    IEnumerator waitThreeSeconds()
    {
		started = false;
        yield return new WaitForSeconds(0.5F);
        GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[1];
        yield return new WaitForSeconds(0.5F);
        GameObject.Find("Panel").GetComponent<Image>().sprite = backgrounds[0];
		started = true;
    }
}
