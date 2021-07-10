using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Miratti
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Persistencia 
        protected override void OnStartup(StartupEventArgs e)
        {
            // Logging
            Trace.TraceInformation("Aplicacion iniciada.");
            Trace.Flush();
            //config = new Miratti.Config();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //recuperarConfig();
            Trace.TraceInformation("Configuracion de personalizacion cargada: ");
            // Multi languages
            var LangCode = Miratti.Properties.Settings.Default.LanguageCode;
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LangCode);
            base.OnStartup(e);
        }
    }
}