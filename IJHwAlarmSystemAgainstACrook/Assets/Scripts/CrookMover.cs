using UnityEngine;

public class CrookMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float  _moveSpeed;
    [SerializeField] private float  _rotationSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxisRaw(Horizontal);
        transform.Rotate(Vector3.up * rotation * _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw(Vertical);

        transform.Translate(Vector3.forward * direction * _moveSpeed * Time.deltaTime);
    }
}
