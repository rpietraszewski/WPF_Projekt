using System.Collections.Generic;

namespace ToDoListLogic
{
    public class Category
    {
        public const string School = "Szkoła";
        public const string Job = "Praca";
        public const string Health = "Zdrowie";
        public const string Travel = "Podróż";
        public const string Home = "Dom";
        public const string Social = "Społeczność";

        public static IEnumerable<string> GetCategories()
        {
            List<string> categories = new List<string>()
            {
                School,
                Job,
                Health,
                Travel,
                Home,
                Social,
            };
            return categories;
        }
    }
}
