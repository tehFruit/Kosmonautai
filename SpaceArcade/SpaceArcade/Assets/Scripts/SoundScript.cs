using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip hit, fire, explode;
    static AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("hit");
        fire = Resources.Load<AudioClip>("shoot");
        explode = Resources.Load<AudioClip>("explosion");

        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
