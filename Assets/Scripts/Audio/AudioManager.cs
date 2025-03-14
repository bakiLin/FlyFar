using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }

    public Sound[] sounds;

    private void Awake()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        s?.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        s?.source.Stop();
    }
}
