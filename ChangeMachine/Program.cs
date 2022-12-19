namespace ChangeMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            var coinsInMachine = new Dictionary<string, int>()
            {
                {"Dollars", 100},
                {"Fiddy", 200},
                {"Quarters", 400},
                {"Dimes", 1000},
                {"Nickels", 2000}
            };
            int dollarCoins = 0;
            int fiddyCentCoins = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            Console.WriteLine("Stamps are currently $0.60 each. Please enter how many you would like: ");
            int stamps = Convert.ToInt32(Console.ReadLine());
            var totalCost = stamps * 0.60;
            Console.WriteLine($"The total cost for your stamps will be ${totalCost.ToString("0.00")}");

            Console.WriteLine("Enter the amount of money you're entering into the machine: ");
            double moneyEntered = Convert.ToDouble(Console.ReadLine());

            double totalReturn = moneyEntered - totalCost;
            Console.WriteLine($"Your change is ${totalReturn.ToString("0.00")}. Please wait, calculating coins to return...");

            while (totalReturn / 1 >= 1 && totalReturn > 0)
            {
                dollarCoins++;
                coinsInMachine["Dollars"]--;
                totalReturn--;
                if (coinsInMachine["Dollars"] < 1)
                {
                    break;
                }
            }
            Console.WriteLine($"Dollar coins returned: {dollarCoins}");

            while (totalReturn >= 0.5 && totalReturn > 0)
            {
                fiddyCentCoins++;
                coinsInMachine["Fiddy"]--;
                totalReturn = totalReturn - 0.50;
                if (coinsInMachine["Fiddy"] < 1)
                {
                    break;
                }
            }
            Console.WriteLine($"Fiddy cent coins returned: {fiddyCentCoins}");

            while (totalReturn >= 0.25 && totalReturn > 0)
            {
                quarters++;
                coinsInMachine["Quarters"]--;
                totalReturn = totalReturn - 0.25;
            }
            Console.WriteLine($"Quarters returned: {quarters}");

            while (totalReturn >= 0.1 && totalReturn > 0)
            {
                dimes++;
                coinsInMachine["Dimes"]--;
                totalReturn = totalReturn - 0.10;
            }
            Console.WriteLine($"Dimes returned: {dimes}");

            while (totalReturn >= 0.05 && totalReturn > 0)
            {
                nickels++;
                coinsInMachine["Nickels"]--;
                totalReturn = totalReturn - 0.05;
            }
            Console.WriteLine($"Nickels returned: {nickels}");
        }


    }
}