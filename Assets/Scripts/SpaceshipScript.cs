using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] float speed=2;
    [SerializeField] float ShootCooldown;
    [SerializeField] bool CanShoot=true;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController=GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(ShootCooldown);
        Debug.Log ("Ya puedes disparar");
        CanShoot=true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && CanShoot)
        {
            Debug.Log("Disparo /n A esperar");
            StartCoroutine(EnableShoot());
            CanShoot=false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed ) ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed ) ;
        }
        
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemigo detectado");
            
            Destroy(collision.transform.parent.gameObject);
        }
    }
    

}
