using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MisiuniManager4 : MonoBehaviour
{
    public Misiuni[] misiuni;

    public PlayerManager playerManager;

    public Transform player;

    public TextMeshProUGUI descriereText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI baniText;
    public TextMeshProUGUI progresText;

    public BaraProgres baraProgres;

    public Button revendicaBTN;
    public GameObject revendica;

    public static int progresSareMisiune;
    public static int progresRostogolireMisiune;
    public static int progresBanutziMisiune;

    public int a = 0;

    public bool complet = false;


    void Start()
    {
        if (!PlayerPrefs.HasKey("complet3"))
        {
            PlayerPrefs.SetInt("complet3", 0);
            Incarca();
        }
        else
        {
            Incarca();
        }

        if (!PlayerPrefs.HasKey("c"))
        {
            PlayerPrefs.SetInt("c", 0);
            Incarca();
        }
        else
        {
            Incarca();
        }

        baraProgres.Progres(misiuni[a].progres);
        baraProgres.Cerinta(misiuni[a].cerinta);
    }


    void Update()
    {
        MisiuniActive();
    }

    public void Recompensa()
    {
        progresSareMisiune = 0;
        progresRostogolireMisiune = 0;
        progresBanutziMisiune = 0;

        complet = false;
        playerManager.banutziT += misiuni[a].bani;
        PlayerManager.exp2 += misiuni[a].exp;

        ReincarcaMisiuni();
        Salveaza();

    }

    public void ReincarcaMisiuni()
    {

        a += 1;

        misiuni[a].progres = 0;

        revendica.SetActive(true);
        revendicaBTN.gameObject.SetActive(true);

        MisiuniActive();

    }

    public void MisiuniActive()
    {

        if (a >= misiuni.Length)
        {
            a = 0;
        }

        baraProgres.Progres(misiuni[a].progres);

        if (playerManager.romana == false)
            descriereText.text = misiuni[a].descriere;
        else
            descriereText.text = misiuni[a].descrieRO;

        expText.text = misiuni[a].exp.ToString();
        baniText.text = misiuni[a].bani.ToString();
        progresText.text = misiuni[a].progres.ToString("0") + " / " + misiuni[a].cerinta.ToString("0");

        ProgresM();
    }

    public void ProgresM()
    {
        if (misiuni[a].goal == "mers")
        {
            Mers();
        }

        if (misiuni[a].goal == "sare")
        {
            Sare();
        }

        if (misiuni[a].goal == "roll")
        {
            Roll();
        }

        if (misiuni[a].goal == "bani")
        {
            Bani();
        }
    }

    public void Mers()
    {

        misiuni[a].progres = (int)playerManager.scor;

        if (misiuni[a].progres >= misiuni[a].cerinta || complet == true)
        {

            complet = true;
            misiuni[a].progres = misiuni[a].cerinta;
            revendicaBTN.gameObject.SetActive(true);

            Salveaza();

        }
        else
        {
            revendicaBTN.gameObject.SetActive(false);
        }
    }

    public void Sare()
    {
        misiuni[a].progres = progresSareMisiune;

        if (misiuni[a].progres >= misiuni[a].cerinta)
        {
            misiuni[a].progres = misiuni[a].cerinta;
            revendicaBTN.gameObject.SetActive(true);
        }
        else
        {
            revendicaBTN.gameObject.SetActive(false);
        }
    }

    public void Roll()
    {
        misiuni[a].progres = progresRostogolireMisiune;

        if (misiuni[a].progres >= misiuni[a].cerinta)
        {
            misiuni[a].progres = misiuni[a].cerinta;
            revendicaBTN.gameObject.SetActive(true);
        }
        else
        {
            revendicaBTN.gameObject.SetActive(false);
        }
    }

    public void Bani()
    {
        misiuni[a].progres = progresBanutziMisiune;

        if (misiuni[a].progres >= misiuni[a].cerinta)
        {
            misiuni[a].progres = misiuni[a].cerinta;

            revendicaBTN.gameObject.SetActive(true);
        }
        else
        {
            revendicaBTN.gameObject.SetActive(false);
        }
    }

    private void Salveaza()
    {
        PlayerPrefs.SetInt("complet3", complet ? 1 : 0);
        PlayerPrefs.SetInt("c", a);
    }

    private void Incarca()
    {
        complet = PlayerPrefs.GetInt("complet3") == 1;
        a = PlayerPrefs.GetInt("c");
    }
}
