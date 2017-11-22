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
        void EditOrganization(Organization organization);
        void DeleteOrganization(int OrganizationID);
        //Maybe List Orgnizations by Heroes ?
    }
}
