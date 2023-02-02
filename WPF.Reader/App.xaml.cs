using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WPF.Reader.Model;
using WPF.Reader.Service;
using WPF.Reader.ViewModel;

namespace WPF.Reader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var rootFrame = new Frame
            {
                NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden
            };

            // Si vous avez besoin de rajouter des services, vous pouvez le déclarer ici
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<INavigationService>(new NavigationService(rootFrame))
                .AddSingleton(new LibraryService())
                .BuildServiceProvider());



            Thread newThread = new Thread(new ThreadStart(LongRunningMethod));
            newThread.Start();

            Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListBook>();
            

        }

        private static void LongRunningMethod()
        {
            Ioc.Default.GetRequiredService<LibraryService>().Init();

        }
    }
}
