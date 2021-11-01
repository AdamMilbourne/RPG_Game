using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Character/Create new character")]
public class CharacterBaseStats : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] int maxHp;
    [SerializeField] int damage;
    [SerializeField] int defence;

    public string Name {get { return name; }}

    public string Description { get { return description; } }

    public Sprite FrontSprite { get { return frontSprite; } }

    public Sprite BackSrite { get { return backSprite; } }

    public int MaxHp { get { return maxHp; } }
    public int Damage { get { return damage; } }
    public int Defence { get { return defence; } }
}
