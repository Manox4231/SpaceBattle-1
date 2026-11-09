using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform[] spawns;
    [SerializeField] public GameObject enemySP;
    [SerializeField] float Timer;
    [SerializeField] float CountTo;
    //[SerializeField] public SpaceshipScript spaceshipScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer+=1*Time.deltaTime;
        if (Timer >= CountTo) //Se completa el timer 
        {
            Timer = 0; //Reset al timer

            GameObject newEnemy = Instantiate(enemySP);//Crea una manzana

            newEnemy.transform.position = spawns[Random.Range(0,spawns.Length)].transform.position;//Coloca la manzana
        }
    }
    /*
    public void destroyPrefab()
    {
        foreach(GameObject Enemy in enemyDestroy)
        {
            Destroy(Enemy);
        }
        enemyDestroy.Clear();
    }
   /* 
    public void DestroyEnemy()
    {
       foreach (GameObject enemy in enemyDestroy)
        {
            enemyList.Remove(enemyPrefab);
        
            Destroy(enemyPrefab);

        }
    }
    */

    
}
