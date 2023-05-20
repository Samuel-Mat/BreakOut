
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ballMovement : MonoBehaviour
{
    public int speed;
    public Vector2 ballPosition;
    private Vector2 startPosition = Vector2.zero;
    public player player;
    public GameObject item;
    public GameObject heart;
 

  

    // Start is called before the first frame update
    void Start()
    {
    player = GameObject.Find("player").GetComponent<player>();
    StartBall();
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ballPosition.x = ballPosition.x + player.move.x;
            ballPosition.y = -ballPosition.y;
        }

        else if (other.gameObject.CompareTag("border"))
        {
      
            ballPosition.x = -ballPosition.x;
        }

        else if (other.gameObject.CompareTag("topBorder"))
        {
            ballPosition.y = -ballPosition.y;
        }
        

        else if (other.gameObject.CompareTag("destroyable"))
        {
            Vector2 itemPosition = other.gameObject.transform.position;
            Quaternion rotation = Quaternion.identity;

            if (!player.strongBall)
            {
                if (gameObject.transform.position.y <= other.gameObject.transform.position.y - 0.25 || gameObject.transform.position.y >= other.gameObject.transform.position.y + 0.25)
                {
                    ballPosition.y = -ballPosition.y;
                   
                }
                else if (gameObject.transform.position.x <= other.gameObject.transform.position.x - 0.45 || gameObject.transform.position.x >= other.gameObject.transform.position.x + 0.45)
                {
                    ballPosition.x = -ballPosition.x;
                    
                }

            }
            UIScript ui = GameObject.Find("UI").GetComponent<UIScript>();
            ui.IncreaseScore(20);
           
            Destroy(other.gameObject);
            int itemNumber = Random.Range(0, 15);

            if(itemNumber == 7)
            {
                GameObject newItem = Instantiate(item, itemPosition, rotation);
            }

            SpawnHeart(other.gameObject.transform.position);


         
         

        }

        else if (other.gameObject.CompareTag("death"))
        {
            transform.position = startPosition;
            Destroy(gameObject);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        
            if(balls.Length == 1)
            {
                UIScript ui = GameObject.Find("UI").GetComponent<UIScript>();
                ui.DecreaseLives();
                player.NewBall(Vector2.zero);
            }
          

        }
        if (speed < 7)
        {
            speed++;
        }



    }

    public void SpawnHeart(Vector2 position)
    {
        Quaternion rotation = Quaternion.identity;
        int randomNumber = Random.Range(0, 61);
        if(randomNumber == 33)
        {
            Instantiate(heart, position, rotation );
        }

        
    }


    public void StartBall()
    {
       
        speed = 3;
        ballPosition = new Vector2(0f, -2f);
        transform.position = (ballPosition);

        ballPosition = new Vector2(Random.Range(0, 1), -Random.Range(0,0.3f));
        ballPosition.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(player.strongBall == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if(player.strongBall == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        
        ballPosition.y -= 0.00001f;
  
        ballPosition.Normalize();

        if(gameObject.transform.position.x < -8 || gameObject.transform.position.x > 8)
        {
            ballPosition.x = -ballPosition.x;
        }

        transform.Translate(ballPosition * Time.deltaTime * speed);

    }
}
