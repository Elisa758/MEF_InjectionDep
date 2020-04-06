﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_Quest
{
    class Program
    {
        private Mef _host;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();

            Console.ReadKey();
        }

        private void Run()
        {
            _host = new Mef();
            HelloSayer hello = _host.Container.GetExportedValue<HelloSayer>();
        }
            

    }

    internal class Mef
    {
        public CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var catalog =
                        new DirectoryCatalog(".", "MEF_Quest.*");

                    _container = new CompositionContainer(catalog);
                }

                return _container;
            }
        }
        private CompositionContainer _container = null;
    }

    [Export]
    internal class HelloSayer
    {
        public HelloSayer()
        {
            SayHello();
        }

        public void SayHello()
        {
            Console.WriteLine("Bonjour !");
        }
    }


}
