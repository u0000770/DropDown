using System.ComponentModel.DataAnnotations;

namespace DropDown.Services
{
    public class EventTypeDTO
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
