using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР6._2
{
    // Сервисы
    class Catalog
    {
        Random rnd = new Random();
        List<string> list = new List<string>() { "Книга Гари потер", "Книга Мерипопинс", "Книга Пушкин", "Флешка с фильмами марвел", "Футболка с миньенами", "Флешка с фильмом Гадкий Я", "Футболка с ироничнойнатписью" };
        List<string> catalog = new List<string>();
        string menuStr = null;
        string str;
        public IStrategy Movable { get; set; }
        public Catalog(IStrategy istrategy)
        {
            Movable = istrategy;
        }
        public string RndCatalog()
        {
            menuStr = null;
            str = null;
            for (int i = 1; i <= 3; i++)
            {
                str = catalog[rnd.Next(catalog.Count - 1)];
                menuStr += $"{i}  {str}\n";
                catalog.Remove(str);
            }
            return menuStr;
        }
        public void CatalogList()
        {
            catalog.Clear();
            catalog.AddRange(list);
        }
        public string NewOrder(string str)
        {
            return Movable.NewOrder(str);
        }
    }

    public interface IStrategy
    {
        string NewOrder(string str);
    }

    public class NewOrder1 : IStrategy
    {
        Random rnd = new Random();
        public string NewOrder(string str)
        {
            string[] words;
            if (rnd.Next(1, 11) != 1)
            {
                words = str.Split(',');
                str = $"Количество заказываемых вами предметов: {words.Length}\nСтоимость равняется: {words.Length * rnd.Next(100, 200)}";
            }
            else str = null;
            return str;
        }
    }

    public class NewOrder2 : IStrategy
    {
        Random rnd = new Random();
        public string NewOrder(string str)
        {
            string[] words;
            if (rnd.Next(1, 11) != 1)
            {
                words = str.Split(',');
                str = $"Количество заказываемых вами предметов: {words.Length}\nСтоимость равняется: {words.Length * rnd.Next(500, 1000)}";
            }
            else str = null;
            return str;
        }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm(string str)
        {
            ContextStrategy.NewOrder(str);
        }
    }
}
