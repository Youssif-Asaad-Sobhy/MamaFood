using MamaFood.API.Domain.Consts;
using MamaFood.API.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MamaFood.API.Infrastructure.Contexts
{
    public class AppDbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder ApplicationBuilder)
        {
            using (var ServiceScope = ApplicationBuilder.ApplicationServices.CreateScope())
            {
                var RoleManager = ServiceScope.ServiceProvider.
                    GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = ServiceScope.ServiceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();
                #region roles
                if (!await RoleManager.RoleExistsAsync(UserRoles.Admin))
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await RoleManager.RoleExistsAsync(UserRoles.FoodConsumer))
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.FoodConsumer));

                if (!await RoleManager.RoleExistsAsync(UserRoles.FoodProvider))
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.FoodProvider));

                if (!await RoleManager.RoleExistsAsync(UserRoles.Delivery))
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.Delivery));
                #endregion

                #region Users
                
                string AdminUserName = "TestAdmin";
                var AdminUser = await UserManager.FindByNameAsync(AdminUserName);
                if(AdminUser == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        Name = "Admin Test",
                        UserName = AdminUserName,
                        NID = "12345678901234",
                    };
                    await UserManager.CreateAsync(newAdmin, "Admin@123");
                    await UserManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }
                
                string DeliveryUserName = "TestDelivery";
                var DeliveryUser = await UserManager.FindByNameAsync(DeliveryUserName);
                if (DeliveryUser == null)
                {
                    var newDevlivery = new ApplicationUser()
                    {
                        Name = "Deivery Test",
                        UserName = DeliveryUserName,
                        NID = "12345678901234",
                    };
                    await UserManager.CreateAsync(newDevlivery, "Delivery@123");
                    await UserManager.AddToRoleAsync(newDevlivery, UserRoles.Delivery);
                }

                string ProviderUserName = "TestProvider";
                var ProviderUser = await UserManager.FindByNameAsync(ProviderUserName);
                if (ProviderUser == null)
                {
                    var newProvider = new ApplicationUser()
                    {
                        Name = "Provider Test",
                        UserName = ProviderUserName,
                        NID = "12345678901234",
                    };
                    await UserManager.CreateAsync(newProvider, "provider@123");
                    await UserManager.AddToRoleAsync(newProvider, UserRoles.FoodProvider);
                }

                string ConsumerUserName = "TestConsumer";
                var ConsumerUser = await UserManager.FindByNameAsync(ConsumerUserName);
                if (ConsumerUser == null)
                {
                    var newConsumer = new ApplicationUser()
                    {
                        Name = "Consumer Test",
                        UserName = ConsumerUserName,
                        NID = "12345678901234",
                    };
                    await UserManager.CreateAsync(newConsumer, "Consumer@123");
                    await UserManager.AddToRoleAsync(newConsumer, UserRoles.FoodConsumer);
                }
                #endregion
            }
        }
    }
}
