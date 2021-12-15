using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarinProject.controller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryDesc : ContentPage
    {
        public int id { get; set; }
        public HistoryDesc(string name, string description)
        {
            InitializeComponent();
            updateHistory(name, description);
        }

        public void updateHistory(string name, string description)
        {
            //string parsedId = id.ToString();
            title.Text = name;
            desc.Text = description;
        }
    }
}