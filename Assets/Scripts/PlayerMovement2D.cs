using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private bool m_CanJump = true;
    private float m_MovementSpeed;
    private float m_JumpPower;

    public float movementSpeed;
    public float jumpPower;

    public KeyCode leftControl;
    public KeyCode rightControl;
    public KeyCode jumpControl;

    private void Awake ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        // Number control. Wanted to enter in more whole numbers than fractions
	    m_MovementSpeed = movementSpeed / 10;
	    m_JumpPower = jumpPower / 10;
    }
	
	private void Update ()
	{
        var movement = new Vector3();

        // Get Input
        if (Input.GetKey(rightControl))
            movement += transform.right;

        if (Input.GetKey(leftControl))
            movement -= transform.right;

        // Determine if we are in the air
        var velocity = (m_CanJump) ? movement.normalized * m_MovementSpeed : movement.normalized * m_MovementSpeed / 2;

        // Apply motion
        transform.Translate(velocity);

        // Can the play jump
        if (!Input.GetKeyDown(jumpControl) || !m_CanJump) return;

        // Jump motion
        m_Rigidbody2D.AddForce(Vector3.up * m_JumpPower * 10, ForceMode2D.Impulse);
        m_CanJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(transform.position.y > other.collider.bounds.center.y)
            m_CanJump = true;
    }
}
