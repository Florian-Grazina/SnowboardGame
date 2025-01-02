using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float torqueAmount = 1f;
    [SerializeField] protected float boostSpeed = 35f;
    [SerializeField] protected float baseSpeed = 20f;

    protected new Rigidbody2D rigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

    #region public methods
    public void DisableControls()
    {
        canMove = false;
    }
    #endregion

    #region protected methods
    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    protected void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
    #endregion

    #region private methods
    private void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }
    #endregion
}
