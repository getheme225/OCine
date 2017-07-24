using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OCineManagerApps.OcineManager.Helper.UserControls
{
   public class FilmShedulesListView :ViewBase
    {
        public DataTemplate ItemTemplate { get; set; }

        protected override object DefaultStyleKey => new ComponentResourceKey(GetType(), "FilmShedulesListView");

        protected override object ItemContainerDefaultStyleKey => new ComponentResourceKey(GetType(), "FilmShedulesListView");
    }
}

