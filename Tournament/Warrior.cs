using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tournament
{
    public class Warrior
    {
        public int MaxHp;
        public int Hp;
        public int HandAvailable = 2;
        public Weapon MainHandItem;
        public WeaponBuff WeaponBuff;
        public WarriorBuff WarriorBuff;
        public Shield OffHandItem;
        public Armor WearedArmor;
        public int DebugCountDealsDamage;

        public void Engage(Warrior enemy)
        {
            while (Hp > 0 && enemy.Hp > 0)
            {
                Attack(enemy);
                if (enemy.Hp > 0)
                    enemy.Attack(this);
            }
        }

        public void InitMaxHp()
        {
            MaxHp = Hp;
        }

        public double HitPoints()
        {
            return Hp;
        }

        public void Attack(Warrior target)
        {
            int finalDamage = 0;
            if (MainHandItem.NbUsed == 0 || MainHandItem.MissEveryNb == 0 ||
                MainHandItem.NbUsed % (MainHandItem.MissEveryNb) != 0)
            {
                if (target.OffHandItem == null) //don't have shield
                {
                    finalDamage += MainHandItem.Damage;
                }
                else if (target.OffHandItem != null)
                {
                    if (target.OffHandItem.NbUsed % (target.OffHandItem.MissEveryNb) != 0 || target.OffHandItem.MissEveryNb == 0)
                    {
                            finalDamage += MainHandItem.Damage;
                    }

                    else
                    {
                        if (MainHandItem.GetType() == typeof(Axe))
                        {
                            target.OffHandItem.Durability--;
                        }
                    }

                    target.OffHandItem.NbUsed++;
                    if (target.OffHandItem.Durability == 0)
                        target.OffHandItem = null;
                }

                if (WeaponBuff != null)
                {
                    finalDamage += WeaponBuff.bonusDamage;
                    WeaponBuff.durability--;
                    if (WeaponBuff.durability == 0)
                        WeaponBuff = null;
                }

                if (WarriorBuff != null)
                {
                    if (Hp < (MaxHp * WarriorBuff.ThresholdActivation) / 100)
                    {
                        finalDamage *= WarriorBuff.RatioBonusDamage;
                    }
                }

                if (target.WearedArmor != null)
                {
                    finalDamage -= target.WearedArmor.reducingTakenDamage;
                }
                if (WearedArmor != null)
                {
                    finalDamage -= WearedArmor.reducingDealingDamage;
                }

                if (finalDamage > 0)
                {
                    target.Hp -= finalDamage;
                    DebugCountDealsDamage++;
                }
                if (target.Hp < 0)
                    target.Hp = 0;
            }

            MainHandItem.NbUsed++;
        }

        public bool CanBeUsed(Item item)
        {
            return (item.MissEveryNb == 0 || item.NbUsed % (item.MissEveryNb) != 0);
        }

        public void Defend()
        {

        }


    }
}