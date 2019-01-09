using System;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;


namespace AgentNetworkManagement.Business.Repositories
{
    internal class MemberInformation:IMember
    {

        private readonly ApplicationDbContext _ctx;

        public MemberInformation(ApplicationDbContext context)
        {
            _ctx = context;
        }

        /// <summary>
        /// get memeber information
        /// </summary>
        /// <param name="predicate">lambda expression</param>
        /// <returns>return collection of member </returns>
        //public IEnumerable<Member> Get(Func<Member, bool> predicate = null) => predicate == null
        //    ? _ctx.Members.OrderBy(s => s.Name)
        //    : _ctx.Members.Where(predicate);


        /// <summary>
        /// get single member object
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>return member object</returns>
        public Member Find(Func<Member, bool> predicate) => _ctx.Members
            .FirstOrDefault(predicate);


        //public Notification Add(UserPositionHeldInOrganogramm entity)
        //{
        //    var notification = new Notification();
        //    try
        //    {
                
        //        _ctx.UserPositionHeld.Add(entity);
        //        _ctx.SaveChanges();
        //        notification.Message = "role was created successful";
        //        notification.Success = false;
        //    }
        //    catch
        //    {
        //        notification.Message = "fail to create role";
        //        notification.Success = false;
        //    }
        //    return notification;
        //}

        public Notification Add(UserPositionHeldInOrganogramm entity)
        {
            var notification = new Notification();
            using (var trns = _ctx.Database.BeginTransaction())
            {
                try
                {
                    var checkOfUserHasWorkSpace = _ctx.UserPositionHeld.SingleOrDefault(s => s.UserId.Equals(entity.UserId));
                    if (checkOfUserHasWorkSpace != null )
                    {
                        var userspace = new UserPositionHeldInOrganogramm
                        {
                            UserId = checkOfUserHasWorkSpace.UserId,
                            OrggrammId = checkOfUserHasWorkSpace.OrggrammId
                        };
                        var delete = _ctx.Database.ExecuteSqlCommand("Delete FROM  UserPositionHeldInOrganogramms where UserId = {0}", new object[] { userspace.UserId });
                        //_ctx.Entry(userspace).State = EntityState.Deleted;
                        //_ctx.SaveChanges();
                        _ctx.UserPositionHeld.Add(entity);
                        _ctx.SaveChanges();
                    }
                    else
                    {
                        _ctx.UserPositionHeld.Add(entity);
                        _ctx.SaveChanges();
                    }
                   
                    trns.Commit();
                    notification.Id = Guid.NewGuid().ToString();
                    notification.Message = "role was created successful";
                    notification.Success = true;
                }
                catch (Exception ex)
                {
                    trns.Rollback();
                    notification.Id = Guid.NewGuid().ToString();
                    notification.Message = "fail to create role";
                    notification.Success = false;
                }
            }

            return notification;
        }



        public Notification AddMemberToAgentNetwork(AssignUsersToTheirAgentNetwork entity)
        {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.UsersToTheirAgentNetworks.Add(entity);
                _ctx.SaveChanges();
                notification.Id = Guid.NewGuid().ToString();
                notification.Message = "role was created successful";
                notification.Success = true;
            }
            catch
            {
                notification.Id = Guid.NewGuid().ToString();
                notification.Message = "fail to create role";
                notification.Success = false;
            }
            return notification;
        }


        public IQueryable<Member> GetMembers() => from u in _ctx.Members
            select u;

        public IQueryable<Member> Get(Func<Member, bool> predicate = null)
            => predicate == null
                ? _ctx.Members.OrderBy(s => s.Name)
                : _ctx.Members.Where(predicate).AsQueryable();

       
    }
}
