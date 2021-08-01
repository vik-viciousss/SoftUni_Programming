using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            this.item = new Item("owner", "1");
        }

        [Test]
        public void When_TryToAddToNonExistentCell_ShouldThrowArgEx()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("T67", this.item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void When_TryToAddToTakenCell_ShouldThrowArgEx()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("A1", new Item("owner2", "2"));
            }, "Cell is already taken!");
        }

        [Test]
        public void When_TryAddExistingItem_ShouldThrowInvalidOp()
        {
            this.vault.AddItem("A1", this.item);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.vault.AddItem("A2", this.item);
            }, "Item is already in cell!");
        }

        [Test]
        public void When_TryAddWithValidParams_ShouldAddItemToVault()
        {
            this.vault.AddItem("A1", this.item);

            Assert.That(this.vault.VaultCells["A1"], Is.EqualTo(this.item));
        }

        [Test]
        public void When_ItemAddedSuccessufully_ShouldReturnString()
        {
            Assert.That(this.vault.AddItem("A1", this.item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void When_TryRemoveItemFromInvalidCell_ShouldThrowArgEx()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("T56", this.item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void When_TryRemoveMissingItem_ShouldThrowArgEx()
        {
            var itemTwo = new Item("ownerTwo", "2");
            this.vault.AddItem("A1", itemTwo);
            
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A1", this.item);
            }, "Item in that cell doesn't exists!");
        }

        [Test]
        public void When_RemoveValidItem_ShouldClearCell()
        {
            this.vault.AddItem("A1", this.item);
            this.vault.RemoveItem("A1", this.item);

            Assert.That(this.vault.VaultCells["A1"], Is.Null);
        }

        [Test]
        public void When_RemoveValidItem_ShouldReturnString()
        {
            this.vault.AddItem("A1", this.item);

            Assert.That(this.vault.RemoveItem("A1", this.item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }
    }
}