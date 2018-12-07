using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
