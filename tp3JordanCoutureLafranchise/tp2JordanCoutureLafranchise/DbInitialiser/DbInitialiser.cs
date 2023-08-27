using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tp2JordanCoutureLafranchise.Models.Data;
using tp3JordanCoutureLafranchise.Models;

namespace tp3JordanCoutureLafranchise.DbInitialiser
{
    public class DbInitializer : IdBInitialiser
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HockeyRebelsDBContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            HockeyRebelsDBContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize()
        {
            // Exécuter les migrations sont effectuées
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            // Créer les rôles suivants si aucun rôle ne figure dans la bd
            if (!_roleManager.RoleExistsAsync(AppConstants.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(AppConstants.AdminRole))
                    .GetAwaiter().GetResult();

                _roleManager.CreateAsync(new IdentityRole(AppConstants.User))
                    .GetAwaiter().GetResult();

            

                // Créer un User pour le rôle Admin
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Jordan@HockeyRebels.com",
                    Email = "Jordan@HockeyRebels.com",
                    NickName = "Jord",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true
                }, "Admin123*").GetAwaiter().GetResult();
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Jordan@HockeyRebels.com");
                _userManager.AddToRoleAsync(user, AppConstants.AdminRole)
                    .GetAwaiter().GetResult();


                // Créer deux Users pour le rôle Chasseur
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Sidthekid@HockeyRebels.com",
                    Email = "Sidthekid@HockeyRebels.com",
                    NickName = "Top Chasseur",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true,
                }, "Chasseur123*").GetAwaiter().GetResult();
                ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Sidthekid@HockeyRebels.com");
                _userManager.AddToRoleAsync(user2, AppConstants.User)
                    .GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "MaxSlapshot@HockeyRebels.com",
                    Email = "MaxSlapshot@HockeyRebels.com",
                    NickName = "Crazy Chasseur",
                    PhoneNumber = "1111111111",
                    EmailConfirmed = true,
                }, "Chasseur123*").GetAwaiter().GetResult();
                ApplicationUser user3 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "MaxSlapshot@HockeyRebels.com");
                _userManager.AddToRoleAsync(user3, AppConstants.User)
                    .GetAwaiter().GetResult();


            }
        }

       
        
    }

    }
