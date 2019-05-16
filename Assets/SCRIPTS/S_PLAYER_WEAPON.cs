using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PLAYER_WEAPON : MonoBehaviour
{
    public Text ScoreDisplay;


    public Transform firepoint;
    public GameObject bulletPrefab;

    public int score;

   public void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        ScoreDisplay.text = score.ToString();
    }

}
