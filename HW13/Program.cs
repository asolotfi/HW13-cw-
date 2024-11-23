using HW13.Entities;
using HW13.infrastructure;
using HW13.infrastructure.Repositories;
using HW13.Role;
using HW13.Services;
MemberRepository memberRepository = new MemberRepository();
LibrerianRepository librerianRepository = new LibrerianRepository();
AuthenticationService authenticationSevice = new AuthenticationService();
BookService bookServic = new BookService();
MemberService memberService = new MemberService();
mainMenu();
void mainMenu()
{
    Console.Clear();
    Console.WriteLine("Please Select Your Action :  1.Login   2.Register");
    if (!Int32.TryParse(Console.ReadLine(), out int ActionId))
    {
        Console.WriteLine("Selected َAction is InValid");
        mainMenu();
    }
    switch (ActionId)
    {
        case 1:
            login();

            break;
        case 2:
            Register();
            break;
    }
}
void Register()
{
    Console.Clear();
    Console.WriteLine("=====================================");
    Console.WriteLine($"             Register               ");
    Console.WriteLine("=====================================");
    Console.WriteLine("Pleas Enter your firstName");
    var Firstname = Console.ReadLine();
    Console.WriteLine("Pleas Enter your LastName");
    var LastName = Console.ReadLine();
    Console.WriteLine("Pleas Enter your Email");
    var userName = Console.ReadLine();
    Console.WriteLine("Pleas Enter your Password");
    var password = Console.ReadLine();
    DateTime RegistrationDate = DateTime.Now;
    DateTime ExpiryDate = memberService.ExtendMembershipRegister();
    Console.WriteLine("Pleas Enter your Role  Member=>1  Librarian=>2 ");
    int Role = int.Parse(Console.ReadLine());
    RoleEnum role = RoleEnum.member;
    if (Role == 1)
        role = RoleEnum.member;
    else if (Role == 2)
        role = RoleEnum.Librarian;
    if (authenticationSevice.Register(Firstname, LastName, userName, password, RegistrationDate, ExpiryDate, role))
        login();
    else
        Console.WriteLine("user is found");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.ReadKey();
    mainMenu();
}
void login()
{
    try
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine($"              login                 ");
        Console.WriteLine("=====================================");
        Console.WriteLine("Pleas Enter your Username(Email)");
        var Email = Console.ReadLine();
        Console.WriteLine("Pleas Enter your Password");
        var password1 = Console.ReadLine();
        var result = authenticationSevice.Login(Email, password1);
        var result1 = RoleEnum.member;
       if(InMemoryDB.OnlineLibrarian.role == null && InMemoryDB.OnlineLibrarian ==null)
        {
            result1 = RoleEnum.member;
        }
        else
        {
            result1 = RoleEnum.Librarian;
        }
        if (result && result1 == RoleEnum.member)
        {
            if (memberService.CanBorrowBooks(InMemoryDB.OnlineMember.Id))
                MenuMember();
            else
            {
                Console.WriteLine("You have no credit");
                Console.ReadKey();
                login();
            }
        }
        else if (result && InMemoryDB.OnlineLibrarian.role == RoleEnum.Librarian)
            MenuLibrarian();
    }
    catch
    {
        Console.WriteLine("pleas enter login/register");
        Console.ReadKey();
    }
}
void MenuMember()
{
    while (true)
    {
        int action = 0;
        Console.Clear();
        Console.WriteLine("1   BorrowBook");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("2   ReturnBook");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("3  your Book List ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("4   Book List");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("5  Log Out");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ResetColor();
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            action = number;
        }
        else
        {
            Console.WriteLine("Pleas Enter number");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ReadKey();
        }
        switch (action)
        {
            case 1:
                try
                {
                    Console.Clear();
                    Console.WriteLine("===========BorrowBook=================");
                    List<Book> books = bookServic.getAvailableBooks();
                    foreach (var item in books)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} Title | {item.Title} Author | {item.Author} IsBorrowed | {item.IsBorrowed} Order | PublicationYear {item.PublicationYear}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    Console.WriteLine("================================");
                    Console.WriteLine("Pleas Enter BookId");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    var Id = int.Parse(Console.ReadLine());
                    var result = bookServic.BorrowBook(Id);
                    if (result)
                        Console.WriteLine("successful");
                    else
                        Console.WriteLine("unsuccessful");
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Pleas Enter id");
                }
                break;
            case 2:
                try
                {
                    Console.Clear();
                    Console.WriteLine("===========ReturnBook=================");
                    int MemberId = InMemoryDB.OnlineMember.Id;
                    List<Book> books = bookServic.GetListOfUserBooks(MemberId);
                    foreach (var item in books)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} Title | {item.Title} Author | {item.Author} IsBorrowed | {item.IsBorrowed} Order | PublicationYear {item.PublicationYear}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    Console.WriteLine("================================");
                    Console.WriteLine("Pleas Enter BookId");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    var Id = int.Parse(Console.ReadLine());
                    var result = bookServic.ReturnBook(Id);
                    if (result)
                        Console.WriteLine("successful");
                    else
                        Console.WriteLine("unsuccessful");
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Pleas Enter id");
                }
                break;
            case 3:
                try
                {
                    Console.Clear();
                    Console.WriteLine($"===========your Book {InMemoryDB.OnlineMember.FirstName}=================");
                    int MemberId = InMemoryDB.OnlineMember.Id;
                    List<Book> books = bookServic.GetListOfUserBooks(MemberId);
                    foreach (var item in books)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} Title | {item.Title} Author | {item.Author} IsBorrowed | {item.IsBorrowed} Order | PublicationYear {item.PublicationYear}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Book not found");
                }
                break;
            case 4:
                try
                {
                    Console.Clear();
                    Console.WriteLine($"=========== List Book =================");
                    List<Book> books = bookServic.getAvailableBooks();
                    foreach (var item in books)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} Title | {item.Title} Author | {item.Author} IsBorrowed | {item.IsBorrowed} Order | PublicationYear {item.PublicationYear}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Book not found");
                }
                break;
            case 5:
                InMemoryDB.OnlineMember = null;
                login();
                break;
        }
    }
}
void MenuLibrarian()
{
    while (true)
    {
        int action = 0;
        Console.Clear();
        Console.WriteLine("1   show All Book");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("2   Show All Member");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("3  Add Book ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("4 ExtendMemberBorrow ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("5  logout ");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ResetColor();
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            action = number;
        }
        else
        {
            Console.WriteLine("Pleas Enter number");
        }
        switch (action)
        {
            case 1:
                Console.Clear();
                int userId2 = InMemoryDB.OnlineLibrarian.Id;
                List<Book> books = bookServic.ShowAll();
                foreach (var item in books)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine($" id | {item.Id} Title | {item.Title} IsBorrowed | {item.IsBorrowed} ");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                }
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                int userId1 = InMemoryDB.OnlineLibrarian.Id;
                List<Member> member = memberService.GetMemberList();
                if (member == null)
                    Console.WriteLine("Member not found");
                else
                    foreach (var item in member)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} UserName | {item.UserName} FirstName | {item.FirstName} LastName | {item.LastName}  ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------");
                    }
                Console.ReadKey();
                break;
            case 3:
                try
                {
                    Console.Clear();
                    Console.WriteLine("=====================================");
                    Console.WriteLine($"             Add Book               ");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("Pleas Enter your Title");
                    var Title = Console.ReadLine();
                    Console.WriteLine("Pleas Enter your Author");
                    var Author = Console.ReadLine();
                    Console.WriteLine("Pleas Enter your PublicationYear");
                    DateTime Publication_year = DateTime.Parse(Console.ReadLine());
                    if (bookServic.AddBook(Title, Author, Publication_year))
                    {
                        Console.WriteLine("success");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ReadKey();
                        MenuLibrarian();
                    }
                    else
                        Console.WriteLine("unsuccess");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ReadKey();
                    mainMenu();
                }
                catch
                {
                    Console.WriteLine("Pleas Enter item Correct");
                }
                break;
            case 4:
                Console.Clear();
                int userId3 = InMemoryDB.OnlineLibrarian.Id;
                List<Member> members = memberService.GetMemberList();
                foreach (var item in members)
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($" id | {item.Id} FirstName | {item.FirstName} LastName | {item.LastName} ExpiryDate | {item.ExpiryDate} ");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                }
                Console.WriteLine("Pleas Enter Day");
                int Day = int.Parse(Console.ReadLine());
                Console.WriteLine("Pleas Enter MemberId");
                int id = int.Parse(Console.ReadLine());
                if (memberService.ExtendMembership(Day, id))
                {
                    Console.WriteLine("success");
                    List<Member> members1 = memberService.GetMemberList();
                    foreach (var item in members1)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($" id | {item.Id} FirstName | {item.FirstName} LastName | {item.LastName} ExpiryDate | {item.ExpiryDate} ");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("unsuccess");
                    Console.ReadKey();
                }
                break;
            case 5:
                InMemoryDB.OnlineMember = null;
                login();
                break;


        }
    }
}

