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
        Transform collider = collision.GetComponent<Transform>();
        if (collision.CompareTag("Start"))
        {
            while (rb.velocity.x < maxRunningSpeed)
            {
                rb.velocity = new Vector2(vSpeed += runningIncreaseSpeed, 0);
                currentPlayerState = "Running";
            }
        }
        else if (collision.CompareTag("Rope"))
        {
            if (Input.GetKeyDown("space"))
            {
                transform.SetParent(collider);
                rb.simulated = false;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                rb.simulated = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            rb.velocity = new Vector2(vSpeed, jumpPower);
        }
    }
}
