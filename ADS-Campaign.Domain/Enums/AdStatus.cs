using System.ComponentModel.DataAnnotations;

namespace ADS_Campaign.Domain.Enums
{
    public enum AdStatus
    {
        [Display(Name = "نو")]
        New = 0,

        [Display(Name = "در حد نو")]
        AlmostNew = 1,

        [Display(Name = "کارکرده")]
        Used = 2
    }
}
