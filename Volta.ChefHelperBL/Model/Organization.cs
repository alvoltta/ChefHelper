using System;
using System.Collections.Generic;
using System.Text;

namespace Volta.ChefHelperBL.Model
{
    class Organization
    {
        public string Name { get; }
        public string Comment { get; set; }

        public Organization(string name, string comment)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя организации не может быть пустым");
            }
            Name = name;
            Comment = comment;

        }
    }
}
