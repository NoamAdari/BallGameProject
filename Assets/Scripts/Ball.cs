using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
        public int ScoreGiven=0;
        public Ball()
        {
            
        }

        public int GetScoreGiven()
        {
            return this.ScoreGiven;
        }
}

