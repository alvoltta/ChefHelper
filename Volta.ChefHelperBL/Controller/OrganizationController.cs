using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Volta.ChefHelperBL.Model;

namespace Volta.ChefHelperBL.Controller
{
    public class OrganizationController
    {
        public Organization Organization { get; }
        public OrganizationController(Organization organization)
        {
                Organization = organization ?? throw new ArgumentNullException("Name of organization cannot be null", nameof(organization));
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var filstream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filstream, Organization);
            }
        }
        public Organization Load()
        {
            var formatter = new BinaryFormatter();
            using (var filstream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filstream, Organization);
            }
        }
    }
}
