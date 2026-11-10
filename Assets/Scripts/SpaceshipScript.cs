using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms.Impl;

public class SpaceshipScript : MonoBehaviour
{
    //Creamos todas las variables que vayamos a usar y las referencias a los gameObjects/scripts que vayamos a usar
    [SerializeField] GameController gameController;
    [SerializeField] GameObject proyectil;
    [SerializeField] float speed;
    [SerializeField] float ShootCooldown;
    [SerializeField] bool CanShoot=true;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator EnableShoot() //Corrutina para el cooldown del disparo
    {
        yield return new WaitForSeconds(ShootCooldown);
        Debug.Log ("Ya puedes disparar");
        CanShoot=true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && CanShoot)//Disparo
        {
            GameObject Disparo = Instantiate(proyectil);
            Disparo.transform.position = transform.position + new Vector3 (0,1,0);
            Debug.Log("Disparo \nA esperar");
            StartCoroutine(EnableShoot());
            CanShoot=false;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed ) ; //Movimiento a la derecha con AddForce
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed ); //Movimiento a la izquierda con AddForce
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")//Detectamos si son enemigos
        {
            gameController.PerderVidas(gameController.vidas);
        }
    }

}
