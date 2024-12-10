using UnityEngine;

public class enemyInRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            other.gameObject.tag = $"{other.gameObject.tag}/InRange";
        }

        if (other.gameObject.tag.Contains("Chest"))
        {
            other.gameObject.tag = $"{other.gameObject.tag}/InRange";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("InRange"))
        {
            other.gameObject.tag = other.gameObject.tag.Replace("/InRange", "");
        }
    }
}
