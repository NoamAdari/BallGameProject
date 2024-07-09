using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private ScoreManager _scoreManager;
    [SerializeField] private float startingTime = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.startingTime -= Time.deltaTime;
        if (this.startingTime < 0)
        {
            
        }
    }
}
