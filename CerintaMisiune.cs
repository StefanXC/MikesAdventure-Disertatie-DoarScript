using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CerintaMisiune
{
    public Misiuni[] misiuni;
    public PlayerManager player;
    public GameObject Misiune1;

    public GoalType goalType;

    public int cerinta;
    public int progresCM;


    public int progres;


   /* public void ProgresM()
{
        for (int i = 0; i < 4; i++)
        {
            if (misiuni[i].goal == "mers")
            {
                misiuni[i].progres = (int)player.score;

                if (misiuni[i].progres >= misiuni[i].cerinta)
                {
                    PlayerManager.numarBanutzi += misiuni[i].bani;
                    PlayerManager.exp += misiuni[i].exp;

                    Debug.Log("Misiune Completa!");

                    //ReincarcaMisiuni(i);
                    misiuni[i].isComplete = true;
                    misiuni[i].isActive = false;



                    Misiune1.SetActive(false);
                }
            }
            else if (misiuni[i].goal == "sare")
            {
                misiuni[i].progres = progresCM;
                progres = progresCM;
                if (misiuni[i].progres >= misiuni[i].cerinta)
                {
                    PlayerManager.numarBanutzi += misiuni[i].bani;
                    PlayerManager.exp2 += misiuni[i].exp;

                    Debug.Log("Misiune Completa!");

                    //ReincarcaMisiuni(i);
                    misiuni[i].isComplete = true;
                    misiuni[i].isActive = false;



                    Misiune1.SetActive(false);
                }
            }
            else if (misiuni[i].goal == "bani")
            {
                misiuni[i].progres = progres;
                if (misiuni[i].progres >= misiuni[i].cerinta)
                {
                    PlayerManager.numarBanutzi += misiuni[i].bani;
                    PlayerManager.exp2 += misiuni[i].exp;

                    Debug.Log("Misiune Completa!");

                    //ReincarcaMisiuni(i);
                    misiuni[i].isComplete = true;
                    misiuni[i].isActive = false;



                    Misiune1.SetActive(false);
                }
            }
            else if (misiuni[i].goal == "NM")
            {
                misiuni[i].progres += 1;
            }

        }


    }


    /*public bool CompletM()
    {
        return (progress >= cerinta);
    }
    */
}

public enum GoalType
{
    colecteaza,
    mergi,
    saripeste

}
