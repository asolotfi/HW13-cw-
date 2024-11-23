using HW13.Contract.Repositoris;
using HW13.Contract.Sevices;
using HW13.Entities;
using HW13.infrastructure.Repositories;

namespace HW13.Services
{
    public class MemberService : IMemberSevices
    {
        private readonly IMemberRepository _MemberRepository;
        public MemberService()
        {
            _MemberRepository = new MemberRepository();
        }
        public List<Member> GetMemberList()
        {
            return _MemberRepository.GetMemberList();
        }
        public bool CanBorrowBooks(int id)
        {
            return _MemberRepository.CanBorrowBooks(id);
        }
        public bool ExtendMembership(int Days, int id)
        {
            _MemberRepository.ExtendMembership(Days, id);
            return true;
        }
        public DateTime ExtendMembershipRegister()
        {
            return _MemberRepository.ExtendMembershipRegister();
        }
    }
}
