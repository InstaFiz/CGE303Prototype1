using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public DisplayBar healthBar;
    private Rigidbody2D rb;
    public float knockbackForce = 5f;
    public GameObject playerDeathEffect;
    public static bool hitRecently = false;
    public float hitRecoveryTime = 0.2f;

    private AudioSource playerAudio;
    public AudioClip playerHitSound;

    private Animator animator;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetValue(health);

        if (health <= 0)
        {
            Die();
        }
        else
        {
            playerAudio.PlayOneShot(playerHitSound);
            animator.SetBool("hit", true);
        }
    }

    public void Die()
    {
        ScoreManager.gameOver = true;
        GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);
        gameObject.SetActive(false);
    }

    public void Knockback(Vector3 enemyPosition)
    {
        if (hitRecently)
        {
            return;
        }

        hitRecently = true;
        if (gameObject.activeSelf)
        {
            StartCoroutine(RecoverFromHit());
        }
        Vector2 direction = transform.position - enemyPosition;
        direction.Normalize();
        direction.y = direction.y * 0.5f + 0.5f;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator RecoverFromHit()
    {
        yield return new WaitForSeconds(hitRecoveryTime);
        hitRecently = false;
        animator.SetBool("hit", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on player");
        }

        healthBar.SetMaxValue(health);
        hitRecently = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
