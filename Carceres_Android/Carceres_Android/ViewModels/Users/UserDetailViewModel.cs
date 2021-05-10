﻿using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Carceres_Android.ViewModels.Users
{
    [QueryProperty(nameof(UserId),nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private string userId;
        private string username;
        private string userType;

        public string Id { get; set; }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string UserType
        {
            get => userType;
            set => SetProperty(ref userType, value);
        }

        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                LoadUserId(value);
            }
        }
        public async void LoadUserId(string userId)
        {
            try
            {
                var user = await UserList.GetUserAsync(userId);
                Id = user.id;
                Username = user.username;
                UserType = user.userType;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }
    }
}