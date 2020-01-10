using System;
using NUnit.Framework;

/*
 *
 * This is a duel simulation
 *
 * Blow exchange are sequential, A engage B means that A will give the first blow, then B will respond
 *
 */
namespace Tournament.Tests
{
    [TestFixture]
    public class TournamentTest
    {
        [Test]
        public void SimpleTestCase()
        {
            Assert.IsTrue(true);
        }

        /*
        * A Swordsman has 100 hit points and use a 1 hand sword that does 5 dmg
        * A Viking has 120 hit points and use a 1 hand axe that does 6 dmg
        */
        [Test]
        public void SwordsmanVsViking()
        {

            Warrior swordsman = new Swordsman();

            Viking viking = new Viking();

            swordsman.Engage(viking);

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(35, viking.HitPoints());
        }

        /*
        * a buckler cancel all the damages of a blow one time out of two
        * a buckler is destroyed after blocking 3 blow from an axe
        */
        [Test]
        public void SwordsmanWithBucklerVsVikingWithBuckler()
        {
            Swordsman swordsman = new Swordsman()
                    .Equip("buckler");

            Viking viking = new Viking()
                    .Equip("buckler");

            swordsman.Engage(viking);

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(70, viking.HitPoints());
        }


        /*
         * an Highlander as 150 hit points and fight with a Great Sword
         * a Great Sword is a two handed sword deliver 12 damages, but can attack only 2 every 3 )(attack ; attack ; no attack)
         * an armor : reduce all received damages by 3 & reduce delivered damages by one
         */
        [Test]
        public void ArmoredSwordsmanVsHighlander()
        {
            Highlander highlander = new Highlander();

            Swordsman swordsman = new Swordsman()
                    .Equip("buckler")
                    .Equip("armor");

            swordsman.Engage(highlander);

            Assert.AreEqual(0, swordsman.HitPoints());
            Assert.AreEqual(10, highlander.HitPoints());
        }

        /*
         * a vicious Swordsman is a Swordsman that put poison on his weapon.
         * poison add 20 damages on two first blows
         * a veteran Highlander goes Berserk once his hit points are under 30% of his initial total
         * once Berserk, he doubles his damages
         */
        [Test]
        public void ViciousSwordsmanVsVeteranHighlander()
        {
            Swordsman swordsman = new Swordsman("Vicious")
                    .Equip("axe")
                    .Equip("buckler")
                    .Equip("armor");

            Highlander highlander = new Highlander("Veteran");

            swordsman.Engage(highlander);

            Assert.AreEqual(1, swordsman.HitPoints());
            Assert.AreEqual(0, highlander.HitPoints());
        }

    }
}
