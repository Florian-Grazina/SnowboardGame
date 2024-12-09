using UnityEngine;

public class FinishLine : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            Debug.Log("Finish Line!");
    }
}
