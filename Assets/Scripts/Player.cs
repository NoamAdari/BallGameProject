using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private float moveSpeed = 7f;
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = +1;
        } if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = -1;
        } if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        } if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = +1;
        }
        
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        float playerSize = .7f;
        bool canMove = !Physics.Raycast(transform.position, moveDir, playerSize);

        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (GameManager.ballList.Contains(collision.gameObject))
        {

            Ball ball = collision.gameObject.GetComponentInChildren<Ball>();

            //If the GameObject's name matches the one you suggest, output this message in the console
            Destroy(collision.gameObject);

            Debug.Log("Object touched player +1");

            ScoreManager scoreManager = GameManager.scoreManager;

            int score = scoreManager.GetCount() + ball.GetScoreGiven();
            scoreManager.addCount(ball.GetScoreGiven());

            if (this.txt != null)
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
