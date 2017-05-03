using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public AudioSource audio;
    public bool started;

    // Use this for initialization
    void Start()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            if (!started)
            {
                started = true;
                StartCoroutine("wait");
            }
        }
        
    }
    IEnumerator wait()
    {
        started = false;
        yield return new WaitForSeconds(5F);
        SceneManager.LoadSceneAsync("Second Menu");
    }
}
