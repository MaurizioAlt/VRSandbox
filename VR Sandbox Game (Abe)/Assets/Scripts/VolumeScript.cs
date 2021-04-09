using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeScript : MonoBehaviour
{
    public AudioSource music;
    public AudioSource[] sfx;
    

    public static float musicVolume = .5f;
    public static float sfxVolume = .5f;
    public static int musicVolumeInt = 50;
    public static int sfxVolumeInt = 50;
    public TMP_Text musicCurrentVolume;
    public TMP_Text sfxCurrentVolume;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = musicVolume;
        musicCurrentVolume.SetText(""+ musicVolumeInt);

        sfxCurrentVolume.SetText("" + sfxVolumeInt);
        for (int i=0; i < sfx.Length; i++)
        {
            sfx[i].volume = sfxVolume;
        }

        
    }

}
