using UnityEngine;

public class ParteInferior : MonoBehaviour
{
    //Creamos todas las variables que vayamos a usar y las referencias a los gameObjects/scripts que vayamos a usar
    [SerializeField] GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("¡¡¡Se ha colado un enemigo!!!");
            gameController.PerderVidas(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Debug.Log("¡¡¡Se ha colado un jefe enemigo!!!");
            gameController.PerderVidas(gameController.vidaBoss);
            Destroy(collision.gameObject);
        }
    }
}
