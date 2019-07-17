using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    public BoxCollider2D keepRunningTrigger;
    public int maxRunningSpeed;
    public int jumpPower;
    public float runningIncreaseSpeed;
    public string currentPlayerState;

    private Rigidbody2D rb;
    private float vSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vSpeed = rb.velocity.x;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        while (rb.velocity.x < maxRunningSpeed)
        {
            rb.velocity = new Vector2(vSpeed += runningIncreaseSpeed, 0);
            currentPlayerState = "Running";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.velocity = new Vector2(vSpeed, jumpPower);
    }
}
