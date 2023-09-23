using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class FereastraMeniu : MonoBehaviour
{
    public float animOpen = 0.2f;
    public float animClose = 0.3f;
    public float delay = 0.2f;

    public Transform[] Frame;
    public Transform meniu;

    public CanvasGroup background;

    //public GameObject Blur;
    
 
    private void Start()
    {
        //Blur.SetActive(false);

        for (int i = 0 ; i < Frame.Length ; i++)
        {
            Frame[i].localScale = Vector3.zero;
        }
        
    }


    private void OnEnable()
    {
        //Blur.SetActive(true);

        background.alpha = 0;
        background.LeanAlpha(1, animOpen);

        for(int i = 0 ; i < Frame.Length ; i ++)
        {
            Frame[i].LeanScale(Vector3.one, 0.4f + i * 0.1f);
        }
       // meniu.localPosition = new Vector3(0, -Screen.height);
        //meniu.LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay;
        

        
    }

    public void ClosePause()
    {
        //Blur.SetActive(false);

        background.LeanAlpha(0, animClose);

        for(int i = 0; i< Frame.Length; i++)
        {
            Frame[i].LeanScale(Vector3.zero, 0.15f + i * 0.1f).setEaseInBack();
        }
        

        //meniu.LeanMoveLocalY(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);
        

    }

    void Inchide()
    {
        gameObject.SetActive(false);
    }

}
