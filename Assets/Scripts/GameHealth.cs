using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHealth : MonoBehaviour
{
    [SerializeField]
    public static float maxHealth;
    public static float currentHealth;

    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    public Image healthBar;
    protected virtual void Awake()
    {
        maxHealth = 100;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        if (healthBar != null)
            healthBar.fillAmount = 1.0f;
    }
    void Update()
    {
        TakeDamage();
    }
    public  void TakeDamage()
    {
        currentHealth -= 2f * Time.deltaTime;

        if (healthBar != null)
            healthBar.fillAmount = currentHealth/ maxHealth;

        if (currentHealth <= 0f)
            SceneManager.LoadScene("GameOver");
    }
}
