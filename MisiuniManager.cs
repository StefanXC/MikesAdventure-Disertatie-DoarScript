using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MisiuniManager : MonoBehaviour
{
    /*[SerializeField]
    //private Misiuni[] misiuni;
    //public CerintaMisiune cerinta;

    public static int progresCM;
    public static int progresSM;

    public PlayerManager player;

    //public GameObject Misiune1;


    //----------Misiune1---------//
   // public Text titluText;
    //public Text descriereText;
    public TextMeshProUGUI descriereText;
    //public Text expText;
    //public Text baniText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI baniText;
    //public Text progresText;
    public TextMeshProUGUI progresText;

    //----------Misiune2---------//
    public TextMeshProUGUI descriereText2;
    public TextMeshProUGUI expText2;
    public TextMeshProUGUI baniText2;
    public TextMeshProUGUI progresText2;

    //----------Misiune3---------//
    public TextMeshProUGUI descriereText3;
    public TextMeshProUGUI expText3;
    public TextMeshProUGUI baniText3;
    public TextMeshProUGUI progresText3;
    //------------------------//

    public int progres;
    public bool activ;
    public bool complet;

    public int a = 0;
    public int b = 0;
    public int c = 0;

    public ProgressBar progressBar;
    public ProgressBar progressBar2;
    public ProgressBar progressBar3;

    public Button revendicaBTN;
    public Button revendicaBTN2;
    public Button revendicaBTN3;
    public GameObject dani;


    void Start()
    {
        if (player.a >= player.misiuni.Length)
        {

            player.a = 0;
        }

        revendicaBTN.gameObject.SetActive(false);
        revendicaBTN2.gameObject.SetActive(false);
        revendicaBTN3.gameObject.SetActive(false);

        //activ = true;

        if (player.a == 4)
            player.a = 0;
        
        a = player.a;
        b = player.b;
        c = player.c;

        progressBar.SetProgress(player.misiuni[a].progres);
        progressBar.SetRequirement(player.misiuni[a].cerinta);

        progressBar2.SetProgress(player.misiuni2[b].progres);
        progressBar2.SetRequirement(player.misiuni2[b].cerinta);

        progressBar3.SetProgress(player.misiuni3[c].progres);
        progressBar3.SetRequirement(player.misiuni3[c].cerinta);



    }
    void Update()
    {    
        MisiuniActive();
        progressBar.SetProgress(player.misiuni[a].progres);
        progressBar2.SetProgress(player.misiuni2[b].progres);
        progressBar3.SetProgress(player.misiuni3[c].progres);
    }

    public void MisiuniActive()
    {

        if (player.a >= player.misiuni.Length)
        {

            player.a = 0;
        }
        
        // if(activ==true)
         //{ 
         //a = player.a;

            //titluText.text = player.misiuni[i].titlu;
            descriereText.text = player.misiuni[a].descriere;
            expText.text = player.misiuni[a].exp.ToString();
            baniText.text = player.misiuni[a].bani.ToString();
            //progresText.text = player.misiuni[i].progres.ToString();

            progresText.text = player.misiuni[a].progres.ToString("0") + " / " + player.misiuni[a].cerinta.ToString("0");
        
        

        /*descriereText2.text = player.misiuni2[b].descriere;
        expText2.text = player.misiuni2[b].exp.ToString();
        baniText2.text = player.misiuni2[b].bani.ToString();
        progresText2.text = player.misiuni2[b].progres.ToString("0") + " / " + player.misiuni2[b].cerinta.ToString("0");


        descriereText3.text = player.misiuni3[c].descriere;
        expText3.text = player.misiuni3[c].exp.ToString();
        baniText3.text = player.misiuni3[c].bani.ToString();
        progresText3.text = player.misiuni3[c].progres.ToString("0") + " / " + player.misiuni3[c].cerinta.ToString("0");

        */
        /*ProgresM();
        // }
        // else
        // {
        //   i = 4;
        // }

    }

    public void ProgresM()
    {
        if (player.misiuni[a].goal == "mers")
        {
            Mers();
        }
        if (player.misiuni[a].goal == "sare")
        {
            Sare();
        }
        if (player.misiuni[a].goal == "bani")
        {
            Bani();
        }
        //----------------------------//
        if (player.misiuni2[b].goal == "mers")
        {
            Mers2();
        }
        if (player.misiuni2[b].goal == "sare")
        {
            Sare2();
        }
        if (player.misiuni2[b].goal == "bani")
        {
            Bani2();
        }
        //------------------------------//
        if (player.misiuni3[c].goal == "mers")
        {
            Mers3();
        }
        if (player.misiuni3[c].goal == "sare")
        {
            Sare3();
        }
        if (player.misiuni3[c].goal == "bani")
        {
            Bani3();
        }

    } 

    public void Mers()
    {
        player.misiuni[a].progres = (int)player.score;

        if (player.misiuni[a].progres >= player.misiuni[a].cerinta)
        {
            revendicaBTN.gameObject.SetActive(true);
            //Recompensa();

            Debug.Log("Misiune Completa mers!");

            //ReincarcaMisiuni();

        }
    }

    public void Mers2()
    {
        player.misiuni2[b].progres = (int)player.score;

        if (player.misiuni2[b].progres >= player.misiuni2[b].cerinta)
        {
            revendicaBTN2.gameObject.SetActive(true);
            //Recompensa();

            //Debug.Log("Misiune Completa mers!");

            //ReincarcaMisiuni();

        }
    }

    public void Mers3()
    {
        player.misiuni3[c].progres = (int)player.score;

        if (player.misiuni3[c].progres >= player.misiuni3[c].cerinta)
        {
            revendicaBTN3.gameObject.SetActive(true);
            //Recompensa();

            Debug.Log("Misiune Completa mers!");

            //ReincarcaMisiuni();

        }
    }

    public void Sare()
    {
        player.misiuni[a].progres = progresSM;
        
        if (player.misiuni[a].progres == player.misiuni[a].cerinta)
        {
            revendicaBTN.gameObject.SetActive(true);
            //Recompensa();

            //Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();
           

        }
    }

    public void Sare2()
    {
        player.misiuni2[b].progres = progresSM;

        if (player.misiuni2[b].progres == player.misiuni2[b].cerinta)
        {
            revendicaBTN2.gameObject.SetActive(true);
            //Recompensa();

            //Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();


        }
    }

    public void Sare3()
    {
        player.misiuni3[c].progres = progresSM;

        if (player.misiuni3[c].progres == player.misiuni3[c].cerinta)
        {
            revendicaBTN3.gameObject.SetActive(true);
            //Recompensa();

            //Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();


        }
    }

    public void Bani()
    {

        player.misiuni[a].progres = progresCM;

        if (player.misiuni[a].progres >= player.misiuni[a].cerinta)
        {
            player.misiuni[a].progres = player.misiuni[a].cerinta;
            //Recompensa();
            revendicaBTN.gameObject.SetActive(true);
            Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();
        }
    }

    public void Bani2()
    {

        player.misiuni2[b].progres = progresCM;

        if (player.misiuni2[b].progres >= player.misiuni2[b].cerinta)
        {
            player.misiuni2[b].progres = player.misiuni2[b].cerinta;
            //Recompensa();
            revendicaBTN2.gameObject.SetActive(true);
           // Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();
        }
    }

    public void Bani3()
    {

        player.misiuni3[c].progres = progresCM;

        if (player.misiuni3[c].progres == player.misiuni3[c].cerinta)
        {
            //Recompensa();
            revendicaBTN3.gameObject.SetActive(true);
            Debug.Log("Misiune Completa!");

            //ReincarcaMisiuni();
        }
    }

    public void Recompensa()
    {
        activ = false;

        progresCM = 0;
        PlayerManager.numarBanutzi += player.misiuni[a].bani;
        PlayerManager.exp2 += player.misiuni[a].exp;

        //revendicaBTN.gameObject.SetActive(false);
        dani.SetActive(false);

        ReincarcaMisiuni();


    }

    public void Recompensa2()
    {      

        progresCM = 0;
        PlayerManager.numarBanutzi += player.misiuni2[b].bani;
        PlayerManager.exp2 += player.misiuni2[b].exp;

        //revendicaBTN.gameObject.SetActive(false);
        //dani.SetActive(false);

        ReincarcaMisiuni2();


    }

    public void Recompensa3()
    {
        activ = false;

        progresCM = 0;
        PlayerManager.numarBanutzi += player.misiuni3[c].bani;
        PlayerManager.exp2 += player.misiuni3[c].exp;

        //revendicaBTN.gameObject.SetActive(false);
        //dani.SetActive(false);

        ReincarcaMisiuni();


    }


    public void ReincarcaMisiuni()
    {
        //player.misiuni[i].isComplete = true;
       // player.misiuni[i].isActive = false;
        player.misiuni[a].progres = 0;
        revendicaBTN.gameObject.SetActive(true);
        //Misiune1.SetActive(false);
        Debug.Log("Se incarca misiune");
        if (a >= player.misiuni.Length)
        {
            player.a = 0;
        }
        else
        {
            player.a += 1;
        }
        //activ = false;

        MisiuniActive();
    }

    public void ReincarcaMisiuni2()
    {
        //player.misiuni[i].isComplete = true;
        // player.misiuni[i].isActive = false;
        player.misiuni2[b].progres = 0;
        revendicaBTN2.gameObject.SetActive(true);
        //Misiune1.SetActive(false);
        Debug.Log("Se incarca misiune");
        if (b == player.misiuni2.Length)
        {
            player.b = 0;
        }
        else
        {
            player.b += 1;
        }
        //activ = false;

        MisiuniActive();
    }

    public void ReincarcaMisiuni3()
    {
        
        player.misiuni3[c].progres = 0;
        revendicaBTN3.gameObject.SetActive(true);
        
        Debug.Log("Se incarca misiune");
        if (c == player.misiuni3.Length)
        {
            player.c = 0;
        }
        else
        {
            player.c += 1;
        }
        //activ = false;

        MisiuniActive();
    }*/

}
