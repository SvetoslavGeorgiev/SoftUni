namespace SchoolMealsOrderingSystem.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SchoolUser : ApplicationUser
    {

        public string SchoolName { get; set; }

    }
}
