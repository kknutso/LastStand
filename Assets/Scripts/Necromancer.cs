using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    [SerializeField] Enemy skeletonPrefab;
    [SerializeField] GameObject[] summonPoints;

    void Start()
    {
        this.transform.position += new Vector3(0f, .15f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (!otherObject.GetComponent<Cavalry>())
        {
            return;
        }
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Enemy>().Attack(otherObject);
        }
    }

    public void SummonSkeletons()
    {
        foreach (GameObject summonPoint in summonPoints)
        {
            Instantiate(skeletonPrefab, summonPoint.transform.position, Quaternion.identity);
        }
    }
}
