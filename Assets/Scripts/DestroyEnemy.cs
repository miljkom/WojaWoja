
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject.transform.parent.transform.parent.gameObject);
    }
}
