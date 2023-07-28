using System.ComponentModel.DataAnnotations;

public enum Statuses
{
    [Display(Name = "Не установлено")]
    None = 0,
    [Display(Name = "Актуальный")]
    Actual = 1,
    [Display(Name = "Удален")]
    Deleted = 2
}
