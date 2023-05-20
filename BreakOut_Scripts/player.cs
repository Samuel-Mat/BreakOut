
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class player : MonoBehaviour
{
    public float speed = 4f;
    public bool touchWallLeft = false;
    public bool touchWallRight = false;
    public Vector2 position;
    public  Vector2 move = Vector2.zero;
    private float counter = 0;
    public bool strongBall = false;
    public GameObject ball;



    private void Start()
    {
        NewBall(Vector2.zero);
    }


    void Update()
    {
        if (strongBall == true)
        {
            counter += Time.deltaTime;

            if (counter >= 10)
            {
                counter = 0;
                strongBall = false;
            }
        }

        

        position = transform.position;
        move = Vector2.zero;
  

        if (!touchWallLeft)
        {


            
            if (Input.GetKey(KeyCode.A))
            {
                move = Vector2.left;
            }
           
        }
        if (!touchWallRight)
        {

            if (Input.GetKey(KeyCode.D))
            {
                move = Vector2.right;
            }

            
        }
       
        transform.Translate(move * Time.deltaTime * speed);

    }

    public void ScaleDown()
    {
        if (gameObject.transform.localScale.x >= 0.6f)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x - 0.2f, 0.4f);
        }
    }
    public void ScaleUp()
    {
        if (gameObject.transform.localScale.x <= 2.4f)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x + 0.1f, 0.4f);
        }
    }
    public void NewBall(Vector2 ballPosition)
    {
        GameObject parent = GameObject.Find("balls");
        Quaternion rotation = Quaternion.identity;
      
        GameObject newBall = Instantiate(ball, ballPosition, rotation, transform.parent );
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        UIScript ui = GameObject.Find("UI").GetComponent<UIScript>();
        if (collision.gameObject.CompareTag("border") && collision.transform.position.x < 0){
            touchWallLeft = true;   
        }
        if (collision.gameObject.CompareTag("border") && collision.transform.position.x > 0)
        {
            touchWallRight = true;
        }
        if (collision.gameObject.CompareTag("item")) {
            ui.IncreaseScore(50);
            item item = collision.gameObject.GetComponent<item>() ;
            if (item.scalePlayerDown == true)
            {
                item.scalePlayerDown = false;            
               ScaleDown();
            }
            if(item.scalePlayerUp == true)
            {
                item.scalePlayerUp = false;
                ScaleUp();
            }
            if (item.ballIsStrong == true)
            {
                item.ballIsStrong = false;
                counter = 0;
                strongBall = true;
        
            }
            if(item.createOneBall == true)
            {
                item.createOneBall = false;
                GameObject[] newBallPosition = GameObject.FindGameObjectsWithTag("ball");
                NewBall(newBallPosition[0].transform.position);
            }
            
            Destroy(item.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("heart"))
        {
           
            ui.IncreaseLives();
            ui.IncreaseScore(100);
            Destroy(collision.gameObject);
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("border"))
        {
            touchWallLeft = false;
        }
        if (collision.gameObject.CompareTag("border"))
        {
            touchWallRight = false;
        }
    
    }
}
