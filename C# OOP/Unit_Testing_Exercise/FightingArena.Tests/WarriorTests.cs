using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private string name = "Warrior";
        private int damage = 50;
        private int hp = 100;
        private Warrior warrior;
        private Warrior enemy;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(name, damage, hp);
            this.enemy = new Warrior(name, damage, hp);

        }

        [Test]
        [TestCase(null, 50, 100)]
        [TestCase(" ", 50, 100)]
        [TestCase("", 50, 100)]
        [TestCase("Warrior", 0, 100)]
        [TestCase("Warrior", -10, 100)]
        [TestCase("Warrior", 50, -10)]
        public void When_CtorIsCalledWithInvalidData_ShouldThrowArgumentEx(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void When_CtorIsCalledWithValidData_ShouldSetInitialValues()
        {
            Assert.That(this.warrior.Name == this.name);
            Assert.That(this.warrior.Damage == this.damage);
            Assert.That(this.warrior.HP == this.hp);
        }

        [Test]
        public void When_AttackIsInvokedWithHpLessThanMin_ShouldThrowInvalidOp()
        {
            int fakeHp = 20;
            this.warrior = new Warrior(this.name, this.damage, fakeHp);
            this.enemy = new Warrior(this.name, this.damage, this.hp);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemy));
        }

        [Test]
        public void When_AttackingEnemyWithHpLessThatMin_ShouldThrowInvalidOp()
        {
            int fakeHp = 20;
            this.warrior = new Warrior(this.name, this.damage, this.hp);
            this.enemy = new Warrior(this.name, this.damage, fakeHp);

            
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemy));

        }

        [Test]
        public void When_AttackIsInvokedWithHpLessThanEnemyDamage_ShouldThrowInvalidOp()
        {
            int fakeHp = 40;
            this.warrior = new Warrior(this.name, this.damage, fakeHp);
            this.enemy = new Warrior(this.name, this.damage, this.hp);

            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(enemy));
        }

        [Test]
        public void When_AttackingWithValidWarriors_ShouldDecreaseAttackerHP()
        {
            int warriorHpBefore = this.warrior.HP;

            this.warrior.Attack(this.enemy);

            int warriorHpAfter = this.warrior.HP;

            Assert.That(warriorHpBefore, Is.GreaterThan(warriorHpAfter));

        }

        [Test]
        public void When_AttackingWithValidWarriorsAndEnemyHpGoesBelowZero_ShouldSetEnemyHPToZero()
        {
            int fakeHp = 40;
            this.enemy = new Warrior(this.name, this.damage, fakeHp);

            this.warrior.Attack(enemy);

            Assert.That(enemy.HP == 0);
        }

        [Test]
        public void When_AttackingWithValidWarriors_ShouldDecreaseEnemyHP()
        {
            int enemyrHpBefore = this.enemy.HP;

            this.warrior.Attack(this.enemy);

            int enemyHpAfter = this.warrior.HP;

            Assert.That(enemyrHpBefore, Is.GreaterThan(enemyHpAfter));

        }
    }
}