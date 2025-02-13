using UnityEngine;

public class PickupManager : MonoBehaviour
{
    float healAmount = 400;
    float boostMultiplier = 2;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ExpGems"))
        {
            ExperienceGem gem = col.GetComponent<ExperienceGem>();
            gem.Collect();
        }
        else if (col.CompareTag("HealthPotion"))
        {
            PlayerStats player = Object.FindAnyObjectByType<PlayerStats>();
            player.RestoreHealth(healAmount);
            player.UpdateHealthBar();
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("SpeedPotion"))
        {
            PlayerStats player = Object.FindAnyObjectByType<PlayerStats>();
            player.SpeedBoost(boostMultiplier);
            Destroy(col.gameObject);
        }
    }

}
