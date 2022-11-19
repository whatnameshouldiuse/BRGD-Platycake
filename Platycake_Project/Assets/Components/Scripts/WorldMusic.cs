using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMusic : MonoBehaviour
{
    public AudioClip outsideOfTown;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = outsideOfTown;
        audioSource.Play();
    }
}
