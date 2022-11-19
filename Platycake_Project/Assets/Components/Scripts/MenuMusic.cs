using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioClip jermaTheme;
    public AudioSource audioSource;

    private bool activatedEasterEgg;
    private string keyPresses;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = mainTheme;
        audioSource.Play();
    }

    void Update() {
        this.keyPresses += Input.inputString;
        if(keyPresses.Length >= 6 && !activatedEasterEgg) {
            if(keyPresses.Substring(keyPresses.Length - 6, 6).ToLower() == "aaeeoo") {
                this.activatedEasterEgg  = true;
                audioSource.clip = jermaTheme;
                audioSource.Play();
            }
            keyPresses = "";
        }
    }
}
