using System;
namespace Volta.ChefHelperBL.Model
{
    /// <summary>
    /// Organization.
    /// </summary>
    [Serializable]
    public class Organization
    {
        #region Properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Comment.
        /// </summary>
        public string Comment { get; set; }
        #endregion
        /// <summary>
        /// Create new organization.
        /// </summary>
        /// <param name="name"> Name. </param>
        /// <param name="comment"> Comment. </param>

        public Organization(string name, 
                            string comment)
        {
            #region check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of organization cannot be empty or null");
            }
            #endregion
            Name = name;
            Comment = comment;

        }

        public Organization(string name)
        {
            #region check1
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of organization cannot be empty or null");
            }
            #endregion
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
