using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;

public class Movments : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Movements")]
    public float moveSpeed;
    public float goundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    [System.Obsolete]
    void Update()
    {
        //Controllo se tocca terra
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f /*+ 0.2f*/, whatIsGround);

        MyInput();
        SpeedControl();

        //gestion drag
        if(grounded)
            rb.drag = goundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //salto
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown); //Se tieni premuto il pulsante di salto continua a saltare ad intervalli regolari
        }
    }

    private void MovePlayer()
    {
        //Direazione del movimento
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //Terra
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        //In aria 
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //Limitare la velocità in modo che non vada sopra al valore dato
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //Resetta la velocità verticale per il salto
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
