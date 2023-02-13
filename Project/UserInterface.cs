namespace Project
{
    public class UserInterface
    {
        private string? input;
        private APOD register;
        public UserInterface(APOD register)
        {
            this.register = register;
            this.input = "";
        }
        public void Start()
        {
            Choose();
        }
        public void Choose()
        {
            while (true)
            {
                Info();
                input = Console.ReadLine();

                if (input == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ok bye!");
                    break;
                }
                else if (input == "1")
                {
                    register.TodaysAPOD();
                }

                else if (input == "2")
                {
                    register.YesterdaysAPOD();
                }

                else if (input == "3")
                {
                    register.GetRandomAPOD();
                }

                else
                {
                    Console.WriteLine("User pressed the wrong key");
                }
            }
        }
        public void Info()
        {
            Console.WriteLine("Choose a number: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1 - Downloads today's astronomical picture.");
            Console.WriteLine("2 - Downloads yesterdays's astronomical picture.");
            Console.WriteLine("3 - Downloads an astronomical picture from 16.6.1996 to this moment.");
            Console.WriteLine("0 - Quits the program." + "\n");
            Console.Write(": ");
        }
    }
}