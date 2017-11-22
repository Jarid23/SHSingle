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

        public void EditOrganization(Organization organization)
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
    }
}

