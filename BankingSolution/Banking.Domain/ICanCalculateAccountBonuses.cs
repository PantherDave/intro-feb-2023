namespace Banking.Domain;

public interface ICanCalculateAccountBonuses
{
    decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
}