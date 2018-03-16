using System.ComponentModel;

namespace WpfLesson.ViewModel
{
    public interface IEntitiesViewModel : INotifyPropertyChanged
    {
        string SelectedPropertyName { get; set; }
        IEntityViewModel SelectedEntity { get; set; }
        void UpdateEntity();
    }
}
