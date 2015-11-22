using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace Hippocrate.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AddStaffViewModel : ViewModelBase
    {
        #region get/set
        private ICommand _cancelcommand;

        public ICommand CancelCommand
        {
            get { return _cancelcommand; }
            set { _cancelcommand = value; }
        }

        private ICommand _createcommand;

        public ICommand CreateCommand
        {
            get { return _createcommand; }
            set { _createcommand = value; }
        }

        private ICommand _choosepicturecommand;

        public ICommand ChoosePictureCommand
        {
            get { return _choosepicturecommand; }
            set { _choosepicturecommand = value; }
        }

        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set {
                _firstname = value;
                RaisePropertyChanged("Firstname");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }

        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; RaisePropertyChanged("Login"); }
        }

        private string _role;

        public string Role
        {
            get { return _role; }
            set { _role = value; RaisePropertyChanged("Role"); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
        }

        private string _errormessage;

        public string ErrorMessage
        {
            get { return _errormessage; }
            set { _errormessage = value; RaisePropertyChanged("ErrorMessage"); }
        }

        private ObservableCollection<string> _listrole;

        public ObservableCollection<string> ListRole
        {
            get { return _listrole; }
            set { _listrole = value; RaisePropertyChanged("ListRole"); }
        }

        private BitmapImage _image;

        public BitmapImage Image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged("Image"); }
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the AddStaffViewModel class.
        /// </summary>
        public AddStaffViewModel()
        {
            Firstname = "";
            Name = "";
            Login = "";
            Role = "";
            Password = "";
            ErrorMessage = "";
            CancelCommand = new RelayCommand(() =>
            {
                CancelPopup();
            });

            ChoosePictureCommand = new RelayCommand(() =>
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|" +
                                    "BMP Files: (*.BMP; *.DIB; *.RLE) | *.BMP; *.DIB; *.RLE |" + "JPEG Files: (*.JPG; *.JPEG; *.JPE; *.JFIF)| *.JPG; *.JPEG; *.JPE; *.JFIF |" +
                                    "GIF Files: (*.GIF) | *.GIF | " + "TIFF Files: (*.TIF; *.TIFF)| *.TIF; *.TIFF |" + "PNG Files: (*.PNG) | *.PNG |" + "All Files | *.* ";

                ViewModelLocator vml = new ViewModelLocator();
                vml.StaffListView.DissmissPopup();
                if (openDialog.ShowDialog().Value)
                {
                    vml.StaffListView.CanViewAdd = true;
                    Image = new BitmapImage(new Uri(openDialog.FileName));
                }
                vml.StaffListView.CanViewAdd = true;
            });

            CreateCommand = new RelayCommand(() =>
            {
                if (Firstname == "" || Name == "" || Role == "" || Password == "" || Role == "" || Login == "")
                    ErrorMessage = "Tous les champs sont requis";
                else
                {
                    User user = new User();
                    user.Firstname = Firstname;
                    user.Name = Name;
                    user.Login = Login;
                    user.Role = Role;
                    user.Picture = ConvertImage(Image);
                    user.Pwd = Password;
                    try
                    {
                        BusinessManagement.User.AddUser(user);
                        ViewModelLocator vml = new ViewModelLocator();
                        vml.StaffListView.UserListUpdate();
                        CancelPopup();
                    }
                    catch (Exception)
                    {
                        ErrorMessage = "La taille de l'image est trop grande";
                    }
                }
            });

            Image = new BitmapImage(new Uri("/Assets/anonym.jpg", UriKind.Relative));
            ListRole = new ObservableCollection<string>() { "Infirmière", "Medecin", "Chirurgien", "Radiologue" };
        }

        private byte[] ConvertImage(BitmapImage image)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        public void CancelPopup()
        {
            ViewModelLocator vml = new ViewModelLocator();
            Firstname = "";
            Name = "";
            Login = "";
            Role = "";
            Password = "";
            ErrorMessage = "";
            Image = new BitmapImage(new Uri("/Assets/anonym.jpg", UriKind.Relative));
            vml.StaffListView.DissmissPopup();
        }
    }
}