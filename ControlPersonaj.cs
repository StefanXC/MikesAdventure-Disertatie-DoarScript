using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaj : MonoBehaviour
{
    private CharacterController controller;
    public CapsuleCollider capsCollider;
    private Vector3 direction;
    
    public float viteza; //viteza de msicare cu care incepe personajul
    public float vitezaMaxima;//viteza maxima pe care o poate atinge personajul

    public Animator[] anim; //lista cu componentele Animator ale caracterelor

    private int bandaDorita = 1; //banda pe care trebuie sa fie personajul
    public float latimeBanda = 1; //latimea benzilor 1 2 si 3

    public float saritura = 15; //forta personajului pentru saritura
    public float gravitatie = 20;//forta gravitationala

    private float verticalVelocity;

    private bool isRolling = false;

    public int personajCurent;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        personajCurent = PlayerPrefs.GetInt("PersonajActiv", 0);
    }

    public void Pause() //functie apelata in momentul in care dorim sa oprin temporar animatia
    {
        //for (int i = 0; i < anim.Length; i++)
            //anim[i].gameObject.GetComponent<Animator>().enabled = false;

        anim[personajCurent].gameObject.GetComponent<Animator>().enabled = false;
    }

    public void Resume() //functie apelata in momentul in care dorim sa reluam animatiile
    {
        //for (int i = 0; i < anim.Length; i++)
            //anim[i].gameObject.GetComponent<Animator>().enabled = true;

        anim[personajCurent].gameObject.GetComponent<Animator>().enabled = true;
    }

    public void EndAnim() //functia apelata in momentul in care dorim sa oprim animatiile
    {
        //for (int i = 0; i < anim.Length; i++)
            //anim[i].gameObject.GetComponent<Animator>().enabled = false;

        anim[personajCurent].gameObject.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {

        //for (int i = 0; i < anim.Length; i++)
        //{
        //   anim[i].SetFloat("Speed", viteza);

        // }  

        anim[personajCurent].SetFloat("Speed", viteza); //cat timp personajul se misca in directia Z animatia de alergat va rula


        if (viteza < vitezaMaxima) //verificam daca viteza curenta este mai mica de cat viteza maxima
            viteza += 0.1f * Time.deltaTime; //marim viteza de miscare curenta

        direction.z = viteza;

       

        if (MenegerGlisare.glisareDreapta)//verificam daca jucatorul a glisat catre dreapta
        {
            SchimbaBanda(true);
            StartCoroutine(Dreapta());
        }


        if (MenegerGlisare.glisareStanga)//verificam daca jucatorul a glisat catre stanga
        {
            SchimbaBanda(false);
            StartCoroutine(Stanga());
        }

        Vector3 targetPossition = transform.position.z * Vector3.forward;

        if (bandaDorita == 0)
            targetPossition += Vector3.left * latimeBanda;
        else if (bandaDorita == 2)
            targetPossition += Vector3.right * latimeBanda;

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPossition - transform.position).normalized.x * viteza;

        //if(PePamant())
        if(controller.isGrounded)//verificam daca personajul atinge strada
        {
            //for (int i = 0; i < anim.Length; i++)
            //{
            //    anim[i].SetBool("Sare", false);
            //}

            anim[personajCurent].SetBool("Sare", false);//oprim animatia de sarit


            verticalVelocity = -0.1f;
            if(MenegerGlisare.glisareSus)//verificam daca jucatorul a glisat in sus
            {
                // for (int i = 0; i < anim.Length; i++)
                //{
                //   anim[i].SetBool("Sare", true);
                //}

                anim[personajCurent].SetBool("Sare", true);//pornim animatia de sarit

                verticalVelocity = saritura;
                
            }

            if (MenegerGlisare.glisareJos && !isRolling)//verificam daca jucatorul a glisat in jos
            {
                StartCoroutine(Roll());
            }
        }
        else
        {
            verticalVelocity -= (gravitatie * Time.deltaTime);

            if(MenegerGlisare.glisareJos)//verificam daca jucatorul a glisat in jos in timpul sariturii
            {
                verticalVelocity = -saritura;//daca a glisat atunci personajul va ateriza mult mai repede
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = viteza;

        controller.Move(moveVector * Time.deltaTime);

    }

    private void Jump()
    {
        direction.y = saritura;
        Debug.Log("sare2");

        //for (int i = 0 ; i < anim.Length ; i++)
        //{
        //    anim[i].SetBool("Sare", true);
        //}  

        anim[personajCurent].SetBool("Sare", true);

    }

    private void SchimbaBanda(bool goingRight)
    {
        bandaDorita += (goingRight) ? 1 : -1; //verificam daca jcuatorula glisat catre dreapta
        bandaDorita = Mathf.Clamp(bandaDorita, 0, 2); //folosim math.clamp pentru a seta valoarea minima 0 si valoarea maxima 2
        //orice valaore ce nu se regaseste in acest interval nu va fi atribuita
    }

    private IEnumerator Dreapta()
    {

        /*for (int i = 0; i < anim.Length; i++) o varianta de animat ineficienta
        {

            anim[i].SetBool("Dreapta", true);
        }
        */

        anim[personajCurent].SetBool("Dreapta", true); //pornim animatia de facut dreapta 

        yield return new WaitForSeconds(0.3f);//functia ia o pauza de 1/3 secunde dupa care continua

        /*for (int i = 0; i < anim.Length; i++) o varianta de animat ineficienta
        {

            anim[i].SetBool("Dreapta", false);
        }
        */

        anim[personajCurent].SetBool("Dreapta", false);//oprim animatia de facut dreapta 

        Debug.Log("Dreapta");

    }

    private IEnumerator Stanga()
    {

        /*for (int i = 0; i < anim.Length; i++) o varianta de animat ineficienta
        {

            anim[i].SetBool("Stanga", true);
        }
        */

        anim[personajCurent].SetBool("Stanga", true);//pornim animatia de facut stanga 

        yield return new WaitForSeconds(0.3f); //functia ia o pauza de 1/3 secunde dupa care continua

        /*for (int i = 0; i < anim.Length; i++) o varianta de animat ineficienta
        {
            anim[i].SetBool("Stanga", false);
        }
        */

        anim[personajCurent].SetBool("Stanga", false);//oprim animatia de facut stanga
        Debug.Log("Stanga");

    }

    private IEnumerator Roll()
    {
        /*for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Stanga", false);
        }

        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Dreapta", false);
        }*/

        isRolling = true;
        controller.center = new Vector3(0, -0.5f, 0);//modificam pozitia controller-ului(script prestabilid de Unity)
        controller.height = 1; //setam inaltimea controller-ului(script prestabilid de Unity)

        capsCollider.center = new Vector3(0, -0.5f, +0.5f);//modificam pozitia --collider-ului de tip capsula--
        capsCollider.height = 1;//setam inaltimea --collider-ului de tip capsula--

        //for (int i = 0; i < anim.Length; i++)
        //{
        //    anim[i].SetBool("isRolling", true);         
        //}

        anim[personajCurent].SetTrigger("Rolling");//activam animatia de rostogolit

        yield return new WaitForSeconds(0.9f);//functia ia o pauza de 0.9 secunde dupa care continua

        //for (int i = 0; i < anim.Length; i++)
        //{

        //   anim[i].SetBool("isRolling", false);
        //}

        controller.center = new Vector3(0, 0, 0);//modificam pozitia controller-ului(script prestabilid de Unity)
        controller.height = 2;//setam inaltimea controller-ului(script prestabilid de Unity)

        capsCollider.center = new Vector3(0, 0, +0.5f);//modificam pozitia --collider-ului de tip capsula--
        capsCollider.height = 2;//setam inaltimea --collider-ului de tip capsula--

        isRolling = false;
    }

    private bool PePamant()
    {
        Ray groundRay = new Ray( new Vector3( controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,controller.bounds.center.z), Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);
        
        return (Physics.Raycast(groundRay, 0.2f + 0.1f));

    }

}
