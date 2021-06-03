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

            foreach (var number in numbersToCall)
            {
                try
                {
                    string result = number.Length == 10
                    ? smartphone.Call(number)
                    : stationaryPhone.Call(number);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in sitesToVisit)
            {
                try
                {
                    string result = smartphone.Browse(url);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



            //for (int i = 0; i < numbersToCall.Length; i++)
            //{
            //    string currNumber = numbersToCall[i];

            //    if (currNumber.Length == 7)
            //    {
            //        string result = stationaryPhone.Call(currNumber);
            //    }
            //    else if (currNumber.Length == 10)
            //    {
            //        string result = smartphone.Call(currNumber);
            //    }
            //}

            //for (int i = 0; i < sitesToVisit.Length; i++)
            //{
            //    string currSite = sitesToVisit[i];
            //    smartphone.Browse(currSite);
            //}
        }
    }
}
