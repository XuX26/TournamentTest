namespace Tournament
{
    public class Veteran : WarriorBuff
    {
        public Veteran()
        {
            RatioBonusDamage = 2;
            ThresholdActivation = 30;   // to improve : add sign and create method to detect > or <
        }
    }
}