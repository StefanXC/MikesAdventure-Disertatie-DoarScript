using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timpMagnetTXT; //textul in care afisam timpul ramas pentru magnet
    [SerializeField] TextMeshProUGUI slowMotionTXT; //textul in care afisam timpul ramas pentru miscare lenta

    [SerializeField] bool magnetActiv;
    [SerializeField] bool slowMotion;

    public ProgresCircular progresCircularMagnet;
    public ProgresCircular progresCircularMiscareLenta;

    float timpCurentMagnet = 0;
    float startingTimeMagnet;

    float timpCurentMiscareLenta = 0;
    float startingTimeSlow ;

    public GameObject banutziDetector;
    public GameObject magnetTimer;
    public GameObject slowmotionTimer;


    void Start()
    {

        magnetActiv = false;
        magnetTimer.SetActive(false);
        banutziDetector.SetActive(false);

        slowMotion = false;
        slowmotionTimer.SetActive(false);

    }

    public void MagnetColectat()
    {

        progresCircularMagnet.max = 5 * PlayerPrefs.GetInt("upgradeMagnet") + 5;
        startingTimeMagnet = 5 * PlayerPrefs.GetInt("upgradeMagnet") + 5;
        progresCircularMagnet.curent = progresCircularMagnet.max;
        timpCurentMagnet = startingTimeMagnet;

        magnetActiv = true;
        magnetTimer.SetActive(true);
        banutziDetector.SetActive(true);

        Debug.Log("S-a atins magnet");

    }

    public void MiscareLentaColectata()
    {
        progresCircularMiscareLenta.max = 5 * PlayerPrefs.GetInt("upgradeSlowMotion") + 5;
        startingTimeSlow = 5 * PlayerPrefs.GetInt("upgradeSlowMotion") + 5;
        progresCircularMiscareLenta.curent = progresCircularMiscareLenta.max;
        timpCurentMiscareLenta = startingTimeSlow;

        slowMotion = true;
        slowmotionTimer.SetActive(true);

        Debug.Log("S-a atins Slow");
    }

    void Update()
    {

        //-----------------------M A G N E T  T I M E R---------------------//
        //if(PauseMenu.jocPePauza==false )//&& PlayerManager.jocTerminat)
        if (magnetActiv == true)
        {

            timpCurentMagnet -= 1 * Time.deltaTime;
            progresCircularMagnet.curent -= 1 * Time.deltaTime;


            timpMagnetTXT.text = timpCurentMagnet.ToString("0");
            //Debug.Log(currentTime);

            if (timpCurentMagnet <= 0)
            {
                magnetActiv = false;
                banutziDetector.SetActive(false);

                magnetTimer.SetActive(false);
                timpCurentMagnet = 0;

            }

        }
        //---------------------------------------------------------//


        //-----------------S L O W  T I M E R-------------------//

        if (slowMotion == true)
        {


            timpCurentMiscareLenta -= 2 * Time.deltaTime;
            progresCircularMiscareLenta.curent -= 2 * Time.deltaTime;


            Time.timeScale = 0.5f;


            slowMotionTXT.text = timpCurentMiscareLenta.ToString("0");
            //Debug.Log("timp slow" + currentTime);

            if (timpCurentMiscareLenta <= 0)
            {
                slowMotion = false;
                slowmotionTimer.SetActive(false);
                timpCurentMiscareLenta = 0;
                Time.timeScale = 1f;

            }
        }
        //---------------------------------------------------------//

    }



}
