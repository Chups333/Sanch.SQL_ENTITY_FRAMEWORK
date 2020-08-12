using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Sanch.SQL_ENTITY_FRAMEWORK
{
    class Program
    {
        static void Main(string[] args)
        {
            //В каждом твоем приложеннии если ты будешь работать с базами данных
            //Нужно в панели управлении NuGet скачать Entity Framework.
            //Entity Framework - нужен для базы данных. Сейчас Здесь он уже установлен.
            //Приложение разделено на 3 части
            //1 - Программная часть
            //2 - Виртуальная база данных (не та что в Sql Server) - база ненастоящая 
            //Entity Framework - создает копию данных и хранит. Нет нагрузки на сервер.

            //3 способа создания приложения с БД
            //1 - DataBaseFirst - сначала в SQL Server делаешь базу и потом к ней в программе обращаешься
            //2 - CodeFirst - Создаешь базу данных уже в программе кодом
            //3 - ModelFirst - рисуешь сущности и их связи где то и потом само создается бд с классами(таблицами)

            //подключение виртуальное
            using (var context = new MyDBContext())
            {
                var group = new Group()
                {
                    Name = "Rammstain",
                    Year = 1994

                };
                var group2 = new Group()
                {
                    Name = "Linkin Park",
                    Year = 1996

                };

                context.Groups.Add(group); // добавили в виртуальный БД группу
                context.Groups.Add(group2); // добавили в виртуальный БД группу
                context.SaveChanges(); // отправили из локального хранилища (виртуальный БД) в базу данных настоящую

                var songs = new List<Song> // создание коллекции 
                {
                    new Song()
                    {
                        Name="In the end",
                        GroupId=group2.Id

                    },
                    new Song()
                    {
                        Name="Numb",
                        GroupId=group2.Id
                    },
                    new Song()
                    {
                        Name="Mutter",
                        GroupId=group.Id
                    }
                };

                context.Songs.AddRange(songs); // addrange - быстрее работает чем цикл
                context.SaveChanges();

                // по поводу изменений
                /*
                 * var s = context.Group.Single(x=> x.Id == group.Id);
                 * s.Name = "dasdasdas";
                 * context.SaveChanges();
                */

                foreach (var song in songs)
                {
                    Console.WriteLine($"Song Name: {song.Name}, Group Name: {song.Group.Name}");// song.Group?.Name проверка на наличие группы
                }


                Console.ReadLine();
                // чтобы дописать поля в таблицы нужно
                //в Меню-Вид-Другие окна-Консоль диспетчера пакетов написать строку enable-migrations и add-migration AddGroupType и после update-database
                // эта строка разрешает совершать миграции программно - дописать поле таблицы (без ошибки)
            }
        }
    }
}
