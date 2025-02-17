using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody rb;
    private bool isGrounded;
    public int score = 0;
    
    public Text scoreText; // UI Reference (Assign in Inspector)

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure scoreText is assigned
        if (scoreText != null)
        {
            UpdateScoreUI();
        }
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        float yVelocity = rb.linearVelocity.y; // Preserve gravity

        Vector3 move = new Vector3(moveX, yVelocity, moveZ);
        rb.linearVelocity = move;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Reset downward force
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Collectible collectible = other.GetComponent<Collectible>();
            if (collectible != null)
            {
                AddScore(collectible.scoreValue);
            }

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("NegativeObject"))
        {
            AddScore(-10);
            Destroy(other.gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreText != null)
        {
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
