using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Volta.ChefHelperBL.Model;

namespace Volta.ChefHelperBL.Controller
{
    /// <summary>
    /// Controller Organization.
    /// </summary>
    public class OrganizationController
    {
        /// <summary>
        /// App Organization.
        /// </summary>
        public List<Organization> Organizations { get; }
        public Organization CurrenOrganization { get; }

        /// <summary>
        /// Creating new Organization controller.
        /// </summary>
        /// <param name="organization"></param>
        public OrganizationController(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of organization cannot be null", nameof(name));
            }
            Organizations = GetOrgData();

            CurrenOrganization = Organizations.SingleOrDefault(o => o.Name == name);

            if (CurrenOrganization == null)
            {
                CurrenOrganization = new Organization(name);
                Organizations.Add(CurrenOrganization);
                Save();
            }
        }
        private List<Organization> GetOrgData()
        {
            var formatter = new BinaryFormatter();
            using (var filestream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(filestream) is List<Organization> organizations)
                {
                    return organizations;
                }
                else 
                {
                    return new List<Organization>();
                }
            }
        }
        /// <summary>
        /// Saving Orgs Data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var filestream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, Organizations);
            }
        }
        /// <summary>
        /// Load Orgs Data.
        /// </summary>
        /// <returns> Current organization. </returns>
        public OrganizationController()
        {
            var formatter = new BinaryFormatter();
            using (var filestream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(filestream) is List<Organization> organizations)
                {
                    Organizations = organizations;
                }

                // TODO: What should to do if Organization data was not read?
            }
        }
    }
}
