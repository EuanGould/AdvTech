using MetaVoiceChat;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerBehaviour : NetworkBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float chat_length = 10f;
    [SerializeField] private MetaVc meta_vc;

    private Vector3 respawnPoint;

    private Rigidbody rb;

    private Vector2 movingDirection = Vector2.zero;

    private LineRenderer lr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        lr = gameObject.GetComponent<LineRenderer>();

    }

    public void Move(InputAction.CallbackContext context)
    {
        //if (!IsOwner) return;
        movingDirection = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        
        if (rb.isKinematic)
        {
            rb.isKinematic = false;
        }

        if (Mathf.Abs(rb.linearVelocity.y) <= 0.1f)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0) + (new Vector3(movingDirection.x, 0, movingDirection.y) * speed);
        }

        if (GameObject.FindGameObjectsWithTag("Player").Length != 2)
        {
            LineDefault();
            meta_vc.isDeafened.Value = true;

        }
        else if ((GameObject.FindGameObjectsWithTag("Player")[0].transform.position - GameObject.FindGameObjectsWithTag("Player")[1].transform.position).magnitude < chat_length)
        {
            lr.SetPosition(0, GameObject.FindGameObjectsWithTag("Player")[0].transform.position);
            lr.SetPosition(1, GameObject.FindGameObjectsWithTag("Player")[1].transform.position);
            meta_vc.isDeafened.Value = false;
        }
        else
        {
            LineDefault();
            meta_vc.isDeafened.Value = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            gameObject.transform.position = respawnPoint;
        }
    }

    private void LineDefault()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }
}
