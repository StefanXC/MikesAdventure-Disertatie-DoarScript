using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private bool mut = false;

    public Image culoareButonSunet;
    public Transform cerc;

    public Color verdeCUL;  //culori folosite pentru buton
    public Color griCUL;   //

    public Sound[] sounds;//lista cu sunetele jocului

    public float animOpen = 0.2f;    //
    public float animClose = 0.3f;  //variabile folosite pentru animatii
    public float delay = 0.2f;     //

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;  //
            s.source.pitch = s.pitch;   //caracteristici ale sunetelor
            s.source.loop = s.loop;    //
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("mut")) //verifica daca a fost memorata valoarea
        {
            PlayerPrefs.SetInt("mut", 0);  //setam ca valoare implicita 0

            Incarca();
        }
        else
        {
            Incarca();
        }

        Play("Fundal");  //incepe redarea melodiei de fundal
        ActualizareBTN();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sunetul: " + name + "nu a fost gasit!");
            return;
        }
        s.source.Play();
    }


    public void SunetOnOff()
    {

        if (mut == false)
        {
            mut = true;
            AudioListener.pause = true; //toate sunetele se opresc
            culoareButonSunet.color = griCUL; //fundalul butonului devine gri
            cerc.LeanMoveLocalX(-50, animOpen).setEaseInOutExpo().delay = delay; //cercul din buton se muta 50 de pixeli catre stanga
        }
        else
        {

            mut = false;
            AudioListener.pause = false;  //toate sunetele pot fi redate
            culoareButonSunet.color = verdeCUL; //fundalul butonului devine verde
            cerc.LeanMoveLocalX(50, animOpen).setEaseInOutExpo().delay = delay; //cercul din buton se muta 50 de pixeli catre dreapta
        }

        Salveaza();
        ActualizareBTN();
        //AudioListener.pause = muted;
    }

   

    private void ActualizareBTN()
    {
        if (mut == false)
        {
            //soundOnIcon.enabled = true;
            //soundOffIcon.enabled = false;
            culoareButonSunet.color = verdeCUL;
            cerc.LeanMoveLocalX(50, animOpen).setEaseInOutExpo().delay = delay;
        }
        else
        {
            //soundOnIcon.enabled = false;
            //soundOffIcon.enabled = true;
            culoareButonSunet.color = griCUL;
            cerc.LeanMoveLocalX(-50, animOpen).setEaseInOutExpo().delay = delay;
        }
    }

    /*public void SunetMaiIncet()
    {
        AudioListener.volume = 0.8f;
        //AudioListener.pitch = 0.8f;
    }*/

    

    private void Salveaza()
    {
        PlayerPrefs.SetInt("mut", mut ? 1 : 0); //stocheaza in memorie valoarea
        if (mut == true)  //verificam valoarea si afisam in consola mesajul corespunzator
            Debug.Log("Optiunea de silentios a fost dezactivata");
        else
            Debug.Log("Optiunea de silentios a fost activata");
    }

    private void Incarca()
    {
        mut = PlayerPrefs.GetInt("mut") == 1;
        if (mut == true)
        {
            AudioListener.pause = true; //sunetele devin inaccesibile
            Debug.Log("Sunetul este oprit");
        }
        else
            Debug.Log("Sunetul este pornit");
    }

}
