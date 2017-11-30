using Superhero.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero.Data.OrganizationRepository
{
    public interface IOrgRepo
    {
        void AddOrganization(Organization organization);
        void EditOrg(Organization organization);
        void DeleteOrganization(int OrganizationID);
        IEnumerable<Organization> GetAllOrganizations();
        Organization GetOrganizationById(int OrganizationID);
    }
}
