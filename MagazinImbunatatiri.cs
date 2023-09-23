using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MagazinImbunatatiri : MonoBehaviour
{
   //------------magnet------------//
    public BaraProgres baraProgresMagnet;
    public TextMeshProUGUI nivelMagnet;

    public Button cumparaMagnetBTN;
    //---------------------------//

    //-------------miscare lenta---------//
    public BaraProgres baraProgresMiscareLenta;
    public TextMeshProUGUI nivelMiscareLenta;

    public Button cumparaMiscareLentaBTN;
    //----------------------------//

    public PlayerManager playerManager; //referinta pentru apelare playerManager

    public int imbunatatireMagnet = 0;
    public int imbunatatireMiscareLenta = 0;

    void Start()
    {
        //playerManager = GetComponent<PlayerManager>();

        //-------verificam daca exista salvari anterioare pentru magnet---//
        if (!PlayerPrefs.HasKey("upgradeMagnet"))
        {
            PlayerPrefs.SetInt("upgradeMagnet", 0);
            Incarca();
        }
        else
        {
            Incarca();
        }
        //-------------------------------------------------------------//

        //---------verificam daca exista salvari anterioare pentru miscare lenta------------//
        if (!PlayerPrefs.HasKey("upgradeSlowMotion"))
        {
            PlayerPrefs.SetInt("upgradeSlowMotion", 0);
            Incarca();
        }
        else
        {
            Incarca();
        }
        //-----------------------------------------------------------//
        UpdateUI();

        baraProgresMagnet.Progres(imbunatatireMagnet);//afisam progresul imbunatatirii magnetului
        baraProgresMagnet.Cerinta(5);//setam maximul de imbunatatiri la 5 pentru magnet

        baraProgresMiscareLenta.Progres(imbunatatireMiscareLenta);//afisam progresul imbunatatirii miscarii lente
        baraProgresMiscareLenta.Cerinta(5);//setam maximul de imbunatatiri la 5 pentru miscare lenta


    }

    void Update()
    {
        UpdateUI();
        //-------------------test pentru scaderea imbunatatirii pentru magnet ----------//
        if(Input.GetKeyDown(KeyCode.T))
        {
            imbunatatireMagnet -= 1;
            Salveaza();
            UpdateUI();

            baraProgresMagnet.Progres(imbunatatireMagnet);
        }
        //---------------------------------------------//

    }

    /*public void DownGradeMagnet()
    {
        upgradeMagnet -= 1;
        Salveaza();
        UpdateUI();

        magnetProgressBar.SetProgress(upgradeMagnet);
    } 
    */

    public void ImbunatatireMagnet() //functie apelata la apasarea butonul de imbunatatire magnet
    {

        if (imbunatatireMagnet <= 5) //verificam nivelul la care este imbunatatit magnetul
        {
            Debug.Log("Magnet imbunatatit"); //afisam in consola
            playerManager.banutziT = playerManager.banutziT - (imbunatatireMagnet * 250 + 400); //Fara paranteze calculeaza 0/100/200..
            imbunatatireMagnet += 1; //crestem nivelul imbunatatirii
            playerManager.SavePlayer(); //salvam modificarea banilor jucatorului
            Debug.Log(playerManager.banutziT); //afisam in consola banii jucatorului
        }
       
        Salveaza();
        UpdateUI();

        baraProgresMagnet.Progres(imbunatatireMagnet); //actualizam bara de progres
        
    }

    public void ImbunatatireMiscareLenta() //functie apelata la apasarea butonul de miscare lenta
    {
        if (imbunatatireMiscareLenta <= 5)
        {
            imbunatatireMiscareLenta += 1; //crestem nivelul imbunatatirii
            Debug.Log("Miscare lenta imbunatatita"); //afisam in consola
            playerManager.banutziT = playerManager.banutziT - (imbunatatireMiscareLenta * 200 + 300);//Fara paranteze calculeaza 0/100/200..
            playerManager.SavePlayer(); //salvam modificarea banilor jucatorului
            Debug.Log(playerManager.banutziT); //afisam in consola banii jucatorului
        }

        Salveaza();
        UpdateUI();

        baraProgresMiscareLenta.Progres(imbunatatireMiscareLenta); //actualizam bara de progres
    }

    private void Salveaza()
    {
        PlayerPrefs.SetInt("upgradeMagnet", imbunatatireMagnet); //salvam progresul imbunatatirii magnetului
        PlayerPrefs.SetInt("upgradeSlowMotion", imbunatatireMiscareLenta); //salvam progresul imbunatatirii miscarii lente
    }

    private void Incarca()
    {
        imbunatatireMagnet = PlayerPrefs.GetInt("upgradeMagnet");
        Debug.Log("upgrade magnet = " + imbunatatireMagnet);

        imbunatatireMiscareLenta = PlayerPrefs.GetInt("upgradeSlowMotion");
        Debug.Log("upgrade slowmotion = " + imbunatatireMiscareLenta);


    }

    private void UpdateUI() //functia actualizeaza interfata grafica a magazinului
    {
        if (imbunatatireMagnet > 4) //ne asiguram ca imbunatatirea magnetului nu este mai mare decat 4
        {
            cumparaMagnetBTN.gameObject.SetActive(false); //eliminam din interfata butonul de cumparare imbunatatire
        }
        else
        {
            cumparaMagnetBTN.gameObject.SetActive(true); //ne asiguram ca butonul de cumparat este vizibil
            cumparaMagnetBTN.GetComponentInChildren<TextMeshProUGUI>().text = "Cumpara -" + (imbunatatireMagnet * 250 + 400); //afisam pretul in textul butonului
            if (imbunatatireMagnet * 250 + 400 < playerManager.banutziT)
            {
                cumparaMagnetBTN.interactable = true; //daca acesta are suficienti bani butonul poate fi apasat
            }
            else
            {
                cumparaMagnetBTN.interactable = false; //daca acesta nu are suficienti butonul nu poate fi apasat
            }
        }

        baraProgresMagnet.Progres(imbunatatireMagnet);
        nivelMagnet.text = imbunatatireMagnet.ToString("0") + " / " + 5;

        if (imbunatatireMiscareLenta > 4) //ne asiguram ca imbunatatirea miscarii lente nu este mai mare decat 4
        {
            cumparaMiscareLentaBTN.gameObject.SetActive(false); //eliminam din interfata butonul de cumparare imbunatatire
        }
        else
        {
            cumparaMiscareLentaBTN.gameObject.SetActive(true); //ne asiguram ca butonul de cumparat este vizibil
            cumparaMiscareLentaBTN.GetComponentInChildren<TextMeshProUGUI>().text = "Cumpara -" + (imbunatatireMiscareLenta * 200 + 300); //afisam pretul in textul butonului
            if (imbunatatireMiscareLenta * 200 + 300 < playerManager.banutziT) //verificam banii jucatorului 
            {
                cumparaMiscareLentaBTN.interactable = true; //daca acesta are suficienti bani butonul poate fi apasat
            }
            else
            {
                cumparaMiscareLentaBTN.interactable = false; //daca acesta nu are suficienti butonul nu poate fi apasat
            }
        }

        baraProgresMiscareLenta.Progres(imbunatatireMiscareLenta);
        nivelMiscareLenta.text = imbunatatireMiscareLenta.ToString("0") + " / " + 5;


    }
}
