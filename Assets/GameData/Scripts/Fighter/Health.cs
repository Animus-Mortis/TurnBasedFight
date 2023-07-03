using Game.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Fighter
{
    public class Health : MonoBehaviour, IAlive
    {
        [SerializeField] private int maxHP;
        [SerializeField] private Bar barHP;
        [SerializeField] private UnityEvent receivedDamageEvent;
        [SerializeField] private UnityEvent dieEvent;

        public bool die { get; private set; }

        private int HP;
        private int passedDamage;
        private Armor armor;

        private void Start()
        {
            HP = maxHP;
            armor = GetComponent<Armor>();
            barHP.UpdateBar(HP, maxHP);
        }

        public void GetDamage(int damage, Vampirism vampirism = null)
        {
            if (die) return;
            if (armor != null)
                passedDamage = armor.PassedDamage(damage);
            else
                passedDamage = damage;

            if (passedDamage > 0)
            {
                receivedDamageEvent?.Invoke();
                HP -= passedDamage;
                barHP.UpdateBar(HP, maxHP);

                if (vampirism != null)
                    vampirism.TakeHealth(passedDamage);

                if (HP <= 0)
                    Die();
            }
        }

        public void GetHealth(int value)
        {
            if (die) return;

            HP += value;

            if (HP > maxHP)
                HP = maxHP;

            barHP.UpdateBar(HP, maxHP);
        }

        public void Die()
        {
            die = true;
            dieEvent?.Invoke();
        }
    }
}