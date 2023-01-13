using UnityEngine.Audio;

using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public GameObject audioPrefab3d;
    public Sound[] sounds;
    void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Debug.Log("Hola");
            Play("MainMenuTheme");
        }
        else if (SceneManager.GetActiveScene().name == "BigMap")
        {
            Play("School");
        }

    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void Play(string name, GameObject attached = null)
    {
        Sound newSound = Array.Find(sounds, sound => sound.name == name);
        if (newSound == null)
            return;

        AudioSource newAudio = Instantiate(audioPrefab3d, null).GetComponent<AudioSource>();

        newAudio.clip = newSound.clip;
        newAudio.pitch = newSound.pitch;
        newAudio.volume = newSound.volume;
        newAudio.loop = newSound.loop;

        if(attached != null)
            newAudio.transform.parent = attached.transform;
    }
}
