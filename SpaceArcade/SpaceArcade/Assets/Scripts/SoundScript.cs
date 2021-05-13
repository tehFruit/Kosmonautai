using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour
{
    public static AudioClip hit, fire, explode;
    static AudioSource src;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("hit");
        fire = Resources.Load<AudioClip>("shoot");
        explode = Resources.Load<AudioClip>("explosion");

        src = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "fire":
                src.PlayOneShot(fire);
                break;
            case "hit":
                src.PlayOneShot(hit);
                break;
            case "explode":
                src.PlayOneShot(explode);
                break;
        }
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10 (sliderValue) * 20);
    }
}
