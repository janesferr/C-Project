using System;
using CustomerEntity;
using CheckingEntity;
using BusinessEntity;
using LoanEntity;
using TermEntity;
using CustomerBL;
using CheckingBL;
using BusinessBL;
using LoanBL;
using TermBL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class Frontend
    {
        static List<string> trans = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("'Wasted Too Much Time Thinking Of A Good Name' National Bank (;_;)");

            Customerentity cusent = new Customerentity();
            Checkingentity checkent = new Checkingentity();
            Businessentity busent = new Businessentity();
            Loanentity loent = new Loanentity();
            Termentity trment = new Termentity();

            Customerbl custbl = new Customerbl();
            Checkingbl checkbl = new Checkingbl();
            Businessbl busbl = new Businessbl();
            Loanbl lobl = new Loanbl();
            Termbl trmbl = new Termbl();

            Random rand = new Random();
            bool isclosed = false;

            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("To Register Type 'register'");
                Console.WriteLine("To Open A New Account Type 'open'");
                Console.WriteLine("To Close An Account Type 'close'");
                Console.WriteLine("To Deposit To An Account type 'deposit'");
                Console.WriteLine("To Withdraw From An Account type 'withdraw'");
                Console.WriteLine("To Transfer Between Accounts Type 'transfer'");
                Console.WriteLine("To Pay Loan Installments Type 'payloan'");
                Console.WriteLine("To Display List Of Accounts Type 'accdisplay'");
                Console.WriteLine("To Display Transactions For An Account Type 'transactions'");

                string userchoice = Console.ReadLine();

                if (userchoice == "register")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Your First Name:");
                    cusent.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Your Last Name:");
                    cusent.LastName = Console.ReadLine();
                    cusent.Id = rand.Next(1, 100);

                    Console.WriteLine();
                    Console.WriteLine("Registration Complete. Account Details:");
                    Console.WriteLine("First Name: " + cusent.FirstName);
                    Console.WriteLine("Last Name: " + cusent.LastName);
                    Console.WriteLine("ID: " + cusent.Id);

                    custbl.Create(cusent);
                }

                if (userchoice == "open")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            Console.WriteLine();
                            Console.WriteLine("To Open A Checking Account Type 'checking'");
                            Console.WriteLine("To Open A Business Account Type 'business'");
                            Console.WriteLine("To Open A Loan Account Type 'loan'");
                            Console.WriteLine("To Open A Term Account Type 'term'");

                            string accounttype = Console.ReadLine();

                            if (accounttype == "checking")
                            {
                                checkent.AccountNum = rand.Next(1000, 2000);
                                checkent.AccountBalance = 0;
                                checkent.AccountType = "checking";
                                checkent.Interest = 10.45;

                                Console.WriteLine();
                                Console.WriteLine("New Account Created!");
                                Console.WriteLine("Your Account Number Is: " + checkent.AccountNum);
                                Console.WriteLine("Your Default Balance is: " + checkent.AccountBalance);
                                Console.WriteLine("Your Account Type is: " + checkent.AccountType);
                                Console.WriteLine("Your Interest Rate is: " + checkent.Interest);

                                checkbl.Create(checkent);
                            }

                            if (accounttype == "business")
                            {
                                busent.AccountNum = rand.Next(2000, 3000);
                                busent.AccountBalance = 0;
                                busent.AccountType = "business";

                                Console.WriteLine();
                                Console.WriteLine("New Account Created!");
                                Console.WriteLine("Your Account Number Is: " + busent.AccountNum);
                                Console.WriteLine("Your Default Balance is: " + busent.AccountBalance);
                                Console.WriteLine("Your Account Type is: " + busent.AccountType);

                                busbl.Create(busent);
                            }

                            if (accounttype == "loan")
                            {
                                loent.AccountNum = rand.Next(3000, 4000);

                                loent.AccountBalance = 0;
                                loent.AccountType = "loan";

                                Console.WriteLine();
                                Console.WriteLine("New Account Created!");
                                Console.WriteLine("Your Account Number Is: " + loent.AccountNum);
                                Console.WriteLine("Your Default Balance is: " + loent.AccountBalance);
                                Console.WriteLine("Your Account Type is: " + loent.AccountType);

                                lobl.Create(loent);
                            }

                            if (accounttype == "term")
                            {
                                trment.AccountNum = rand.Next(4000, 5000);

                                trment.AccountBalance = 0;
                                trment.AccountType = "term";

                                Console.WriteLine("How Many Years Till Maturity?");
                                trment.Age = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine();
                                Console.WriteLine("New Account Created!");
                                Console.WriteLine("Your Account Number Is: " + trment.AccountNum);
                                Console.WriteLine("Your Default Balance is: " + trment.AccountBalance);
                                Console.WriteLine("Your Account Type is: " + trment.AccountType);
                                Console.WriteLine("You Can Withdraw Money After " + trment.Age + " Years");

                                trmbl.Create(trment);
                            }
                        }

                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found!");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }

                if (userchoice == "close")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            Console.WriteLine();
                            Console.WriteLine("What is the Account Number of the Account You Wish To Close?");
                            int idcheck = Convert.ToInt32(Console.ReadLine());

                            if (idcheck == checkent.AccountNum)
                            {
                                checkbl.Close(checkent);
                                isclosed = true;
                            }
                            if (idcheck == busent.AccountNum)
                            {
                                busbl.Close(busent);
                                isclosed = true;
                            }
                            if (idcheck == loent.AccountNum)
                            {
                                lobl.Close(loent);
                                isclosed = true;
                            }
                            if (idcheck == trment.AccountNum)
                            {
                                trmbl.Close(trment);
                                isclosed = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }

                }

                if (userchoice == "deposit")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter Your ID:");
                    int readid = Convert.ToInt32(Console.ReadLine());

                    if (readid == cusent.Id)
                    {
                        Console.WriteLine();
                        Console.WriteLine("What is the Account Number of the Account You Wish To Deposit To?");
                        int idcheck = Convert.ToInt32(Console.ReadLine());

                        if (idcheck == checkent.AccountNum)
                        {
                            if (isclosed == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("How Much Would You Like To Deposit?");
                                int userin = Convert.ToInt32(Console.ReadLine());

                                if (userin > 0)
                                {
                                    checkent.AccountBalance = checkent.AccountBalance + userin;

                                    Console.WriteLine();
                                    Console.WriteLine("The Checking Account With Account Number " + checkent.AccountNum + " Now Has " + checkent.AccountBalance);

                                    trans.Add("Deposit of " + userin + " To " + checkent.AccountType + " With Account Number " + checkent.AccountNum);
                                }

                                else
                                {
                                    Console.WriteLine("You Cannot Deposit A Negative Amount!");
                                }

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("This Account Has Been Deleted");
                            }
                        }

                        if (idcheck == busent.AccountNum)
                        {
                            if (isclosed == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("How Much Would You Like To Deposit?");
                                int userin = Convert.ToInt32(Console.ReadLine());

                                if (userin > 0)
                                {
                                    busent.AccountBalance = busent.AccountBalance + userin;

                                    Console.WriteLine();
                                    Console.WriteLine("The Business Account With Account Number " + busent.AccountNum + " Now Has " + busent.AccountBalance);

                                    trans.Add("Deposit of " + userin + " To " + busent.AccountType + " With Account Number " + busent.AccountNum);
                                }
                                else
                                {
                                    Console.WriteLine("You Cannot Deposit A Negative Amount!");
                                }
                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("This Account Has Been Deleted");
                            }
                        }

                        if (idcheck == trment.AccountNum)
                        {
                            if (isclosed == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("How Much Would You Like To Deposit?");
                                int userin = Convert.ToInt32(Console.ReadLine());

                                if (userin > 0)
                                {
                                    trment.AccountBalance = trment.AccountBalance + userin;

                                    Console.WriteLine();
                                    Console.WriteLine("The Term Account With Account Number " + trment.AccountNum + " Now Has " + trment.AccountBalance);

                                    trans.Add("Deposit of " + userin + " To " + trment.AccountType + " With Account Number " + trment.AccountNum);
                                }
                                else
                                {
                                    Console.WriteLine("You Cannot Deposit A Negative Amount!");
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("This Account Has Been Deleted");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No Such Customer Id Found");
                    }
                   
                }

                if (userchoice == "withdraw")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            Console.WriteLine();
                            Console.WriteLine("What is the Account Number of the Account You Wish To Withdraw From?");
                            int idcheck = Convert.ToInt32(Console.ReadLine());

                            if (idcheck == checkent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("How Much Would You Like To Withdraw?");
                                    int userin = Convert.ToInt32(Console.ReadLine());

                                    if (userin > 0)
                                    {
                                        if ((checkent.AccountBalance -= userin) >= 0)
                                        {
                                            checkent.AccountBalance = checkent.AccountBalance - userin;

                                            Console.WriteLine();
                                            Console.WriteLine("The Checking Account With Account Number " + checkent.AccountNum + " Now Has " + checkent.AccountBalance);

                                            trans.Add("Withdrawal of " + userin + " From " + checkent.AccountType + " With Account Number " + checkent.AccountNum);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Checking Account Balance Cannot Be Negative!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Cannot Withdraw A Negative Amount!");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }

                            if (idcheck == busent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("How Much Would You Like To Withdraw?");
                                    int userin = Convert.ToInt32(Console.ReadLine());

                                    if (userin > 0)
                                    {

                                        busent.AccountBalance = busent.AccountBalance - userin;

                                        if (busent.AccountBalance < 0)
                                        {
                                            Console.WriteLine("You Have Negative Balance. You Will Be Charged 10.45% Interest On The Current Balance.");
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("The Business Account With Account Number " + busent.AccountNum + " Now Has " + busent.AccountBalance);

                                        trans.Add("Withdrawal of " + userin + " From " + busent.AccountType + " With Account Number " + busent.AccountNum);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Cannot Withdraw A Negative Amount!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }

                            if (idcheck == loent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("How Much Would You Like To Withdraw?");
                                    int userin = Convert.ToInt32(Console.ReadLine());

                                    if (userin > 0)
                                    {
                                        loent.AccountBalance = loent.AccountBalance - userin;

                                        Console.WriteLine();
                                        Console.WriteLine("The Loan Account With Account Number " + loent.AccountNum + " Now Has " + loent.AccountBalance);

                                        trans.Add("Withdrawal of " + userin + " From " + loent.AccountType + " With Account Number " + loent.AccountNum);
                                       
                                        Console.WriteLine("Loan Account Balance Cannot Be Positive!");
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("You Cannot Withdraw A Negative Amount!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }

                            if (idcheck == trment.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("How Many Years Has It Been?");
                                    int time = Convert.ToInt32(Console.ReadLine());

                                    if (time >= trment.Age)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("How Much Would You Like To Withdraw?");
                                        int userin = Convert.ToInt32(Console.ReadLine());

                                        if (userin > 0)
                                        {
                                            if ((trment.AccountBalance -= userin) >= 0)
                                            {

                                                trment.AccountBalance = trment.AccountBalance - userin;

                                                Console.WriteLine();
                                                Console.WriteLine("The Term Account With Account Number " + trment.AccountNum + " Now Has " + trment.AccountBalance);

                                                trans.Add("Withdrawal of " + userin + " From " + trment.AccountType + " With Account Number " + trment.AccountNum);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Term Account Balance Cannot Be Negative!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You Cannot Withdraw A Negative Amount!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("You Cannot Withdraw Yet");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }

                if (userchoice == "transfer")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            Console.WriteLine();
                            Console.WriteLine("What is the Account Number of the Account You Wish To Transfer From?");
                            int idcheck = Convert.ToInt32(Console.ReadLine());

                            if (idcheck == checkent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("What is the Account Number of the Account You With to Transfer to?");
                                    int idcheck2 = Convert.ToInt32(Console.ReadLine());

                                    if (idcheck2 == busent.AccountNum)
                                    {
                                        if (isclosed == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("How Much Would You Like To Transfer?");
                                            int userin = Convert.ToInt32(Console.ReadLine());

                                            if (userin > 0)
                                            {
                                                if ((checkent.AccountBalance -= userin) >= 0)
                                                {

                                                    checkent.AccountBalance = checkent.AccountBalance - userin;
                                                    busent.AccountBalance = busent.AccountBalance + userin;

                                                    Console.WriteLine();
                                                    Console.WriteLine("The Checking Account With Account Number " + checkent.AccountNum + " Now Has " + checkent.AccountBalance);
                                                    Console.WriteLine("The Business Account With Account Number " + busent.AccountNum + " Now Has " + busent.AccountBalance);

                                                    trans.Add("Transfer of " + userin + " From " + checkent.AccountType + " With Account Number " + checkent.AccountNum + " To " + busent.AccountType + " With Account Number  " + busent.AccountNum);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Checking Account Balance Cannot Be Negative!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("You Cannot Transfer A Negative Amount!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("This Account Has Been Deleted");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }

                            if (idcheck == busent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("What is the Account Number of the Account You With to Transfer to?");
                                    int idcheck2 = Convert.ToInt32(Console.ReadLine());

                                    if (idcheck2 == checkent.AccountNum)
                                    {
                                        if (isclosed == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("How Much Would You Like To Transfer?");
                                            int userin = Convert.ToInt32(Console.ReadLine());

                                            if (userin > 0)
                                            {

                                                busent.AccountBalance = busent.AccountBalance - userin;
                                                checkent.AccountBalance = checkent.AccountBalance + userin;

                                                if (busent.AccountBalance < 0)
                                                {
                                                    Console.WriteLine("You Have Negative Balance. You Will Be Charged 10.45% Interest On The Current Balance.");
                                                }

                                                Console.WriteLine();
                                                Console.WriteLine("The Business Account With Account Number " + busent.AccountNum + " Now Has " + busent.AccountBalance);
                                                Console.WriteLine("The Checking Account With Account Number " + checkent.AccountNum + " Now Has " + checkent.AccountBalance);

                                                trans.Add("Transfer of " + userin + " From " + busent.AccountType + " With Account Number " + busent.AccountNum + " To " + checkent.AccountType + " With Account Number  " + checkent.AccountNum);
                                            }
                                            else
                                            {
                                                Console.WriteLine("You Cannot Transfer A Negative Amount!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("This Account Has Been Deleted");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }

                            if (idcheck == loent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("What is the Account Number of the Account You With to Transfer to?");
                                    int idcheck2 = Convert.ToInt32(Console.ReadLine());

                                    if (idcheck2 == checkent.AccountNum)
                                    {
                                        if (isclosed == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("How Much Would You Like To Transfer?");
                                            int userin = Convert.ToInt32(Console.ReadLine());

                                            if (userin > 0)
                                            {
                                                loent.AccountBalance = loent.AccountBalance - userin;
                                                checkent.AccountBalance = checkent.AccountBalance + userin;

                                                Console.WriteLine();
                                                Console.WriteLine("The Loan Account With Account Number " + loent.AccountNum + " Now Has " + loent.AccountBalance);
                                                Console.WriteLine("The Checking Account With Account Number " + checkent.AccountNum + " Now Has " + checkent.AccountBalance);

                                                trans.Add("Transfer of " + userin + " From " + loent.AccountType + " With Account Number " + loent.AccountNum + " To " + checkent.AccountType + " With Account Number  " + checkent.AccountNum);
                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("You Cannot Transfer A Negative Amount!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("This Account Has Been Deleted");
                                        }
                                    }

                                    if (idcheck2 == busent.AccountNum)
                                    {
                                        if (isclosed == false)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("How Much Would You Like To Transfer?");
                                            int userin = Convert.ToInt32(Console.ReadLine());

                                            if (userin > 0)
                                            {
                                                loent.AccountBalance = loent.AccountBalance - userin;
                                                busent.AccountBalance = busent.AccountBalance + userin;

                                                Console.WriteLine();
                                                Console.WriteLine("The Loan Account With Account Number " + loent.AccountNum + " Now Has " + loent.AccountBalance);
                                                Console.WriteLine("The Business Account With Account Number " + busent.AccountNum + " Now Has " + busent.AccountBalance);

                                                trans.Add("Transfer of " + userin + " From " + loent.AccountType + " With Account Number " + loent.AccountNum + " To " + busent.AccountType + " With Account Number  " + busent.AccountNum);


                                            }
                                               
                                        }
                                        else
                                        {
                                            Console.WriteLine("You Cannot Transfer A Negative Amount!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("This Account Has Been Deleted");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("This Account Has Been Deleted");
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }
                if (userchoice == "payloan")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            Console.ReadLine();
                            Console.WriteLine("Which Loan Account Do You Wish To Pay? Please Enter The Account Number");
                            int idcheck = Convert.ToInt32(Console.ReadLine());

                            if (idcheck == loent.AccountNum)
                            {
                                if (isclosed == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Your Current Balance Is " + loent.AccountBalance);
                                    Console.WriteLine("How Much Would You Like To Pay Off?");
                                    int userin = Convert.ToInt32(Console.ReadLine());

                                    if (userin > 0)
                                    {
                                        loent.AccountBalance = loent.AccountBalance + userin;

                                        Console.WriteLine();
                                        Console.WriteLine("The Loan Account With Account Number " + loent.AccountNum + " Now Has " + loent.AccountBalance);

                                        trans.Add("Payment of " + userin + " To " + loent.AccountType + " With Account Number " + loent.AccountNum);

                                    }
                                    else
                                    {
                                        Console.WriteLine("You Cannot Pay A Negative Amount!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("This Account Has Been Deleted");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }

                if (userchoice == "accdisplay")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {

                            if (checkent.AccountNum != 0)
                            {
                                Console.WriteLine("The Account Number Is: " + checkent.AccountNum + " The Account Balance Is: " + checkent.AccountBalance + " The Interest Rate Is: " + checkent.Interest + " The Account Type Is: " + checkent.AccountType);

                            }
                            else
                            {
                                Console.WriteLine("There Are No Checking Accounts");
                            }

                            if (busent.AccountNum != 0)
                            {
                                Console.WriteLine("The Account Number Is: " + busent.AccountNum + " The Account Balance Is: " + busent.AccountBalance + " The Account Type Is: " + busent.AccountType);

                            }
                            else
                            {
                                Console.WriteLine("There Are No Business Accounts");
                            }

                            if (loent.AccountNum != 0)
                            {
                                Console.WriteLine("The Account Number Is: " + loent.AccountNum + " The Account Balance Is: " + loent.AccountBalance + " The Account Type Is: " + loent.AccountType);

                            }
                            else
                            {
                                Console.WriteLine("There Are No Loan Accounts");
                            }

                            if (trment.AccountNum != 0)
                            {
                                Console.WriteLine("The Account Number Is: " + trment.AccountNum + " The Account Balance Is: " + trment.AccountBalance + " Years Till Maturity: " + trment.Age + " The Account Type Is: " + trment.AccountType);

                            }
                            else
                            {
                                Console.WriteLine("There Are No Term Accounts");
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }

                if (userchoice == "transactions")
                {
                    try
                    {

                        Console.WriteLine();
                        Console.WriteLine("Please Enter Your ID:");
                        int readid = Convert.ToInt32(Console.ReadLine());

                        if (readid == cusent.Id)
                        {
                            foreach (string msg in trans)
                            {
                                Console.WriteLine();
                                Console.WriteLine(msg);

                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("No Such Customer Id Found");
                        }
                    }
                    catch (FormatException FormatEx)
                    {
                        Console.WriteLine(FormatEx.Message);
                    }
                }
            }
        }
    }
}