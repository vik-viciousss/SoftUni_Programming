using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private readonly List<Warrior> warriors;
        private Arena arena;
        private Warrior warrior;
        private Warrior enemy;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Warrior", 50, 100);
            this.enemy = new Warrior("Enemy", 50, 100);
        }

        [Test]
        public void When_CtorIsCalled_ShouldInitializeWarriorsList()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void When_EnrollIsInvokedWithExistingWarriorName_ShouldThrowInvalidOp()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.warrior));
        }

        [Test]
        public void When_EnrollIsInvoked_ShouldAddWarriorToList()
        {
            this.arena.Enroll(this.warrior);
            this.warrior = new Warrior("WarrierTwo", 50, 100);

            this.arena.Enroll(warrior);

            var warriorsList = this.arena.Warriors;

            Assert.That(warriorsList, Does.Contain(warrior));

        }

        [Test]
        public void When_FightIsInvokedWithTwoEnrolledWarriors_AttackShouldHappen()
        {
            string warriorName = this.warrior.Name;
            string enemyName = this.enemy.Name;

            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.enemy);

            this.arena.Fight(warriorName, enemyName);

        }

        [Test]
        public void When_EnemyIsNotEnrolled_ShouldThrowInvalidOp()
        {
            string warriorName = this.warrior.Name;
            string enemyName = this.enemy.Name;

            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(warriorName, enemyName));
        }

        [Test]
        public void When_WarriorIsNotEnrolled_ShouldThrowInvalidOp()
        {
            string warriorName = this.warrior.Name;
            string enemyName = this.enemy.Name;

            this.arena.Enroll(this.enemy);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(warriorName, enemyName));
        }
    }
}
