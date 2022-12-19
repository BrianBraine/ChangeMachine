namespace ChangeMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            const double STAMP_COST = 0.60;
            var coinsInMachine = new Dictionary<string, int>()
            {
                {"Dollars", 100},
                {"Fiddies", 200},
                {"Quarters", 400},
                {"Dimes", 1000},
                {"Nickels", 2000},
                {"Pennies", 10000 }
            };
            int dollarCoins = 0;
            int fiddyCentCoins = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;

            double dollarDenom = 1;
            double fiddyDenom = 0.5;
            double quarterDenom = 0.25;
            double dimeDenom = 0.1;
            double nickelDenom = 0.05;
            double pennyDenom = 0.01;



            Console.WriteLine($"Stamps are currently ${STAMP_COST.ToString("0.00")} each. Please enter how many you would like: ");
            int stamps = Convert.ToInt32(Console.ReadLine());
            var totalCost = stamps * STAMP_COST;
            Console.WriteLine($"The total cost for your stamps will be ${totalCost.ToString("0.00")}");

            Console.WriteLine("Enter the amount of money you're entering into the machine: ");
            double moneyEntered = Convert.ToDouble(Console.ReadLine());

            double totalReturn = moneyEntered - totalCost;
            Console.WriteLine($"Your change is ${totalReturn.ToString("0.00")}. Please wait, calculating coins to return...");

            CoinReturn(coinsInMachine, dollarCoins, ref totalReturn, dollarDenom, "Dollars");
            CoinReturn(coinsInMachine, fiddyCentCoins, ref totalReturn, fiddyDenom, "Fiddies");
            CoinReturn(coinsInMachine, quarters, ref totalReturn, quarterDenom, "Quarters");
            CoinReturn(coinsInMachine, dimes, ref totalReturn, dimeDenom, "Dimes");
            CoinReturn(coinsInMachine, nickels, ref totalReturn, nickelDenom, "Nickels");
            CoinReturn(coinsInMachine, pennies, ref totalReturn, pennyDenom, "Pennies");


        }

        private static void CoinReturn(Dictionary<string, int> coinsInMachine, int coins, ref double totalReturn, double denomination, string coinType)
        {
            while (totalReturn >= denomination && totalReturn > 0)
            {
                coins++;
                coinsInMachine[$"{coinType}"]--;
                totalReturn = totalReturn - denomination;
                if (coinsInMachine[$"{coinType}"] < 1)
                {
                    break;
                }
            }
            Console.WriteLine($"{coinType} returned: {coins}");
        }
    }
}