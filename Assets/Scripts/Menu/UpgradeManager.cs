using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    PlayerStats player;
    public static int currentKnifeLevel = 3;
    

    [System.Serializable]
    public class Weapons
    {
        public string name;
        public int weaponLevel;
        public WeaponScriptableObject weaponData;
    }

     //Knife Upgrade
    public KnifeController knifePrefab;
    public ProjectileWeaponBehaviour knifeData;
    public List<Weapons> weaponList;

    // Garlic Upgrade
    public MeleeWeaponBehaviour garlicData;
    public float garlicSize = 4;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        player = Object.FindAnyObjectByType<PlayerStats>();

        knifePrefab = Object.FindAnyObjectByType<KnifeController>();
        knifeData = Object.FindAnyObjectByType<ProjectileWeaponBehaviour>();

        garlicData = Object.FindAnyObjectByType<MeleeWeaponBehaviour>();
    }

    void Start()
    {
        
    }
    public void UpgradeKnifeWeapon()
    {
        if (player.level == 2)
        {
            knifePrefab.weaponData = weaponList[1].weaponData;
        }
        else if (player.level == 3)
        {
            knifePrefab.weaponData = weaponList[2].weaponData;
        }
        else if (player.level == 4)
        {
            knifePrefab.weaponData = weaponList[3].weaponData;
        }
        else if (player.level == 5)
        {
            knifePrefab.weaponData = weaponList[4].weaponData;
        }
        else if (player.level == 6)
        {
            knifePrefab.weaponData = weaponList[5].weaponData;
        }
        else
        {
            knifeData.currentDamage += 5;
            knifeData.currentCooldownDuration -= 0.1f;
            knifeData.currentSpeed += 0.5f;

        }
        ReturnToGame();

    }

    public void UpgradeGarlicWeapon()
    {
        
        Vector3 scale = new Vector3(garlicSize, garlicSize, garlicSize);
        garlicSize = Mathf.Min(garlicSize + 0.3f, 6f);
        garlicData.weaponData.Weapon.transform.localScale = scale;
        garlicData.currentDamage += 10;
        garlicData.currentSpeed += 10;
        garlicData.currentCooldownDuration -= 0.1f;

        ReturnToGame() ;
    }

    public void UpgradePhysicalStats()
    {
        player.MaxHealth += 200;
        player.currentHealth = player.MaxHealth;
        player.MaxMoveSpeed += 0.3f;
        player.currentMoveSpeed = player.MaxMoveSpeed;
        player.UpdateHealthBar();
        ReturnToGame();
    }

    public void ReturnToGame()
    {
        SceneManager.UnloadSceneAsync("UpgradeScene");
        Time.timeScale = 1; // Resume the game
    }
}
