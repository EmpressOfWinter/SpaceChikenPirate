using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PLAYER_SWIP : MonoBehaviour
{
    [Header("HEALTH")]
    public int health;
    public Text healthDisplay;

    [Header("CONTROLS")]
    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;


    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    void Update()
    {
        //health 
        if (health <= 0)
        {
            //spawner.SetActive(false);
            //restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();



        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {

        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }
    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    void OnSwipeUp()
    {
        //Do something when swiped up

        //camAnim.SetTrigger("shake");
        //Instantiate(moveEffect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y + increment);
           

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
        

    void OnSwipeDown()

    {
            //Do something when swiped down
            
                //camAnim.SetTrigger("shake");
                //Instantiate(moveEffect, transform.position, Quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y - increment);
                

                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            
    }

    void OnSwipeLeft()
    {
            //Do something when swiped left

            //camAnim.SetTrigger("shake");
            //Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x - increment, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    void OnSwipeRight()
    {
            //Do something when swiped right
            //camAnim.SetTrigger("shake");
            //Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x + increment, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    


}
