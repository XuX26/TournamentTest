using System;
using System.Runtime.CompilerServices;

namespace Tournament
{
    public static class Inventory
    {
        public static T Equip<T>(this T user, String item) where T : Warrior
        {
            if (item == WeaponData.WeaponAxe)
            {
                user.MainHandItem = new Axe();
                user.HandAvailable -= user.MainHandItem.NbHandRequire;
            }

            else if (item == WeaponData.WeaponSword)
            {
                user.MainHandItem = new Sword();
                user.HandAvailable -= user.MainHandItem.NbHandRequire;
            }

            else if (item == WeaponData.WeaponLongSword)
            {
                user.MainHandItem = new LongSword();
                user.HandAvailable -= user.MainHandItem.NbHandRequire;
            }

            else if (item == BucklerData.Buckler)
            {
                user.OffHandItem = new Buckler();
                user.HandAvailable -= user.OffHandItem.NbHandRequire;
            }

            else if (item == ArmorData.BasicArmor)
            {
                user.WearedArmor = new BasicArmor();
            }

            else if (item == WeaponBuffData.WeaponPoison)
            {
                user.WeaponBuff = new Vicious();
            }

            else if (item == WarriorBuffData.VeteranBuff)
            {
                user.WarriorBuff = new Veteran();
            }

            return user;
        }
    }
}
