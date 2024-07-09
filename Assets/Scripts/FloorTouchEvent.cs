using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using TMPro;

public class FloorTouchEvent : MonoBehaviour
{

    public TextMeshPro txt;

    void Start()
    {
        this.txt = GameObject.Find("ScoreText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {


        Debug.Log("Collision detected with: " + collision.gameObject.name);
        //Check for a match with the specified name on any GameObject that collides with your GameObject

        if (GameManager.ballList.Contains(collision.gameObject))
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Destroy(collision.gameObject);

            Debug.Log("Object touched floor -1");

            ScoreManager scoreManager = GameManager.scoreManager;

            int score = scoreManager.GetCount() - 1;
            scoreManager.addCount(-1);

            if (txt != null)
            {
                this.txt.text = "Score: " + score;
            }
            else
            {
                Debug.LogError("Text component not found!");
            }
        }


    }

}