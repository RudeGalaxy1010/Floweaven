using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float arrowsX;
    private float arrowsZ;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInput();
        Move();
    }

    private void ReadInput()
    {
        arrowsX = Input.GetAxis("Horizontal");
        arrowsZ = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 forwardShift = transform.forward * arrowsZ * _speed * Time.deltaTime;
        Vector3 rightShift = transform.right * arrowsX * _speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + forwardShift + rightShift);
    }
}
