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

    private bool addindScore;

   public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bullet.GetComponent<S_Bullet>().Weapon = this.gameObject;

    }

    private void Start()
    {
        addindScore = false;
        score = 0;
    }

    void Update()
    {
        if (addindScore == false)
        {
            StartCoroutine(ScoreTimer());
            addindScore = true;
        }

        ScoreDisplay.text = score.ToString();
    }

    IEnumerator ScoreTimer()
    {
        yield return new WaitForSeconds(1);
        addindScore = false;
        score++;
    }

}
