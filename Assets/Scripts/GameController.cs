using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    //Creamos todas las variables que vayamos a usar y las referencias a los gameObjects/scripts que vayamos a usar
    [SerializeField] public int score;
    [SerializeField] public int BossCounter;
    [SerializeField] public int vidas;
    [SerializeField] public int vidaBoss;
    [SerializeField] private GameObject nave;
    [SerializeField] public GameObject enemySP;
    [SerializeField] public GameObject enemyBoss;
    [SerializeField] float Timer;
    [SerializeField] float CountTo;
    //[SerializeField] public SpaceshipScript spaceshipScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        BossCounter = 0;
        Timer = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (vidas > 0)
        {
            Timer += 1 * Time.deltaTime;
            if (Timer >= CountTo && BossCounter < 10) //Se completa el timer 
            {
                Timer = 0; //Reset al timer

                GameObject newEnemy = Instantiate(enemySP);//Crea la nave

                newEnemy.transform.position = new Vector3 (Random.Range(-7f,7f), 10, 0);//Posiciona la nave
            }
            else if (Timer >= CountTo && BossCounter >= 10)
            {
                Timer = 0; //Reset al timer

                BossCounter = 0; //Reset a la cuenta para que aparezca un jefe

                GameObject newBoss = Instantiate(enemyBoss);//Crea al jefe

                newBoss.transform.position = new Vector3 (Random.Range(-7f,7f), 10, 0);//Posiciona al jefe

                vidaBoss = 3;
            }
        }
    }
    public void PerderVidas(int i)
    {
        vidas -= i;
        if (vidas <= 0)
        {
            Debug.Log("Final Score: " + score + "\nGame over");
            Destroy(nave); //Destruimos desde aqui para no tener que hacer el chec de vidas en cada script
        }
    }
    public void Puntaje(int i)
    {
        score+= i;
        BossCounter +=i;
    }
    public void DanoBoss(int i)
    {
        vidaBoss-= i;
    }
    
}
