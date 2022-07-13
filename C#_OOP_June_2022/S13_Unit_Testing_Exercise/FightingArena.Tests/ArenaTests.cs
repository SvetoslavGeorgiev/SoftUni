namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {

        [Test]
        public void ConstructorCheck()
        {
            var arena = new Arena(); 

            Assert.IsNotNull(arena);

            Assert.AreEqual(0, arena.Warriors.Count);
        }

        [Test]
        public void AddingWorriorInToTheArena()
        {
            var arena = new Arena();
            var worrior = new Warrior("Pesho", 55, 150);

            arena.Enroll(worrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void WhenAddingWorriorInToTheArenaWithExistingNameShouldThrowInvalidOperationExeption()
        {
            var arena = new Arena();
            var worrior = new Warrior("Pesho", 55, 150);

            arena.Enroll(worrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Pesho", 150, 350)));
        }

        [Test]
        public void FigthShouldThrowInvalidOperationExceptionIfAttackerNotInTheArena()
        {
            var arena = new Arena();

            var worrior = new Warrior("Gosho", 55, 150);
            var worrior1 = new Warrior("Pesho", 55, 35);
            var worrior2 = new Warrior("Ivan", 55, 65);


            arena.Enroll(worrior);
            arena.Enroll(worrior1);
            arena.Enroll(worrior2);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Stoyan", "Pesho"));
        }

        [Test]
        public void FigthShouldThrowInvalidOperationExceptionIfDefenderNotInTheArena()
        {
            var arena = new Arena();
            var worrior = new Warrior("Gosho", 55, 150);
            var worrior1 = new Warrior("Pesho", 55, 35);
            var worrior2 = new Warrior("Ivan", 55, 65);


            arena.Enroll(worrior);
            arena.Enroll(worrior1);
            arena.Enroll(worrior2);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Stoyan"));
        }

        [Test]
        public void FigthShouldChancheTheHpIfAttackerAndDefenderExist()
        {
            var arena = new Arena();
            var worrior = new Warrior("Gosho", 55, 150);
            var worrior1 = new Warrior("Pesho", 55, 35);
            var worrior2 = new Warrior("Ivan", 55, 65);


            arena.Enroll(worrior);
            arena.Enroll(worrior1);
            arena.Enroll(worrior2);

            arena.Fight("Gosho", "Pesho");

            Assert.AreEqual(95, worrior.HP);
            Assert.AreEqual(0, worrior1.HP);

            arena.Fight("Gosho", "Ivan");

            Assert.AreEqual(10, worrior2.HP);
        }


    }
}
