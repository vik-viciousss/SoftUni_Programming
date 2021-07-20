using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionsById;

        public Chainblock()
        {
            this.transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if(this.transactionsById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists!");
            }

            this.transactionsById.Add(tx.Id, tx);
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                return false;
            }

            ITransaction existingTx = this.transactionsById[tx.Id];

            return tx.From == existingTx.From &&
                tx.To == existingTx.To &&
                tx.Amount == existingTx.Amount &&
                tx.Status == existingTx.Status;
        }

        public bool Contains(int id)
        {
            return this.transactionsById.ContainsKey(id);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"Transaction with ID: {id} does non exist!");
            }

            ITransaction tx = this.transactionsById[id];
            tx.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with ID: {id} does not exist!");
            }

            this.transactionsById.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with ID: {id} does not exist!");
            }

            return this.transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> filteredTxs = this.transactionsById.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount).ToList();

            if (filteredTxs.Count == 0)
            {
                throw new InvalidOperationException($"There are not transactions with status {status}");
            }

            return filteredTxs;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.From).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with status {status} exist!");
            }

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionsById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.To).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with status {status} exist!");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            List<ITransaction> orderedTxs = this.transactionsById.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            return orderedTxs;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> txs = this.transactionsById.Values.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ToList();

            if (txs.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with sender {sender} exist!");
            }

            return txs;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> txs = this.transactionsById.Values.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            if (txs.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with receiver {receiver} exist!");
            }

            return txs;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> txs = this.transactionsById.Values.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount).ToList();

            return txs;
        }
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> txs = this.transactionsById.Values.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount).ToList();

            if (txs.Count == 0)
            {
                throw new InvalidOperationException($"No transactions with sender {sender} and amount less that {amount} exist!");
            }

            return txs;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var tx in this.transactionsById)
            {
                yield return tx.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
