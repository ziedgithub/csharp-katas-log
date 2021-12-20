﻿using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Banking.Tests.Unit
{

    public class AccountTests
    {
        [Fact]
        public void Should_be_able_to_deposit()
        {
            // Arrange
            Account account = new Account();

            // Act
            account.Deposit(1, DateTime.Parse("2021-11-15 00:00:00"));

            // Assert
            var statement = account.GetStatement();
            var transaction = statement.GetTransactions().First();
            transaction.Amount.Should().Be(1);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-15 00:00:00"));
            transaction.Should().BeOfType(typeof(Deposit));
        }

        [Fact]
        public void Should_be_able_to_withdraw()
        {
            //Arrange
            Account account = new Account();

            //Act
            account.Withdraw(1, DateTime.Parse("2021-11-15 00:00:00"));

            //Assert
            var transaction = account.GetStatement().GetTransactions().First();
            transaction.Amount.Should().Be(1);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-15 00:00:00"));
            transaction.Should().BeOfType(typeof(WithDraw));
        }

        [Fact]
        public void Should_be_able_to_deposits_and_withdraw()
        {
            // Arrange
            Account account = new Account();

            // Act
            account.Deposit(1000, DateTime.Parse("2021-11-15 00:00:00"));
            account.Withdraw(100, DateTime.Parse("2021-11-16 00:00:00"));
            account.Deposit(500, DateTime.Parse("2021-11-17 00:00:00"));


            // Assert
            var statement = account.GetStatement();
            var transaction = statement.GetTransactions().First();
            transaction.Balance.Should().Be(1400);
            transaction.Date.Should().Be(DateTime.Parse("2021-11-17 00:00:00"));
        }
    }

}
