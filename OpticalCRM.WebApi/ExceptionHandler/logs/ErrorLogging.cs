using OpticalCRM.Data.DomainContext;
using OpticalCRM.EntityFramework.Entity;
using OpticalCRM.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalCRM.WebApi.ExceptionHandler.logs
{
    public class ErrorLogging
    {
        OpticalCRMDomainContext context = new OpticalCRMDomainContext();
        public void InsertErrorLog(logResource log)
        {
            try
            {
                var entity = new log
                {
                    RequestMethod = log.RequestMethod,
                    RequestUri = log.RequestUri,
                    CreatedDate = log.CreatedDate,
                    Message = log.Message
                };
                context.Add(entity);
                context.SaveChanges();              
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
