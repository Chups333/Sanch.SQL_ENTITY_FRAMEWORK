
namespace Sanch.SQL_ENTITY_FRAMEWORK
{
    public class Song //таблица
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GroupId { get; set; } // еще нет связи между таблицами

        //дополнительное свойство виртуальное для EF
        public virtual Group Group { get; set; } // будет автоматически подставлять вот эти свойства - особеннсть EF 
    }
}
