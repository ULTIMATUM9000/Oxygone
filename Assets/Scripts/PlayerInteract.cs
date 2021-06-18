using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject Fertilizer;
    public GameObject Pesticide;
    public GameObject WateringCan;
    public GameObject effect;

    public static bool hasItem = false;
    public int itemNum;

    GameObject newpower;

    private void Start()
    {
        hasItem = false;
    }
    void SpawnWateringCan()
    {
        hasItem = true; 
        newpower = Instantiate(WateringCan, new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
        newpower.transform.parent = gameObject.transform;
        newpower.transform.localScale = new Vector3(0.5f, 0.5f, 2);
        
    }

    void SpawnPesticide()
    {
        hasItem = true;
        newpower = Instantiate(Pesticide, new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
        newpower.transform.parent = gameObject.transform;
        newpower.transform.localScale = new Vector3(0.5f, 0.5f, 2);
    }
    void SpawnFertilizer()
    {
        hasItem = true;
        newpower = Instantiate(Fertilizer, new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z), Quaternion.identity);
        newpower.transform.parent = gameObject.transform;
        newpower.transform.localScale = new Vector3(0.5f, 0.5f, 2);   
    }
        
    void OnTriggerStay2D(Collider2D collision) // GET ITEM SKILL -- MIGHT BE PROBLEM
    {
        if (hasItem == false)
        {
            if (Input.GetKey(KeyCode.Space) && newpower == null)
            {
                if (collision.gameObject.CompareTag("Water"))
                {
                    FindObjectOfType<AudioManagerScript>().Play("water");
                    SpawnWateringCan();
                    itemNum = 1;
                    Destroy(Instantiate(effect, transform.position, transform.rotation), 1); 
                }

                if (collision.gameObject.CompareTag("Pesticide"))
                {
                    FindObjectOfType<AudioManagerScript>().Play("spray");
                    SpawnPesticide();
                    itemNum = 2;
                    Destroy(Instantiate(effect, transform.position, transform.rotation), 1); 
                }

                if (collision.gameObject.CompareTag("Fertilizer"))
                {
                    FindObjectOfType<AudioManagerScript>().Play("fertilizer"); 
                    SpawnFertilizer();
                    itemNum = 3;
                    Destroy(Instantiate(effect, transform.position, transform.rotation), 1); 
                }
            }
        }
      
        else if(hasItem == true)
        {
            if (Input.GetKey(KeyCode.Space) && collision.gameObject.CompareTag("Tree"))
            {
                hasItem = false;
                itemNum = 0;
                foreach (Transform child in transform)
                    GameObject.Destroy(child.gameObject);
                newpower = null;
            }
        }
    }
}
