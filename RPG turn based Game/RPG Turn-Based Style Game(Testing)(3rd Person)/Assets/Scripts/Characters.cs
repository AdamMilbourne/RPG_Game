using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    CharacterBaseStats _base;
    int level;

    public Characters(CharacterBaseStats cBase, int cLevel)
    {
        _base = cBase;
        level = cLevel;
    }

        public int Damage { get { return Mathf.FloorToInt((_base.Damage * level) / 100f) + 5; } }
        public int Defence { get { return Mathf.FloorToInt((_base.Defence * level) / 100f) + 5; } }
        public int MaxHp { get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 5; } }

}

