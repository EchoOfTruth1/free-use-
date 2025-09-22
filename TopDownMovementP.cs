using UnityEngine;

public class TopDownP : MonoBehaviour
{
    public float movespeed = 3.5f;
    public Rigidbody2D rb;
    public Vector2 movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontal, vertical).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
public class interact : MonoBehaviour
{
    public float range = 3f;
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, interactableLayer);
            if (hit.collider != null)
            {
                Debug.Log("Interacted with " + hit.collider.name);
                // Add interaction logic here
            }
        }
    }
}