﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppMVCComboCascadeEF.Models;

[Table("T_Regione")]
public partial class TRegione
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nome { get; set; }

    [Column("isAutonoma")]
    public bool? IsAutonoma { get; set; }

    public int? NumAbitanti { get; set; }

    [InverseProperty("IdRegioneNavigation")]
    public virtual ICollection<TProvincium> TProvincia { get; set; } = new List<TProvincium>();
}