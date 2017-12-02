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
                Organization toEdit = db.Organizations.Include("OrganizationHeroes").SingleOrDefault(o => o.OrganizationID == OrganizationID.OrganizationID);
                if (toEdit != null)
                {
                    toEdit.OganizationAddress = OrganizationID.OganizationAddress;
                    toEdit.OrganizationLocation = db.Locations.Single(l => l.LocationID == OrganizationID.OrganizationLocation.LocationID);
                    toEdit.OrganizationName = OrganizationID.OrganizationName;
                    toEdit.Phone = OrganizationID.Phone;

                    //var heroesToDelete = new List<Hero>();

                    //foreach (var hero in toEdit.OrganizationHeroes)
                    //{
                    //    heroesToDelete.Add(hero);
                    //}
                    toEdit.OrganizationHeroes.Clear();
                    db.SaveChanges();

                    //foreach (var hero in heroesToDelete)
                    //{
                    //    toEdit.OrganizationHeroes.Remove(hero);
                    //}

                    foreach (Hero hero in OrganizationID.OrganizationHeroes)
                    {
                        //db.Heroes.Attach(hero);
                        toEdit.OrganizationHeroes.Add(db.Heroes.Single(h => h.HeroID == hero.HeroID));
                    }
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
                return db.Organizations.Include("OrganizationHeroes").Where(o => o.OrganizationID == OrganizationID).FirstOrDefault();
            }
        }
    }
}
