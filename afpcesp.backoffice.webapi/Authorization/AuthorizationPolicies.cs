using Microsoft.AspNetCore.Authorization;

namespace afpcesp.backoffice.webapi.Authorization
{
    /// <summary>
    /// Define os nomes das políticas de autorização da aplicação.
    /// </summary>
    public static class Policies
    {
        /// <summary>
        /// Política que requer que o usuário seja um administrador.
        /// </summary>
        public const string RequireAdminRole = "RequireAdminRole";

        /// <summary>
        /// Política que requer que o usuário seja um gerente ou administrador.
        /// </summary>
        public const string RequireManagerRole = "RequireManagerRole";

        /// <summary>
        /// Política que requer que o usuário tenha pelo menos 18 anos.
        /// </summary>
        public const string RequireMinimumAge = "RequireMinimumAge";

        /// <summary>
        /// Política que requer que o usuário possa visualizar dados sensíveis.
        /// </summary>
        public const string CanViewSensitiveData = "CanViewSensitiveData";
    }

    /// <summary>
    /// Requirement para verificar idade mínima.
    /// </summary>
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }

    /// <summary>
    /// Handler para verificar idade mínima.
    /// </summary>
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(c => c.Type == "DateOfBirth");

            if (dateOfBirthClaim == null)
            {
                return Task.CompletedTask;
            }

            if (DateTime.TryParse(dateOfBirthClaim.Value, out DateTime dateOfBirth))
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                
                if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                if (age >= requirement.MinimumAge)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Requirement para permissões específicas.
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }

    /// <summary>
    /// Handler para verificar permissões.
    /// </summary>
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var permissionClaim = context.User.FindFirst(c => 
                c.Type == "Permission" && c.Value == requirement.Permission);

            if (permissionClaim != null)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
