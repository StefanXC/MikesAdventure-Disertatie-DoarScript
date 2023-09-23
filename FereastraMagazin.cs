using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FereastraMagazin : MonoBehaviour
{
    public float animOpen = 0.3f;
    public float animClose = 0.3f;
    public float delay = 0.15f;
    
    public Transform magazin;
    public Transform[] ElementeMagazin;
    public CanvasGroup background;


    private void Start()
    {

        for (int i = 0; i < ElementeMagazin.Length; i++)
        {
            ElementeMagazin[i].localScale = Vector3.zero;
        }
    }

    public void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1, animOpen);


        //cartonase personaje
        
        for(int i=0;i<ElementeMagazin.Length;i++)
        {
            if(i!=11 && i != 12 && i != 13)
            ElementeMagazin[i].LeanScale(Vector3.one, 0.4f + i*0.1f);
        }
        //

        magazin.localPosition = new Vector2(0, -Screen.height);
        magazin.LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay;
       
    }

    public void CloseOption()
    {

        background.LeanAlpha(0, animClose);
        //cartonase personaje
        for (int i = 0; i < ElementeMagazin.Length; i++)
        {
            ElementeMagazin[i].LeanScale(Vector3.zero, 0.15f + i * 0.1f).setEaseInBack();
        }
        //

        
        
        magazin.LeanMoveLocalY(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);       
    }

    void Inchide()
    {
        gameObject.SetActive(false);
    }

    public void SchimbaLaUpgrades()
    {
        for (int i = 1; i < ElementeMagazin.Length-5; i++)
        {
            ElementeMagazin[i].LeanScale(Vector3.zero, 0.15f + i * 0.1f).setEaseInBack();
        }

        ElementeMagazin[11].LeanScale(Vector3.one, 0.7f);
        ElementeMagazin[12].LeanScale(Vector3.one, 0.9f);
        ElementeMagazin[13].LeanScale(Vector3.one, 1.1f);

    }

    public void SchimbaLaCharactere()
    {
        for (int i = 1; i < ElementeMagazin.Length-5; i++)
        {
            ElementeMagazin[i].LeanScale(Vector3.one, 0.4f + i * 0.1f);
        }

        ElementeMagazin[11].LeanScale(Vector3.zero, 0.3f).setEaseInBack();
        ElementeMagazin[12].LeanScale(Vector3.zero, 0.5f).setEaseInBack();
        ElementeMagazin[13].LeanScale(Vector3.zero, 0.7f).setEaseInBack();

    }
}
