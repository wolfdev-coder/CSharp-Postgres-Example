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
                User user1 = new User { Name = namePerson, Role = rolePerson, Job = jobPerson };
                db.Users.AddRange(user1);
                db.SaveChanges();
                Console.WriteLine("Успешно!");


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
                Console.WriteLine("Успешно!");
                Cars newCar = new Cars { Name =  nameCar, Engine = engineCar };
                db.Car.AddRange(newCar);
                db.SaveChanges();
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