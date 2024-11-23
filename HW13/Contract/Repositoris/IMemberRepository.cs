using HW13.Entities;

namespace HW13.Contract.Repositoris
{
    public interface IMemberRepository
    {
        List<Member> GetMemberList();
        bool CanBorrowBooks(int id);
        bool ExtendMembership(int Days, int id);
        DateTime ExtendMembershipRegister();

    }
}
