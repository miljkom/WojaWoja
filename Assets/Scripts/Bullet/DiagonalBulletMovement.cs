using UnityEngine;

public class DiagonalBulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float direction;
    [SerializeField] private GameObject topBound;
    [SerializeField] private GameObject bottomBound;
    
    private Transform _transform;
    private float _topY;
    private float _bottomY;
    
    private void Awake()
    {
        _transform = transform;
        _topY = topBound.transform.position.y;
        _bottomY = bottomBound.transform.position.y;
    }

    private void Update()
    {
        if (direction > 0)
        {
            if (_transform.position.y > _topY)
            {
                direction = -1;
                return;
            }
        }

        if (direction < 0)
        {
            if (_transform.position.y < _bottomY)
            {
                direction = 1;
                return;
            }
        }
        transform.Translate(new Vector2(-1,1 * direction).normalized  * Time.deltaTime * speed);
    }
}
