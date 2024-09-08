using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public string name;
    public int maxHealth, currentHealth;
    public int strength, magic, defence, speed;
    public List<Element> resistances, weaknesses;
    int defenceFactor = 10; //when an entity's defence equals this value, their damage reduction will be exactly half

    public Entity(string _name, int _maxHealth, int _strength, int _magic, int _defence, int _speed, List<Element> _resistances, List<Element> _weaknesses) {
        name = _name;
        maxHealth = _maxHealth;
        currentHealth = maxHealth;
        strength = _strength;
        magic = _magic;
        defence = _defence;
        speed = _speed;
        resistances = _resistances;
        weaknesses = _weaknesses;
    }
    public float GetDamageReduction() {
        return 1f - ((float)defence / (float)(defence + defenceFactor));
    }
}
