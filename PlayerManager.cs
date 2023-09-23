using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverPanel; //ferestra ce apare cand personajul se loveste de un obstacol
    public bool jocTerminat = false; //booleanul in care vom stoca valoarea True daca eprsonajul atinge un obstacol
     
    public Transform player; //referinta catre pozitia/rotirea/scalarea personajului.
    public GameObject personaj; //referinta catre personaj ca obiect in scena

    public int nivel = 0;
    public int exp = 0;
    public static int exp2;
    public float scor = 0;
    public float scorMax = 0;
    public static int numarBanutzi;
    public static int baniT;
    public int banu;
    public int banutziT;

    public TextMeshProUGUI scoreText;      //
    public TextMeshProUGUI scoreMaxText;  //
    public TextMeshProUGUI banutziText;  // obiecte de tipul text în care vom afisa pe ecran scor/scor maxim/ bani totali/bani/nivel
    public TextMeshProUGUI banuTText;   //
    public TextMeshProUGUI nivelText;  //

    public TextMeshProUGUI scoreGameOverText;
    public TextMeshProUGUI banutziGameOverText;

    public bool romana = true; //booleanul cu care putem verifica daca limba selectata este romana sau engleza


    void Start()
    {
        if (!PlayerPrefs.HasKey("romana")) //daca nu s-a gasit  o salvare anterioara jocul va seta ca limba prestabilita romana
        {
            PlayerPrefs.SetInt("romana", 1); 
            IncarcaLimba();
        }
        else
        {
            IncarcaLimba();
        }

        Time.timeScale = 1f; //scalarea timpului va fi normala (nu mai lenta nu mai rapida)
        numarBanutzi = 0; //banii obtinuti în nivel vor fi la inceput 0 de fiecare data
        banutziT += numarBanutzi;

        LoadPlayer(); //apelam acesta functie pentru a putea incarca salvarile anterioare

    }

    void Update()
    {

        if (Input.GetKeyDown("space"))// prin apasarea tastei Space testam daca functia SavePlayer salveaza progresul
        {
            SavePlayer();
            Debug.Log("Am salvat");
        }

        if(Input.GetKeyDown("t")) //prin apasarea tastei T testam daca functia LoadPlayer incarca salvarea anterioara
        {
            LoadPlayer();
        }

        //banutziText.text =  numarBanutzi + " Coins";
        banutziText.text = numarBanutzi.ToString(); //afisam la fiecare cadru valoarea stocata in variabila numarBanutzi in obiectul de tip text
        banutziGameOverText.text = numarBanutzi.ToString(); //

        //banuTText.text = banutziT + "Coins";
        banuTText.text = banutziT.ToString();//afisam la fiecare cadru valoarea stocata in varialiba banutziT in obiectul de tip text
        baniT = banutziT;

        exp = exp2;

        nivelText.text = nivel.ToString();

        scoreGameOverText.text = player.position.z.ToString("0") + " Scor";
        scoreText.text = player.position.z.ToString("0") + " Scor";
        scor = player.position.z;
        
        scoreMaxText.text = scorMax.ToString("0") + " Record!";

        //nivel = exp / 75;

        if (Input.GetKeyDown(KeyCode.F))
            numarBanutzi += 1000;
        

    }

    //------------------INCARCARE SI SALVARE LIMBA ----------------------//

    private void SalveazaLimba()
    {
        PlayerPrefs.SetInt("romana", romana ? 1 : 0);
        
    }


    private void IncarcaLimba()
    {
        romana = PlayerPrefs.GetInt("romana") == 1;
        if (romana == true)
        {
            Debug.Log("Jocul este in limba romana.");
        }
        else
            Debug.Log("Jocul este in limba engleza.");
    }


    public void RomanaSelectata()
    {
        romana = true;
        SalveazaLimba();
        Debug.Log("A fost selectatat limba romana.");
    }

    public void EnglezaSelectata()
    {
        romana = false;
        SalveazaLimba();
        Debug.Log("A fost selectatat limba engleza.");
    }

    //-----------------------------------------------------------------------//



    public void CresteExp()
    {
        exp2 += 20;
        Debug.Log("Am adaugat exp");
    }

   
    public void EndGame() //functie apelata in momentul in care personajul se loveste de un obstacol
    {
        if (jocTerminat == false)
        {
            Debug.Log("Coliziune");

            jocTerminat = true;
            Debug.Log("Game over");
            gameOverPanel.SetActive(true);//apare fereastra de joc terminat
            Time.timeScale = 1f;

            GameObject playerController = GameObject.FindWithTag("Player");
            playerController.GetComponent<ControlPersonaj>().enabled = false;

            GameObject magnet = GameObject.FindWithTag("PowerUp");
            magnet.GetComponent<PowerUpsManager>().enabled = false;


          

            FindObjectOfType<ControlPersonaj>().EndAnim();//apelam functia EndAim din scriptul ControlPersonaj
        }
        if (scorMax < scor) //verificam daca scorul maxim de pana acum este mai mic de cat scorul obtinut acum
        {
            scorMax = scor; //daca este adevarat vom atribuit scorul obtinut acum scorului maxim
        }

       
    }

    public void IncarcaMeniu() //fuctie apelata in momentul in care jucatorul apasa butonul Meniu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Meniu");

        SavePlayer(); //apelam functia pentru a salva progresul
    }

    public void Restart() //functie apelata la apasarea butonul Reincearca
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//incarcam aceeasi scena doar ca de la 0
        gameOverPanel.SetActive(false);//ne asiguram ca fereastra de joc terminat este inchisa

        SavePlayer(); //apelam functia pentru a salva progresul
    }


    public void SavePlayer()//functia ce salveazaz progresul
    {
        banutziT = banutziT + numarBanutzi;//atribuim monedele colectate in acest nivel la monedele totale
        Save.SavePlayer(this);

        Debug.Log("Progres salvat");
        
    }

    public void LoadPlayer()//functia ce incarca progresul anterior
    {

        PlayerData data = Save.LoadPlayer();
  
        banutziT = data.banutziTotal;
        scorMax = data.scorMaxim;
        nivel = data.nivel;
        exp = data.exp;   

    }    
    
}
