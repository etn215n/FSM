using UnityEngine;

public class FreeMove : FSMAction
{
    public float moveSpeed;


    public void Move(Vector2 direction, Rigidbody2D rb)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
