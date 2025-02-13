using UnityEngine;

public class ExperienceGem : MonoBehaviour
{
    public int experienceAmount;

    public void Collect()
    {
        PlayerStats player = Object.FindAnyObjectByType<PlayerStats>();
        player.IncreaseExperience(experienceAmount);
        Destroy(gameObject);
    }
}
