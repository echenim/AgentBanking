using System;
using System.Collections.Generic;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.DbViews;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
     public class OrganogramLogic
     {
         private readonly IOrganogram _organogram;

         public OrganogramLogic()
         {
             _organogram = new OrganogrammRepositories(new ApplicationDbContext());
         }


        /// <summary>
        /// get all agency structure
        /// </summary>
        /// <param name="predicate">filter parameter</param>
        /// <returns>collection of organization structure</returns>
        public IEnumerable<Organogramm> GetStructure(Func<Organogramm, bool> predicate = null) => _organogram.Get(predicate);


        /// <summary>
        /// get all agency platform
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
         public IEnumerable<National> GetPlatform(Func<National, bool> predicate = null) => _organogram.Get(predicate);

        /// <summary>
        /// get all agency regional listinh
        /// </summary>
        /// <param name="predicate">Agency name</param>
        /// <returns>collection of all the region categorization of the agency</returns>
        public IEnumerable<Region> GetRegion(Func<Region, bool> predicate = null) => _organogram.Get(predicate);

        /// <summary>
        /// get all agency state categorization  
        /// </summary>
        /// <param name="predicate">agency regional name</param>
        /// <returns>collection of all the state categorization of the agency within a region</returns>
        public IEnumerable<State> GetState(Func<State, bool> predicate = null) => _organogram.Get(predicate);


        /// <summary>
        /// get all agency local goverment area categorization within a state
        /// </summary>
        /// <param name="predicate">agency state name</param>
        /// <returns>collection of all the local goverment area categorization of the agency</returns>
        public IEnumerable<Area> GetArea(Func<Area, bool> predicate = null) => _organogram.Get(predicate);


        /// <summary>
        /// get all agency zone categorizatio with-in a local goverment area
        /// </summary>
        /// <param name="predicate">zone name</param>
        /// <returns>collection of all the clusters categorization of the agency</returns>
        public IEnumerable<Zone> GetZone(Func<Zone, bool> predicate = null) => _organogram.Get(predicate);


        /// <summary>
        /// get all agency cluster name within a zone
        /// </summary>
        /// <param name="predicate">Agency name</param>
        /// <returns>collection of all the region categorization of the agency</returns>
        public IEnumerable<Cluster> GetCluster(Func<Cluster, bool> predicate = null) => _organogram.Get(predicate);

         public Notification Add(National entity) => _organogram.Add(entity);

        public Notification Add(Region entity) => _organogram.Add(entity);

        public Notification Add(State entity) => _organogram.Add(entity);

        public Notification Add(Area entity) => _organogram.Add(entity);

        public Notification Add(Zone entity) => _organogram.Add(entity);

        public Notification Add(Cluster entity) => _organogram.Add(entity);


    }
}
