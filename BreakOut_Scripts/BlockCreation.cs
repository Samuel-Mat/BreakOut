using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockCreation : MonoBehaviour
{
    private int blockNumber = 1;
    private int rowCounter = 0;

    //Inspired by https://gamedevbeginner.com/how-to-spawn-an-object-in-unity-using-instantiate/

    public GameObject newBlock;
    public Transform parent;
    private Vector2 position = new Vector2( -6.5f,3.6f) ;
    private Quaternion rotation;
    private float counter;
    private double timeToNewRow = 15;



    void Start()
    {
        while (rowCounter != 4)
        {
            GameObject block = Instantiate(newBlock, position, rotation, parent);
            position.x +=  1.4f;
            Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            var renderer = block.GetComponent<Renderer>();
            renderer.material.color = color;
            if (blockNumber % 11 == 0 && blockNumber != 0)
            {
                position.y -= 1f;
                position.x = -6.5f;

                rowCounter++;
               
            }
 
            blockNumber++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Idea with the counter from: https://www.gutefrage.net/frage/wie-kann-ich-einen-unity-c-script-in-5-sekunden-wiederholen
        counter += Time.deltaTime;
        if (counter >= timeToNewRow)
        {
            if (timeToNewRow > 7)
            {
                timeToNewRow = timeToNewRow - 0.05;
            }
            counter = 0; 
            CreateNewRow();
        }
       
    }

    public void CreateNewRow()
    {
        int i = 0;
        position.x = -6.5f;
        position.y = 3.6f;
        MoveRowsDown();

        while (i != 11)
        {
            
            GameObject block = Instantiate(newBlock, position, rotation, parent);
            Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            var renderer = block.GetComponent<Renderer>();
            renderer.material.color = color;
            position.x += 1.4f;
            i++;
        }
 

    }
    public void MoveRowsDown()
    {
        List <GameObject> blockswe = new List <GameObject>();
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("destroyable");
        for(int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = blocks[i].transform.position - new Vector3(0f, 1f);
        }

    }
}
