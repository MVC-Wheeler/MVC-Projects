using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Models;

public partial class Task
{
    [Key]
    [Column("TaskID")]
    public int TaskId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; }
}
