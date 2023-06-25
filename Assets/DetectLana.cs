using UnityEngine;

public class DetectLana : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Lana"))
        {
            FindObjectOfType<Player>().AddLife();
            Destroy(col.gameObject);
        }
    }
}
