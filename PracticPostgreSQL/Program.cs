using PracticPostgreSQL;
using System.ComponentModel.Design;
using System.Runtime;
using System.Threading.Tasks.Dataflow;

class Program
{
    public static ApplicationContext db = new ApplicationContext();
    static void Main(string[] args)
    {
        while (true)
        {
            string message  = Console.ReadLine();
            if (message == "Создать персонажа")
            {
                Console.WriteLine("Введите имя персонажа");
                string namePerson = Console.ReadLine();
                Console.WriteLine("Введите роль персонажа");
                string rolePerson = Console.ReadLine();
                Console.WriteLine("Введите работу персонажа");
                string jobPerson = Console.ReadLine();
                try
                {
                    User user1 = new User { Name = namePerson, Role = rolePerson, Job = jobPerson };
                    db.Users.AddRange(user1);
                    db.SaveChanges();
                    Console.WriteLine("Успешно!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            else if (message == "Персонажи")
            {
                var users = db.Users.ToList();
                Console.WriteLine("Персонажи:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Role} | {u.Job}");
                }
            }
            else if ( message == "Создать машину")
            {
                Console.WriteLine("Введите название машины");
                string nameCar = Console.ReadLine();
                Console.WriteLine("Введите литраж двигателя машины");
                double engineCar = Convert.ToDouble(Console.ReadLine());
                try
                {
                    Cars newCar = new Cars { Name = nameCar, Engine = engineCar };
                    db.Car.AddRange(newCar);
                    db.SaveChanges();

                    Console.WriteLine("Успешно!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if ( message == "Машины")
            {
                var carsList = db.Car.ToList();
                Console.WriteLine("Машины:");
                foreach (Cars car in carsList)
                {
                    Console.WriteLine($"{car.Id}.{car.Engine} - {car.Name}");
                }
            }
        }
    }
}