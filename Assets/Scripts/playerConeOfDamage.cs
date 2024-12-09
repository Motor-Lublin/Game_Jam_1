using UnityEngine;

public class enemyInRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.tag = "Enemy/InRange";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //other.GetComponent<distanceScript>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy/InRange")
        {
            other.gameObject.tag = "Enemy";
        }
    }
}
