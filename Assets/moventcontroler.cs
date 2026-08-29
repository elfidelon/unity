using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class moventcontroler : MonoBehaviour
{
    public InputActionAsset InputActionAsset;
    public float speed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 0.15f;
    public LayerMask groundLayer = ~0;

    private InputActionMap InputActionMap;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Rigidbody _rb;
    private SphereCollider _sphereCollider;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _sphereCollider = GetComponent<SphereCollider>();

        InputActionMap = InputActionAsset.FindActionMap("Player");
        _moveAction = InputActionMap.FindAction("Move");
        _jumpAction = InputActionMap.FindAction("Jump");
        _moveAction.Enable();
        _jumpAction.Enable();
    }

    void Update()
    {
        if (_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        Vector2 joyStickValue = _moveAction.ReadValue<Vector2>();
        Vector3 movimiento = new Vector3(joyStickValue.x, 0, joyStickValue.y) * speed;
        _rb.linearVelocity = new Vector3(movimiento.x, _rb.linearVelocity.y, movimiento.z);
    }

    bool IsGrounded()
    {
        float radius = _sphereCollider != null ? _sphereCollider.radius * transform.lossyScale.x : 0.5f;
        return Physics.Raycast(transform.position, Vector3.down, radius + groundCheckDistance, groundLayer);
    }
}
