using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    // Start is called before the first frame update
    public Entity player, enemy;
    public Button attackButton;
    public AttackList attackList;
    void OnEnable() {
        attackButton.onClick.AddListener(() => Attack(attackList.regularAttack, player, enemy));
    }
    void Start()
    {
        player = PlayerList.player;
        enemy = EnemyList.enemy;
    }

    int Attack(Attack attack, Entity user, Entity target) {
        int damage = attack.GetDamage(user, target);
        target.currentHealth -= damage;
        Debug.Log(user.name + " dealt " + damage + " damage to " + target.name + " (now has " + target.currentHealth + " health)");
        return damage; 
    }
    public void Run(Attack attack) {
        Attack(attack, player, enemy);
    }
}
