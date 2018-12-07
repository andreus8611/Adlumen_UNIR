using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class AspNetUser : ITenant
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.AspNetRoles = new List<AspNetRole>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Level { get; set; }
        public System.DateTime JoinDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Client { get; set; }
        public string Logo { get; set; }
        public int IdLocal { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public int IdTenant { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
