using System.Collections.Generic;
using AgentNetworkManager.Domain.Models;

namespace AgentNetworkManagement.Business.CommandAndQuery
{
    public class GenderProcess
    {
        public List<Gender> GetSex()
        {
            var sex = new List<Gender>();
            sex.Add(new Gender
            {
                Id = "Female",
                Name = "Female"
            });
            sex.Add(new Gender
            {
                Id = "Male",
                Name = "Male"
            });

            return sex;
        }
    }
}
