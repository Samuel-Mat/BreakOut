using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class item : MonoBehaviour
{
    
    public bool createOneBall = false;
    public bool scalePlayerUp = false;
    public bool scalePlayerDown = false;
    public bool ballIsStrong = false;
    private string itemName;




    // Start is called before the first frame update
    void Start()
    {
        ItemDefinieren();
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
    
            switch (itemName)
            {
               
                case "OneBall":
                    createOneBall = true;
                    break;
                case "ScaleUp":
                    scalePlayerUp = true;
                    break;
                case "StrongBall":
                    ballIsStrong = true;
                    break;
                case "ScaleDown":
                    scalePlayerDown = true;
                    break;
            }
           
        }

        if(collision.gameObject.CompareTag("death"))
        {
            Destroy(gameObject);
        }
    }



    public void ItemDefinieren()
    {
        int chosenItem = Random.Range(2, 6);

        switch (chosenItem)
        {
            
            //1 Ball taucht auf
            case 2:
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            itemName = "OneBall";
            break;
            //Plattform wird grösser
            case 3:
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            itemName = "ScaleUp";
            break;
            //Ball geht für 10 Sekunden durch die Blöcke durch ohne abzuprallen
            case 4:
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            itemName = "StrongBall";
            break;
            //Plattform wird kleiner
            case 5:
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            itemName = "ScaleDown";
            break;



        }




       

    }
}
