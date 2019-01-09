using System;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManagement.Business.Repositories;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.Models;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
   public class SpatialSystem
   {
       readonly ISpatial _spatial;

       public SpatialSystem()
       {
           _spatial = new SpatialRepository(new ApplicationDbContext());
       }

       public bool NonTransactionData(string username,string trsnsacction, string latitude, string longitude)
       {
           var spatial = new SpatialNonTransactionScheme()
           {
               Id = new ReferenceGenerator().NGeneratedId(12).Replace("-", ""),
               Agent = username,
               Partition = "NonTransactional",
               Transaction = trsnsacction,
               Latitude = latitude.Trim(),
               Longitude = longitude.Trim(),
               CreatedOn = DateTime.Now
           };
         return  _spatial.Add(spatial);

       }

        public void NonTransactionData(string username,string transactionid,string trsnsacction, string latitude, string longitude)
        {
            var spatial = new SpatialTransactionScheme()
            {
                Id = new ReferenceGenerator().NGeneratedId(12).Replace("-", ""),
                AgentId = username,
                Partition = "Transactional",
                TransactionId = transactionid,
                Transaction = trsnsacction,
                Latitude = latitude.Trim(),
                Longitude = longitude.Trim(),
                CreatedOn = DateTime.Now
            };
            _spatial.Add(spatial);

        }



    }
}
