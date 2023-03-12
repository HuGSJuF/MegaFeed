using megaSite_feed.Models;
using megaSite_feed.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace megaSite_feed.Views
{
    public partial class NewItemPage : ContentPage
    {
        public News News { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}