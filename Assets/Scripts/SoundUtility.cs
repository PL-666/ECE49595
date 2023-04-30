using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUtility : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip cardSpawnSound;
    public AudioClip cardClickSound;
    public float spawnSound = 0.7f;
    public float clickSound = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSpawnCardSound()
    {
        audioSource.PlayOneShot(cardSpawnSound, spawnSound);
    }

    public void playClickCardSound()
    {
        audioSource.PlayOneShot(cardClickSound, clickSound);
    }
}
