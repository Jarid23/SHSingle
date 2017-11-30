using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superhero.Model.Models;

namespace Superhero.Data.OrganizationRepository
{
    public class MockOrgRepo : IOrgRepo
    {
        private static List<Organization> _organizations = new List<Organization>
        {
            new Organization
            {
                OrganizationID = 3,
                OganizationAddress = "East Africa",
                OrganizationName = "The third org",
                Phone = "1234567899",
                OrganizationHeroes = new List<Hero>
                {
                    new Hero
                    {
                        HeroName = "OrgHero1"
                    } }

            },
             new Organization
            {
                OrganizationID = 4,
                OganizationAddress = "West Africa",
                OrganizationName = "The fourth org",
                Phone = "12345678998",
                OrganizationHeroes = new List<Hero>
                {
                    new Hero
                    {
                        HeroName = "OrgHero2"
                    } }
            }
        };

        public void AddOrganization(Organization organization)
        {
            _organizations.Add(organization);
        }

        public void DeleteOrganization(int OrganizationID)
        {
            _organizations.RemoveAll(o => o.OrganizationID == OrganizationID);
        }

        public void EditOrg(Organization organization)
        {
            var o = new Organization();
            foreach (var org in _organizations)
            {
                if (org.OrganizationID == organization.OrganizationID)
                {
                    org.OganizationAddress = organization.OganizationAddress;
                    org.OrganizationHeroes = organization.OrganizationHeroes;
                    org.OrganizationLocation = organization.OrganizationLocation;
                    org.OrganizationName = organization.OrganizationName;
                    org.Phone = organization.Phone;                    
                }
            }
            o = organization;
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return _organizations;
        }

        public Organization GetOrganizationById(int OrganizationID)
        {
            foreach (var organization in _organizations)
            {
                if (organization.OrganizationID == OrganizationID)
                {
                    return organization;
                }
            }
            return new Organization();
        }
    }
}

