using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonManagementContext>>()))
            {
                // Look for any person.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }
                var positions = new Position[]{
                    new Position
                    {
                        PositionName = "Department Leader",
                        SalaryAmount = 50000
                    },
                    new Position
                    {
                        PositionName = "Administrator",
                        SalaryAmount = 45000
                    },
                    new Position
                    {
                        PositionName = "Saler",
                        SalaryAmount = 40000
                    },
                    new Position
                    {
                        PositionName = "Assistant",
                        SalaryAmount = 35000
                    }
                };
                foreach (Position po in positions)
                {
                    context.Position.Add(po);
                }
                context.SaveChanges();
                var departments = new Department[]{
                        new Department
                        {
                            DepartmentName = "Shoes"
                        },
                        new Department
                        {
                            DepartmentName = "Socks"
                        },
                        new Department
                        {
                            DepartmentName = "Cap"
                        },
                        new Department
                        {
                            DepartmentName = "Vest"
                        }
                };
                foreach (Department d in departments)
                {
                    context.Department.Add(d);
                }
                context.SaveChanges();
                var people = new Person[]{
                    new Person
                    {
                        Mobil = "90000001",
                        Name = "Maria Jensen",
                        Street = "Eventyrveien",
                        Streetnumber = "8",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Socks").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId

                    },

                    new Person
                    {
                        Mobil = "90000002",
                        Name = "Linda Hansen",
                        Street = "Eventyrveien",
                        Streetnumber = "8",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Socks").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },

                    new Person
                    {
                        Mobil = "90000003",
                        Name = "Martin Berg",
                        Street = "Eventyrveien",
                        Streetnumber = "9",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Shoes").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId

                    },

                    new Person
                    {
                        Mobil = "90000004",
                        Name = "Per Haug",
                        Street = "Eventyrveien",
                        Streetnumber = "21",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Cap").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId

                    },
                    new Person
                    {
                        Mobil = "90000008",
                        Name = "Ming Cai",
                        Street = "Eventyrveien",
                        Streetnumber = "13",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Shoes").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId

                    },
                     new Person
                     {
                         Mobil = "90000020",
                         Name = "Lars Rangen",
                         Street = "Furusethveien",
                         Streetnumber = "20",
                         Postnumber = "1811",
                         City = "Askim",
                         Province = "Ostfold",
                         DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                         PositionId = positions.Single(p => p.PositionName == "Saler").PositionId

                     },
                    new Person
                    {
                        Mobil = "45000002",
                        Name = "Moe Sal",
                        Street = "Eventyrveien",
                        Streetnumber = "19",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "90000034",
                        Name = "Rebekka Halsen",
                        Street = "Bekkeveien",
                        Streetnumber = "100",
                        Postnumber = "1811",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "90000052",
                        Name = "Mona Viksen",
                        Street = "Bekkeveien",
                        Streetnumber = "101",
                        Postnumber = "1811",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000012",
                        Name = "Jon Pekesen",
                        Street = "Sentraleveien",
                        Streetnumber = "101",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000013",
                        Name = "Pia Kanghan",
                        Street = "Sentraleveien",
                        Streetnumber = "102",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000014",
                        Name = "Junn Fay",
                        Street = "Sentraleveien",
                        Streetnumber = "103",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000015",
                        Name = "Tonia Hersen",
                        Street = "Sentraleveien",
                        Streetnumber = "104",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Socks").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000016",
                        Name = "Pia Maiksen",
                        Street = "Sentraleveien",
                        Streetnumber = "105",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000017",
                        Name = "Mia Raug",
                        Street = "Sentraleveien",
                        Streetnumber = "106",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "70000018",
                        Name = "Linn Drammen",
                        Street = "Sentraleveien",
                        Streetnumber = "107",
                        Postnumber = "1800",
                        City = "Moss",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    },
                    new Person
                    {
                        Mobil = "90000003",
                        Name = "Martin Yens",
                        Street = "Eventyrveien",
                        Streetnumber = "8",
                        Postnumber = "1807",
                        City = "Askim",
                        Province = "Ostfold",
                        DepartmentId = departments.Single(d => d.DepartmentName == "Vest").DepartmentId,
                        PositionId = positions.Single(p => p.PositionName == "Saler").PositionId
                    }
                };
                foreach (Person p in people)
                {
                    context.Person.Add(p);
                }
                context.SaveChanges();
            }
        }
        internal static void Initialize(PersonManagementContext context)
        {
            throw new NotImplementedException();
        }

    }
}
