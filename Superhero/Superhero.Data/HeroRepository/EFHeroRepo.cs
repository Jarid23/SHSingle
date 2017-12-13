using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;
using System.Data.Entity.Migrations;

namespace Superhero.Data.HeroRepository
{
    public class EFHeroRepo : IHeroRepo
    {
        //SuperheroDBContext context = new SuperheroDBContext();
        public void AddHero(Hero hero)
        {
            using (var db = new SuperheroDBContext())
            {                
                //db.Set<Hero>().AddOrUpdate(hero);
                db.Heroes.Add(hero);
                db.SaveChanges();
            }
        }

        public void DeleteHero(int HeroID)
        {
            using (var db = new SuperheroDBContext())
            {
                Hero toRemove = db.Heroes.SingleOrDefault(h => h.HeroID == HeroID);
                if (toRemove != null)
                {
                    db.Heroes.Remove(toRemove);
                }
                db.SaveChanges();
            }
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            using (var db = new SuperheroDBContext())
            {
                var heroes = from h in db.Heroes
                             select h;
                return heroes.ToList();
            }
        }


        public void EditHero(Hero HeroID)
        {
            using (var db = new SuperheroDBContext())
            {
                Hero toEdit = db.Heroes.Include("Organizations").SingleOrDefault(h => h.HeroID == HeroID.HeroID);
                if (toEdit != null)
                {
                    toEdit.Description = HeroID.Description;
                    toEdit.HeroName = HeroID.HeroName;
                    toEdit.Sightings = HeroID.Sightings;
                    toEdit.Superpower = HeroID.Superpower;
                    var orgsToDelete = new List<Organization>();

                    foreach (var org in toEdit.Organizations)
                    {
                        orgsToDelete.Add(org);
                    }

                    foreach (var org in orgsToDelete)
                    {
                        toEdit.Organizations.Remove(org);
                    }

                    foreach (var org in HeroID.Organizations)
                    {
                        //db.Organizations.Add(org);
                        toEdit.Organizations.Add(db.Organizations.Single(o => o.OrganizationID == org.OrganizationID));
                    }
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<Hero> GetHereosByOrganization(int OrganizationID)
        {
            using (var db = new SuperheroDBContext())
            {
                var org = db.Organizations.Include("OrganizationHeroes").Where(o => o.OrganizationID == OrganizationID).FirstOrDefault();
                if (org != null)
                {
                    return org.OrganizationHeroes;
                }
                return null;
            }
        }

        public IEnumerable<Hero> GetHereosBySighting(int SightingID)
        {
            using (var db = new SuperheroDBContext())
            {
                var hero = db.Sightings.Include("SighintgHeroes").Where(s => s.SightingID == SightingID).FirstOrDefault();
                if (hero != null)
                {
                    return hero.SightingHeroes;
                }
                return null;
            }
        }

        public Hero GetHereosByID(int HeroID)
        {
            using (var context = new SuperheroDBContext())
            {
                return context.Heroes.Include("Organizations").Where(h => h.HeroID == HeroID).FirstOrDefault();
            }
        }
    }
}
