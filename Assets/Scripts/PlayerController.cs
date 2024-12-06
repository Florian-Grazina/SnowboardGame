using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected float torqueAmount = 1f;

    protected new Rigidbody2D rigidbody2D;

    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    protected void Update()
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
}
