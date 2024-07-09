using UnityEngine;
namespace DefaultNamespace
{
    public class SelfDestruct : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (transform.position.y <= 1)
            {
                Destroy(gameObject);
            }
        }
    }
}