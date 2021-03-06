using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(this.attack, this.durability);
        this.dummy = new Dummy(5, 6);
    }

    [Test]
    public void When_AxeAttackAndDursbilityProvided_ShouldBeSetCorrectly()
    {
        

        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void When_AxeAttacks_ShouldLoseDurability()
    {
        this.axe.Attack(this.dummy);

        Assert.AreEqual(this.axe.DurabilityPoints, this.durability - 1);
    }

    [Test] 
    public void When_AxeAttackWithDurabilityPointsZero_ShouldThrowException()
    {
        this.dummy = new Dummy(500, 500);

        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
        {
            for (int i = 0; i < 7; i++)
            {
                axe.Attack(this.dummy);
            }
        });

        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }

    [Test]
    public void When_AxeAttackIsCalledWithNullDummy_ShouldThrowNullRef()
    {
        Assert.Throws<NullReferenceException>(() => { axe.Attack(null); });

    }
}