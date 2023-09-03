namespace ConsoleAppPersons
{
    public class Program
    {

        static void Main(string[] args)
        {
            var workWithSQL = new WorkWithSql();
            workWithSQL.OpenConnectionToSql();

            string choice;
            do
            {
                Console.WriteLine("What you want to do?\n 1. Show persons\n 2. Create person\n 3. Delete person by Id\n 4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        workWithSQL.SelectAllFromDbAdnPrint();
                        break;

                    case "2":
                        WorkWithConsole.AskLastName(out string lastName);
                        WorkWithConsole.AskFirstName(out string firstName);
                        WorkWithConsole.AskAge(out int age);
                        workWithSQL.InsertToTablePersons(lastName, firstName, age);
                        break;

                    case "3":
                        workWithSQL.DeleteFromDbById();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("You entered something wrong, re-enter!!");
                        break;
                }
                Console.WriteLine("Do you want to continue? (yes(y)/no(n))");
                choice = Console.ReadLine();
            }
            while (choice == "yes" || choice == "y");

            workWithSQL.CloseConnectionToSql();
        }



    }
}