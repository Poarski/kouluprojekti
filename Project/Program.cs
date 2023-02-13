using System;
using System.Drawing;
using System.Net;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            APOD register = new APOD();
            UserInterface ui = new UserInterface(register);
            ui.Start();
        }
    }
}