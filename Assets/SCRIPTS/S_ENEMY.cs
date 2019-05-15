using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ENEMY : MonoBehaviour
{
    public int damage = 1;

    public float speed;
    public GameObject effect;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            //player takes damage

            other.GetComponent<Player>().health--;
            
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        if (other.CompareTag("Borders"))
        {
        Destroy(gameObject);
        }
           

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


    }
}
