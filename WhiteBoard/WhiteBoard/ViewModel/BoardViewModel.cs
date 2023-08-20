using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WhiteBoard.Model;
using WhiteBoard.Services.Interfaces;
using WhiteBoard.View;

namespace WhiteBoard.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly ISendService _sendService;

        public string ImgName;

        private byte[] _imageBytes;
        public byte[] ImageBytes
        {
            get => _imageBytes;
            set => Set(ref _imageBytes, value);
        }

        private string _tempImgName;
        public string TempImgName
        {
            get => _tempImgName;
            set => Set(ref _tempImgName, value);
        }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get => _imageSource;
            set => Set(ref _imageSource, value);
        }
        public BoardViewModel(INavigationService navigationService, ISendService sendService)
        {
            _navigationService = navigationService;
            _sendService = sendService;
        }

        public RelayCommand LogOutCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<LoginViewModel>();
            });
        }

        public RelayCommand<Canvas> ExportCommand
        {
            get => new(param =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Images (*.png)|*.png|JPEG Images (*.jpg)|*.jpg|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)param.ActualWidth, (int)param.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                    renderBitmap.Render(param);

                    BitmapEncoder encoder = null;

                    if (filePath.EndsWith(".png"))
                    {
                        encoder = new PngBitmapEncoder();
                    }
                    else if (filePath.EndsWith(".jpg"))
                    {
                        encoder = new JpegBitmapEncoder();
                    }

                    if (encoder != null)
                    {
                        encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            encoder.Save(fs);
                        }
                    }
                }
            });
        }

        public RelayCommand<Canvas> PrintCommand
        {
            get => new(canvas =>
            {
                PrintDialog printDialog = new();

                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(canvas, "Canvas Print");
                }
            });
        }

        public RelayCommand<InkCanvas> SendCommand
        {
            get => new RelayCommand<InkCanvas>((inkCanvas) =>
            {
                if (inkCanvas != null)
                {
                    _sendService.Send(inkCanvas, ImageBytes);
                }
            });
        }
    }
}
