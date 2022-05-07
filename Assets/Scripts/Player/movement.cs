using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    //Check ground variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    public Vector3 lastMove;

    private float currentSpeed;

    public Vector3 velocity;
    
    [SerializeField]
    List<AudioClip> footsteps;
    [SerializeField] List<AudioClip> jumpSFXS;

    private int footstepCounter;
    private AudioSource[] audioPlayers;
    private float footstepTime;


    private void Start()
    {
        currentSpeed = movementSpeed;
        lastMove = Vector3.zero;
        footstepCounter = 0;
        footstepTime = 3f;
        audioPlayers = GetComponents<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get Movement Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        handleJump();
        handleSpeed();


        // Move Character
        Vector3 move = transform.right * x + transform.forward * z;

        footstepTime = footstepTime + Time.deltaTime;
        if (!isGrounded)
        {
            controller.Move((lastMove + (move * 0.25f)) * currentSpeed * Time.deltaTime);
            footstepTime = 3f;
        }
        else
        {
            controller.Move(move * currentSpeed * Time.deltaTime);
            lastMove = move;
            if (move.magnitude > 0f)
            {
                playFootstep();
            }

        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void handleSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = 2 * movementSpeed;
        }
        else
        {
            currentSpeed = movementSpeed;
        }
    }

    void playFootstep()
    {
        if (footstepTime > footsteps[footstepCounter].length)
        {
            audioPlayers[0].PlayOneShot(footsteps[footstepCounter], 0.1f);
            footstepTime = 0;
            footstepCounter += 1;
            if (footstepCounter == footsteps.Count)
            {
                footstepCounter = 0;
            }
        }
    }

    void handleJump()
    {
        //Grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            audioPlayers[1].PlayOneShot(jumpSFXS[Random.Range(0, jumpSFXS.Count)], .5f);
        }
    }

}
