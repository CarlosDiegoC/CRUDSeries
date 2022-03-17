
namespace CRUDSeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {            
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        RemoveSerie();
                        break;
                    case "5":
                        VisualizeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                userOption = GetUserOption();
            }
            Console.WriteLine("Thank you for use Series App");            
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("#CRUD SERIES APP#");
            Console.WriteLine();
            Console.WriteLine("Chose a option below:");
            Console.WriteLine("1 - LIST YOUR SERIES");
            Console.WriteLine("2 - INSERT A NEW SERIE");
            Console.WriteLine("3 - UPDATE A SERIE REGISTER");
            Console.WriteLine("4 - REMOVE A SERIE");
            Console.WriteLine("5 - VISUALIZE A SERIE");
            Console.WriteLine("C - CLEAN SCREEN");
            Console.WriteLine("X - EXIT");

            string userOption = Console.ReadLine();
            Console.WriteLine();
            return userOption;

        }

        
        private static void ListSeries()
        {
            Console.WriteLine("LIST OF YOUR SERIES");

            var list = repository.List();
            
            if (list.Count == 0)
            {
                Console.WriteLine("There's no serie register");
                return;
            }
            
            foreach (var serie in list)
            {
                var removed = serie.ReturnRemoveStatus();
                Console.WriteLine($"ID: {serie.ReturnId()} TITLE: {serie.ReturnTitle()} {(removed ? "#EXCLUDED#" : "")}");
            }
        }


        private static void InsertSerie()
        {
            Console.WriteLine("Insert a new serie");
            
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genre), i)}");
            }
            Console.Write("Enter with genre option:");
            int inputGenre = int.Parse(Console.ReadLine());
            
            Console.Write("Enter with serie Title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Enter with serie description: ");
            string inputDescription = Console.ReadLine();

            Console.Write("Enter with serie Year: ");
            int inputYear = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: repository.NextId(),
                                    genre: (Genre)inputGenre, 
                                    title: inputTitle, 
                                    description: inputDescription, 
                                    year: inputYear);
            
            repository.Insert(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Enter with Serie Id to update serie: ");
            int inputId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genre), i)}");
            }
            Console.Write("Enter with genre option: ");
            int inputGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter with serie Title: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Enter with serie description: ");
            string inputDescription = Console.ReadLine();

            Console.Write("Enter with serie Year: ");
            int inputYear = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: inputId,
                                    genre: (Genre)inputGenre,
                                    title: inputTitle,
                                    description: inputDescription,
                                    year: inputYear);

            repository.Update(inputId, serie);
        }
        
        private static void RemoveSerie()
        {
            Console.Write("Enter with serie id to remove a serie: ");
            int inputId = int.Parse(Console.ReadLine());
            repository.Remove(inputId);
        }

        private static void VisualizeSerie()
        {
            Console.Write("Enter with a serie id to visualize a serie: ");
            int inputId = int.Parse(Console.ReadLine());
            var serie = repository.ReturnById(inputId);
            Console.WriteLine(serie);
        }
    }
}