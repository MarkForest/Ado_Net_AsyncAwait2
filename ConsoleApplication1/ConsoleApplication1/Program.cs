﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApplication1
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Language { get; set; }
        public User()
        {
            Language = new List<string>();
        }
    }

    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }

    class Player
    {
        public string  Name { get; set; }
        public string  team { get; set; }
    }

    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] teams = { "Бавария", "Борусия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            int[] numbers = { 1, 23, 45, 5, 7, 878, 989, 6, 67, 4, 7, 12, 5 };
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            List<Team> teams2 = new List<Team> {
                new Team {Name="Бавария", Country="Германия" },
                new Team {Name="Барселона", Country="Испания" }
            };

            List<Player> players = new List<Player>
            {
                new Player { Name="Месси",team = "Барселона" },
                new Player { Name="Неймар",team = "Барселона" },
                new Player { Name="Роббен",team = "Бавария" }
            };

            List<User> users = new List<User> {
                new User {Name="Bob", Age = 14, Language = new List<string> { "Английский","Арабский"} },
                new User {Name="Tom", Age = 23, Language = new List<string> { "Английский","Француский"} },
                new User {Name="Jon", Age = 34, Language = new List<string> { "Английский","Португальский"} },
                new User {Name="Bob", Age = 54, Language = new List<string> { "Арабский", "Француский" } }
            };

            List<Phone> phones = new List<Phone> {
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="iPhone 6", Company="Apple Кривой Рог" },
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="iPhone 5", Company="Apple Кривой Рог" },
                new Phone {Name="iPhone x", Company="Apple Кривой Рог" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6s", Company="Apple Кривой Рог" },
                new Phone {Name="LG G 4", Company="LG" },
                new Phone {Name="iPhone 7", Company="Apple Кривой Рог" }
            };

            //Основы LINQ
            Console.WriteLine("-----------Основы LINQ-----------");
            MethodLinQ(teams);
            //Фильтрация
            Console.WriteLine("-----------Фильтрация-----------");
            MethodLinQ2(numbers);

            //Выборка сложных обьектов
            Console.WriteLine("-----------Выборка сложных обьектов-----------");
            MethodLinQ3(users);

            //Проэкция
            Console.WriteLine("-----------Проэкция-----------");
            MethodLinQ4(users);

            //Выборка из нескольких источников
            Console.WriteLine("-----------Выборка из нескольких источников-----------");
            MethodLinQ5(users, phones);

            //Выборка из нескольких источников
            Console.WriteLine("-----------Выборка из нескольких источников-----------");
            MethodLinQ5(users, phones);

            //Сортировка
            Console.WriteLine("-----------Сортировка-----------");
            MethodLinQ6(users);

            //Работа с множествами
            //Разность множеств
            Console.WriteLine("-----------Разность множеств-----------");
            MethodLinQ7(soft, hard);

            //Пересечения множеств
            Console.WriteLine("-----------Пересечения множеств-----------");
            MethodLinQ8(soft, hard);

            //Обьединение множеств
            Console.WriteLine("-----------Обьединение множеств-----------");
            MethodLinQ9(soft, hard);
            //Удаление дубликата
            Console.WriteLine("-----------Удаление дубликата-----------");
            MethodLinQ10(soft, hard);

            //Агрегатные операции
            //Метод Aggregate
            Console.WriteLine("-----------Метод Aggregate-----------");
            MethodLinQ11(numbers);

            //Методы агрегирования
            Console.WriteLine("-----------Метод Count-----------");
            MethodLinQ12(numbers, users);

            //Take, Skip, Take&Skip
            Console.WriteLine("-----------Take-----------");
            MethodLinQ13(numbers);

            //TakeWhile, SkipWhile
            Console.WriteLine("-----------Take-----------");
            MethodLinQ14(teams);
            //Групировка
            Console.WriteLine("-----------Групировка-----------");
            MethodLinQ15(phones);
            //Групировка Count
            Console.WriteLine("-----------Групировка Count-----------");
            MethodLinQ16(phones);
            //Cоединение колекций. Метод Join
            Console.WriteLine("-----------Cоединение колекций. Метод Join, Zip-----------");
            MethodLinQ17(players, teams2);
            //Cоединение колекций. All Any
            Console.WriteLine("-----------All Any-----------");
            MethodLinQ18(users);
            //Немедленное выполнение
            Console.WriteLine("-----------Немедленное выполнение-----------");
            MethodLinQ19(teams);

        }

        




        //Основы LINQ
        private static void MethodLinQ(string[] teams)
        {
            var selectedTeam = from team in teams //определяем каждый обьект из teams как team
                               where team.StartsWith("Б") //фильтрация по критериям
                               orderby team // сортируем по возростанию
                               select team.ToUpper(); // выбираем в обьект


            foreach (string team in selectedTeam)
            {
                Console.WriteLine(team);
            }

            var selectedTeam2 = teams.Where(t => t.StartsWith("Б")).Select(t => t.ToUpper());

            foreach (var team in selectedTeam2)
            {
                Console.WriteLine(team);
            }
        }
        //Фильтрация
        private static void MethodLinQ2(int[] numbers)
        {
            IEnumerable<int> result = (from i in numbers
                                       where i % 2 == 0 && i > 10
                                       select i).Distinct();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            IEnumerable<int> result2 = numbers.Where(num => num % 2 == 0 && num > 10);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            foreach (var item in numbers.Where(num => num % 2 == 0 && num > 10))
            {
                Console.WriteLine(item);
            }

        }
        //Выборка сложных обьектов
        private static void MethodLinQ3(List<User> users)
        {
            var selectedUsers = from user in users
                                where user.Age > 25
                                select user;
            foreach (var item in selectedUsers)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }

            var selectedUsersLang = from user in users
                                    from lang in user.Language
                                    where user.Age > 25
                                    where lang == "Английский"
                                    select user;
            foreach (var item in selectedUsersLang)
            {
                Console.WriteLine(item.Name+ " "+ item.Age);
            }

            var selectedUsersLangM = users.SelectMany(u => u.Language, (u, l) => new { User = u, lang = l }).
                Where(u => u.lang == "Английский" && u.User.Age > 25).Select(u => u.User);
            foreach (var item in selectedUsersLangM)
            {
                Console.WriteLine(item.Name+" "+item.Age);
            }
        }
        //Проэкция
        private static void MethodLinQ4(List<User> users)
        {
            
            foreach (var item in (from u in users select u.Name))
            {
                Console.WriteLine(item);
            }

            var namesAge = from u in users
                           select new
                           {
                               FirstName = u.Name,
                               UserAge = u.Age
                           };
            foreach (var item in namesAge)
            {
                Console.WriteLine(item.FirstName+" "+item.UserAge);
            }

            //выборка по имени
            foreach (var item in users.Select(u => u.Name))
            {
                Console.WriteLine(item);
            }

            //выборка обьекта ананимного типа
            var items = users.Select(u => new {u.Name, u.Age});
            foreach (var item in items)
            {
                Console.WriteLine(item.Age+" "+item.Name);
            }

        }
        //Выборка из нескольких источников
        private static void MethodLinQ5(List<User> users, List<Phone> phones)
        {
            var people = from user in users
                         from phone in phones
                         select new { Name = user.Name, Phone = phone.Name };

            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} - {item.Phone}");
            }
        }
        //Сортировка
        private static void MethodLinQ6(List<User> users)
        {
            var result = from user in users
                         orderby user.Name descending
                         select user;
            foreach (var item in result)
            {
                foreach (var leng in item.Language){ Console.Write(" "+leng);}
                Console.WriteLine($"{ item.Name}, { item.Age}, { item.Language[0]}");
            }

            var resultTwo = users.OrderByDescending(u => u.Name.Length).ThenBy(u => u.Age);

        }
        //Разность множеств
        private static void MethodLinQ7(string[] soft, string[] hard)
        {
            foreach (var item in soft.Except(hard))
            {
                Console.WriteLine(item);
            }
        }
        //Пересечения множеств
        private static void MethodLinQ8(string[] soft, string[] hard)
        {
            foreach (var item in soft.Intersect(hard))
            {
                Console.WriteLine(item);
            }
        }
        //Обьединение множеств
        private static void MethodLinQ9(string[] soft, string[] hard)
        {
            foreach (var item in soft.Union(hard))
            {
                Console.WriteLine(item);
            }

            foreach (var item in soft.Concat(hard))
            {
                Console.WriteLine(item);
            }
        }
        //Удаление дубликата
        private static void MethodLinQ10(string[] soft, string[] hard)
        {
            foreach (var item in soft.Concat(hard).Distinct())
            {
                Console.WriteLine(item);
            }
        }
        //Метод Aggregate
        private static void MethodLinQ11(int[] numbers)
        {
            int query = numbers.Aggregate((x,y)=>x+y); //1 - 23 - 45 - 5 - 7 - 878 - n
        }
        //Методы агрегирования
        private static void MethodLinQ12(int[] numbers, List<User>users)
        {
            int size = (from i in numbers where i % 2 == 0 && i > 10 select i).Count();
            Console.WriteLine(size);
            Console.WriteLine(numbers.Count(i => i % 2 == 2 && i > 10));
            Console.WriteLine(users.Sum(user=>user.Age));
            Console.WriteLine(numbers.Min());
            Console.WriteLine(users.Min(u => u.Age));
            Console.WriteLine(numbers.Max());
            Console.WriteLine(users.Max(u => u.Age));
            Console.WriteLine(numbers.Average());
            Console.WriteLine(users.Average(u => u.Age));
        }
        //Take, Skip, Take&Skip
        private static void MethodLinQ13(int[] numbers)
        {
            foreach (var item in numbers.Take(3))
            {
                Console.WriteLine(item);
            }

            foreach (var item in numbers.Skip(3))
            {
                Console.WriteLine(3);
            }

            foreach (var item in numbers.Skip(4).Take(3))
            {
                Console.WriteLine(item);
            }


        }
        //TakeWhile
        private static void MethodLinQ14(string[] teams)
        {
            foreach (var item in teams.TakeWhile(team => team.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }
            foreach (var item in teams.SkipWhile(team => team.StartsWith("Б")))
            {
                Console.WriteLine(item);
            }

        }
        //Групировка
        private static void MethodLinQ15(List<Phone> phones)
        {
            //var phoneGroups = from phone in phones
            //                  group phone by phone.Company;

            var phoneGroups = phones.GroupBy(p => p.Company);

            foreach (IGrouping<string, Phone> item in phoneGroups)
            {
                Console.WriteLine(item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine(i.Name);
                }
                Console.WriteLine();
            }

        }
        //Групировка Count
        private static void MethodLinQ16(List<Phone> phones)
        {
            //var phoneGroup = from phone in phones
            //                 group phone by phone.Company into g
            //                 select new { Name = g.Key, Count = g.Count() };

            var phoneGroup = phones.GroupBy(p => p.Company)
                .Select(g => new { Name = g.Key, Count = g.Count() });

            foreach (var group in phoneGroup)
            {
                Console.WriteLine($"{group.Name}: {group.Count}");
            }

            foreach (var item in phones.Select(p => p))
            {
                Console.WriteLine(item.Name);
            }

            //Вложенные запросы
            var phoneGroup2 = from phone in phones
                              group phone by phone.Company into g
                              select new
                              {
                                  Name = g.Key,
                                  Count = g.Count(),
                                  Phones = from p in g select p
                              };


            //var phoneGroup2 = phones.GroupBy(p => p.Company)
            //    .Select(g => new {
            //        Name = g.Key,
            //        Count = g.Count(),
            //        Phones = g.Select(p=>p) });

            foreach (var group in phoneGroup2)
            {
                Console.WriteLine($"{group.Name}: {group.Count}");
                foreach (Phone p in group.Phones)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }

        }
        //Cоединение колекций. Метод Join, Zip
        private static void MethodLinQ17(List<Player> players, List<Team> teams2)
        {
            var result = from p in players
                         join t in teams2 on p.team equals t.Name
                         select new { Name = p.Name, Team = p.team, t.Country};
            foreach (var player in result)
            {
                Console.WriteLine($"{player.Name} - {player.Team} ({player.Country})");
            }

            var result2 = players.Join(
                teams2, //second collection
                p => p.team, //property of first collection
                t => t.Name, //property of second collection
                (p, t) => new { Name = p.Name, Team = p.team, t.Country } //result
            );

            foreach (var player in result2)
            {
                Console.WriteLine($"{player.Name} - {player.Team} ({player.Country})");
            }
        }
        //All Any
        private static void MethodLinQ18(List<User> users)
        {
            bool result = users.All(u => u.Age > 20); //false
            bool result2 = users.Any(u => u.Age < 20); //true
        }
        //Немедленное выполнение
        private static void MethodLinQ19(string[] teams)
        {
            int i = (from t in teams where t.StartsWith("Б") orderby t select t).Count();
            Console.WriteLine(i); //3
            //teams[1] = "Ugaslavia";
            Console.WriteLine(i); //3

            var result = from t in teams where t.StartsWith("Б") orderby t select t;
            Console.WriteLine(result.Count()); //3
            //teams[1] = "Ugaslavia";
            Console.WriteLine(result.Count()); //2

            var result2 = (from t in teams where t.StartsWith("Б") orderby t select t).ToList<string>();
            Console.WriteLine(result2.Count()); //3
            teams[1] = "Ugaslavia";
            Console.WriteLine(result2.Count()); //3

        }

    }
}
