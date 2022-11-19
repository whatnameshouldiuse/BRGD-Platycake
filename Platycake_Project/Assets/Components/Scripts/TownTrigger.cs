using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTrigger : MonoBehaviour
{
    public AudioSource insideOfTownSource;
    public AudioSource outsideOfTownSource;

    // Start is called before the first frame update
    void Start()
    {
        outsideOfTownSource.Play();
        insideOfTownSource.Play();
        outsideOfTownSource.volume = 1.0f;
        insideOfTownSource.volume = 0.0f;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            outsideOfTownSource.volume = 0.0f;
            insideOfTownSource.volume = 1.0f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            outsideOfTownSource.volume = 1.0f;
            insideOfTownSource.volume = 0.0f;
        }
    }
}
