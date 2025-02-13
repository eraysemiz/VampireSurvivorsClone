using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    PlayerStats playerData;

    [HideInInspector] float currentMoveSpeed;
    [HideInInspector] float currentHealth;
    [HideInInspector] float currentDamage;

    // Damage and Death effect
    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.6f;
    Color originalColor;
    SpriteRenderer sr;
    EnemyMovement movement;


    void Awake() // awake start fonksiyonundan önce çalýþýr
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        movement = GetComponent<EnemyMovement>();
        playerData = Object.FindAnyObjectByType<PlayerStats>();
    }
    public void TakeDamage(float damage, Vector2 srcPosition, float knockbackForce = 5f, float knockbackDuration = 0.2f)
    {
        currentHealth -= damage;
        StartCoroutine(DamageFlash());

        if (knockbackForce > 0)
        {
            Vector2 dir = (Vector2)transform.position - srcPosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = originalColor;
    }

    public void Kill()
    {
        //Destroy(gameObject);
        if (gameObject.CompareTag("Enemy"))
            EnemySpawner.minionKillCount++;
        else if (gameObject.CompareTag("MiniBoss"))
            EnemySpawner.miniBossKillCount++;
        else if (gameObject.CompareTag("FinalBoss"))
        {
            EnemySpawner.finalBossKillCount++;
            DatabaseManager db = gameObject.GetComponent<DatabaseManager>();
            db.SavePlayerScore();
            PauseMenu menu = Object.FindAnyObjectByType<PauseMenu>();
            menu.EndGame();
            Time.timeScale = 0;
        }
        StartCoroutine(KillFade());
    }

    IEnumerator KillFade()
    {
        WaitForEndOfFrame w = new WaitForEndOfFrame();
        float t = 0;
        float originalAlpha = sr.color.a;

        while (t < deathFadeTime)
        {
            yield return w;
            t += Time.deltaTime;

            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (1 - t / deathFadeTime) * originalAlpha);
        }
        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
