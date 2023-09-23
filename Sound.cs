using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; //numele

    public AudioClip clip; //clipul audio


    [Range(0f, 1f)]
    public float volume; //volumul clipului audio
    [Range(-1f, 3f)]
    public float pitch;

    public bool loop; //booleanul folosit pentru a putea pune melodia de fundal în bucla

    [HideInInspector]
    public AudioSource source;

}
