using System;
public class Attack
{
    public string name;
    public int baseDamage;
    public Element element;
    public bool strengthBased;

    public Attack(string _name, int _baseDamage, Element _element, bool _strengthBased) {
        name = _name;
        baseDamage = _baseDamage;
        element = _element;
        strengthBased = _strengthBased;
    }

    public int GetDamage(Entity user, Entity target) {
        float damage = (strengthBased ? user.strength : user.magic) * baseDamage;
        float damageReduction = target.GetDamageReduction();
        float damageWeaknessModifier = target.weaknesses.Contains(element) ? 2 : 1;
        float damageResistanceModifier = target.resistances.Contains(element) ? 0.5f : 1;

        return (int)Math.Ceiling((damage * damageReduction * damageWeaknessModifier * damageResistanceModifier));
    }
}

public enum Element {
    PHYSICAL,
    FIRE,
    ICE,
    THUNDER,
}