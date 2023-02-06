using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] sound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        int randSound = Random.Range(0, sound.Length);
        source.clip = sound[randSound];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
