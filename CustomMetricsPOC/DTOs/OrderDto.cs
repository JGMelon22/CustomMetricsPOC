using System.ComponentModel.DataAnnotations;

namespace CustomMetricsPOC.DTOs;

public record OrderDto(
    [Required(ErrorMessage = "Product Name is a required field!")]
    [MinLength(3, ErrorMessage = "Product Name must be at least 3 characters!")]
    [MaxLength(150, ErrorMessage = "Product Name can not exceed 150 characters!")]
    string ProductName,

    [Required(ErrorMessage = "Product Price is a required field!")]
    [Range(1.0, 999_999.99, ErrorMessage = "Product price can not exceed 8,2 decimal range!")]
    decimal Price,

    [Required(ErrorMessage = "Product Quantity is a required field!")]
    [Range(0, int.MaxValue, ErrorMessage = "Product Quantity must be greater than 0!")]
    int Quantity,

    [Required(ErrorMessage = "Product Resgistered Date is a required field!")]
    [DataType(DataType.Date, ErrorMessage = "Product Resgistered Date must follow the YYYY-MM-DD convention")]
    DateTime RegisteredDate
);
