//Project name: Module 5 Programming Assigment
//Project purpose: Alarm Clock  
//Created by: Jacob McMahon

using System;
using System.Threading;

namespace Mod_5_Programming_Assignment_Jacob_McMahon
{
    public class Clock
    {
        private int seconds_left;
        public Clock(int seconds_left)
        {
            this.seconds_left = seconds_left;
        }

        public delegate void SecondChanged(object clock, CountDown CountDown);
        public SecondChanged second_elapsed;
        public void Run()
        {
            while (this.seconds_left >= 0)
            {
                CountDown CountDown = new CountDown(this.seconds_left);
                if (second_elapsed != null)
                {
                    second_elapsed(this, CountDown);
                }
                Thread.Sleep(1000); //in milliseconds
                this.seconds_left--;
            }
        }
    }

    public class WriteCountDown //Show user the live countdown 
    {
        
        public void Counter(Clock clock)
        {
            clock.second_elapsed += Countdownseconds_left;
        }

        public void Countdownseconds_left(object clock, CountDown ti)
        {
            Console.WriteLine("seconds_left: {0}", ti.seconds_left.ToString());
        }
    }

    
    public class Launch
    {
        public void Counter(Clock clock)
        {
            clock.second_elapsed += AlertUser;
        }

        public void AlertUser(object clock, CountDown ti)//Check if the timer is down to 0 
        {
            
            if (ti.seconds_left == 0)
            {
                Console.WriteLine("BEEP BEEP BEEP TIME HAS ELAPSED");
            }
        }
    }

        public class CountDown : EventArgs
    {
       
        public int seconds_left;
        
        public CountDown(int seconds_left)
        {
            this.seconds_left = seconds_left;
        }
    }

    public class Observer
    {
        //implement the Run method
        public void Run()
        {

            Console.WriteLine("Enter the number of seconds to wait ");
            int seconds = Convert.ToInt32(Console.ReadLine());
            Clock clock = new Clock(seconds);
            WriteCountDown countdown = new WriteCountDown();

            countdown.Counter(clock);

            Launch LaunchObject = new Launch();

            LaunchObject.Counter(clock);
            clock.Run();
        }
    }

    class Program
    {
        //main method
        public static void Main()//Main starts timer 
        {
            Observer timer = new Observer();
            timer.Run();
        }
    }
}
