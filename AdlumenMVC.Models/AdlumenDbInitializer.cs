using AdlumenMVC.Models.Migrations;
using System.Data.Entity;

namespace AdlumenMVC.Models.Model
{
    internal sealed class AdlumenDbInitializer : MigrateDatabaseToLatestVersion<Adlumen2SocEntities, Configuration>
    {
    }
}