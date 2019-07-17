using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject anchor;
    public GameObject chainSprite;
    [SerializeField] private int chains = 6;

    // Start is called before the first frame update
    void Start()
    {
        CreateRope();
    }

    private void CreateRope()
    {

        Rigidbody2D previousChain = anchor.GetComponent<Rigidbody2D>();
        for (int x = 0; x < chains; x++)
        {
            GameObject chain =  Instantiate(chainSprite, transform);
            HingeJoint2D hinge = chain.GetComponent<HingeJoint2D>();
            hinge.connectedBody = previousChain;
            previousChain = chain.GetComponent<Rigidbody2D>();
        }
    }
}
