namespace MvcAppSearch.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcAppSearch.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<MvcAppSearch.Form.DRdb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcAppSearch.Form.DRdb context)
        {
            var Inmates = new List<Inmate>
            {

                new Inmate {LastName = "Brown", FirstName="James", Location="A", FloorNo=int.Parse("1"), ReportDate= DateTime.Parse ("2013-01-01") },
                new Inmate {LastName = "Jordan", FirstName="Robert", Location="B", FloorNo=int.Parse("5"), ReportDate= DateTime.Parse ("2013-02-02") },
                new Inmate {LastName = "Green", FirstName="Justin", Location="C", FloorNo=int.Parse("4"), ReportDate= DateTime.Parse ("2013-03-03") },
                new Inmate {LastName = "Due", FirstName="John", Location="D", FloorNo=int.Parse("2"), ReportDate= DateTime.Parse ("2012-04-04") }

            };
            Inmates.ForEach(s => context.Inmates.AddOrUpdate(p => p.InmateID, s));
            context.SaveChanges();

            var officers = new List<Officer>
            {
                new Officer { OfficerID = 1020, LastName = "Richardson", FirstName="Tom", Role="Sergeant",},
                new Officer { OfficerID = 1030, LastName = "Raymond", FirstName="Bob", Role="Supervisor",},
                new Officer { OfficerID = 1040, LastName = "Black", FirstName="Sam", Role="Asst Chief",},
                new Officer { OfficerID = 1050, LastName = "Green", FirstName="George", Role="Chief",},

            };

            officers.ForEach(s => context.Officers.AddOrUpdate(p => p.OfficerID, s));
            context.SaveChanges();

            var reports = new List<Report> 
            {

                new Report { InmateID= Inmates.Single ( s => s.LastName == "Brown" ).InmateID,
                    OfficerID = officers.Single( c => c.Role == "Sergeant" ).OfficerID,
                   Status = Status.A
                },

                new Report { InmateID= Inmates.Single ( s => s.LastName == "Jordan" ).InmateID,
                    OfficerID = officers.Single( c => c.Role == "Supervisor" ).OfficerID,
                   Status = Status.B
                },

                new Report { InmateID= Inmates.Single ( s => s.LastName == "Green" ).InmateID,
                    OfficerID = officers.Single( c => c.Role == "Asst Chief" ).OfficerID,
                   Status = Status.B
                },
                new Report { InmateID= Inmates.Single ( s => s.LastName == "Due" ).InmateID,
                    OfficerID = officers.Single( c => c.Role == "Cheif" ).OfficerID,
                   Status = Status.C
                }
            };

            foreach (Report e in reports)
            {
                var reportInDataBase = context.Reports.Where(s =>
                    s.Inmate.InmateID == e.InmateID && s.Officer.OfficerID == e.OfficerID).SingleOrDefault();
                if (reportInDataBase == null)
                {
                    context.Reports.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}





