using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.OrganizationRepository
{   
    public class EFOrgRepo : IOrgRepo
    {
        SuperheroDBContext context = new SuperheroDBContext();
        public void AddOrganization(Organization organization)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                context.Organizations.Add(organization);
                context.SaveChanges();
            }
        }

        public void DeleteOrganization(int OrganizationID)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                Organization toRemove = context.Organizations.SingleOrDefault(o => o.OrganizationID == OrganizationID);
                if (toRemove != null)
                {
                    context.Organizations.Remove(toRemove);
                }
                context.SaveChanges();
            }
        }

        public void EditOrg(Organization OrganizationID)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                Organization toEdit = context.Organizations.SingleOrDefault(o => o.OrganizationID == OrganizationID.OrganizationID);
                if (toEdit != null)
                {
                    toEdit.OganizationAddress = OrganizationID.OganizationAddress;
                    toEdit.OrganizationHeroes = OrganizationID.OrganizationHeroes;
                    toEdit.OrganizationLocation = OrganizationID.OrganizationLocation;
                    toEdit.OrganizationName = OrganizationID.OrganizationName;
                    toEdit.Phone = OrganizationID.Phone;

                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            var orgs = from o in context.Organizations
                         select o;
            return orgs.ToList();
        }

        public Organization GetOrganizationById(int OrganizationID)
        {
            SuperheroDBContext context = new SuperheroDBContext();
            {
                return context.Organizations.Where(o => o.OrganizationID == o.OrganizationID).FirstOrDefault();
            }
        }
    }
}
