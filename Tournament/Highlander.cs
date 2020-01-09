namespace Tournament
{
    public class Highlander : Warrior
    {
        public Highlander()
        {
            Hp = 150;
            this.Equip(WeaponData.WeaponLongSword);
        }

        public Highlander(string buff)
        {
            Hp = 150;
            this.Equip(WeaponData.WeaponLongSword);
            this.Equip(buff);
            InitMaxHp();
        }
    }
}