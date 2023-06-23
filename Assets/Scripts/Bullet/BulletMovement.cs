using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float shootSpeed;

    private void Update()
    {
        transform.Translate(Vector3.right * shootSpeed * Time.deltaTime);
    }
}
