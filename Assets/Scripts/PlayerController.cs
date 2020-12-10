using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 6f;
    private float jumpPower = 6f;

    public Rigidbody playerRB;

    private bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movements WASD
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        //Jumping, Single
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            PlayerJump();
        }

        if (transform.position.y <= -1)
        {
            Debug.Log("Lose!");
        }
    }

    void PlayerJump()
    {
        isOnGround = false;
        playerRB.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            isOnGround = true;
            //Debug.Log("touch");
        }

        if (collision.gameObject.CompareTag("DissPlat"))
        {

        }
    }
}
