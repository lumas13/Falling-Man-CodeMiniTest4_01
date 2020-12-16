using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float jumpPower = 6f;
    private float jumpTime = 1.5f;

    private bool isOnGround;

    public Animator playerAni;
    public Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        //Physics.gravity *= Vector3(0, -1.0, 0);
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        PlayerLose();
    }

    void PlayerJump()
    {
        //Single Jump
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRB.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
    void PlayerMovement()
    {
        //Movements WASD
        if (Input.GetKey(KeyCode.W))
        {
            playerAni.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAni.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        { 
            playerAni.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerAni.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerAni.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAni.SetBool("isRunning", false);
        }
    }
    void PlayerLose()
    {
        //Check if player is out of bounds (put into a fucntion soon)
        if (transform.position.y <= -1)
        {
            Debug.Log("Lose!");
            SceneManager.LoadScene("LoseScene");
        }
        else if (transform.position.x <= -15 || transform.position.x >= 15)
        {
            Debug.Log("Lose!");
            SceneManager.LoadScene("LoseScene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("DissPlat"))
        {
            isOnGround = true;           
        }
        
        if (collision.gameObject.CompareTag("WinCube"))
        {
            SceneManager.LoadScene("WinScene");
        }

        if (collision.gameObject.CompareTag("FallingBalls"))
        {
            transform.position = new Vector3(0f, 1.2f, 133f);
        }
    }
}
