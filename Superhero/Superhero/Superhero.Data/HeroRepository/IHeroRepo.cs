using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.HeroRepository
{
    public interface IHeroRepo
    {        
        void AddHero(Hero hero);
        void EditHero(Hero HeroID);
        void DeleteHero(int HeroID);
        IEnumerable<Hero> GetAllHeroes();
        IEnumerable<Hero> GetHereosByOrganization(int OrganzationID);
        IEnumerable<Hero> GetHereosBySighting(int SightingID);
        Hero GetHereosByID(int HeroID);
    }
}
