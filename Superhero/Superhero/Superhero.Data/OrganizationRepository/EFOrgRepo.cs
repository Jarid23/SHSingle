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
        //SuperheroDBContext context = new SuperheroDBContext();
        public void AddOrganization(Organization organization)
        {
            using (var db = new SuperheroDBContext())
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
            }        
        }

        public void DeleteOrganization(int OrganizationID)
        {
            using (var db = new SuperheroDBContext())
            {
                Organization toRemove = db.Organizations.SingleOrDefault(o => o.OrganizationID == OrganizationID);
                if (toRemove != null)
                {
                    db.Organizations.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public void EditOrg(Organization OrganizationID)
        {
            using (var db = new SuperheroDBContext())
            {
                Organization toEdit = db.Organizations.SingleOrDefault(o => o.OrganizationID == OrganizationID.OrganizationID);
                if (toEdit != null)
                {
                    toEdit.OganizationAddress = OrganizationID.OganizationAddress;
                    toEdit.OrganizationHeroes = OrganizationID.OrganizationHeroes;
                    toEdit.OrganizationLocation = OrganizationID.OrganizationLocation;
                    toEdit.OrganizationName = OrganizationID.OrganizationName;
                    toEdit.Phone = OrganizationID.Phone;

                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            using (var db = new SuperheroDBContext())
            {
                var orgs = from o in db.Organizations
                           select o;
                return orgs.ToList();
            }
        }

        public Organization GetOrganizationById(int OrganizationID)
        {
            using (var db = new SuperheroDBContext())
            {
                return db.Organizations.Where(o => o.OrganizationID == o.OrganizationID).FirstOrDefault();
            }
        }
    }
}
