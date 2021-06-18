using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFertilizer : MonoBehaviour
{
    public GameObject Fertilizer;

    public void DoInteraction()
    {
        var newVertilizer = Instantiate(Fertilizer, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newVertilizer.transform.parent = gameObject.transform;
        newVertilizer.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, 0);
        newVertilizer.transform.localScale = new Vector3(0.2f, 0.2f, 1);
    }
}
