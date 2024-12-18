using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] protected ParticleSystem trailDustEffect;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            trailDustEffect.Play();
    }

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            trailDustEffect.Stop();
    }
}
