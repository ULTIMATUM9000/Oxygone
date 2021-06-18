using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    public GameObject Fertilizer;
    public GameObject Pesticide;
    public GameObject WateringCan;
    public GameObject Effect; //heart
    public GameObject plus; // +1
    public GameObject skull; //skull

    public Animator animator;
    int playerItem;

    ScoreTracker scoreTracker;

    GameObject newdamage;

    public int damageNum;
    bool hasDamage = false;
    bool item;

    private void Start()
    {
        StartCoroutine(Randomizer());
        GameObject player = GameObject.Find("Player");
        PlayerInteract playerinteract = player.GetComponent<PlayerInteract>();
        scoreTracker = GameObject.FindObjectOfType<ScoreTracker>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        playerItem = GameObject.Find("Player").GetComponent<PlayerInteract>().itemNum;
        item = PlayerInteract.hasItem;
    }

    void SelectDamage()
    {
        switch(damageNum)
        {
            case 1:
                Dry();
                break;
            case 2:
                Pest();
                break;
            case 3:
                Unfertilized();
                break;
        }
    }

    void Dry()
    {
        animator.ResetTrigger("isRepaired");
        animator.SetTrigger("isDry");
        newdamage = Instantiate(WateringCan, new Vector3(transform.position.x + 1.0f, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
        newdamage.transform.parent = gameObject.transform;
        newdamage.transform.localScale = new Vector3(0.4f, 0.4f, 2);
    }

    void Pest()
    {
        animator.SetTrigger("isPest");
        newdamage = Instantiate(Pesticide, new Vector3(transform.position.x + 1.0f, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
        newdamage.transform.parent = gameObject.transform;
        newdamage.transform.localScale = new Vector3(0.4f, 0.4f, 2);
    }

    void Unfertilized()
    {
        animator.ResetTrigger("isRepaired");
        animator.SetTrigger("isUnfertilized");
        newdamage = Instantiate(Fertilizer, new Vector3(transform.position.x + 1.0f, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
        newdamage.transform.parent = gameObject.transform;
        newdamage.transform.localScale = new Vector3(0.5f, 0.5f, 2);
    }

    void Restore()
    {
        FindObjectOfType<AudioManagerScript>().Play("TreeRegen");
        GameHealth.currentHealth += 3f;

        animator.SetTrigger("isRepaired");

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
            hasDamage = false;
            damageNum = 0;
            newdamage = null;
        }
        scoreTracker.AddScore(1f);
        StartCoroutine(Randomizer());
        Destroy(Instantiate(Effect, transform.position, transform.rotation), 1); // heart
        Destroy(Instantiate(plus, transform.position, transform.rotation), 1); // +1
    }

    void damaged()
    {
        GameHealth.currentHealth -= 1f;
        FindObjectOfType<AudioManagerScript>().Play("damage");
        Destroy(Instantiate(skull, transform.position, transform.rotation), 1); //skull
    }
    
    IEnumerator Randomizer()
    {

        while(hasDamage == false)
        {
            yield return new WaitForSeconds(Random.Range(1, 12));
            hasDamage = true;
            damageNum = Random.Range(1, 4);
            Debug.Log(damageNum);
            SelectDamage();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.CompareTag("Player") && hasDamage == true)
        {
            if(playerItem == damageNum)
            {
                Restore();
            }
            
            else if(playerItem != damageNum && item == true)
            {
                damaged();
            }
        }
    }
}
