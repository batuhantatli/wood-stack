using UnityEngine;

public class TreeDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GroundTag"))
        {
            Destroy(gameObject);
        }
    }
}
