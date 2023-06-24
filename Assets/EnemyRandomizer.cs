using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomizer : MonoBehaviour
{
    [SerializeField] private List<Color> outfitColor;
    [SerializeField] private List<GameObject> masks;
    [SerializeField] private List<GameObject> mouth;
    [SerializeField] private List<GameObject> eyeBrow;
    [SerializeField] private List<GameObject> hair;
    [SerializeField] private List<GameObject> addonsOnHead;
    [SerializeField] private List<GameObject> beard;
    [SerializeField] private List<GameObject> leftFoot;
    [SerializeField] private List<GameObject> rightFoot;

    private void Awake()
    {
        var maskColor = outfitColor[Random.Range(0, outfitColor.Count)];
        foreach (var mask in masks)
        {
            mask.GetComponent<SpriteRenderer>().color = maskColor;
        }
        mouth[Random.Range(0, mouth.Count)].SetActive(true);
        eyeBrow[Random.Range(0, eyeBrow.Count)].SetActive(true);
        hair[Random.Range(0, hair.Count)].SetActive(true);
        addonsOnHead[Random.Range(0, addonsOnHead.Count)].SetActive(true);
        beard[Random.Range(0, beard.Count)].SetActive(true);
        var randomizeFoot = Random.Range(0, leftFoot.Count);
        leftFoot[randomizeFoot].SetActive(true);
        rightFoot[randomizeFoot].SetActive(true);
    }

    public void KillEnemy()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
