using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Modele;

namespace Groovify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    
    public partial class App : Application
    {
        public Manager managerTest { get; set; }
        public App()
        {
            managerTest = new Manager(new DataContractPersistance.DataContractPers());
        }
    }
}