using Abp.Application.Navigation;
using Abp.Localization;
using TestApp.Authorization;

namespace TestApp.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class TestAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", TestAppConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users",
                        requiredPermissionName: PermissionNames.Pages_Users
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Roles",
                        L("Roles"),
                        url: "#users",
                        icon: "fa fa-tag",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", TestAppConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "TiposNumeracion",
                        new LocalizableString("TiposNumeracion", TestAppConsts.LocalizationSourceName),
                        url: "#/tiposnumeracion",
                        icon: "fa fa-ship"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Periodo",
                        new LocalizableString("Periodos", TestAppConsts.LocalizationSourceName),
                        url: "#/periodos",
                        icon: "fa fa-info"
                    )
                )
                  .AddItem(
                    new MenuItemDefinition(
                        "Cuenta",
                        new LocalizableString("Cuentas", TestAppConsts.LocalizationSourceName),
                        url: "#/cuentas",
                        icon: "fa fa-info"
                    )
                )
                  .AddItem(
                    new MenuItemDefinition(
                        "Comprobante",
                        new LocalizableString("Comprobantes", TestAppConsts.LocalizationSourceName),
                        url: "#/comprobantes",
                        icon: "fa fa-info"
                    )
                )
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TestAppConsts.LocalizationSourceName);
        }
    }
}
