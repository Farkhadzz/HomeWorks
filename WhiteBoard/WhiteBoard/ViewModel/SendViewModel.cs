using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteBoard.View;
using WhiteBoard.ViewModel;
using WhiteBoard.Services.Classes;
using WhiteBoard.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WhiteBoard.Model;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Controls;
using System.Security;
using System.Runtime.InteropServices;

namespace WhiteBoard.ViewModel
{
    public class SendViewModel : ViewModelBase
    {
        public byte[] ImageBytes { get; set; }
        private readonly ISendService _sendService;
        private string _subject;
        public string Subject
        {
            get => _subject;
            set => Set(ref _subject, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public SendViewModel(ISendService sendService)
        {
            _sendService = sendService;
        }

        public RelayCommand SendCommand
        {
            get => new(() =>
            {
                _sendService.SendToEmail(Email, Subject, Name, Message);
            });
        }
    }
}
