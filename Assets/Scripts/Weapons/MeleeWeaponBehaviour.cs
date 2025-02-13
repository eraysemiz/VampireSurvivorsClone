using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public float destroyAfterSeconds;

    [HideInInspector] public float currentDamage;
    [HideInInspector] public float currentSpeed;
    [HideInInspector] public float currentCooldownDuration;

    [HideInInspector] public float Damage;
    [HideInInspector] public float Speed;
    [HideInInspector] public float CooldownDuration;
    [HideInInspector] public Vector3 Scale;
    void Awake()
    {
        Damage = weaponData.Damage;
        Speed = weaponData.Speed;
        CooldownDuration = weaponData.CooldownDuration;
        Scale = weaponData.Weapon.transform.localScale;

        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("MiniBoss") || col.CompareTag("FinalBoss"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage, transform.position);
        }
        else if (col.CompareTag("Prop"))
        {
            BreakableProps prop = col.GetComponent<BreakableProps>();
            prop.TakeDamage(currentDamage);
        }
    }
}
