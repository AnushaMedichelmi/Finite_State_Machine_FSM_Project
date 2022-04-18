using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health;
    public bool isDead=false;
    public GameObject enemy;
    public float playerSpeed;
    public float rotationSpeed;
    Rigidbody rb;
    public Vector3 targetVelocity;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.freezeRotation = true;
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, Input.GetAxis("Mouse Y"),0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
