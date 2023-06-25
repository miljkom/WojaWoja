using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingGroupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SortingGroup sort = GetComponent<SortingGroup>();
        sort.sortingOrder = Mathf.RoundToInt(transform.position.y * -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
