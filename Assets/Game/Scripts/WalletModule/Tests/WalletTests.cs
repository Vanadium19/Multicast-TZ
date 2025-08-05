using System.Collections.Generic;
using NUnit.Framework;
using R3;

namespace WalletModule.Tests
{
    public class WalletTests
    {
        private Wallet _wallet;

        [SetUp]
        public void SetUp()
        {
            _wallet = new Wallet();
        }

        [Test]
        public void Wallet_StartsWithZeroMoney()
        {
            Assert.AreEqual(0, _wallet.Money.CurrentValue);
        }

        [Test]
        public void AddMoney_PositiveAmount_IncreasesMoney()
        {
            _wallet.AddMoney(100);

            Assert.AreEqual(100, _wallet.Money.CurrentValue);
        }

        [Test]
        public void AddMoney_NegativeOrZero_DoesNothing()
        {
            _wallet.AddMoney(0);
            _wallet.AddMoney(-50);

            Assert.AreEqual(0, _wallet.Money.CurrentValue);
        }

        [Test]
        public void RemoveMoney_PositiveAmount_DecreasesMoney()
        {
            _wallet.AddMoney(100);
            _wallet.RemoveMoney(40);

            Assert.AreEqual(60, _wallet.Money.CurrentValue);
        }

        [Test]
        public void RemoveMoney_MoreThanAvailable_DoesNothing()
        {
            _wallet.AddMoney(50);
            _wallet.RemoveMoney(100);

            Assert.AreEqual(50, _wallet.Money.CurrentValue);
        }

        [Test]
        public void RemoveMoney_NegativeOrZero_DoesNothing()
        {
            _wallet.AddMoney(100);
            _wallet.RemoveMoney(0);
            _wallet.RemoveMoney(-50);

            Assert.AreEqual(100, _wallet.Money.CurrentValue);
        }

        [Test]
        public void AddMoney_RaisesMoneyAddedEvent()
        {
            var addedEvents = new List<int>();
            
            _wallet.MoneyAdded.Subscribe(addedEvents.Add);

            _wallet.AddMoney(10);
            _wallet.AddMoney(20);

            CollectionAssert.AreEqual(new[] { 10, 20 }, addedEvents);
        }

        [Test]
        public void AddMoney_ZeroOrNegative_DoesNotRaiseMoneyAddedEvent()
        {
            List<int> addedEvents = new();
            _wallet.MoneyAdded.Subscribe(addedEvents.Add);

            _wallet.AddMoney(0);
            _wallet.AddMoney(-10);

            Assert.IsEmpty(addedEvents);
        }
    }
}