using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AfisareFPS : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FPSText;
    [SerializeField] Image FPSOffIcon;
    [SerializeField] Image FPSOnIcon;

    private bool FPSafisat = false;
  
    void Start()
    {
        if (!PlayerPrefs.HasKey("FPSafisat"))//cauta în memorie valorea
        {
            PlayerPrefs.SetInt("FPSafisat", 0);//setam ca valoare prestabilita 0
            Incarca();
        }
        else
        {
            Incarca();
        }
        ActualizareBTN();

    }


    public void FPSOnOff()//functie apelata la apăsarea butonului cu acelasi nume
    {
        if (FPSafisat == false)
        {
            FPSafisat = true;
            FPSText.enabled = true;//facem vizibil textul în care afisam FPS
        }
        else
        {
            FPSafisat = false;
            FPSText.enabled = false;//ascundem textul în care afisam FPS
        }

        Salveaza();
        ActualizareBTN();
    }


    private void Salveaza()
    {
        PlayerPrefs.SetInt("FPSafisat", FPSafisat ? 1 : 0);//salveaza valoarea
    }

    private void Incarca()
    {
        FPSafisat = PlayerPrefs.GetInt("FPSafisat") == 1;
        if (FPSafisat == false)
        {     
            FPSText.enabled = false;//ascundem textul în care afisam FPS
        }
        else
        {           
            FPSText.enabled = true; //facem vizibil textul în care afisam FPS
        }

    }

    private void ActualizareBTN()
    {
        if (FPSafisat == false)
        {
            FPSOffIcon.enabled = true;//afiseaza iconita pentru FPS dezactivate 
            FPSOnIcon.enabled = false;
        }
        else
        {
            FPSOffIcon.enabled = false;
            FPSOnIcon.enabled = true; //afiseaza iconita pentru FPS activate
        }
    }
   
}
