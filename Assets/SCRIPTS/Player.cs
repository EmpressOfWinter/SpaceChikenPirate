using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public Text healthDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            //spawner.SetActive(false);
            //restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();


    }
}
