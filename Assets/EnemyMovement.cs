using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody enemyRB;

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
        enemyRB = GetComponent<Rigidbody>();
        PlayerMovementForce = PlayerGroundForce;
    }

    void Update()
    {
        // if (GroundCheckFunction())
        // {
        //     if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         PlayerJump();
        //     }
        //
        //     PlayerLimitVelocity();
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMoveForward();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerMoveBack();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMoveRight();
        }
    }

    // void PlayerJump()
    // {
    //     playerRB.AddForce(Vector3.up * PlayerJumpForce, ForceMode.Impulse);
    // }

    void PlayerMoveForward()
    {
        enemyRB.AddForce(Vector3.forward * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveBack()
    {
        enemyRB.AddForce(Vector3.back * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveLeft()
    {
        enemyRB.AddForce(Vector3.left * PlayerMovementForce, ForceMode.Force);
    }

    void PlayerMoveRight()
    {
        enemyRB.AddForce(Vector3.right * PlayerMovementForce, ForceMode.Force);
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
