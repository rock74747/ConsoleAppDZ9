using System.Xml.Linq;

namespace ConsoleAppDZ9
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1");

            int[] numbers = { -1, -2,-3, -4, -10, -34, -55, -66, -77, -88 };

            try
            {
               var num = numbers.Where (p => p > 0).ToArray ();
                if (num.Count() == 0)
                {
                    throw new NoPositiveNumbersException ("В последовательности нет положительных чисел");
                }
                else
                {              
                    Console.WriteLine($"Среднее арифметическое положительных чисел равно: {num.Average()}"); 
                }
                
            }
            catch (NoPositiveNumbersException ex) 
            {
                Console.WriteLine($"Возникла шибка: {ex.Message}");
                
            }

            Console.WriteLine("Задача 2");
            ContactsManager contacts = new ContactsManager();
            contacts.AddContact("Петров В.В.", 89065894153);
            contacts.AddContact("Иванов П.Д.", 89062084559);
            contacts.AddContact("Баширов Л.Д.",89042351781);
            contacts.AddContact("Журавлев В.В.", 89514152387);
            contacts.AddContact("Семенов В.Д.", 89235487129);
            contacts.AddContact("Петров В.В.", 89514897456);
            
            Console.WriteLine("\nДобавление контакта \n Введите Ф.И.О. (Фамилия И.О) -> "); // добавление контакта
            string name = Console.ReadLine();
            Console.WriteLine("Введите номер телефона (11-значный номер) -> ");
            long phonenumber = (long)Convert.ToInt64(Console.ReadLine()); 
            contacts.AddContact(name, phonenumber);
            Console.WriteLine("\nКонтакт добавлен!");
            contacts.Print();

            Console.WriteLine("\nПоиск контакта \n Введите Ф.И.О. (Фамилия И.О.) -> "); // поиск контакта по Ф.И.О.
            name = Console.ReadLine();
            List<Contact> contact = contacts.FindContactByName(name);
            if (contact.Count == 0)
                Console.WriteLine($"Данного контакта не существует");
            else
            {
                int count = 0;
                foreach (Contact emp in contact)
                {
                    Console.WriteLine($"{count + 1}. Фамилия И.О.: {emp.Name}, номер телефона: {emp.PhoneNumber}");
                    count++;
                }
            }
        }

    }
    
}
