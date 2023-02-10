using Banking.Domain;
namespace BankingKiosk;

public partial class Form1 : Form
{
    BankAccount _account;
    public Form1()
    {
        InitializeComponent();
        _account = new BankAccount(
            new StandardBonusCalculator(
                new StandardBusinessClock(
                    new SystemTime())));
        UpdateBalanceDisplay();
    }

    private void UpdateBalanceDisplay()
    {
        this.Text = $"You have a balance of {_account.GetBalance():c} currently";
    }

    private void depositButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Deposit);
    }

    private void DoTransaction(Action<decimal> op)
    {
        string message;
        try
        {
            var amount = decimal.Parse(amountInput.Text);
            op(amount);
            UpdateBalanceDisplay();
        }
        catch (FormatException)
        {
            message = "Enter a number, you moron.";
            DisplayTransactionError(message);
        }
        catch (AccountOverdraftException)
        {
            message = "Not enough money to withdraw specified amount";
            DisplayTransactionError(message);
        } catch (NoNegativeNumbersException) 
        {
            message = "No negative numbers allowed!";
            DisplayTransactionError(message);
        } finally
        {
            amountInput.SelectAll();
            amountInput.Focus();
        }
        
    }

    private void withdrawButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Withdraw);

    }

    private void ShowMessage(object sendet, EventArgs e)
    {
        DoTransaction((amount) => MessageBox.Show("You clicked a button, blah" + amount.ToString()));

        //DoTransaction(delegate (decimal amount)
        //{
        //    MessageBox.Show("You clicked a button, blah" + amount.ToString();
        //});
    }

    private void DisplayTransactionError(string message)
    {
        MessageBox.Show(message, "Error in transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}