using UnityEngine;


[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "Scriptable Objects/Character")]
public class CharacterScriptableObjects : ScriptableObject
{
    [SerializeField]
    GameObject startingKnife;
    public GameObject StartingKnife { get => startingKnife; private set => startingKnife = value;}

    [SerializeField]
    GameObject startingGarlic;
    public GameObject StartingGarlic { get => startingGarlic; private set => startingGarlic = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }

}
