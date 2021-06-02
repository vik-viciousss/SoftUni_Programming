using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();

            string[] sitesToVisit = Console.ReadLine().Split();

            ICallable stationaryPhone = new StationaryPhone();
            IBrowsable smartphone = new Smartphone();

            for (int i = 0; i < numbersToCall.Length; i++)
            {
                string currNumber = numbersToCall[i];

                if (currNumber.Length == 7)
                {
                    stationaryPhone.Call(currNumber);
                }
                else if (currNumber.Length == 10)
                {
                    smartphone.Call(currNumber);
                }
            }


            for (int i = 0; i < sitesToVisit.Length; i++)
            {
                string currSite = sitesToVisit[i];
                smartphone.Browse(currSite);
            }
        }
    }
}
