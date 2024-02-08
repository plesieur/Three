namespace Three
{
    internal class Program
    {
        //Written by Al McWhiggin (In less than 1 hour and still included comments!)
        //Owner/Coder/Toy Collector and self proclaimed Chicken Man
        static void Main(string[] args)
        {
            bool again = false;
            do
            {
                float total = 0;   //Running Total

                //Gather Info from Sales Person
                float cost = promptValue("\nPrice of goods");
                float weight = promptValue("Weight of goods");
                bool card = promptYes("Pay with credit card");

                //Does the customer get a 5% redeuction (R1)
                if (cost > 500)
                {
                    total = cost * (float)0.95;
                } else
                {
                    total = cost;
                }

                //Does the user pay a surcharge for credit card (R4)
                if (card)
                {
                    total = total * (float)1.03;

                    //Exemption from credit card surcharge (R5)
                    if ((cost > 1000) && (weight < 10))
                    {
                        //Deduct service charge added above
                        total = total * (float)0.97;
                    }
                }

                //Calculate Shipping Cost (R2) + (R3)
                float shipping = weight / (float)2.0;
                if ((weight > 10) && (total < 250))
                {
                    total += shipping;
                }

                //Calculate State Sales Tax (R6)
                total *= (float)1.05;

                Console.WriteLine("\n\nReceipt\n-------");
                Console.WriteLine("Cost of Goods:         ${0,8:N2}",   cost);
                Console.WriteLine("Shipping:              ${0,8:N2}",   shipping);
                Console.WriteLine("Tax on Goods:          ${0,8:N2}",   cost * (float).05);
                Console.WriteLine("Credit Card Charged:   ${0,8:N2}\n", total);

                again = promptYes("Again");
            } while (again);
        }
        
        //Query user for Yes/No answer
        //Input: Query Prompt to display
        //Returns Boolean Value: true - yes
        //                      false - no
        static bool promptYes(string display)
        {
            bool rv = true;

            Console.Write("{0} [y/n]? ", display);
            char response = Console.ReadKey().KeyChar;
            if (response == 'n')
            {
                rv = false;
            }
            Console.WriteLine();
            return rv;
        }

        //Query user for value
        //Input: Query Prompt to display
        //Returns value entered by user as a float
        static float promptValue(string display)
        {
            Console.Write("{0}? ", display);
            float rv = float.Parse(Console.ReadLine());
            return rv;
        }
    }
}
