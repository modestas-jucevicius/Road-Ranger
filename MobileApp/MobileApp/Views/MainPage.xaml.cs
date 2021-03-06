﻿using System;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class MainPage : ContentPage, IMainView
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        string IMainView.Score
        {
            get => Score.Text;
            set => Score.Text = value;
        }
        public bool IsPressable
        {
            set => this.IsEnabled = value;
        }

        public Page Page => this;

        protected override void OnAppearing()
        {
            if (this.Appear != null)
                Appear(this, null);
        }

        private void SearchButton_Clicked(object sender, EventArgs args)
        {
            SearchClick(this, args);
        }

        private void CameraButton_Clicked(object sender, EventArgs args)
        {
            StartClick(this, args);
        }

        private void MoreButton_Clicked(object sender, EventArgs args)
        {
            MoreClick(this, args);
        }

        private void TopButton_Clicked(object sender, EventArgs args)
        {
            TopClick(this, args);
        }

        private void ShopButton_Clicked(object sender, EventArgs args)
        {
            ShopClick(this, args);
        }

        public event EventHandler<EventArgs> SearchClick;
        public event EventHandler<EventArgs> StartClick;
        public event EventHandler<EventArgs> MoreClick;
        public event EventHandler<EventArgs> TopClick;
        public event EventHandler<EventArgs> ShopClick;
        public event EventHandler<EventArgs> Appear;
    }
}
