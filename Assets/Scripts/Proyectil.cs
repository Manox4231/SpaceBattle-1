using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //Creamos todas las variables que vayamos a usar y las referencias a los gameObjects/scripts que vayamos a usar
    [SerializeField] GameController gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController=GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemigo abatido");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameController.Puntaje(1);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Debug.Log("Jefe impactado");
            gameController.DanoBoss(1);
            if (gameController.vidaBoss == 0)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
            gameController.Puntaje(1);
        }
    }
}
