using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorNivel : MonoBehaviour
{
    public GameObject[] modelStrazi; //lista ce contine toate modelele de strada
    public float punctDeRandare = 0; //punctul din care se va incepe alcatuirea nivelului
    public float lungimeStrada = 50; //lungimea segmentelor de strazi
    public int numarStrazi = 2;  //numarul strazilor active (numaratoarea incepe de la 0)

    private List<GameObject> straziActive = new List<GameObject>(); //lista strazilor active 

    public Transform playerTransform;

    void Start()
    {
        AdaugaStrada(0); //nivelul va incepe de fiecare data cu modelul de strada 0
        //SpawnTile(1);
        //SpawnTile(4);

        for (int i = 0; i < numarStrazi; i++)
        {
            //if (i == 0)
                //SpawnTile(0);
            //else
                AdaugaStrada(Random.Range(1, modelStrazi.Length)); //se va genera un model de strada aleator
        }
    }

    void Update()
    {
        if (playerTransform.position.z > punctDeRandare - (numarStrazi * lungimeStrada)) //verificam pozitia personajului fata de punctul de randare
        {
            AdaugaStrada(Random.Range(1, modelStrazi.Length)); //vom adauga o strada generata aleatoriu din colectie
            EliminaStrada(); //vom elima cea mai veche strada generata
        }
    }

    public void AdaugaStrada(int tileIndex) //functia care  adauga o strada generata aleatoriu din colectie
    {
        GameObject go = Instantiate(modelStrazi[tileIndex],transform.forward *punctDeRandare,transform.rotation);
        straziActive.Add(go);
        punctDeRandare += lungimeStrada;
    }

    private void EliminaStrada() //functia care elima cea mai veche strada generata
    {
        Destroy(straziActive[0]);
        straziActive.RemoveAt(0);
    }

}


