using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int personajCurent;
    public GameObject[ ] personaje;

    public ClasaPersonaje[] pers;
    public Button buyButton;

    void Start()
    {
        foreach(ClasaPersonaje personaj in pers)
        {
            if (personaj.pret == 0)
                personaj.cumparat = true;
            else
                personaj.cumparat = PlayerPrefs.GetInt(personaj.nume, 0) ==0 ? false: true;

        }


        personajCurent = PlayerPrefs.GetInt("PersonajActiv", 0);
        foreach (GameObject personaj in personaje)
            personaj.SetActive(false);


        personaje[personajCurent].SetActive(true);
    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void PersonajUrmator()
    {
        personaje[personajCurent].SetActive(false);

        personajCurent++;

        if (personajCurent == personaje.Length)
            personajCurent = 0;

        personaje[personajCurent].SetActive(true);

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
    }

    public void PersonajAnterior()
    {
        personaje[personajCurent].SetActive(false);

        personajCurent--;

        if (personajCurent == -1)
            personajCurent = personaje.Length - 1; 

        personaje[personajCurent].SetActive(true);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
    }

    public void CumparaPersonaj()
    {
        ClasaPersonaje c = pers[personajCurent];
        PlayerPrefs.SetInt(c.nume, 1);
        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
        c.cumparat = true;

        PlayerManager.numarBanutzi = PlayerManager.numarBanutzi - c.pret;

        //PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - c.pret);
    }

    private void UpdateUI()
    {
        ClasaPersonaje c = pers[personajCurent];
        if (c.cumparat)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + c.pret;
            if(c.pret < /*PlayerPrefs.GetInt("NumberOfCoins",0)*/ PlayerManager.numarBanutzi)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }

    }

}
