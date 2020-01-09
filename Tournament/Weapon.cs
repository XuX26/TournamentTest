namespace Tournament
{
    public class Weapon : Item
    {
        public int Damage;

        public Weapon() 
        {
            NbHandRequire = 1;
            MissEveryNb = 0; //Always attack
        }
    }
}
