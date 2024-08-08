using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppDZ9
{
    public class ContactsManager
    {
        List<Contact> list = new List<Contact> { };
        public void AddContact(string name, long phonenumber)
        {
            try
            {
                if (name == null || name.Length == 0 || name.LastIndexOf(".") != name.Length - 1 || phonenumber.ToString().Length != 11)
                    throw new InvalidContactException("Имя или номер введены неправильно");
            }
            catch (InvalidContactException ex)
            {
                while (name == null || name.Length == 0 || name.LastIndexOf(".") != name.Length - 1 || phonenumber.ToString().Length != 11)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    Console.Write("\nВведите Ф.И.О. -> ");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона (11-значный номер) -> ");
                    phonenumber = (long)Convert.ToInt64 (Console.ReadLine());
                }
            }
            list.Add(new Contact(name, phonenumber));
        }

        public List<Contact> FindContactByName(string name)
        {
            try
            {
                if (name == null || name.Length == 0 || name.LastIndexOf(".") != name.Length-1)
                    throw new InvalidContactException("Имя введено неправильно");
            }
            catch (InvalidContactException ex)
            {
                while (name == null || name.Length == 0 || name.LastIndexOf(".") != name.Length-1)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}");
                    Console.Write("\nВведите Ф.И.О. (Фамилия И.О.)-> ");
                    name = Console.ReadLine();
                }
            }
            var result = list.Where(p => p.Name == name);
            return result.ToList();
        }
        public void Print() // Метод вывода в консоль телефонной книги
        {
            int counter = 0;
            foreach (Contact el in list)
            {
                Console.WriteLine($"{counter + 1}. Имя: {el.Name}, номер телефона: {el.PhoneNumber}");
                counter++;
            }
        }
    }
}
