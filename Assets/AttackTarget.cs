using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool magicAttack;

	[SerializeField]
	private float manaCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	[SerializeField]
	private float minResistanceMultiplier;

	[SerializeField]
	private float maxResistanceMultiplier;
	
	public void hit(GameObject target) {
		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if(this.magicAttack) {
			if (ownerStats.mana >= this.manaCost) {
				float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
				float damage = attackMultiplier * ownerStats.magic;

				float resistanceMultiplier = (Random.value * (this.maxResistanceMultiplier - this.minResistanceMultiplier)) + this.minResistanceMultiplier;
				damage = Mathf.Max(0, damage - (resistanceMultiplier * targetStats.resistance));

				this.owner.GetComponent<Animator> ().Play (this.attackAnimation);

				targetStats.receiveDamage (damage);

				ownerStats.mana -= this.manaCost;
			}
		}
		else {
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			float damage = attackMultiplier * ownerStats.attack;

			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);

			targetStats.receiveDamage (damage);		
		}
	}
}
