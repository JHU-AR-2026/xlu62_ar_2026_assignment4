
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private Rigidbody rb;

    public float moveSpeed = 0f;
    public float jumpForce = 0f;

    private bool controlsEnabled = false;
    private bool isGrounded = false;
    private bool jumpQueued = false;

    public GameObject startButton;
    public GameObject count;
    public GameObject powerUpCapsule;
    public GameObject statusText;
    public GameObject youWinText;

    private float originalMoveSpeed;

    public bool IsPoweredUp { get; private set; } = false;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;
        originalMoveSpeed = moveSpeed;

        if (count != null)
            count.SetActive(false);

        if (powerUpCapsule != null)
            powerUpCapsule.SetActive(false);

        if (statusText != null)
            statusText.SetActive(false);

        if (youWinText != null)
            youWinText.SetActive(false);
    }

    void Update()
    {
        if (!controlsEnabled)
            return;

        if (isGrounded && jumpAction.triggered)
            jumpQueued = true;
    }

    private void FixedUpdate()
    {
        if (!controlsEnabled)
            return;

        if (jumpQueued)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpQueued = false;
        }

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveValue.x, 0f, moveValue.y);

        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }

    public void StartGame()
    {
        controlsEnabled = true;
        rb.isKinematic = false;

        if (startButton != null)
            startButton.SetActive(false);

        if (count != null)
            count.SetActive(true);
    }

    public void ApplySpeedBoost(float multiplier)
    {
        IsPoweredUp = true;
        moveSpeed = originalMoveSpeed * multiplier;
    }
}
