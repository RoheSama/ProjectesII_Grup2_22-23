using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelfDestruct : MonoBehaviour
{
    public AudioSource audio;
    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
            Destroy(this.gameObject);
    }
}
