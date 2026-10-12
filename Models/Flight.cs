using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_rabtsevich.Models;

public class Flight
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите номер рейса")]
    [Display(Name = "Номер рейса")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите пункт вылета")]
    [Display(Name = "Пункт вылета")]
    public string Departure { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите пункт назначения")]
    [Display(Name = "Пункт назначения")]
    public string Destination { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите время вылета")]
    [Display(Name = "Время вылета")]
    [DataType(DataType.DateTime)]
    public DateTime DepartureTime { get; set; }

    [Range(0, 1_000_000, ErrorMessage = "Некорректная цена")]
    [Display(Name = "Цена билета")]
    public decimal TicketPrice { get; set; }

    [Range(0, 1000, ErrorMessage = "Некорректное число мест")]
    [Display(Name = "Свободных мест")]
    public int SeatsAvailable { get; set; }

    [Display(Name = "Рейс активен")]
    public bool IsActive { get; set; } = true;
}