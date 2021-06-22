using System;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            SweetTooth st = new SweetTooth();
            SpiceHound sh = new SpiceHound();

            while(!st.IsFull)
                st.Consume(buffet.Serve());
            st.Consume(buffet.Serve());

            while(!sh.IsFull)
                sh.Consume(buffet.Serve());
            sh.Consume(buffet.Serve());

            if(st.ConsumptionHistory.Count > sh.ConsumptionHistory.Count)
                Console.WriteLine($"Sweet Tooth consumed: {st.ConsumptionHistory.Count} items!, more than Spice Hound: {sh.ConsumptionHistory.Count} items.");
            else if(st.ConsumptionHistory.Count < sh.ConsumptionHistory.Count)
                Console.WriteLine($"Spice Hound consumed: {sh.ConsumptionHistory.Count} items!, more than Sweet Tooth: {st.ConsumptionHistory.Count} items.");
            else
                Console.WriteLine($"Sweet Tooth and Spice Hound consumed the same amount of items: {st.ConsumptionHistory.Count}");


        }
    }
}
