using HW13.Contract.Repositoris;
using HW13.Entities;

namespace HW13.infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;
        public MemberRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Member> GetMemberList()
        {
            return _appDbContext.members.ToList();
        }
        public bool CanBorrowBooks(int id)
        {
            Member member = _appDbContext.members.Where(M => M.Id == id).FirstOrDefault();
            if (member.ExpiryDate.HasValue && member.ExpiryDate.Value >= DateTime.Now)
                return true;
            else
                return false;
        }
        public bool ExtendMembership(int Days, int id)
        {
            Member member = _appDbContext.members.Where(M => M.Id == id).FirstOrDefault();
            if (member.ExpiryDate.HasValue)
            {
                member.ExpiryDate = member.ExpiryDate.Value.AddDays(Days);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public DateTime ExtendMembershipRegister()
        {
                return DateTime.Now.AddDays(30);
        }
    }
}
