using UnityEngine;

public class ParteInferior : MonoBehaviour
{
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
            
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
