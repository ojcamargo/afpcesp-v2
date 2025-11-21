using afpcesp.application.Models;
using afpcesp.backoffice.webapi.ViewModel;

namespace afpcesp.backoffice.webapi.Mappers
{
    /// <summary>
    /// Mapper para converter entre ViewModels (WebApi) e Models (Application).
    /// </summary>
    public static class ViewModelMapper
    {
        // ==================== User Mappings ====================

        /// <summary>
        /// Converte UserModel para UserViewModel.
        /// </summary>
        public static UserViewModel ToViewModel(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new UserViewModel
            {
                Id = model.Id,
                Username = model.Username,
                Email = string.Empty, // TODO: Adicionar email ao UserModel se necessário
                Name = model.Username
            };
        }

        /// <summary>
        /// Converte lista de UserModel para lista de UserViewModel.
        /// </summary>
        public static IEnumerable<UserViewModel> ToViewModelList(IEnumerable<UserModel> models)
        {
            return models?.Select(ToViewModel) ?? Enumerable.Empty<UserViewModel>();
        }

        /// <summary>
        /// Converte CreateUserRequest para CreateUserModel.
        /// </summary>
        public static CreateUserModel ToCreateModel(CreateUserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new CreateUserModel
            {
                Username = request.Username,
                Password = request.Password
            };
        }

        /// <summary>
        /// Converte UpdateUserRequest para UpdateUserModel.
        /// </summary>
        public static UpdateUserModel ToUpdateModel(UpdateUserRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new UpdateUserModel
            {
                Id = request.Id,
                Username = request.Username
            };
        }

        // ==================== Auth Mappings ====================

        /// <summary>
        /// Converte LoginRequest para LoginModel.
        /// </summary>
        public static LoginModel ToLoginModel(LoginRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return new LoginModel
            {
                Username = request.Username,
                Password = request.Password
            };
        }

        /// <summary>
        /// Converte AuthResponseModel para LoginResponse.
        /// </summary>
        public static LoginResponse ToLoginResponse(AuthResponseModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new LoginResponse
            {
                Token = model.Token,
                ExpiresAt = model.ExpiresAt,
                Username = model.Username,
                Email = model.Email,
                Roles = model.Roles
            };
        }
    }
}
