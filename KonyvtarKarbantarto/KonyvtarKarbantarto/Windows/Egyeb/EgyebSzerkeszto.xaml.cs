﻿using KonyvtarKarbantarto.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KonyvtarKarbantarto.Windows
{
    /// <summary>
    /// Interaction logic for EgyebSzerkeszto.xaml
    /// </summary>
    public partial class EgyebSzerkeszto : Window
    {
        string token;
        bool edit = false;
        int identificator = 0;
        string currenttask = null;
        public EgyebSzerkeszto(string tok, string task)
        {
            token = tok;
            currenttask = task;
            InitializeComponent();
        }

        public EgyebSzerkeszto(string tok, string task, EgyebDto egyeb)
        {
            token = tok;
            currenttask = task;
            InitializeComponent();
            edit = true;
            identificator = egyeb.id;
            Name.Text = egyeb.name;
        }
        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (edit == true)
                {
                    EgyebDto egyebDto = new EgyebDto()
                    {
                        id = identificator,
                        name = Name.Text,
                    };

                    MessageBox.Show(CRUD.APSPut(token,currenttask,identificator,egyebDto));

                }
                else
                {
                    EgyebDto egyebDto = new EgyebDto()
                    {
                        id = 0,
                        name = Name.Text,
                    };

                    MessageBox.Show(CRUD.APSPost(token,currenttask,egyebDto));
                }
            }
            catch (Exception z)
            {
                MessageBox.Show("Hiba történt a művelet feldolgozása közben: " + z.Message);
            }


        }
    }
}
