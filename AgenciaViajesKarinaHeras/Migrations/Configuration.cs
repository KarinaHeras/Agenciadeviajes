namespace AgenciaViajesKarinaHeras.Migrations
{
    using AgenciaViajesKarinaHeras.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AgenciaViajesKarinaHeras.DbContext.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(AgenciaViajesKarinaHeras.DbContext.Context context)
        //protected override void Seed(AgenciaViajesKarinaHeras.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var viajeros = new List<Viajero>
            {
                new Viajero{Nombre="Maria Carson",Dni="68399365X", Telefono="645124777",FechaNacimiento=DateTime.Parse("20-06-1990")},
                new Viajero{Nombre="Paula Robledo",Dni="56344060V",Telefono="645145788",FechaNacimiento=DateTime.Parse("20-12-1960")},
                new Viajero{Nombre="Nicolás Rivas",Dni="67117170L",Telefono ="644512455", FechaNacimiento=DateTime.Parse("1-4-1986")},
                new Viajero{Nombre="Alma Carrillo",Dni="5227170P",Telefono="6451247852",FechaNacimiento=DateTime.Parse("9-8-2001")},
                new Viajero{Nombre="Adela Cantero",Dni="84159432V",Telefono ="64512445700", FechaNacimiento=DateTime.Parse("19-4-1973")},
                new Viajero{Nombre="Roberto Guzman",Dni="50011907V",Telefono ="645124780", FechaNacimiento=DateTime.Parse("19-11-1992")},
                new Viajero{Nombre="Fausto Torrecilla",Dni="20055611W",Telefono ="6451243344", FechaNacimiento=DateTime.Parse("27-10-1962")},
                new Viajero{Nombre="Pilar Martinez",Dni="95315617Y",Telefono ="645124999", FechaNacimiento=DateTime.Parse("7-4-1993")}
            };
            viajeros.ForEach(v => context.Viajero.Add(v));
            context.SaveChanges();
            var agencia = new List<Agencia>
            {
                new Agencia{CodigoViaje=1050,FechaViaje=DateTime.Parse("2005-7-23"),Precio=300,Role=Role.Admin},
                new Agencia{CodigoViaje=4022,FechaViaje=DateTime.Parse("2002-02-16"),Precio=250,Role=Role.Usuario},
                new Agencia{CodigoViaje=4041,FechaViaje=DateTime.Parse("2015-01-11"),Precio=1200,Role=Role.Admin},
                new Agencia{CodigoViaje=1045,FechaViaje=DateTime.Parse("2022-05-25"),Precio=600,Role=Role.Admin},
                new Agencia{CodigoViaje=3141,FechaViaje=DateTime.Parse("2005-09-01"),Precio=630,Role=Role.Usuario},
                new Agencia{CodigoViaje=2021,FechaViaje=DateTime.Parse("2000-10-21"),Precio=150,Role=Role.Usuario},
                new Agencia{CodigoViaje=2042,FechaViaje=DateTime.Parse("2020-06-01"),Precio=820,Role=Role.Usuario}
            };
            agencia.ForEach(a => context.Agencia.Add(a));
            context.SaveChanges();
            var destinos = new List<Destino>
            {
            new Destino{ViajeroId=1,Pais="Hawaii", Ciudad="Honolulu", DestinoID=1, },
            new Destino{ViajeroId=1, Pais="Cuba",Ciudad="La habana", DestinoID=2,CodigoViaje=4022,},
            new Destino{ViajeroId=1, Pais="Mexico",Ciudad="Cancun",DestinoID=3,CodigoViaje=4041,},
            new Destino{ViajeroId=2, Pais="Francia",Ciudad="Paris", DestinoID =4,CodigoViaje=1045,},
            new Destino{ViajeroId=2, Pais="España",Ciudad="Malaga",DestinoID=5, CodigoViaje=3141},
            new Destino{ViajeroId=2, Pais="España",Ciudad="Barcelona", DestinoID=6, CodigoViaje=2021,},
            new Destino{ViajeroId=3,  Pais="España",Ciudad="Tenerife", DestinoID=7, CodigoViaje=1050},
            new Destino{ViajeroId=4, Pais="España",Ciudad="Mallorca", DestinoID=8, CodigoViaje=1050,},
            new Destino{ViajeroId=4,  Pais="España",Ciudad="Tenerife", DestinoID=9, CodigoViaje=4022},
            new Destino{ViajeroId=5, Pais="Colombia",Ciudad="Cartagena de Indias", DestinoID=10, CodigoViaje=4041},
            new Destino{ViajeroId=6, Pais="Italia",Ciudad="Roma", DestinoID=11, CodigoViaje=1045},
            new Destino{ViajeroId=7, Pais="Portugal",Ciudad="Oporto", DestinoID=12, CodigoViaje=3141},
            };
            destinos.ForEach(d => context.Destino.Add(d));
            context.SaveChanges();
        }
    
           
    }
}
