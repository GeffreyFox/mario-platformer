using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private bool isJumping = false;
    private Rigidbody rb;

    private RaycastHit hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * 0.2f;

        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up) * 10, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green);*/
    }
    
}
