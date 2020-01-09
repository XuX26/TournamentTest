namespace Tournament
{
    public class Swordsman : Warrior
    {
        public Swordsman()
        {
            Hp = 100;
            this.Equip(item: WeaponData.WeaponSword);
        }

        public Swordsman(string buff)
        {
            Hp = 100;
            this.Equip(item: buff);
        }

        ~Swordsman() //called when destroyed
        {
        }
    }
}
