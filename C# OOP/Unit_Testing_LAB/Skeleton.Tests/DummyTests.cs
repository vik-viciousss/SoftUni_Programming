using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 5;
    private int experience = 5;
    private int attackPoints = 3;
    Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_DummyIsAttacked_ShouldTakeDamage()
    {
        int health = 5;
        int experience = 5;
        int attackPoints = 3;
        Dummy dummy = new Dummy(health, experience);

        dummy.TakeAttack(attackPoints);

        Assert.AreEqual(dummy.Health, health - attackPoints);
    }

    [Test]
    public void When_DeadDummyIsAttacked_ShouldThrowInvalidOperation()
    {
        dummy = new Dummy(0, 5);


        Assert.That(() =>
        {
            dummy.TakeAttack(this.attackPoints);

        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_DummyIsDead_ShouldReturnExperience()
    {
        dummy = new Dummy(-1, 5);

        int experience = dummy.GiveExperience();

        Assert.That(experience != 0);
    }

    [Test] 
    public void When_DummyIsAlive_ShouldThrowInvalidOperation()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
