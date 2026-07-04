using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRB;

    [Header("Movement")]
    public float PlayerMaxSpeed = 3f;
    public float PlayerGroundForce = 1f;
    public float PlayerAirForce = 5f;
    private float PlayerMovementForce;

    [Header("Jump")]
    public float PlayerJumpForce = 5f;

    [Header("Ground Check")]
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        PlayerMovementForce = PlayerGroundForce;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
        
        // if (GroundCheckFunction())
        // {
        //
        //     
        //     if (PlayerMovementForce != PlayerGroundForce)
        //     {
        //         PlayerMovementForce = PlayerGroundForce;
        //     }
        // }
        // else
        // {
        //     if (PlayerMovementForce != PlayerAirForce)
        //     {
        //         PlayerMovementForce = PlayerAirForce;
        //     }
        // }

        if (Input.GetKey(KeyCode.W))
        {
            PlayerMoveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerMoveBack();
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerMoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerMoveRight();
        }
    }

    void PlayerJump()
    {
        playerRB.AddForce(Vector3.up * PlayerJumpForce, ForceMode.Impulse);
    }

    void PlayerMoveForward()
    {
        playerRB.AddForce(Vector3.forward * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveBack()
    {
        playerRB.AddForce(Vector3.back * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveLeft()
    {
        playerRB.AddForce(Vector3.left * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveRight()
    {
        playerRB.AddForce(Vector3.right * PlayerMovementForce, ForceMode.Force);
    }

    // void PlayerLimitVelocity()
    // {
    //     Vector3 horizontalVelocity = new Vector3(
    //         playerRB.linearVelocity.x,
    //         0,
    //         playerRB.linearVelocity.z);
    //
    //     if (horizontalVelocity.magnitude > PlayerMaxSpeed)
    //     {
    //         horizontalVelocity = horizontalVelocity.normalized * PlayerMaxSpeed;
    //
    //         playerRB.linearVelocity = new Vector3(
    //             horizontalVelocity.x,
    //             playerRB.linearVelocity.y,
    //             horizontalVelocity.z);
    //     }
    // }
    //
    bool GroundCheckFunction()
    {
        return Physics.CheckSphere(
            GroundCheck.position,
            0.1f,
            GroundLayer);
    }
    //
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Obstacle Hitbox"))
    //     {
    //         Destroy(collision.transform.parent.gameObject);
    //         PlayerJump();
    //     }
    //
    //     if (collision.gameObject.CompareTag("Bounce Pad"))
    //     {
    //         PlayerJump();
    //     }
    // }
}