using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackList
{
    public Attack regularAttack = new Attack("Attack", 5, Element.PHYSICAL, true);
    public Attack fireMagic = new Attack("Fire", 5, Element.FIRE, false);
}
