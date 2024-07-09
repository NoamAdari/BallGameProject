using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

namespace DefaultNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        public int score = 0;

        public ScoreManager()
        {
           
        }

        public void addCount(int amount)
        {
            score += amount;
        }
        
        public int GetCount()
        {
            return this.score;
        }
        
    }
}