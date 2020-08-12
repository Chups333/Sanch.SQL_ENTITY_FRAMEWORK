using System;
using System.Data.Entity;

namespace Sanch.SQL_ENTITY_FRAMEWORK
{
    public class MyDBContext : DbContext //подключение
    {
        public MyDBContext() : base("DbConnectionString") //базовый конструктор в который передаем строку подключения
        {
        }

        public DbSet<Group> Groups { get; set; } //набор 
        public DbSet<Song> Songs { get; set; } // таким образом мы получаем всю таблицу
    }
}
