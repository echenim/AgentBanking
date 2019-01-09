using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class MemberLogic
    {
        private readonly IMember _member;

        public MemberLogic()
        {
            _member = new MemberInformation(new ApplicationDbContext());
        }

        //public IEnumerable<Member> Get(Func<Member, bool> predicate = null) => _member.Get(predicate);
        public IQueryable<Member> Get(Func<Member, bool> predicate = null) => _member.Get(predicate);
        public Member Find(Func<Member, bool> predicate) => _member.Find(predicate);

        public Notification AddWorkArea(UserPositionHeldInOrganogramm entity) => _member.Add(entity);

        public Notification AssignMemberToNetwork(AssignUsersToTheirAgentNetwork entity)
            => _member.AddMemberToAgentNetwork(entity);
    }
}
