
using MauiAppEjemplo.Servicios;
using MauiAppEjemplo.Modelo;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppEjemplo
{
    public partial class MainPage : ContentPage
    {
       

        private readonly IEjerciciosService _ejerciciosService;
        public MainPage(IEjerciciosService service)
        {
            InitializeComponent();
            _ejerciciosService = service;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            string prompt = "Consejos sobre cómo hacer ejercicios de gimnasio correctamente";
            var consejos = await _ejerciciosService.ObtenerConsejos(prompt);
            listViewConsejos.ItemsSource = consejos;

            loading.IsVisible = false;


        }
    }
}