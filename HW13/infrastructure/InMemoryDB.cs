using HW13.Entities;

namespace HW13.infrastructure
{
    public class InMemoryDB
    {
        public static Member? OnlineMember { get; set; }
        public static Librarian? OnlineLibrarian { get; set; }
        public static void checkUserIsLogin()
        {
            if (OnlineMember != null && OnlineLibrarian != null)
            {
                throw new Exception("pleas login");
            }
        }
    }
}
