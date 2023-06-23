using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xAxisMovement;
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
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (translation < 0)
        {
            if (_transform.position.y <= _bottomY)
                return;
        }

        if (translation > 0)
        {
            if (_transform.position.y >= _topY)
                return;
        }

        transform.Translate(translation / xAxisMovement, translation, 0);
    }
}
