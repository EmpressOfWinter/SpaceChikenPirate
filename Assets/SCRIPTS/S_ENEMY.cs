using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ENEMY : MonoBehaviour
{
    [Header ("ENEMY HEALTH")]
    public int EnemyHealth;
    public int DamageTaken;

    [Header("ENEMY CONTROLS")]
    public float speed;
    public GameObject effect;

    void Start() 
    {
        EnemyHealth = Random.Range(2,3);
        Debug.Log ("Enemy health" + EnemyHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            //player takes damage
            other.GetComponent<S_PLAYER_SWIP>().health--;
            
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Borders"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("BULLET"))
        {
            DamageTaken =  other.GetComponent<S_Bullet>().Damage;
            EnemyHealth -= DamageTaken; 

            if (EnemyHealth == 0) 
            {
                other.GetComponent<S_Bullet>().Weapon.GetComponent<S_PLAYER_WEAPON>().score++;
            
                Destroy(gameObject);
            } 
 
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
