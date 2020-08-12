
using System.Collections;
using System.Collections.Generic;

namespace Sanch.SQL_ENTITY_FRAMEWORK
{
    public class Group // таблица
    {
        public int Id { get; set; } // можно не писать id, а например dasdasd, но сверху писать [key]
        public string Name { get; set; }
        public int? Year { get; set; } //? - значит поле необязательное
        public string Type { get; set; }//для миграции 

        //дополнительное свойство виртуальное для EF
        public virtual ICollection<Song> Songs { get; set; } // у каждой группы будет хрониться всех ее песен сразу

    }
}
