namespace ConsoleAppPersons
{
    public class WorkWithConsole
    {
        public static void AskFirstName(out string firstName)
        {
            Console.WriteLine("What is your first name?");
            firstName = Console.ReadLine();
        }

        public static void AskLastName(out string lastName)
        {
            Console.WriteLine("What is your last name?");
            lastName = Console.ReadLine();
        }

        public static void AskAge(out int age)
        {
            Console.WriteLine("What is your age?");
            age = int.Parse(Console.ReadLine());
        }


    }
}
