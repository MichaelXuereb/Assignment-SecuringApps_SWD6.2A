using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class MemberService : IMembersService
    {
        private IMapper _autoMapper;
        IMembersRepository _membersRepo;
        public MemberService(IMembersRepository repo, IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _membersRepo = repo;
        }
        public void AddMember(MemberViewModel m)
        {
            Member member = new Member()
            {
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName,
                PublicKey = m.PublicKey,
                PrivateKey = m.PrivateKey,
                TeacherEmail = m.TeacherEmail
            };
            _membersRepo.AddMember(member);
        }

        public MemberViewModel GetMember(string email)
        {
            var m = _membersRepo.GetMember(email);
            if (m == null) return null;
            else
            {
                var result = _autoMapper.Map<MemberViewModel>(m);
                return result;
            }
        }
    }
}
