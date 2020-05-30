using System;
using System.IO;
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
        public Organization Organization { get; }
        /// <summary>
        /// Creating new Organization controller.
        /// </summary>
        /// <param name="organization"></param>
        public OrganizationController(string name, string comment)
        {
            var organization = new Organization(name, comment);
                Organization = organization ?? throw new ArgumentNullException("Name of organization cannot be null", nameof(organization));
        }
        /// <summary>
        /// Saving Orgs Data.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var filestream = new FileStream("Orgs.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, Organization);
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
                if (formatter.Deserialize(filestream) is Organization organization)
                {
                    Organization = organization;
                }

                // TODO: What should to do if Organization data was not read?
            }
        }
    }
}
