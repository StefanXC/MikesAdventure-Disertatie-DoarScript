using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int nivel;
    public int exp;
    public int banutziTotal;
    public float scorMaxim;
   
    public PlayerData(PlayerManager playerManager)
    {
   
        banutziTotal = playerManager.banutziT;
        scorMaxim = playerManager.scorMax;
        nivel = playerManager.nivel;
        exp = playerManager.exp;    

    }
}
