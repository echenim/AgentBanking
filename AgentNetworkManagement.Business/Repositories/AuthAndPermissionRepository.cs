using System;
using AgentNetworkManagement.Business.Contracts;
using AgentNetworkManager.Domain;
using AgentNetworkManager.Domain.Models;
using AgentNetworkManager.Domain.PermissionAndAuthorization.Models;
using AgentNetworkManager.Domain.ViewModels;
using Echenim.Nine.Misc.Functionals.ErrorsAndFailures;
using Echenim.Nine.Util.UniqueReferenceGenerator.Processs;


namespace AgentNetworkManagement.Business.Repositories
{
   internal class AuthAndPermissionRepository:IPermissionAndAuth
    {

        private readonly ApplicationDbContext _ctx;
      

        public AuthAndPermissionRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

      

     

       #region Implementation of IAdd<UserRoleProfile>

       public Notification Add(UserRoleProfile entity)
       {
           throw new NotImplementedException();
       }

        //public Notification Add(RegisterViewModel entity)
        //{
        //    var notificiation = new Notification();


        //    var person = new Person
        //    {
        //        Id = new ReferenceGenerator().GenerateId(),
        //        FirstName = entity.FirstName,
        //        MidleName = entity.MidleName,
        //        LastName = entity.LastName,
        //        ContactAddress = entity.ContactAddress,
        //        Gender = entity.Gender
        //    };



        //    try
        //    {
        //        _ctx.Persons.Add(person);
        //        _ctx.SaveChanges();
        //        notificiation.Id = person.Id;
        //        notificiation.Message = "registration was successful";
        //        notificiation.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string es = ex.Message;
        //        notificiation.Message = "registration was not successful";
        //        notificiation.Success = false;
        //    }

        //    return notificiation;
        //}

        public Notification Add(RegisterAndAssignUserToNetWork entity)
        {
            var notificiation = new Notification();


            var person = new Person
            {
                Id = new ReferenceGenerator().GenerateId(),
                FirstName = entity.FirstName,
                MidleName = entity.MidleName,
                LastName = entity.LastName,
                ContactAddress = entity.ContactAddress,
                Gender = entity.Gender
            };



            try
            {
                _ctx.Persons.Add(person);
                _ctx.SaveChanges();
                notificiation.Id = person.Id;
                notificiation.Message = "registration was successful";
                notificiation.Success = true;
            }
            catch (Exception ex)
            {
                string es = ex.Message;
                notificiation.Message = "registration was not successful";
                notificiation.Success = false;
            }

            return notificiation;
        }

        public Notification Add(RegisterAndAssignPlatformManagerToNetWork entity)
        {
            var notificiation = new Notification();


            var person = new Person
            {
                Id = new ReferenceGenerator().GenerateId(),
                FirstName = entity.FirstName,
                MidleName = entity.MidleName,
                LastName = entity.LastName,
                ContactAddress = entity.ContactAddress,
                Gender = entity.Gender
            };



            try
            {
                _ctx.Persons.Add(person);
                _ctx.SaveChanges();
                notificiation.Id = person.Id;
                notificiation.Message = "registration was successful";
                notificiation.Success = true;
            }
            catch (Exception ex)
            {
                string es = ex.Message;
                notificiation.Message = "registration was not successful";
                notificiation.Success = false;
            }

            return notificiation;
        }

        #endregion

       #region Implementation of IAdd<RegisterViewModel>

       public Notification Add(RegisterViewModel entity)

        {
            var notificiation = new Notification();


            var person = new Person
            {
                Id = new ReferenceGenerator().GenerateId(),
                FirstName = entity.FirstName,
                MidleName = entity.MidleName,
                LastName = entity.LastName,
                ContactAddress = entity.ContactAddress,
                Gender = entity.Gender
            };



            try
            {
                _ctx.Persons.Add(person);
                _ctx.SaveChanges();
                notificiation.Id = person.Id;
                notificiation.Message = "registration was successful";
                notificiation.Success = true;
            }
            catch (Exception ex)
            {
                string es = ex.Message;
                notificiation.Message = "registration was not successful";
                notificiation.Success = false;
            }

            return notificiation;
        }

        #endregion

      
    }
}
