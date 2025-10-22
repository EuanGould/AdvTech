using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class playerBehaviour : NetworkBehaviour
{
    [SerializeField] private float speed = 2f;

    private Vector3 respawnPoint;

    private Rigidbody rb;

    private Vector2 movingDirection = Vector2.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        respawnPoint = transform.position;

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!IsOwner) return;
        movingDirection = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        
        if (Mathf.Abs(rb.linearVelocity.y) <= 0.1f)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0) + (new Vector3(movingDirection.x, 0, movingDirection.y) * speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameObject.transform.position = respawnPoint;
        }
    }
}
