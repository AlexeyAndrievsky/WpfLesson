namespace WpfLesson.DataAccess
{
    public interface IEntity
    {
        int ID { get; set; }
        void Update(IEntity data);
        void Insert(IEntity data);
        void Delete(IEntity data);
    }
}
