using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.HeroRepository
{
    public class EFHeroRepo : IHeroRepo
    {
        SuperheroDBContext context = new SuperheroDBContext();
        public void AddHero(Hero hero)
        {
            context.Heroes.Add(hero);
            context.SaveChanges();
        }

        public void DeleteHero(int HeroID)
        {
            Hero toRemove = context.Heroes.SingleOrDefault(h => h.HeroID == HeroID);
            if (toRemove != null)
            {
                context.Heroes.Remove(toRemove);
            }
            context.SaveChanges();
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            var heroes = from h in context.Heroes
                        select h;
            return heroes.ToList();
        }


        public void EditHero(Hero HeroID)
        {
            Hero toEdit = context.Heroes.SingleOrDefault(h => h.HeroID == HeroID.HeroID);
            if (toEdit != null)
            {
                toEdit.Description = HeroID.Description;
                toEdit.HeroName = HeroID.HeroName;
                toEdit.Organizations = HeroID.Organizations;
                toEdit.Sightings = HeroID.Sightings;
                toEdit.Superpower = HeroID.Superpower;
                context.SaveChanges();
            }
        }

        public IEnumerable<Hero> GetHereosByOrganization(int OrganizationID)
        {
            //return context.Blog.Include("Category").Where(t => t.Title == title).ToList();
            var org = context.Organizations.Include("OrganizationHeroes").Where(o => o.OrganizationID == OrganizationID).FirstOrDefault();
            if (org != null)
            {
                return org.OrganizationHeroes;
            }
            return null;
        }

        public IEnumerable<Hero> GetHereosBySighting(int SightingID)
        {
            var hero = context.Sightings.Include("SighintgHeroes").Where(s => s.SightingID == SightingID).FirstOrDefault();
            if (hero != null)
            {
                return hero.SighintgHeroes;
            }
            return null;
        }

        public Hero GetHereosByID(int HeroID)
        {
            return context.Heroes.Where(h => h.HeroID == HeroID).FirstOrDefault();
        }
    }
}
