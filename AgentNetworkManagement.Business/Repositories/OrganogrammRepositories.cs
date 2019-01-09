using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;

namespace AgentNetworkManagement.Business.Repositories
{
   internal class OrganogrammRepositories:IOrganogram
   {
       private readonly ApplicationDbContext _ctx;

       public OrganogrammRepositories(ApplicationDbContext ctx)
       {
           _ctx = ctx;
       }

       public IEnumerable<Organogramm> Get(Func<Organogramm, bool> predicate = null) => predicate == null
           ? _ctx.Structure.OrderBy(s => s.Agency)
               .ThenBy(s => s.RegionName)
               .ThenBy(s => s.StateName)
               .ThenBy(s => s.Area)
               .ThenBy(s => s.Zone).ThenBy(s => s.Clusta)
           : _ctx.Structure.Where(predicate: predicate);

       public IEnumerable<National> Get(Func<National, bool> predicate = null) => predicate == null
           ? _ctx.National.OrderBy(s => s.Name)
           : _ctx.National.Where(predicate: predicate);
       

       public Notification Add(National entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                entity.ProcessKind = "5B374CF9-4272-4137-9745-77911E863267";
                _ctx.National.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "platform  was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add platform";
                notification.Success = false;
            }
            return notification;
        }

       public IEnumerable<Region> Get(Func<Region, bool> predicate = null) => predicate == null
           ? _ctx.Region.OrderBy(s => s.Name)
           : _ctx.Region.Include(s=>s.National).Where(predicate);

       public Notification Add(Region entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.Region.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "region  was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add region";
                notification.Success = false;
            }
            return notification;
        }

       public IEnumerable<State> Get(Func<State, bool> predicate = null) => predicate == null
           ? _ctx.State.OrderBy(s => s.Region.National.Name)
               .ThenBy(s => s.Region.Name).ThenBy(s => s.Name)
           : _ctx.State.Include(s=>s.Region)
            .Include(s=>s.Region.National)
            .Where(predicate);


       public Notification Add(State entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.State.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "state  was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add state";
                notification.Success = false;
            }
            return notification;
        }

       public IEnumerable<Area> Get(Func<Area, bool> predicate = null) => predicate == null
           ? _ctx.Area.OrderBy(s => s.State.Region.National.Name)
               .ThenBy(s => s.State.Region.Name).ThenBy(s => s.State.Name)
               .ThenBy(s => s.AreaName)
           : _ctx.Area.Include(s=>s.State)
            .Include(s=>s.State.Region)
            .Include(s=>s.State.Region.National)
            .Where(predicate: predicate);

       public Notification Add(Area entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.Area.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "area  was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add area";
                notification.Success = false;
            }
            return notification;
        }

       public IEnumerable<Zone> Get(Func<Zone, bool> predicate = null) => predicate == null
           ? _ctx.Zone.OrderBy(s => s.Area.State.Region.National.Name)
               .ThenBy(s => s.Area.State.Region.Name).ThenBy(s => s.Area.State.Name)
               .ThenBy(s => s.Area.AreaName).ThenBy(s => s.ZoneName)
           : _ctx.Zone.Include(s=>s.Area)
            .Include(s=>s.Area.State)
            .Include(s=>s.Area.State.Region)
            .Include(s=>s.Area.State.Region.National)
            .Where(predicate);

       public Notification Add(Zone entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.Zone.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "zone was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add zone";
                notification.Success = false;
            }
            return notification;
        }

       public IEnumerable<Cluster> Get(Func<Cluster, bool> predicate = null) => predicate == null
           ? _ctx.Clusters.OrderBy(s => s.Zone.Area.State.Region.National.Name)
               .ThenBy(s => s.Zone.Area.State.Region.Name)
               .ThenBy(s => s.Zone.Area.State.Name)
               .ThenBy(s => s.Zone.Area.AreaName)
               .ThenBy(s => s.Zone.ZoneName).ThenBy(s => s.ClusterName)
           : _ctx.Clusters.Include(s=>s.Zone)
            .Include(s=>s.Zone.Area)
            .Include(s => s.Zone.Area.State)
            .Include(s => s.Zone.Area.State.Region)
            .Include(s => s.Zone.Area.State.Region.National)
            .Where(predicate);
        


        public Notification Add(Cluster entity)
       {
            var notification = new Notification();
            try
            {
                entity.Id = new ReferenceGenerator().GenerateId();
                _ctx.Clusters.Add(entity);
                _ctx.SaveChanges();
                notification.Message = "cluster was added successful";
                notification.Success = false;
            }
            catch (Exception ex)
            {
                notification.Message = "fail to add cluster";
                notification.Success = false;
            }
            return notification;
        }
   }
}
