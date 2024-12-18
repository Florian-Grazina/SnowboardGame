using System;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] protected ParticleSystem trailDustEffect;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            trailDustEffect.Play();
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            trailDustEffect.Stop();
    }
}
