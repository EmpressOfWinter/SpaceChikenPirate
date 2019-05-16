using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Bullet : MonoBehaviour
{
    
    
    public GameObject Weapon;
    public float speed = 20f;
    private Rigidbody2D rb;

    

    public float timer;

   

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    
            

    

    void Update()
    {

        
        timer += 1.0f * Time.fixedDeltaTime;
        
        if (timer >= 4)
        {
            Debug.Log("Hit nothing!");
            Destroy(gameObject);
        }
    }
}
