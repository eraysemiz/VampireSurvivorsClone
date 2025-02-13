using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObjects characterData;
    public static ProjectileWeaponBehaviour knifeData;
    public static MeleeWeaponBehaviour garlicData;
    public event Action OnLevelUp;

    // Þuanki statlar
    public float currentHealth;
    float currentRecovery;
    public float currentMoveSpeed;

    public float MaxHealth;
    public float MaxMoveSpeed;

    // Oyuncunun seviyesi ve deneyim puaný
    public int experience = 0;
    public int level = 1;
    public int maxLevel;
    public int experienceCap = 100;
    public int experienceCapIncrease;

    // Oyuncu hasar alma kýsýtlamalarý
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible = false;

    // Potion timerlarý
    public float speedBoostDuration;
    float speedBoostTimer;
    bool isBoosted = false;


    // Database
    [HideInInspector] public int playerScore;
    [HideInInspector] public string playerName;

    public Image healthBar;
    public TMP_Text levelText;
    public ParticleSystem damageEffect;

    WeaponManager weapons;

    void Awake()
    {
        MaxHealth = characterData.MaxHealth;
        MaxMoveSpeed = characterData.MoveSpeed;

        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;

        knifeData = UnityEngine.Object.FindAnyObjectByType<ProjectileWeaponBehaviour>();

        garlicData = UnityEngine.Object.FindAnyObjectByType<MeleeWeaponBehaviour>();

    }

    void Start()
    {
        
        OnLevelUp += LoadUpgradeScene;    
        UpdateHealthBar();
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }

        if (isBoosted)
        {
            if (speedBoostTimer > 0)
            {
                speedBoostTimer -= Time.deltaTime;
            }
            else
            {
                currentMoveSpeed = characterData.MoveSpeed;
                isBoosted = false;
            }
        }
        ScoreCalculator();
        if (currentHealth < characterData.MaxHealth)
            currentHealth += currentRecovery;
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();   
    }

    void LevelUpChecker()
    {
        if (experience > experienceCap && level <= maxLevel)
        {
            level++;
            experience -= experienceCap;
            experienceCap += experienceCapIncrease;
            UpdateLevelText();
            OnLevelUp?.Invoke();
        }
    }

    void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeScene", LoadSceneMode.Additive);

        Time.timeScale = 0;
    }
    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            if (damageEffect) Instantiate(damageEffect, transform.position, Quaternion.identity);

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
            UpdateHealthBar();
        }
    }

    void Kill()
    {
        ScoreCalculator();
        SceneManager.LoadScene("EndMenu");
        Time.timeScale = 0;
    }

    public void RestoreHealth(float amount)
    {
        if (currentHealth + amount < characterData.MaxHealth)
            currentHealth += amount;
        else
            currentHealth = characterData.MaxHealth;
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / characterData.MaxHealth;

    }

    public void UpdateLevelText()
    {
        levelText.text = "Level: " + level.ToString();
    }
    public void SpeedBoost(float amount)
    {
        if (!isBoosted)
        {
            currentMoveSpeed *= amount;
            isBoosted = true;
            speedBoostTimer = speedBoostDuration;
        }
    }

    public void ScoreCalculator()
    {
        int minionScore = EnemySpawner.minionKillCount * 10;
        int miniBossScore = EnemySpawner.miniBossKillCount * 50;
        int finalBossScore = EnemySpawner.finalBossKillCount * 1000;

        playerScore = minionScore + miniBossScore + finalBossScore;
        PlayerStats.PlayerData.score = playerScore;
    }


    public static class PlayerData
    {
        public static string Username;
        public static int score;
    }
}
