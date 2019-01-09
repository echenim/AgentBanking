using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;

namespace AgentNetworkManagement.Business.Repositories
{
   internal  class SystemAuditRepository: ISystemAudit
    {
       readonly ApplicationDbContext _ctx;

       public SystemAuditRepository(ApplicationDbContext ctx)
       {
           _ctx = ctx;
       }

       #region Implementation of IAdd<SystemAudit>

       

        #endregion

       #region Implementation of ISystemAudit

       public void Add(string actor, string whatwastheactodoing,string ranking,string sb)
       {
            //var log = new SystemExceptionMarker
            //{
            //    Originator = actor.ToLower(),
            //    Reason = whatwastheactodoing.ToLower(),
            //    Message = sb.ToString(),
            //    Ranking = ranking,
            //    Stamp = DateTime.Now
            //};
         //  var sql = "INSERT INTO SystemExceptionMarkers(Id,Originator,Reason,Ranking,Message,Stamp) VALUES(NEWID(),'"+ actor + "','" + whatwastheactodoing.ToLower() + "','" + ranking + "','" + sb.ToString() + "',GETDATE())";
           // int noOfRowInserted = _ctx.Database.ExecuteSqlCommand(sql); // .SystemExceptions.Add(log);
           // _ctx.SaveChanges();

            //foreach (var eve in ex.EntityValidationErrors)
            //{
            //    var sb = new StringBuilder();
            //    sb.AppendLine(
            //        $"Entity of type {eve.Entry.Entity.GetType().Name} in state {eve.Entry.State} has the following validation errors:");
            //    foreach (var ve in eve.ValidationErrors)
            //    {
            //        sb.AppendLine($"- Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
            //    }

            //    var log = new SystemExceptionMarker
            //    {
            //        Originator = actor.ToLower(),
            //        Reason = whatwastheactodoing.ToLower(),
            //        Message = sb.ToString(),
            //        Ranking = ranking,
            //        Stamp = DateTime.Now
            //    };
            //    _ctx.SystemExceptions.Add(log);
            //    _ctx.SaveChanges();
            //    //try
            //    //{
            //    //    _ctx.SaveChanges();
            //    //}
            //    //catch (DbEntityValidationException x)
            //    //{
            //    //    var m = x.Message;
            //    //}

            //}

        }

        #endregion
    }
}
