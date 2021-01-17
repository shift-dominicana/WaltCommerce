using Common.Models.Users;
using Ecommerce.Mobile.Fonts;
using Ecommerce.Mobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace Ecommerce.Mobile.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;
        private Menu _menu;
        private string _nombreCompleto;
        private User _usuario;
        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            _nombreCompleto = Preferences.Get("nombreCompleto", "");
            LoadMenus();
        }
        #region Propidades

        public List<Menu> Menus { get; set; }
        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        //public DelegateCommand VerPerfilUsuarioCommand => _verPerfilUsuarioCommand ?? (_verPerfilUsuarioCommand = new DelegateCommand(VerPerfilUsuario));


        //public string NombreCompleto
        //{
        //    get => _nombreCompleto;
        //    set => SetProperty(ref _nombreCompleto, value);
        //}

        public User Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        public string NombreCompleto
        {
            get => _nombreCompleto;
            set => SetProperty(ref _nombreCompleto, value);
        }

        public Menu Menu
        {
            get => _menu;
            set => SetProperty(ref _menu, value);
        }
        #endregion

        #region Metodos

        private void LoadMenus()
        {
            Menus = new List<Menu>
            {
                new Menu
                {
                    Icono = IconFont.DoorOpen,
                    Pagina = "GatewayPage",
                    Titulo = "Puerta"
                },
                 new Menu
                {
                    Icono = IconFont.EnvelopeOpenText,
                    Pagina = "ChatPage",
                    Titulo = "Mensajes"
                },
                  new Menu
                {
                    Icono = IconFont.InfoCircle,
                    Pagina = "OpenRequestPage",
                    Titulo = "Solicitudes"
                },
                new Menu
                {
                    Icono = IconFont.SignOutAlt,
                    Pagina = "LoginPage",
                    Titulo = "Cerrar Sesión"
                }
            };

        }

        private async void SelectMenu()
        {
            if (Menu.Pagina.Equals("LoginPage"))
            {
                var confirm = await App.Current.MainPage.DisplayAlert("Información", "¿Esta seguro que desea cerrar la sesión?", "Salir", "Cancelar");
                if (confirm)
                {
                    await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                }

                return;
            }
            var parameter = new NavigationParameters();
            parameter.Add("Usuario", Usuario);
            await _navigationService.NavigateAsync($"/MenuPage/NavigationPage/{Menu.Pagina}", parameter);

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Usuario = (User)parameters["Usuario"];
            base.OnNavigatedTo(parameters);
        }
        #endregion
    }
}