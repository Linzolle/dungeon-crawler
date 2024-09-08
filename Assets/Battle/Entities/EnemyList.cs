using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyList
{
    public static Entity enemy = new Entity("Enemy", 100, 5, 5, 5, 5, new List<Element>(), new List<Element>(){Element.FIRE});
}
