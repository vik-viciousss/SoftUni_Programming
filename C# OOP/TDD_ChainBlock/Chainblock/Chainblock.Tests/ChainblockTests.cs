using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void When_TryAddTransactionWithExistingId_ShouldThrowInvalidOp()
        {
            this.chainblock.Add(CreateSimpleTx());

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(new Transaction
            {
                Id = 1,
                To = "Nasko",
                From = "Naseto",
                Amount = 100
            }));
        }

        [Test]
        public void When_AddTransactionIsCalledWithValidTxId_ShouldAddItToChainblock()
        {
            ITransaction tx = this.CreateSimpleTx();
            
            this.chainblock.Add(tx);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(tx.Id), Is.True);
        }

        [Test]
        public void When_ContainsByIdIsCalledWithExistingID_ShouldReturnTrue()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            Assert.That(this.chainblock.Contains(tx.Id), Is.True);
        }

        [Test]
        public void When_ContainsByIdIsCalledWithNonExistingID_ShouldReturnFalse()
        {
            Assert.That(this.chainblock.Contains(2), Is.False);
        }

        [Test]
        public void When_ContainsTxIsCalledWithNonExistingId_ShouldReturnFalse()
        {
            Assert.That(this.chainblock.Contains(this.CreateSimpleTx()), Is.False);
        }

        [Test]
        public void When_ContainsTxIsCalledWithExistingIdButOtherPropsDontMatch_ShouldReturnFalse()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            ITransaction tx2 = new Transaction
            {
                Id = tx.Id,
                To = tx.To + "Fake",
                From = tx.From + "Fake",
                Amount = tx.Amount + 50,
                Status = TransactionStatus.Failed
            };

            Assert.That(this.chainblock.Contains(tx2), Is.False);
        }

        [Test]
        public void When_ContainsTxIsCalledWithExistingTx_ShouldReturnTrue()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            ITransaction tx2 = new Transaction
            {
                Id = tx.Id,
                To = tx.To,
                From = tx.From,
                Amount = tx.Amount,
                Status = tx.Status
            };

            Assert.That(this.chainblock.Contains(tx2), Is.True);
        }

        [Test]
        public void When_ChainblockIsEmpty_ShouldReturnCountZero()
        {
            Assert.That(this.chainblock.Count, Is.Zero);
        }

        [Test]
        public void When_ChangeTxStatusIsCalledWithNonExistingId_ShouldThrowArgEx()
        {
            this.chainblock.Add(this.CreateSimpleTx());

            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(100, TransactionStatus.Failed));
        }

        [Test]
        public void When_ChangeTxStatusIsCalledWithExistingId_ShouldChangeTxStatus()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            TransactionStatus newStatus = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(tx.Id, newStatus);

            Assert.That(tx.Status, Is.EqualTo(newStatus));
        }

        [Test]
        public void When_RemoveTxIsCalledWithNonExistingId_ShouldThrowInvalidOp()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(5));
        }

        [Test]
        public void When_RemoveTxIsCalledWithExistingId_ShouldRemoveItFromChainblock()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);
            this.chainblock.RemoveTransactionById(tx.Id);

            Assert.That(this.chainblock.Contains(tx), Is.False);
            Assert.That(this.chainblock.Count, Is.Zero);
        }

        [Test]
        public void When_GetByIdIsCalledWithNonExistingId_ShouldThrowInvalidOp()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(tx.Id + 1));
        }

        [Test]
        public void When_GetByIdIsCalledWithExistingId_ShouldReturnSameTx()
        {
            ITransaction tx = this.CreateSimpleTx();

            this.chainblock.Add(tx);

            ITransaction tx2 = this.chainblock.GetById(tx.Id);

            Assert.AreEqual(tx, tx2);
        } 

        [Test]
        public void When_GetByTxStatusisCalledWithNonExistingStatus_ShouldThrowInvalidOp()
        {
            CreateTxsWiththreeOfFourStatuses();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void WhenGetByTransactionStatus_ChainblockContainsTxWithSearchingStatus_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();

            TransactionStatus filterStatus = TransactionStatus.Failed;

            List<ITransaction> expected = this.chainblock.Where(t => t.Status == filterStatus).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = this.chainblock.GetByTransactionStatus(filterStatus).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetAllSendersWithStatusIsCalledWithNonExistingStatus_ShouldThrowInvalidOp()
        {
            CreateTxsWiththreeOfFourStatuses();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void When_GetAllSendersWithStatusIsCalledWithValidStatus_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();

            TransactionStatus filterStatus = TransactionStatus.Failed;

            List<string> expected = this.chainblock.Where(t => t.Status == filterStatus).OrderBy(t => t.Amount).Select(t => t.From).ToList();
            List<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(filterStatus).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetAllReceiversWithStatusIsCalledWithNonExistingStatus_ShouldThrowInvalidOp()
        {
            CreateTxsWiththreeOfFourStatuses();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void When_GetAllReceiversWithStatusIsCalledWithValidStatus_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();

            TransactionStatus filterStatus = TransactionStatus.Failed;

            List<string> expected = this.chainblock.Where(t => t.Status == filterStatus).OrderBy(t => t.Amount).Select(t => t.To).ToList();
            List<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(filterStatus).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetAllOrderedByAmountDescendingThenByIdIsCalled_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();

            List<ITransaction> expected = this.chainblock.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            List<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetBySenderOrderedByAmountDescendingIsCalledWithInvalidSender_ShouldThrowInvalidOp()
        {
            this.FillWithBulkTxs();
            string fakeSender = "fawrwar";

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending(fakeSender));
        }

        [Test]
        public void When_GetBySenderOrderedByAmoundDescendingIsCalledWithValidSender_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();
            string existingSender = this.chainblock.FirstOrDefault().From;

            List<ITransaction> expected = this.chainblock.Where(t => t.From == existingSender).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending(existingSender).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetByReceiverOrderedByAmountThenByIdIsCalledWithInvalidReceiver_ShouldThrowInvalidOp()
        {
            this.FillWithBulkTxs();
            string fakeReceiver = "Fake";

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById(fakeReceiver));
        }

        [Test]
        public void When_GetByReceiverOrderedByAmountThenByIdIsCalledWithValidReceiver_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();
            string existingReceiver = this.chainblock.FirstOrDefault().To;

            List<ITransaction> expected = this.chainblock.Where(t => t.To == existingReceiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            List<ITransaction> actual = this.chainblock.GetByReceiverOrderedByAmountThenById(existingReceiver).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetByTransactionStatusAndMaximumAmountIsCalledButNoneAreFound_ShouldReturnEmpty()
        {
            this.FillWithBulkTxs();
            double maxAmount = 0;
            TransactionStatus filterStatus = TransactionStatus.Unauthorized;

            Assert.IsEmpty(this.chainblock.GetByTransactionStatusAndMaximumAmount(filterStatus, maxAmount));
        }

        [Test]
        public void When_GetByTransactionStatusAndMaximumAmountIsCalledWithValidData_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();
            double maxAmount = double.MaxValue;
            TransactionStatus filterStatus = TransactionStatus.Unauthorized;

            List<ITransaction> expected = this.chainblock.Where(t => t.Amount <= maxAmount && t.Status == filterStatus).OrderBy(t => t.Amount).ToList();
            List<ITransaction> actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(filterStatus, maxAmount).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void When_GetBySenderAndMinimumAmountDescendingIsCalledWithInvalidData_ShouldThrowInvalidOp()
        {
            this.FillWithBulkTxs();
            double minAmount = double.MaxValue;
            string fakeSender = "fawrwar";

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(fakeSender, minAmount));
        }

        [Test]
        public void When_GetBySenderAndMinimumAmountDescendingIsCalledWithValidData_ShouldReturnFilteredAndSortedData()
        {
            this.FillWithBulkTxs();
            string existingSender = this.chainblock.FirstOrDefault().From;
            double minAmount = 0;

            List<ITransaction> expected = this.chainblock.Where(t => t.From == existingSender && t.Amount > minAmount).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = this.chainblock.GetBySenderAndMinimumAmountDescending(existingSender, minAmount).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        //TODO:test and implement last two methods someday

        private void CreateTxsWiththreeOfFourStatuses()
        {
            this.chainblock.Add(new Transaction
            {
                Id = 1,
                To = "Nasko",
                From = "Nasi",
                Amount = 100,
                Status = TransactionStatus.Failed
            });

            this.chainblock.Add(new Transaction
            {
                Id = 2,
                To = "Nasko",
                From = "Nasi",
                Amount = 100,
                Status = TransactionStatus.Aborted
            });

            this.chainblock.Add(new Transaction
            {
                Id = 3,
                To = "Nasko",
                From = "Nasi",
                Amount = 100,
                Status = TransactionStatus.Successfull
            });
        }

        private void FillWithBulkTxs()
        {
            int n = 100;

            for (int i = 0; i < 100; i++)
            {
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Johnkata";
                string to = "Johnito";
                double amount = 100;


                if (i % 2 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                    from = "Mecho";
                    to = "Momo";
                    amount = 100 + i;
                }
                else if (i % 3 == 0)
                {
                    status = TransactionStatus.Aborted;
                    from = "Bate";
                    to = "Gogi";
                    amount = 100 + i + i;
                }
                else if (i % 5 == 0)
                {
                    status = TransactionStatus.Failed;
                    from = "Gosheto";
                    to = "Maci";
                    amount = 100 + i + i + i;
                }

                ITransaction tx = new Transaction
                {
                    Id = n - i,
                    From = from,
                    To = to,
                    Amount = amount,
                    Status = status
                };

                this.chainblock.Add(tx);
            }
        }

        private ITransaction CreateSimpleTx()
        {
            var transaction = new Transaction
            {
                Id = 1,
                To = "Nasko",
                From = "Nasi",
                Amount = 100,
                Status = TransactionStatus.Successfull
            };

            return transaction;
        }

    }
}
